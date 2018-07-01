namespace SpaceInvaders
{
    partial class GameForm
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
                //Dispose tow Bitmap by Hua WANG 04062018
                bufferBackImage.Dispose();
                bufferImage.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxInstruction = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxReplay = new System.Windows.Forms.PictureBox();
            this.pictureBoxStart = new System.Windows.Forms.PictureBox();
            this.lblEnemyShip = new System.Windows.Forms.Label();
            this.lblEnemyShipCount = new System.Windows.Forms.Label();
            this.lblBombCount = new System.Windows.Forms.Label();
            this.lblBomb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInstruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBoxInstruction
            // 
            this.pictureBoxInstruction.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxInstruction.Image = global::SpaceInvaders.Properties.Resources.instruction;
            this.pictureBoxInstruction.Location = new System.Drawing.Point(18, 512);
            this.pictureBoxInstruction.Name = "pictureBoxInstruction";
            this.pictureBoxInstruction.Size = new System.Drawing.Size(890, 35);
            this.pictureBoxInstruction.TabIndex = 22;
            this.pictureBoxInstruction.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(924, 506);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::SpaceInvaders.Properties.Resources.Space_Invaders_Logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(210, 37);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(580, 262);
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxReplay
            // 
            this.pictureBoxReplay.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxReplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxReplay.Image = global::SpaceInvaders.Properties.Resources.Replay_button;
            this.pictureBoxReplay.Location = new System.Drawing.Point(436, 300);
            this.pictureBoxReplay.Name = "pictureBoxReplay";
            this.pictureBoxReplay.Size = new System.Drawing.Size(127, 127);
            this.pictureBoxReplay.TabIndex = 2;
            this.pictureBoxReplay.TabStop = false;
            this.pictureBoxReplay.Click += new System.EventHandler(this.PictureBoxReplay_Click);
            this.pictureBoxReplay.MouseHover += new System.EventHandler(this.PictureBoxReplay_MouseHover);
            // 
            // pictureBoxStart
            // 
            this.pictureBoxStart.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxStart.Image = global::SpaceInvaders.Properties.Resources.button;
            this.pictureBoxStart.Location = new System.Drawing.Point(436, 337);
            this.pictureBoxStart.Name = "pictureBoxStart";
            this.pictureBoxStart.Size = new System.Drawing.Size(127, 127);
            this.pictureBoxStart.TabIndex = 1;
            this.pictureBoxStart.TabStop = false;
            this.pictureBoxStart.Click += new System.EventHandler(this.PictureBoxStart_Click);
            // 
            // lblEnemyShip
            // 
            this.lblEnemyShip.AutoSize = true;
            this.lblEnemyShip.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyShip.ForeColor = System.Drawing.Color.White;
            this.lblEnemyShip.Location = new System.Drawing.Point(11, 10);
            this.lblEnemyShip.Name = "lblEnemyShip";
            this.lblEnemyShip.Size = new System.Drawing.Size(83, 17);
            this.lblEnemyShip.TabIndex = 23;
            this.lblEnemyShip.Text = "EnemyShip:";
            // 
            // lblEnemyShipCount
            // 
            this.lblEnemyShipCount.AutoSize = true;
            this.lblEnemyShipCount.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyShipCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyShipCount.ForeColor = System.Drawing.Color.White;
            this.lblEnemyShipCount.Location = new System.Drawing.Point(100, 10);
            this.lblEnemyShipCount.Name = "lblEnemyShipCount";
            this.lblEnemyShipCount.Size = new System.Drawing.Size(16, 17);
            this.lblEnemyShipCount.TabIndex = 24;
            this.lblEnemyShipCount.Text = "0";
            // 
            // lblBombCount
            // 
            this.lblBombCount.AutoSize = true;
            this.lblBombCount.BackColor = System.Drawing.Color.Transparent;
            this.lblBombCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBombCount.ForeColor = System.Drawing.Color.White;
            this.lblBombCount.Location = new System.Drawing.Point(194, 10);
            this.lblBombCount.Name = "lblBombCount";
            this.lblBombCount.Size = new System.Drawing.Size(16, 17);
            this.lblBombCount.TabIndex = 26;
            this.lblBombCount.Text = "0";
            // 
            // lblBomb
            // 
            this.lblBomb.AutoSize = true;
            this.lblBomb.BackColor = System.Drawing.Color.Transparent;
            this.lblBomb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBomb.ForeColor = System.Drawing.Color.White;
            this.lblBomb.Location = new System.Drawing.Point(140, 10);
            this.lblBomb.Name = "lblBomb";
            this.lblBomb.Size = new System.Drawing.Size(48, 17);
            this.lblBomb.TabIndex = 25;
            this.lblBomb.Text = "Bomb:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblBombCount);
            this.Controls.Add(this.lblBomb);
            this.Controls.Add(this.lblEnemyShipCount);
            this.Controls.Add(this.lblEnemyShip);
            this.Controls.Add(this.pictureBoxInstruction);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.pictureBoxReplay);
            this.Controls.Add(this.pictureBoxStart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Invaders (2018 S2 Programming2 - Assignment 2 - Hua WANG)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInstruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxStart;
        private System.Windows.Forms.PictureBox pictureBoxReplay;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBoxInstruction;
        private System.Windows.Forms.Label lblEnemyShip;
        private System.Windows.Forms.Label lblEnemyShipCount;
        private System.Windows.Forms.Label lblBombCount;
        private System.Windows.Forms.Label lblBomb;
    }
}

