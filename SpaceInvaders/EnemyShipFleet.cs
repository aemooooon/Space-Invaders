/*
 The EnemyShipFleet class implements the interface of ICheck that hold an collection of Bomb and EnemyShip, and their state, behaviour.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceInvaders
{
    public class EnemyShipFleet:ICheck
    {
        //Const
        private const int ENEMYSHIP_INTERVAL = 0b110001;
        private const int FLEET_ROWS = 0b1010;
        private const int FLEET_COLUMN = 0b100;
        private const int ENEMYSHIPFLEET_DOWN_SPEED = 20;
        private const int BOMB_PROBABILITY_RANGE = 0b1100100;
        private const int BOMB_SPEED= 0b101;
        private const int ENEMYSHIP_SPEED = 5;

        //Field
        private Graphics graphics;
        private List<EnemyShip> enemyShips;
        private List<Bomb> bombs;
        private bool alive;

        //Constructor
        public EnemyShipFleet(Graphics graphics)
        {
            this.graphics = graphics;
            this.alive = Alive;
            bombs = new List<Bomb>();
            enemyShips = new List<EnemyShip>();
            for (int i = 0; i < FLEET_ROWS; i++)
            {
                for (int j = 0; j < FLEET_COLUMN; j++)
                {
                    //enemyShip couldDropBomb field for given whether its have rights to drop bomb 
                    if ((j+1) % FLEET_COLUMN == 0)
                    {
                        enemyShips.Add(new EnemyShip(graphics, GlobalVariable.bitmapEnemyShip, new Point(i * ENEMYSHIP_INTERVAL, j * ENEMYSHIP_INTERVAL), GlobalVariable.bitmapEnemyShip.Width, GlobalVariable.bitmapEnemyShip.Height, ENEMYSHIP_SPEED, true, Direction.Right));
                    }
                    else
                    {
                        enemyShips.Add(new EnemyShip(graphics, GlobalVariable.bitmapEnemyShip, new Point(i * ENEMYSHIP_INTERVAL, j * ENEMYSHIP_INTERVAL), GlobalVariable.bitmapEnemyShip.Width, GlobalVariable.bitmapEnemyShip.Height, ENEMYSHIP_SPEED, false, Direction.Right));
                    }
                }
            }
        }

        /// <summary>
        /// Draw EnemyShip
        /// </summary>
        public void Draw()
        {
            foreach (EnemyShip enemyShip in enemyShips)
            {
                enemyShip.Draw();
            }
        }

        /// <summary>
        /// Move EnemyShip
        /// </summary>
        public void Move()
        {
            //change the direction of every single EnemyShip
            for (int i = 0; i < enemyShips.Count; i++)
            {
                if (enemyShips[0].Position.X <= 0)
                {
                    enemyShips[i].Direction = Direction.Right;
                    enemyShips[i].GetDown(ENEMYSHIPFLEET_DOWN_SPEED);
                }
                if (enemyShips[enemyShips.Count-0b1].Position.X+enemyShips[enemyShips.Count-0b1].Width>=GlobalVariable.boundries.Width)
                {
                    enemyShips[i].Direction = Direction.Left;
                    enemyShips[i].GetDown(ENEMYSHIPFLEET_DOWN_SPEED);
                }
            }

            //Move every EnemyShip
            for (int i = 0; i < enemyShips.Count; i++)
            {
                enemyShips[i].Move();
            }

            for (int i = 0; i < enemyShips.Count; i++)
            {
                //Set the acceleration of EnemyShip when its go down
                if ((enemyShips[0].Position.X <= 0)||
                    (enemyShips[enemyShips.Count - 0b1].Position.X + enemyShips[enemyShips.Count - 0b1].Width >= GlobalVariable.boundries.Width))
                {
                    enemyShips[i].Speed += 0b10;
                }
            }
        }

        /// <summary>
        /// Create Bomb
        /// </summary>
        /// <param name="random">Random</param>
        public void CreateBomb(Random random)
        {
            for (int i = 0; i < enemyShips.Count; i++)
            {
                // only 1% probability to drop bomb, and in the bottom rows of EnemyShip could drop bomb
                if ((enemyShips[i].CouldDropBomb==true)&& random.Next(0, BOMB_PROBABILITY_RANGE) == 0)
                {
                    bombs.Add(new Bomb(graphics, GlobalVariable.bitmapBomb, new Point(enemyShips[i].Position.X + GlobalVariable.bitmapEnemyShip.Width / GlobalVariable.Half, enemyShips[i].Position.Y + GlobalVariable.bitmapEnemyShip.Height / GlobalVariable.Half), GlobalVariable.bitmapBomb.Width, GlobalVariable.bitmapBomb.Height, BOMB_SPEED, true, Direction.Down));
                }
            }
        }

        /// <summary>
        /// Draw Bomb
        /// </summary>
        public void DrawBomb()
        {
            foreach (Bomb bomb in bombs)
            {
                bomb.Draw();
            }
        }

        /// <summary>
        /// Move Bomb
        /// </summary>
        public void MoveBomb()
        {
            foreach (Bomb bomb in bombs)
            {
                bomb.Move();
            }
        }

        /// <summary>
        /// Check Bomb LifeSpan
        /// </summary>
        public void CheckLifeSpan()
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs[i].Position.Y >= GlobalVariable.boundries.Height)
                {
                    bombs.Remove(bombs[i]);
                }
            }
        }

        //Properties
        public List<EnemyShip> EnemyShips { get => enemyShips; set => enemyShips = value; }
        public List<Bomb> Bombs { get => bombs; set => bombs = value; }
        public bool Alive { get => alive; set => alive = value; }
    }
}
