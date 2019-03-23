using WeifenLuo.WinFormsUI.Docking;
using JiaoHui.JHCore;
namespace JHWinUI
{
    partial class OutPut : DockContent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutPut));
            this.txtOutPut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOutPut
            // 
            this.txtOutPut.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtOutPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutPut.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutPut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtOutPut.Location = new System.Drawing.Point(0, 0);
            this.txtOutPut.Multiline = true;
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutPut.Size = new System.Drawing.Size(1000, 520);
            this.txtOutPut.TabIndex = 0;
            this.txtOutPut.TextChanged += new System.EventHandler(this.txtOutPut_TextChanged);
            // 
            // OutPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.txtOutPut);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutPut";
            this.Text = "输出";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutPut;
    }
}