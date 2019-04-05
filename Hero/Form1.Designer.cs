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
            this.HeroList = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.hero1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero5)).BeginInit();
            this.SuspendLayout();
            // 
            // hero1
            // 
            this.hero1.Location = new System.Drawing.Point(483, 15);
            this.hero1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hero1.Name = "hero1";
            this.hero1.Size = new System.Drawing.Size(84, 60);
            this.hero1.TabIndex = 1;
            this.hero1.TabStop = false;
            // 
            // hero2
            // 
            this.hero2.Location = new System.Drawing.Point(588, 15);
            this.hero2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hero2.Name = "hero2";
            this.hero2.Size = new System.Drawing.Size(84, 60);
            this.hero2.TabIndex = 2;
            this.hero2.TabStop = false;
            // 
            // hero3
            // 
            this.hero3.Location = new System.Drawing.Point(693, 15);
            this.hero3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hero3.Name = "hero3";
            this.hero3.Size = new System.Drawing.Size(84, 60);
            this.hero3.TabIndex = 3;
            this.hero3.TabStop = false;
            // 
            // hero4
            // 
            this.hero4.Location = new System.Drawing.Point(798, 15);
            this.hero4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hero4.Name = "hero4";
            this.hero4.Size = new System.Drawing.Size(84, 60);
            this.hero4.TabIndex = 4;
            this.hero4.TabStop = false;
            // 
            // hero5
            // 
            this.hero5.Location = new System.Drawing.Point(903, 15);
            this.hero5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hero5.Name = "hero5";
            this.hero5.Size = new System.Drawing.Size(84, 60);
            this.hero5.TabIndex = 5;
            this.hero5.TabStop = false;
            // 
            // bestHeroes
            // 
            this.bestHeroes.Location = new System.Drawing.Point(483, 92);
            this.bestHeroes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bestHeroes.Name = "bestHeroes";
            this.bestHeroes.Size = new System.Drawing.Size(504, 351);
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
            this.Roles.Location = new System.Drawing.Point(483, 462);
            this.Roles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Roles.Name = "Roles";
            this.Roles.Size = new System.Drawing.Size(160, 102);
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
            this.Roles2.Location = new System.Drawing.Point(667, 462);
            this.Roles2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Roles2.Name = "Roles2";
            this.Roles2.Size = new System.Drawing.Size(173, 102);
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
            this.ByWinrate.Location = new System.Drawing.Point(847, 486);
            this.ByWinrate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.ByDisadvantage.Location = new System.Drawing.Point(847, 518);
            this.ByDisadvantage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ByDisadvantage.Name = "ByDisadvantage";
            this.ByDisadvantage.Size = new System.Drawing.Size(109, 20);
            this.ByDisadvantage.TabIndex = 10;
            this.ByDisadvantage.Text = "By Advantage";
            this.ByDisadvantage.UseVisualStyleBackColor = true;
            // 
            // HeroList
            // 
            this.HeroList.AutoScroll = true;
            this.HeroList.AutoSize = true;
            this.HeroList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HeroList.ColumnCount = 6;
            this.HeroList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HeroList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HeroList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HeroList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HeroList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HeroList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HeroList.Cursor = System.Windows.Forms.Cursors.No;
            this.HeroList.Dock = System.Windows.Forms.DockStyle.Left;
            this.HeroList.Location = new System.Drawing.Point(0, 0);
            this.HeroList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeroList.Name = "HeroList";
            this.HeroList.RowCount = 2;
            this.HeroList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HeroList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HeroList.Size = new System.Drawing.Size(0, 587);
            this.HeroList.TabIndex = 11;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1006, 587);
            this.Controls.Add(this.HeroList);
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
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "Dota Hero Picker";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hero1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hero5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel bestHeroes;
        private System.Windows.Forms.CheckedListBox Roles;
        private System.Windows.Forms.CheckedListBox Roles2;
        private System.Windows.Forms.RadioButton ByWinrate;
        private System.Windows.Forms.RadioButton ByDisadvantage;
        public System.Windows.Forms.PictureBox hero1;
        public System.Windows.Forms.PictureBox hero2;
        public System.Windows.Forms.PictureBox hero3;
        public System.Windows.Forms.PictureBox hero4;
        public System.Windows.Forms.PictureBox hero5;
        private System.Windows.Forms.TableLayoutPanel HeroList;
    }
}

