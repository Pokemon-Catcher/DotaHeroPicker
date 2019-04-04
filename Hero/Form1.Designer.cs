namespace Hero
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeroList = new System.Windows.Forms.ListView();
            this.hero1 = new System.Windows.Forms.PictureBox();
            this.hero2 = new System.Windows.Forms.PictureBox();
            this.hero3 = new System.Windows.Forms.PictureBox();
            this.hero4 = new System.Windows.Forms.PictureBox();
            this.hero5 = new System.Windows.Forms.PictureBox();
            this.bestHeroes = new System.Windows.Forms.Panel();
            this.Roles = new System.Windows.Forms.CheckedListBox();
            this.Roles2 = new System.Windows.Forms.CheckedListBox();
            this.ByWinrate = new System.Windows.Forms.RadioButton();
            this.ByDisadvantage = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.hero1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero5)).BeginInit();
            this.SuspendLayout();
            // 
            // HeroList
            // 
            this.HeroList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.HeroList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeroList.Location = new System.Drawing.Point(12, 12);
            this.HeroList.Name = "HeroList";
            this.HeroList.RightToLeftLayout = true;
            this.HeroList.Size = new System.Drawing.Size(384, 453);
            this.HeroList.TabIndex = 0;
            this.HeroList.UseCompatibleStateImageBehavior = false;
            // 
            // hero1
            // 
            this.hero1.Location = new System.Drawing.Point(414, 12);
            this.hero1.Name = "hero1";
            this.hero1.Size = new System.Drawing.Size(72, 49);
            this.hero1.TabIndex = 1;
            this.hero1.TabStop = false;
            // 
            // hero2
            // 
            this.hero2.Location = new System.Drawing.Point(504, 12);
            this.hero2.Name = "hero2";
            this.hero2.Size = new System.Drawing.Size(72, 49);
            this.hero2.TabIndex = 2;
            this.hero2.TabStop = false;
            // 
            // hero3
            // 
            this.hero3.Location = new System.Drawing.Point(594, 12);
            this.hero3.Name = "hero3";
            this.hero3.Size = new System.Drawing.Size(72, 49);
            this.hero3.TabIndex = 3;
            this.hero3.TabStop = false;
            // 
            // hero4
            // 
            this.hero4.Location = new System.Drawing.Point(684, 12);
            this.hero4.Name = "hero4";
            this.hero4.Size = new System.Drawing.Size(72, 49);
            this.hero4.TabIndex = 4;
            this.hero4.TabStop = false;
            // 
            // hero5
            // 
            this.hero5.Location = new System.Drawing.Point(774, 12);
            this.hero5.Name = "hero5";
            this.hero5.Size = new System.Drawing.Size(72, 49);
            this.hero5.TabIndex = 5;
            this.hero5.TabStop = false;
            // 
            // bestHeroes
            // 
            this.bestHeroes.Location = new System.Drawing.Point(414, 75);
            this.bestHeroes.Name = "bestHeroes";
            this.bestHeroes.Size = new System.Drawing.Size(432, 285);
            this.bestHeroes.TabIndex = 6;
            // 
            // Roles
            // 
            this.Roles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Roles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Roles.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roles.ForeColor = System.Drawing.Color.PeachPuff;
            this.Roles.FormattingEnabled = true;
            this.Roles.Items.AddRange(new object[] {
            "Support",
            "Carry",
            "Durable",
            "Initiator",
            "Disabler"});
            this.Roles.Location = new System.Drawing.Point(414, 375);
            this.Roles.Name = "Roles";
            this.Roles.Size = new System.Drawing.Size(137, 85);
            this.Roles.TabIndex = 7;
            // 
            // Roles2
            // 
            this.Roles2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Roles2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Roles2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Roles2.ForeColor = System.Drawing.Color.PeachPuff;
            this.Roles2.FormattingEnabled = true;
            this.Roles2.Items.AddRange(new object[] {
            "Ranged",
            "Nuker",
            "Escape",
            "Pusher",
            "Melee"});
            this.Roles2.Location = new System.Drawing.Point(572, 375);
            this.Roles2.Name = "Roles2";
            this.Roles2.Size = new System.Drawing.Size(148, 85);
            this.Roles2.TabIndex = 8;
            // 
            // ByWinrate
            // 
            this.ByWinrate.AutoSize = true;
            this.ByWinrate.Checked = true;
            this.ByWinrate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ByWinrate.FlatAppearance.BorderSize = 5;
            this.ByWinrate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ByWinrate.ForeColor = System.Drawing.Color.PeachPuff;
            this.ByWinrate.Location = new System.Drawing.Point(726, 395);
            this.ByWinrate.Name = "ByWinrate";
            this.ByWinrate.Size = new System.Drawing.Size(87, 20);
            this.ByWinrate.TabIndex = 9;
            this.ByWinrate.TabStop = true;
            this.ByWinrate.Text = "By Winrate";
            this.ByWinrate.UseVisualStyleBackColor = true;
            // 
            // ByDisadvantage
            // 
            this.ByDisadvantage.AutoSize = true;
            this.ByDisadvantage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ByDisadvantage.ForeColor = System.Drawing.Color.PeachPuff;
            this.ByDisadvantage.Location = new System.Drawing.Point(726, 421);
            this.ByDisadvantage.Name = "ByDisadvantage";
            this.ByDisadvantage.Size = new System.Drawing.Size(109, 20);
            this.ByDisadvantage.TabIndex = 10;
            this.ByDisadvantage.Text = "By Advantage";
            this.ByDisadvantage.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(862, 477);
            this.Controls.Add(this.ByDisadvantage);
            this.Controls.Add(this.ByWinrate);
            this.Controls.Add(this.Roles2);
            this.Controls.Add(this.Roles);
            this.Controls.Add(this.bestHeroes);
            this.Controls.Add(this.hero5);
            this.Controls.Add(this.hero4);
            this.Controls.Add(this.hero3);
            this.Controls.Add(this.hero2);
            this.Controls.Add(this.hero1);
            this.Controls.Add(this.HeroList);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "Dota Hero Picker";
            ((System.ComponentModel.ISupportInitialize)(this.hero1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView HeroList;
        private System.Windows.Forms.PictureBox hero1;
        private System.Windows.Forms.PictureBox hero2;
        private System.Windows.Forms.PictureBox hero3;
        private System.Windows.Forms.PictureBox hero4;
        private System.Windows.Forms.PictureBox hero5;
        private System.Windows.Forms.Panel bestHeroes;
        private System.Windows.Forms.CheckedListBox Roles;
        private System.Windows.Forms.CheckedListBox Roles2;
        private System.Windows.Forms.RadioButton ByWinrate;
        private System.Windows.Forms.RadioButton ByDisadvantage;
    }
}

