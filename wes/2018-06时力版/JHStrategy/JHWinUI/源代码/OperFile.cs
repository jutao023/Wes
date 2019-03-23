using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JHWinUI
{


    class OperFile
    {
        /***************用户配置窗口使用***********/

        public static bool SaveUserInfoConfig(List<UserInfoConfig> listUsers)
        {
            if(listUsers == null)
            {
                return false;
            }

            string filePath = @".\Config";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在文件夹
            {
                directory.Create();
            }

            if (File.Exists(filePath + @"\UserInfCofig.txt"))
            {
                File.Delete(filePath + @"\UserInfCofig.txt");
            }

            FileStream fwrite = null;
            StreamWriter swriter = null;
            try
            {
                fwrite = new FileStream(filePath + @"\UserInfCofig.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                swriter = new StreamWriter(fwrite);
                for (int i = 0; i < listUsers.Count; i++)
                {
                    string user = listUsers[i].username + "," + listUsers[i].password + "," + listUsers[i].contractID + ",";
                    user += listUsers[i].valsign + "," + listUsers[i].trade_addr_port + "," + listUsers[i].market_addr_port + "," + listUsers[i].http_addr_port;
                    swriter.WriteLine(user);
                }
                swriter.Close();
                fwrite.Close();
                return true;
            }
            catch
            {
                if(swriter != null)
                {
                    swriter.Close();
                }
                if(fwrite != null)
                {
                    fwrite.Close();
                }
                return false;
            }
        }

        public static List<UserInfoConfig> GetUserInfoByFile()
        {
            List<UserInfoConfig> listUsers = new List<UserInfoConfig>();

            string filePath = @".\Config";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在
            {
                return null;
            }
            if (!File.Exists(filePath + @"\UserInfCofig.txt"))
            {
                return null;
            }
            FileStream file = new FileStream(filePath + @"\UserInfCofig.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(file, Encoding.Default);

            string reader = null;
            while ((reader = sr.ReadLine()) != null)
            {
                //过滤
                if (reader == "" || reader == "\n") continue;
                //
                string[] Users = reader.Split(new char[] { ',' });
                if (Users.Length < 7) continue;

                if (listUsers.Count >= 10)
                    return listUsers;

                UserInfoConfig uif = new UserInfoConfig();
                uif.username = Users[0];
                uif.password = Users[1];
                uif.contractID = Users[2];
                uif.valsign = Users[3];
                uif.trade_addr_port = Users[4];
                uif.market_addr_port = Users[5];
                uif.http_addr_port = Users[6];

                bool IsAdd = true;
                if (listUsers.Count > 0)
                {
                    foreach(UserInfoConfig uerif in listUsers)
                    {
                        if(uif.username == uerif.username)
                        {
                            IsAdd = false;
                            break;
                        }
                    }
                }
                if(IsAdd)
                    listUsers.Add(uif);
            }
            sr.Close();
            file.Close();

            return listUsers;
        }

        /***************工程配置窗口使用***********/

        public static bool SaveProjectInfoConfig(List<ProjectStrategy> listPros)
        {
            if (listPros == null)
            {
                return false;
            }

            string filePath = @".\Config";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在文件夹
            {
                directory.Create();
            }

            if (File.Exists(filePath + @"\ProjectInfCofig.txt"))
            {
                File.Delete(filePath + @"\ProjectInfCofig.txt");
            }

            FileStream fwrite = null;
            StreamWriter swriter = null;
            try
            {
                fwrite = new FileStream(filePath + @"\ProjectInfCofig.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                swriter = new StreamWriter(fwrite);
                for (int i = 0; i < listPros.Count; i++)
                {
                    string projectInfo = listPros[i].username + "," + listPros[i].projectName + ",";
                    projectInfo += listPros[i].fileName + "," + listPros[i].strategyName;
                    swriter.WriteLine(projectInfo);
                }
                swriter.Close();
                fwrite.Close();
                return true;
            }
            catch
            {
                if (swriter != null)
                {
                    swriter.Close();
                }
                if (fwrite != null)
                {
                    fwrite.Close();
                }
                return false;
            }
        }

        public static List<ProjectStrategy> GetProjectInfoByFile()
        {
            List<ProjectStrategy> listPros = new List<ProjectStrategy>();

            string filePath = @".\Config";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//如果文件夹不存在
            {
                return null;
            }
            if (!File.Exists(filePath + @"\ProjectInfCofig.txt")) //如果文件不存在
            {
                return null;
            }
            FileStream file = new FileStream(filePath + @"\ProjectInfCofig.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(file, Encoding.Default);

            string reader = null;
            while ((reader = sr.ReadLine()) != null)
            {
                //过滤
                if (reader == "" || reader == "\n") continue;
                //
                string[] projectLine = reader.Split(new char[] { ',' });
                if (projectLine.Length < 4) continue;

                ProjectStrategy pic = new ProjectStrategy();
                pic.username = projectLine[0];
                pic.projectName = projectLine[1];
                pic.fileName = projectLine[2];
                pic.strategyName = projectLine[3];

                bool IsAdd = true;
                foreach(ProjectStrategy ps in listPros)
                {
                    if(pic.username == ps.username || pic.projectName == ps.projectName)
                    {
                        IsAdd = false;
                        break;
                    }
                }
                if(IsAdd)
                    listPros.Add(pic);
            }
            sr.Close();
            file.Close();

            return listPros;
        }
    }
}
