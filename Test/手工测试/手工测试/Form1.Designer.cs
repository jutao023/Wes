namespace 手工测试
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_buy = new System.Windows.Forms.Button();
            this.btn_sell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_id_buy = new System.Windows.Forms.TextBox();
            this.txt_vol_buy = new System.Windows.Forms.TextBox();
            this.txt_coin_buy = new System.Windows.Forms.TextBox();
            this.txt_price_buy = new System.Windows.Forms.TextBox();
            this.txt_price_sell = new System.Windows.Forms.TextBox();
            this.txt_vol_sell = new System.Windows.Forms.TextBox();
            this.txt_coin_sell = new System.Windows.Forms.TextBox();
            this.txt_id_sell = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_buy
            // 
            this.btn_buy.Location = new System.Drawing.Point(535, 95);
            this.btn_buy.Name = "btn_buy";
            this.btn_buy.Size = new System.Drawing.Size(94, 47);
            this.btn_buy.TabIndex = 0;
            this.btn_buy.Text = "买入";
            this.btn_buy.UseVisualStyleBackColor = true;
            this.btn_buy.Click += new System.EventHandler(this.btn_buy_Click);
            // 
            // btn_sell
            // 
            this.btn_sell.Location = new System.Drawing.Point(535, 156);
            this.btn_sell.Name = "btn_sell";
            this.btn_sell.Size = new System.Drawing.Size(94, 50);
            this.btn_sell.TabIndex = 1;
            this.btn_sell.Text = "卖出";
            this.btn_sell.UseVisualStyleBackColor = true;
            this.btn_sell.Click += new System.EventHandler(this.btn_sell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "产品编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "账号ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "价格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "数量";
            // 
            // txt_id_buy
            // 
            this.txt_id_buy.Location = new System.Drawing.Point(75, 107);
            this.txt_id_buy.Name = "txt_id_buy";
            this.txt_id_buy.Size = new System.Drawing.Size(76, 25);
            this.txt_id_buy.TabIndex = 6;
            // 
            // txt_vol_buy
            // 
            this.txt_vol_buy.Location = new System.Drawing.Point(420, 108);
            this.txt_vol_buy.Name = "txt_vol_buy";
            this.txt_vol_buy.Size = new System.Drawing.Size(76, 25);
            this.txt_vol_buy.TabIndex = 7;
            // 
            // txt_coin_buy
            // 
            this.txt_coin_buy.Location = new System.Drawing.Point(191, 108);
            this.txt_coin_buy.Name = "txt_coin_buy";
            this.txt_coin_buy.Size = new System.Drawing.Size(76, 25);
            this.txt_coin_buy.TabIndex = 8;
            // 
            // txt_price_buy
            // 
            this.txt_price_buy.Location = new System.Drawing.Point(306, 107);
            this.txt_price_buy.Name = "txt_price_buy";
            this.txt_price_buy.Size = new System.Drawing.Size(76, 25);
            this.txt_price_buy.TabIndex = 9;
            // 
            // txt_price_sell
            // 
            this.txt_price_sell.Location = new System.Drawing.Point(306, 167);
            this.txt_price_sell.Name = "txt_price_sell";
            this.txt_price_sell.Size = new System.Drawing.Size(76, 25);
            this.txt_price_sell.TabIndex = 10;
            // 
            // txt_vol_sell
            // 
            this.txt_vol_sell.Location = new System.Drawing.Point(420, 167);
            this.txt_vol_sell.Name = "txt_vol_sell";
            this.txt_vol_sell.Size = new System.Drawing.Size(76, 25);
            this.txt_vol_sell.TabIndex = 11;
            // 
            // txt_coin_sell
            // 
            this.txt_coin_sell.Location = new System.Drawing.Point(191, 167);
            this.txt_coin_sell.Name = "txt_coin_sell";
            this.txt_coin_sell.Size = new System.Drawing.Size(76, 25);
            this.txt_coin_sell.TabIndex = 12;
            // 
            // txt_id_sell
            // 
            this.txt_id_sell.Location = new System.Drawing.Point(75, 167);
            this.txt_id_sell.Name = "txt_id_sell";
            this.txt_id_sell.Size = new System.Drawing.Size(76, 25);
            this.txt_id_sell.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 342);
            this.Controls.Add(this.txt_id_sell);
            this.Controls.Add(this.txt_coin_sell);
            this.Controls.Add(this.txt_vol_sell);
            this.Controls.Add(this.txt_price_sell);
            this.Controls.Add(this.txt_price_buy);
            this.Controls.Add(this.txt_coin_buy);
            this.Controls.Add(this.txt_vol_buy);
            this.Controls.Add(this.txt_id_buy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sell);
            this.Controls.Add(this.btn_buy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buy;
        private System.Windows.Forms.Button btn_sell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_id_buy;
        private System.Windows.Forms.TextBox txt_vol_buy;
        private System.Windows.Forms.TextBox txt_coin_buy;
        private System.Windows.Forms.TextBox txt_price_buy;
        private System.Windows.Forms.TextBox txt_price_sell;
        private System.Windows.Forms.TextBox txt_vol_sell;
        private System.Windows.Forms.TextBox txt_coin_sell;
        private System.Windows.Forms.TextBox txt_id_sell;
    }
}

