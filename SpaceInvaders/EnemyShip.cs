/*
 The EnemyShip class is derived from GameObject that hold EnemyShip's state and behaviour.
 */
using System.Drawing;

namespace SpaceInvaders
{
    public class EnemyShip:GameObject
    {
        //Field
        private bool couldDropBomb; // whether has rights to drop bomb

        //constructor
        public EnemyShip(Graphics graphics, Bitmap bitmap, Point position, int width, int height, int speed, bool couldDropBomb, Direction direction) :
            base(graphics, bitmap, position, width, height, speed, direction)
        {
            this.couldDropBomb = couldDropBomb;
        }

        public override void Move()
        {
            switch (this.Direction)
            {
                case Direction.Left:
                    this.position.X -= this.Speed;
                    break;
                case Direction.Right:
                    this.position.X += this.Speed;
                    break;
            }
        }

        public void GetDown(int downSpeed)
        {
            this.position.Y += downSpeed;
        }

        //Properties
        public bool CouldDropBomb { get => couldDropBomb; set => couldDropBomb = value; }
    }
}
