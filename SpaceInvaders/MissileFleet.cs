/*
 The MissileFleet class implements the interface of ICheck that hold an collection of Missile, and its state, behaviour.
 */
using System.Collections.Generic;
using System.Drawing;

namespace SpaceInvaders
{
    public class MissileFleet:ICheck
    {
        //Const
        private const int MAX_MISSILE_NUMBER = 15;
        private const int MISSILE_SPEED = 20;

        //Field
        private List<Missile> missiles;

        //Constructor
        public MissileFleet(Graphics graphics)
        {
            missiles = new List<Missile>();
        }

        public void CreateMissile(Graphics graphics,Point velocity,int lifeSpan)
        {
            if (missiles.Count<= MAX_MISSILE_NUMBER)
            {
                missiles.Add(new Missile(graphics, GlobalVariable.bitmapMissle, new Point(velocity.X, velocity.Y), GlobalVariable.bitmapMissle.Width, GlobalVariable.bitmapMissle.Height, MISSILE_SPEED, lifeSpan, Direction.Up));
            }
        }

        public void CheckLifeSpan()
        {
            for (int i = 0; i < missiles.Count; i++)
            {
                if ((missiles[i].LifeSpan) == 0||missiles[i].Position.Y==0)
                {
                    missiles.Remove(missiles[i]);
                }
            }
        }

        public void Draw()
        {
            foreach (Missile missile in missiles)
            {
                missile.Draw();
            }
        }

        public void Move()
        {
            for (int i = 0; i < missiles.Count; i++)
            {
                missiles[i].Move();
                missiles[i].LifeSpan--; //Missile LifeSpan reduce by time
            }
        }

        //Properties
        internal List<Missile> Missiles { get => missiles; set => missiles = value; }
    }
}
