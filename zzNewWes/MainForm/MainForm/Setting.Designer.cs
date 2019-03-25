namespace wes
{
    partial class Setting
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
            this.l_fk_uid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fk_uid = new System.Windows.Forms.TextBox();
            this.mustMore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OtherMore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.minPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timerGrade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mustToSell = new System.Windows.Forms.TextBox();
            this.mustToBuy = new System.Windows.Forms.TextBox();
            this.otherToBuy = new System.Windows.Forms.TextBox();
            this.otherToSell = new System.Windows.Forms.TextBox();
            this.maxOrderCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_fk_uid
            // 
            this.l_fk_uid.AutoSize = true;
            this.l_fk_uid.Location = new System.Drawing.Point(184, 24);
            this.l_fk_uid.Name = "l_fk_uid";
            this.l_fk_uid.Size = new System.Drawing.Size(31, 15);
            this.l_fk_uid.TabIndex = 0;
            this.l_fk_uid.Text = "uid";
            this.l_fk_uid.Click += new System.EventHandler(this.fk_uid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "必成交倍数";
            // 
            // fk_uid
            // 
            this.fk_uid.Location = new System.Drawing.Point(154, 53);
            this.fk_uid.Name = "fk_uid";
            this.fk_uid.ReadOnly = true;
            this.fk_uid.Size = new System.Drawing.Size(100, 25);
            this.fk_uid.TabIndex = 2;
            // 
            // mustMore
            // 
            this.mustMore.Location = new System.Drawing.Point(155, 131);
            this.mustMore.Name = "mustMore";
            this.mustMore.Size = new System.Drawing.Size(100, 25);
            this.mustMore.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "非必成交倍数";
            // 
            // OtherMore
            // 
            this.OtherMore.Location = new System.Drawing.Point(155, 178);
            this.OtherMore.Name = "OtherMore";
            this.OtherMore.Size = new System.Drawing.Size(100, 25);
            this.OtherMore.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "最小变动单位";
            // 
            // minPrice
            // 
            this.minPrice.Location = new System.Drawing.Point(155, 224);
            this.minPrice.Name = "minPrice";
            this.minPrice.Size = new System.Drawing.Size(100, 25);
            this.minPrice.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "交易等级";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // timerGrade
            // 
            this.timerGrade.Location = new System.Drawing.Point(155, 265);
            this.timerGrade.Name = "timerGrade";
            this.timerGrade.Size = new System.Drawing.Size(100, 25);
            this.timerGrade.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "必成交最大(卖)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "必成交最大(买)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "非必成交最大(买)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 389);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "非必成交最大(卖)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "队列保留数量";
            // 
            // mustToSell
            // 
            this.mustToSell.Location = new System.Drawing.Point(154, 314);
            this.mustToSell.Name = "mustToSell";
            this.mustToSell.Size = new System.Drawing.Size(100, 25);
            this.mustToSell.TabIndex = 15;
            // 
            // mustToBuy
            // 
            this.mustToBuy.Location = new System.Drawing.Point(154, 349);
            this.mustToBuy.Name = "mustToBuy";
            this.mustToBuy.Size = new System.Drawing.Size(100, 25);
            this.mustToBuy.TabIndex = 16;
            // 
            // otherToBuy
            // 
            this.otherToBuy.Location = new System.Drawing.Point(154, 424);
            this.otherToBuy.Name = "otherToBuy";
            this.otherToBuy.Size = new System.Drawing.Size(100, 25);
            this.otherToBuy.TabIndex = 17;
            // 
            // otherToSell
            // 
            this.otherToSell.Location = new System.Drawing.Point(154, 386);
            this.otherToSell.Name = "otherToSell";
            this.otherToSell.Size = new System.Drawing.Size(100, 25);
            this.otherToSell.TabIndex = 18;
            // 
            // maxOrderCount
            // 
            this.maxOrderCount.Location = new System.Drawing.Point(154, 459);
            this.maxOrderCount.Name = "maxOrderCount";
            this.maxOrderCount.Size = new System.Drawing.Size(100, 25);
            this.maxOrderCount.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(269, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "(1-N)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(269, 356);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "(1-N)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(269, 392);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "(1-N)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(269, 428);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "(1-N)";
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(155, 542);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(99, 40);
            this.btn_Update.TabIndex = 24;
            this.btn_Update.Text = "重新设置";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 638);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maxOrderCount);
            this.Controls.Add(this.otherToSell);
            this.Controls.Add(this.otherToBuy);
            this.Controls.Add(this.mustToBuy);
            this.Controls.Add(this.mustToSell);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timerGrade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OtherMore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mustMore);
            this.Controls.Add(this.fk_uid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_fk_uid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_fk_uid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fk_uid;
        private System.Windows.Forms.TextBox mustMore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OtherMore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox minPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox timerGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mustToSell;
        private System.Windows.Forms.TextBox mustToBuy;
        private System.Windows.Forms.TextBox otherToBuy;
        private System.Windows.Forms.TextBox otherToSell;
        private System.Windows.Forms.TextBox maxOrderCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Update;
    }
}