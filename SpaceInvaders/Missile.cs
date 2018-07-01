/*
 The Missile class is derived from GameObject that hold Missile's state and behaviour.
 */
using System.Drawing;

namespace SpaceInvaders
{
    class Missile : GameObject
    {
        //field
        private int lifeSpan;

        public Missile(Graphics graphics, Bitmap bitmap, Point position, int width, int height, int speed, int lifeSpan, Direction direction) :
            base(graphics,bitmap,position, width, height, speed, direction)
        {
            this.lifeSpan = lifeSpan;
        }

        //properties
        public int LifeSpan { get => lifeSpan; set => lifeSpan = value; }
    }
}
