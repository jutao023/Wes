using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;
using JiaoHui.JHCore;

namespace JHWinUI
{
    public partial class RunStrategy : DockContent , DataRecv , StateNotify
    {
        //输出窗口
        private OutPut output = null;
        //构造函数
        public RunStrategy()
        {
            InitializeComponent();
        }

        //账户信息
        List<UserInfoConfig> listUsers = null;

        //类型集合
        List<Type> listTypes = new List<Type>();

        //conbobox selectStrategy
        List<AssemblyClassInfo> listClassInfo = new List<AssemblyClassInfo>();

        //工程信息
        List<ProjectStrategy> listProjects = new List<ProjectStrategy>();

        static void Transmit(ref ProjectStrategy ps, UserInfoConfig user)
        {

            ps.password = user.password;
            ps.valsign = user.valsign;
            ps.contractID = user.contractID;

            string[] ini = user.trade_addr_port.Split(new char[] { ':' });
            ps.trade_addr = ini[0];
            ps.trade_port = ini[1];

            ini = user.market_addr_port.Split(new char[] { ':' });
            ps.market_addr = ini[0];
            ps.market_port = ini[1];

            ini = user.http_addr_port.Split(new char[] { ':' });
            ps.http_addr = ini[0];
            ps.http_port = ini[1];

        }

        //扫描包
        private void ScanAssembly()
        {
            #region 扫描策略包

            string filePath = @".\Strategy";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在
                directory.Create();

            string dirp = Path.Combine(Application.StartupPath, filePath); 
            DirectoryInfo mydir = new DirectoryInfo(dirp);
            foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())
            {
                if (fsi is FileInfo)
                {
                    string s = System.IO.Path.GetExtension(fsi.FullName); //获取扩展名
                    if (s == ".dll")
                    {
                        try
                        {
                            string tagFileName = fsi.FullName;
                            Assembly assm = Assembly.LoadFrom(tagFileName);
                            Type[] type = assm.GetTypes();
                            for (int i = 0; i < type.Length; i++)
                            {
                                if (typeof(Strategy).IsAssignableFrom(type[i]))
                                {
                                    bool isAdd = true;
                                    for (int ind = 0; ind < cboxSelectStrategy.Items.Count; ind++)
                                    {
                                        string str = cboxSelectStrategy.GetItemText(cboxSelectStrategy.Items[ind]);
                                        if (str == type[i].FullName)
                                        {
                                            isAdd = false;
                                            break;
                                        }
                                    }
                                    if (isAdd)
                                    {
                                        listTypes.Add(type[i]);
                                        //添加到ComboBox控件中
                                        cboxSelectStrategy.Items.Add(type[i].FullName);
                                        AssemblyClassInfo aci = new AssemblyClassInfo();
                                        aci.FileFullName = fsi.FullName;
                                        aci.ClassFullName = type[i].FullName;
                                        listClassInfo.Add(aci);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            output.Print(ex.Message);
                        }
                        output.Print("加载策略文件成功! 文件:" + fsi.FullName);
                    }
                }
            }
            #endregion

        }

        //读取账户信息 和 工程配置信息
        private void ReadUserInfo()
        {

            #region 加载用户信息
            if (listUsers == null)
            {
                listUsers = OperFile.GetUserInfoByFile();
                if (listUsers == null)
                    return;

                foreach (UserInfoConfig ufi in listUsers)
                {
                    cboxSelectAccount.Items.Add(ufi.username);
                }
            }
            #endregion

            #region 加载工程配置信息
            List<ProjectStrategy> tmpPS = null;
            tmpPS = OperFile.GetProjectInfoByFile();
            if (tmpPS == null || tmpPS.Count == 0)
            {
                return;
            }
            listProjects = tmpPS;
            bool IsChange = false;

            //检查是否存在失效信息
            for (int i = 0; i < listProjects.Count; i++)
            {
                ProjectStrategy pic = listProjects[i];
                bool IsIn = false;
                foreach (UserInfoConfig ufi in listUsers)
                {
                    if (pic.username == ufi.username)
                    {
                        Transmit(ref pic, ufi);
                        IsIn = true;
                        break;
                    }
                }
                if (IsIn == false)
                {
                    IsChange = true;
                    listProjects.RemoveAt(i);
                }
            }
            if(IsChange == true)
            {
                OperFile.SaveProjectInfoConfig(listProjects);
            }
            #endregion

            #region 显示信息
            foreach (ProjectStrategy ps in listProjects)
            {

                ListViewItem lvi = new ListViewItem();
                lvi.Text = ps.username;
                lvi.SubItems.Add(ps.projectName);
                lvi.SubItems.Add(EnumRunState.未运行.ToString());
                lvi.SubItems.Add(System.IO.Path.GetFileName(ps.fileName));
                lvi.SubItems.Add(ps.strategyName);
                lvi.SubItems.Add(". . .");
                listStrategy.Items.Add(lvi);
            }

            #endregion
        }

        //把工程信息保存到文件
        private void SaveProjectToFile()
        {
            OperFile.SaveProjectInfoConfig(listProjects);
        }

        //加载
        private void RunStrategy_Load(object sender, EventArgs e)
        {
            output = new OutPut();
            output.Show(manSHJH.GetMainFrame().dockPanel1, DockState.DockBottomAutoHide);
            output.Text = "策略管理";
            //加载程序集
            ScanAssembly();

            //加载工程和用户信息
            ReadUserInfo();

            //设置默认选择项
            cboxSelectAccount.SelectedIndex = 0;
            cboxSelectStrategy.SelectedIndex = 0;

        }
        
        //添加工程
        private void btnAddProject_Click(object sender, EventArgs e)
        {

            string userid = cboxSelectAccount.Text;
            string strategy = cboxSelectStrategy.Text;
            string porjname = txtProjectName.Text;

            #region 输入检测

            if(userid == "无" || strategy == "无")
            {
                return;
            }

            if (userid == "" || strategy == "" || porjname == "")
            {
                MessageBox.Show("输入不能为空", "提示");
                return;
            }

            foreach(ListViewItem lvi in listStrategy.Items)
            {
                if(lvi.Text == userid)
                {
                    MessageBox.Show("账户不能重复", "提示");
                    return;
                }
                if(lvi.SubItems[1].Text == porjname)
                {
                    MessageBox.Show("工程名不能重复", "提示");
                    return;
                }
            }
            #endregion

            #region 更新视图
            //获取文件名
            string filename = GetFileNameByClassName(strategy);
            if(filename == null )
            {
                MessageBox.Show("添加失败！文件不存在", "提示");
                return;
            }

            ListViewItem lv = new ListViewItem();
            lv.Text = userid;
            lv.SubItems.Add(porjname);
            lv.SubItems.Add(EnumRunState.未运行.ToString());
            lv.SubItems.Add(System.IO.Path.GetFileName(filename));
            lv.SubItems.Add(strategy);
            lv.SubItems.Add(". . .");
            //添加到视图
            listStrategy.Items.Add(lv);
            #endregion

            #region 保存信息
            //保存数据
            ProjectStrategy pps = new ProjectStrategy();
            pps.username = userid;
            pps.projectName = porjname;
            pps.runFlag = EnumRunState.未运行;
            pps.fileName = filename;
            pps.strategyName = strategy;
            pps.runState = "";

            Transmit(ref pps, GetUserInfoConfig(userid));
            listProjects.Add(pps);

            //保存信息到文件中
            SaveProjectToFile();
            #endregion

        }

        string GetFileNameByClassName(string className)
        {
            foreach (AssemblyClassInfo aci in listClassInfo)
            {
                if (aci.ClassFullName == className)
                {
                    return aci.FileFullName;
                }
            }
            return null;
        }

        UserInfoConfig GetUserInfoConfig(string userid)
        {
            foreach(UserInfoConfig uf in listUsers)
            {
                if(uf.username == userid)
                {
                    return uf;
                }
            }

            return null;
        }

        //主窗体退出程序
        public void ExitOnClose()
        {
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                projectStrag = ps;
                if (projectStrag.runFlag == EnumRunState.停止 || projectStrag.runFlag == EnumRunState.未运行)
                {
                    continue;
                }
                projectStrag.CutOff();
                projectStrag.Free();
                projectStrag.Exit();
                projectStrag.showMessage.Close();
                projectStrag.runFlag = EnumRunState.停止;
                projectStrag.runStrategy = null;
            }
        }

        /*******************************接口实现******************************/

        //账户信息表
        public void OnUserInfoList(List<UserInfoConfig> _listUsers)
        {
            if(_listUsers != null)
            {
                this.listUsers = _listUsers;
                cboxSelectAccount.Items.Clear();
                cboxSelectAccount.Items.Add("无");
                foreach (UserInfoConfig ufi in listUsers)
                {
                    cboxSelectAccount.Items.Add(ufi.username);
                }

                foreach(ProjectStrategy ps in listProjects)
                {
                    bool isIn = false;
                    foreach (UserInfoConfig user in listUsers)
                    {
                        if(user.username == ps.username)
                        {
                            isIn = true;
                            break;
                        }
                    }
                    if(isIn == false)
                    {

                        for(int i = 0; i < listStrategy.Items.Count; i++ )
                        {
                            if(ps.username == listStrategy.Items[i].Text)
                            {
                                if (ps.runFlag == EnumRunState.未运行)
                                {
                                    listStrategy.Items.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        if (ps.runFlag == EnumRunState.未运行)
                        {
                            listProjects.Remove(ps);
                            break;
                        }
                    }
                }
            }
        }

        //运行状态更新
        private void UpdateRunState(string _user, EnumRunState _ers, string _des)
        {
            string des = _des;
            if (des == null)
                des = "";

            foreach( ListViewItem lvi in listStrategy.Items)
            {
                if(lvi.Text == _user)
                {
                    lvi.SubItems[2].Text = _ers.ToString();
                    lvi.SubItems[5].Text = des;
                    break;
                }
            }
        }

        //状态通知
        public void OnNotify(object _obj, string Info)
        {
            foreach(ProjectStrategy ps in listProjects)
            {
                if(ps.runStrategy == _obj)
                {
                    ps.showMessage.Print(Info);
                    if(Info.Length >= 5)
                    {
                        int i = Info.IndexOf('@');
                        if(i > 0)
                        {
                            string code = Info.Substring(0, i);
                            if(code == "1002" || code =="2002" || code == "1004")
                            {
                                UpdateRunState(ps.username, EnumRunState.异常, "运行异常？即将自动重新连接登陆！");
                            }
                            else if(code == "3001")
                            {
                                UpdateRunState(ps.username, EnumRunState.运行中, "启动成功");
                            }else if(code == "1013")
                            {
                                UpdateRunState(ps.username, EnumRunState.错误, "行情服务器返回时间格式错误？请重新启动！");
                            }else if(code == "2013")
                            {
                                UpdateRunState(ps.username, EnumRunState.错误, "交易服务器返回时间格式错误？请重新启动！");
                            }else if(code == "1003")
                            {
                                UpdateRunState(ps.username, EnumRunState.超时, "交易超时？即将自动重新连接登陆！");
                            }
                            else if(code == "2003")
                            {
                                UpdateRunState(ps.username, EnumRunState.超时, "行情超时？即将自动重新连接登陆！");
                            }
                        }
                    }
                    break;
                }
            }
        }

        /**************************菜单事件***********************/
        //【启动】
        private void Start_MenuItem_Click(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;

            ListViewItem lvi = listStrategy.SelectedItems[0];
            string filePath = null;
            string ClassName = null;
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if(lvi.Text == ps.username)
                {
                    filePath = ps.fileName;
                    ClassName = ps.strategyName;
                    projectStrag = ps;
                }
            }

            if(filePath == null || ClassName == null)
            {
                MessageBox.Show("此条记录已经失效！", "提示");
                return;
            }
            if (projectStrag == null)
                return;

            //运行中无法连续启动
            if(projectStrag.runFlag == EnumRunState.运行中 || projectStrag.runFlag == EnumRunState.异常 || projectStrag.runFlag == EnumRunState.超时)
            {
                return;
            }

            //判断是否存在此文件
            if(!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("策略文件不存在或者被删除", "提示");
                return;
            }

            //启动
            Type typeStag = null;
            foreach(Type ty in listTypes)
            {
                if(ty.FullName == ClassName)
                {
                    typeStag = ty;
                    break;
                }
            }
            Strategy stt = null;
            try
            {
                stt = (Strategy)typeStag.Assembly.CreateInstance(typeStag.FullName);
            }catch(Exception es)
            {
                MessageBox.Show(es.Message, "提示");
                return;
            }
            OutPut op = new OutPut();
            op.Text = lvi.SubItems[1].Text;
            op.Show(manSHJH.GetMainFrame().dockPanel1, DockState.DockBottomAutoHide);
            if(!projectStrag.BeforeInit(stt, this, op))
            {
                MessageBox.Show("初始化交易模型失败!", "提示");
                return;
            }
            projectStrag.Init();
            projectStrag.runFlag = EnumRunState.运行中;
            lvi.SubItems[2].Text = EnumRunState.运行中.ToString();

        }
        //【停止】
        private void Stop_MenuItem_Click(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;
            ListViewItem lvi = listStrategy.SelectedItems[0];
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if (lvi.Text == ps.username)
                {
                    projectStrag = ps;
                }
            }
            if (projectStrag == null)
                return;
            if(projectStrag.runFlag == EnumRunState.停止 || projectStrag.runFlag == EnumRunState.未运行)
            {
                return;
            }

            projectStrag.showMessage.Print("策略已经停止运行");
            projectStrag.CutOff();
            projectStrag.Free();
            projectStrag.Exit();
            projectStrag.showMessage.Close();
            projectStrag.runFlag = EnumRunState.停止;
            lvi.SubItems[2].Text = EnumRunState.停止.ToString();
            lvi.SubItems[5].Text = "已停止";

        }
        //【删除】
        private void Delete_MenuItem_Click(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;
            ListViewItem lvi = listStrategy.SelectedItems[0];
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if (lvi.Text == ps.username)
                {
                    projectStrag = ps;
                    if (projectStrag.runFlag == EnumRunState.运行中 || projectStrag.runFlag == EnumRunState.异常 || projectStrag.runFlag == EnumRunState.超时)
                    {
                        MessageBox.Show("运行状态下无法删除", "提示");
                        return;
                    }else
                    {
                        listProjects.Remove(ps);
                        foreach (ListViewItem llv in listStrategy.Items)
                        {
                            if(llv.Text == ps.username)
                            {
                                listStrategy.Items.Remove(llv);
                                break;
                            }
                        }
                        return;
                    }
                }
            }
        }
        //【显示输出窗口】
        private void showMessageMenu_Click(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;
            ListViewItem lvi = listStrategy.SelectedItems[0];
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if (lvi.Text == ps.username)
                {
                    projectStrag = ps;
                }
            }
            if (projectStrag == null)
                return;
            if (projectStrag.runFlag == EnumRunState.运行中 || projectStrag.runFlag == EnumRunState.异常)
            {
                if(projectStrag.showMessage != null)
                    projectStrag.showMessage.Show();
            }
        }
        //【显示心跳信息】
        private void showHeartMenu_Click(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;
            ListViewItem lvi = listStrategy.SelectedItems[0];
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if (lvi.Text == ps.username)
                {
                    projectStrag = ps;
                }
            }
            if (projectStrag == null)
                return;
            if (projectStrag.runFlag == EnumRunState.运行中 || projectStrag.runFlag == EnumRunState.异常)
            {
                if (projectStrag.showMessage != null)
                {
                    if ((sender as ToolStripMenuItem).Checked == false)
                    {
                        projectStrag.showMessage.HeartInfoOnConsole();
                        (sender as ToolStripMenuItem).Checked = true;
                    }
                    else
                    {
                        projectStrag.showMessage.HeartInfoOnConsole(false);
                        (sender as ToolStripMenuItem).Checked = false;

                    }
                }
            }
        }

        private void listStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;
            ListViewItem lvi = listStrategy.SelectedItems[0];
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if (lvi.Text == ps.username)
                {
                    projectStrag = ps;
                }
            }
            ToolStripMenuItem mm = null;
            for (int i = 0; i < contextMenuStrip.Items.Count; i++)
            {
                if (contextMenuStrip.Items[i] is ToolStripMenuItem)
                {
                    foreach (ToolStripMenuItem m in ((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems)
                    {
                        if (m.Text == "显示情报")
                        {
                            mm = m;
                        }
                    }
                }
            }
            if (projectStrag != null)
            {
                if (projectStrag.runFlag == EnumRunState.运行中 || projectStrag.runFlag == EnumRunState.异常)
                {
                    if (mm != null)
                        mm.Checked = projectStrag.showMessage.GetHeartState();
                }
                else
                {
                    if (mm != null)
                    {
                        mm.Checked = false;
                    }
                }
            }
        }

        private void TestTickMenuItem_Click(object sender, EventArgs e)
        {
            if (listStrategy.SelectedItems.Count <= 0)
                return;
            ListViewItem lvi = listStrategy.SelectedItems[0];
            ProjectStrategy projectStrag = null;
            foreach (ProjectStrategy ps in listProjects)
            {
                if (lvi.Text == ps.username)
                {
                    projectStrag = ps;
                }
            }
            if (projectStrag == null)
                return;
            if(projectStrag.runFlag == EnumRunState.运行中)
            {
                projectStrag.runStrategy.TestTick();
            }
        }
    }
}
