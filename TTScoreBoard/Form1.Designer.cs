namespace TTScoreBoard
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnPlayerA = new System.Windows.Forms.Button();
            this.btnPlayerB = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.scoreDisplay = new System.Windows.Forms.TextBox();
            this.rbServiceA = new System.Windows.Forms.RadioButton();
            this.rbServiceB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPlayerA
            // 
            this.btnPlayerA.Location = new System.Drawing.Point(12, 12);
            this.btnPlayerA.Name = "btnPlayerA";
            this.btnPlayerA.Size = new System.Drawing.Size(75, 55);
            this.btnPlayerA.TabIndex = 1;
            this.btnPlayerA.Text = "Player A";
            this.btnPlayerA.UseVisualStyleBackColor = true;
            this.btnPlayerA.Click += new System.EventHandler(this.btnPlayerA_Click);
            // 
            // btnPlayerB
            // 
            this.btnPlayerB.Location = new System.Drawing.Point(252, 12);
            this.btnPlayerB.Name = "btnPlayerB";
            this.btnPlayerB.Size = new System.Drawing.Size(75, 55);
            this.btnPlayerB.TabIndex = 2;
            this.btnPlayerB.Text = "Player B";
            this.btnPlayerB.UseVisualStyleBackColor = true;
            this.btnPlayerB.Click += new System.EventHandler(this.btnPlayerB_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(399, 12);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "NEU";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.Location = new System.Drawing.Point(93, 30);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(153, 20);
            this.scoreDisplay.TabIndex = 4;
            // 
            // rbServiceA
            // 
            this.rbServiceA.AutoSize = true;
            this.rbServiceA.Checked = true;
            this.rbServiceA.Location = new System.Drawing.Point(12, 73);
            this.rbServiceA.Name = "rbServiceA";
            this.rbServiceA.Size = new System.Drawing.Size(14, 13);
            this.rbServiceA.TabIndex = 5;
            this.rbServiceA.TabStop = true;
            this.rbServiceA.UseVisualStyleBackColor = true;
            this.rbServiceA.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbServiceB
            // 
            this.rbServiceB.AutoSize = true;
            this.rbServiceB.Location = new System.Drawing.Point(313, 73);
            this.rbServiceB.Name = "rbServiceB";
            this.rbServiceB.Size = new System.Drawing.Size(14, 13);
            this.rbServiceB.TabIndex = 6;
            this.rbServiceB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 206);
            this.Controls.Add(this.rbServiceB);
            this.Controls.Add(this.rbServiceA);
            this.Controls.Add(this.scoreDisplay);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnPlayerB);
            this.Controls.Add(this.btnPlayerA);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPlayerA;
        private System.Windows.Forms.Button btnPlayerB;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.TextBox scoreDisplay;
        private System.Windows.Forms.RadioButton rbServiceA;
        private System.Windows.Forms.RadioButton rbServiceB;
    }
}

