/*
 The Manager class is a game control class that pass parameters between GameForm and Game Object, and call each method of them.
 */
using System;
using System.Drawing;

namespace SpaceInvaders
{
    public class Manager
    {
        //Const
        private const int LIMITLIFESPAN = 70;
        private const int OFFSET = 0b101010;
        private const int MOTHERSHIP_SPEED = 10;

        //Fields
        private Random random;
        private Graphics graphics;
        private MotherShip motherShip;
        private EnemyShipFleet enemyShipFleet;
        private MissileFleet missileFleet;
        private int enemyShipCount = 0;
        private int bombCount = 0;

        //Constructor
        public Manager(Graphics graphics, Random random)
        {
            this.random = random;
            this.graphics = graphics;
            motherShip = new MotherShip(graphics, GlobalVariable.bitmapMotherShip, new Point(0, GlobalVariable.boundries.Height - GlobalVariable.bitmapMotherShip.Height), GlobalVariable.bitmapMotherShip.Width, GlobalVariable.bitmapMotherShip.Height, MOTHERSHIP_SPEED, 1, Direction.Right);
            enemyShipFleet = new EnemyShipFleet(graphics);
            missileFleet = new MissileFleet(graphics);
        }

        //Draw all objects
        private void Draw()
        {
            enemyShipFleet.Draw();
            missileFleet.Draw();
            enemyShipFleet.DrawBomb();
            motherShip.Draw();
        }

        //Move all objects
        private void Move()
        {
            enemyShipFleet.Move();
            missileFleet.Move();
            enemyShipFleet.MoveBomb();
        }

        public void Run()
        {
            Draw();
            Move();
            enemyShipFleet.CreateBomb(random);
            DetecteCollision();
            missileFleet.CheckLifeSpan(); //Check Missile life
            enemyShipFleet.CheckLifeSpan(); //Check Bomb life
        }

        #region control MotherShip move by mouse move
        /// <summary>
        /// control MotherShip move by mouse move
        /// </summary>
        /// <param name="mousePosition">Mouse cursor location(X, Y)</param>
        public void MouseControll(int mousePosition_X)
        {
            motherShip.Move(mousePosition_X);
        }
        #endregion

        #region control Missile created by mouse click
        /// <summary>
        /// control Missile created by mouse click
        /// </summary>
        public void MotherShipFire()
        {
            missileFleet.CreateMissile(graphics, new Point(motherShip.Position.X + OFFSET, motherShip.Position.Y), random.Next(1, LIMITLIFESPAN));
        }
        #endregion

        /// <summary>
        /// Check EnemyShip life
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckEnemyShipFleetLife()
        {
            return enemyShipFleet.Alive;
        }

        /// <summary>
        /// Check MotherShip life
        /// </summary>
        /// <returns>1: alive, 0: dead by Bomb, -1: dead by EnemyShip</returns>
        public int CheckMotherShipLife()
        {
            return motherShip.AliveStatus;
        }

        #region Detecte collision between EnemyShip with Missile
        /// <summary>
        /// Detecte collision between EnemyShip with Missile
        /// </summary>
        private void DetecteCollision()
        {
            MissileHitEnemyShip();
            MissileHitBomb();
            MotherShipHitBomb();
            MotherShipHitEnemyShip();
        }

        /// <summary>
        /// Missile intersectswith EnemyShip
        /// </summary>
        private void MissileHitEnemyShip()
        {
            if (enemyShipFleet.EnemyShips.Count > 0 && missileFleet.Missiles.Count > 0)
            {
                for (int i = 0; i < missileFleet.Missiles.Count; i++)
                {
                    for (int j = 0; j < enemyShipFleet.EnemyShips.Count; j++)
                    {
                        if (missileFleet.Missiles[i].GetRectangle().IntersectsWith(enemyShipFleet.EnemyShips[j].GetRectangle()))
                        {
                            GlobalVariable.PlaySound(GlobalVariable.explode4);
                            Point explosionLocation = new Point(missileFleet.Missiles[i].Position.X, missileFleet.Missiles[i].Position.Y);
                            missileFleet.Missiles.Remove(missileFleet.Missiles[i]);
                            if (j > 1 && enemyShipFleet.EnemyShips[j].CouldDropBomb) //only last column give drop bomb rights  此处有漏洞（比如打中中间的敌舰，会有两个敌舰同时丢炸弹），需修正 it might be bug here
                            {
                                enemyShipFleet.EnemyShips[j - 1].CouldDropBomb = true;
                            }
                            enemyShipFleet.EnemyShips.Remove(enemyShipFleet.EnemyShips[j]);
                            enemyShipCount++;
                            PlayExplosionEffect(explosionLocation);
                            break;
                        }
                    }
                }
            }
            else if (enemyShipFleet.EnemyShips.Count == 0)
            {
                enemyShipFleet.Alive = true;
            }
        }

        /// <summary>
        /// Missile intersectswith Bomb
        /// </summary>
        private void MissileHitBomb()
        {
            if (enemyShipFleet.Bombs.Count > 0 && missileFleet.Missiles.Count > 0)
            {
                for (int i = 0; i < missileFleet.Missiles.Count; i++)
                {
                    for (int j = 0; j < enemyShipFleet.Bombs.Count; j++)
                    {
                        if (missileFleet.Missiles[i].GetRectangle().IntersectsWith(enemyShipFleet.Bombs[j].GetRectangle()))
                        {
                            GlobalVariable.PlaySound(GlobalVariable.explode4);
                            Point explosionLocation = new Point(missileFleet.Missiles[i].Position.X, missileFleet.Missiles[i].Position.Y);
                            missileFleet.Missiles.Remove(missileFleet.Missiles[i]);
                            enemyShipFleet.Bombs.Remove(enemyShipFleet.Bombs[j]);
                            bombCount++;
                            PlayExplosionEffect(explosionLocation);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// MotherShip intersectswith Bomb
        /// </summary>
        private void MotherShipHitBomb()
        {
            if (enemyShipFleet.Bombs.Count > 0)
            {
                for (int i = 0; i < enemyShipFleet.Bombs.Count; i++)
                {
                    if (enemyShipFleet.Bombs[i].GetRectangle().IntersectsWith(motherShip.GetRectangle()))
                    {
                        GlobalVariable.PlaySound(GlobalVariable.explode4);
                        motherShip.AliveStatus = 0;
                    }
                }
            }
        }

        /// <summary>
        /// MotherShip intersectswith EnemyShip
        /// </summary>
        private void MotherShipHitEnemyShip()
        {
            if (enemyShipFleet.EnemyShips.Count > 0)
            {
                for (int i = 0; i < enemyShipFleet.EnemyShips.Count; i++)
                {
                    if (enemyShipFleet.EnemyShips[i].GetRectangle().IntersectsWith(motherShip.GetRectangle()))
                    {
                        GlobalVariable.PlaySound(GlobalVariable.explode4);
                        motherShip.AliveStatus = -1;
                    }
                }
            }
        }
        #endregion

        public int GetEnemyShipCount() //Get the Player hit how many EnemyShip
        {
            return enemyShipCount;
        }

        public int GetBombCount() //Get the Player hit how many Bomb
        {
            return bombCount;
        }

        /// <summary>
        /// Check any EnemyShip whether reach bottom line except MotherShip top
        /// </summary>
        /// <returns></returns>
        public bool IsEnemyShipReachBottomLine()
        {
            bool result = false;
            if (enemyShipFleet.EnemyShips.Count > 0)
            {
                for (int i = 0; i < enemyShipFleet.EnemyShips.Count; i++)
                {
                    if (enemyShipFleet.EnemyShips[i].Position.Y > motherShip.Position.Y)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Play explosion effect
        /// </summary>
        /// <param name="explosionLocation"></param>
        private void PlayExplosionEffect(Point explosionLocation)
        {
            for (int z = 0; z < GlobalVariable.GetExplosionImages().Length; z++)
            {
                Bitmap bufferbp = new Bitmap(GlobalVariable.GetExplosionImages()[z]);
                graphics.DrawImage(bufferbp, explosionLocation.X, explosionLocation.Y);
            }
        }
    }
}

