namespace wes
{
    partial class MainFrame
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
            this.SuspendLayout();

            // 
            // MainFrame
            // 
            this.ClientSize = new System.Drawing.Size(1090, 638);
            this.Name = "MainFrame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView strategyList;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.ColumnHeader uid;
        private System.Windows.Forms.ColumnHeader coinSymbol;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader show;

    }
}