/*
 The Bomb class is derived from GameObject that hold Bomb's state and behaviour.
 */
using System.Drawing;

namespace SpaceInvaders
{
    public class Bomb:GameObject
    {
        //field
        private bool lifeSpan;

        public Bomb(Graphics graphics, Bitmap bitmap, Point position, int width, int height, int speed, bool lifeSpan, Direction direction) :
            base(graphics, bitmap, position, width, height, speed, direction)
        {
            this.lifeSpan = lifeSpan;
        }

        public bool LifeSpan { get => lifeSpan; set => lifeSpan = value; }
    }
}
