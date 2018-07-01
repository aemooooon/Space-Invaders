/* Program name: 	    <<SpaceInvaders>>
   Project file name:   <<SpaceInvaders>>
   Author:		        <<Hua WANG>>
   Date:	            01-06-2018 
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2017
   Purpose:		        <<To recreate the classic arcade video game Space Invaders.>>
   Description:		    <<In this game, the player controls a ship that moves from side to side at the bottom of the screen. 
                        Descending from the top of the screen is a formation of Enemy Ships, four rows deep and ten columns wide.
                        The enemy ships move in a body from side to side. When the right or left most enemy ship hits the edge of the screen, 
                        the enemy ships all reverse direction. Enemy ship will gradually accelerate with the gradual decline.
                        Mother ship launches missiles, while enemy ship randomly dropped bombs, bombs, missiles, enemy ship 
                        and Mother ship with bounce will die. If Mother Ship dies or all Enemy Ship dies, the game ends.>>
   Known Bugs:		    <<The game requirements said that only the last down rows of EnemyShip could dorp bomb. But in this solution, sometimes the Missile firstly hit the first or second, or third
                        row EnemyShip. That might cause to drop bomb by two rows of EnemyShip in the mean time.>>
   Additional Features: 1. added sound that the background music of game start, when Missile and bomb with MotherShip or EnemyShip intersection. And could turn on / off Sound before gamestart.
                        2. Implement the EmemyShips Fleet move faster as they get lower on the screen.
                        3. Provide the background image for entire game.
                        4. Press White - Space key could pause or resume Game in the process of Gaming.
                        5. Allow for game to be restarted. (Clear all has already run resources and the instance of object, and reset game default states. rather than simply restart application.)
                        6. Implement the explosion effcet when EnemyShip, Missile and Bomb intersection with. (This idea from Programming 2 Check point 3 - SpriteAnimation)

 The GameForm class is derived from Form class that include all controls UI and interact with Manager by a few events.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class GameForm : Form
    {
        //Field
        private Random random;
        private Graphics graphics;
        private Bitmap bufferImage;
        private Bitmap bufferBackImage;
        private Graphics bufferGraphics;
        private Manager manager;
        private bool isStart; //Is a flag to mark press space to pause

        //Constructor
        public GameForm()
        {
            InitializeComponent();
            InitializeGameDefault();
        }

        #region GameForm Event List
        //Timer1 Tick event handler
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bufferGraphics.DrawImage(bufferBackImage, 0, 0, Width, Height);
                manager.Run();
                graphics.DrawImage(bufferImage, 0, 0, Width, Height);

                lblEnemyShipCount.Text = manager.GetEnemyShipCount().ToString();
                lblBombCount.Text = manager.GetBombCount().ToString();

                //check EnemyShipFleet is over
                if (manager.CheckEnemyShipFleetLife())
                {
                    timer1.Enabled = false;
                    GlobalVariable.PlaySound(GlobalVariable.tr_holo_congrats);
                    MessageBox.Show("Congratulate, You destroyed all of the EnemyShip...");
                    pictureBoxReplay.Visible = true;
                    isStart = false;
                }
                else
                {
                    // Check any EnemyShip whether reach bottom line except MotherShip top
                    if (manager.IsEnemyShipReachBottomLine())
                    {
                        timer1.Enabled = false;
                        GlobalVariable.PlaySound(GlobalVariable.ctwin);
                        MessageBox.Show("oops...The EnemyShip has been caught you");
                        pictureBoxReplay.Visible = true;
                        isStart = false;
                    }
                }

                //check MotherShip whether hit all bombs
                if (manager.CheckMotherShipLife() == 0)
                {
                    timer1.Enabled = false;
                    GlobalVariable.PlaySound(GlobalVariable.ctwin);
                    MessageBox.Show("oops...You have been hit by Bomb");
                    pictureBoxReplay.Visible = true;
                    isStart = false;
                }
                else if (manager.CheckMotherShipLife() == -1) //MotherShip is over
                {
                    timer1.Enabled = false;
                    GlobalVariable.PlaySound(GlobalVariable.ctwin);
                    MessageBox.Show("oops...You have been hit by EnemyShip");
                    pictureBoxReplay.Visible = true;
                    isStart = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Keep the mouse cursor whthin the Form
            Cursor.Clip = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
            manager.MouseControll(e.Location.X);
        }

        //MotherShip Fire Missile
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (timer1.Enabled)
            {
                manager.MotherShipFire();
                //GlobalVariable.PlaySound(GlobalVariable.tu_spindown); //Play Fire sound
            }
        }

        /// <summary>
        /// Restart Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxReplay_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            InitializeGameDefault();
            InitializeStartGame();
        }

        /// <summary>
        /// Switch Volume On or Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            GlobalVariable.SoundSwitch = !GlobalVariable.SoundSwitch;
            GlobalVariable.game_music.Stop();
            if (GlobalVariable.SoundSwitch == true)
            {
                pictureBox3.Image = Properties.Resources.VolumeOn;
                GlobalVariable.game_music.Play();
            }
            else
            {
                pictureBox3.Image = Properties.Resources.VolumeOff;
            }
        }

        /// <summary>
        /// press space to pause and resume game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (isStart && (e.KeyCode == Keys.Space))
            {
                timer1.Enabled = !timer1.Enabled;
            }
        }

        private void PictureBoxStart_Click(object sender, EventArgs e)
        {
            InitializeStartGame();
        }

        private void PictureBoxReplay_MouseHover(object sender, EventArgs e)
        {
            PlaySoundMouseHover();
        }
        #endregion

        #region GameForm Private Methods
        /// <summary>
        /// Initialize Game Default states
        /// </summary>
        private void InitializeGameDefault()
        {
            GlobalVariable.PlaySound(GlobalVariable.game_music);
            pictureBoxReplay.Visible = false;
            lblEnemyShip.Visible = false;
            lblEnemyShipCount.Visible = false;
            lblBomb.Visible = false;
            lblBombCount.Visible = false;
            pictureBox3.Image = Properties.Resources.VolumeOn;
            GlobalVariable.boundries = ClientSize;
            random = new Random();
            isStart = false;

            graphics = CreateGraphics();
            bufferImage = new Bitmap(Width, Height);
            bufferBackImage = new Bitmap(Properties.Resources.A10073);
            BackgroundImage = bufferBackImage; //when open game to display background
            bufferGraphics = Graphics.FromImage(bufferImage);
            manager = new Manager(bufferGraphics, random);
        }

        /// <summary>
        /// Start Game
        /// </summary>
        private void InitializeStartGame()
        {
            GlobalVariable.PlaySound(GlobalVariable.letsgo);
            timer1.Enabled = true;
            isStart = true;
            pictureBoxStart.Visible = false;
            pictureBoxLogo.Visible = false;
            pictureBoxInstruction.Visible = false;
            pictureBox3.Visible = false;
            lblEnemyShip.Visible = true;
            lblEnemyShipCount.Visible = true;
            lblBomb.Visible = true;
            lblBombCount.Visible = true;
        }

        private void PlaySoundMouseHover()
        {
            GlobalVariable.PlaySound(GlobalVariable.tutor_msg);
        }
        #endregion
    }
}
