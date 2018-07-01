/*
 The MotherShip class is derived from GameObject that hold MotherShip's state and behaviour.
 */
using System.Drawing;

namespace SpaceInvaders
{
    class MotherShip:GameObject
    {
        //field
        private int aliveStatus; //1: alive, 0: dead by Bomb, -1: dead by EnemyShip

        //constructor
        public MotherShip(Graphics graphics, Bitmap bitmap, Point position, int width, int height, int speed,int aliviStatus, Direction direction) :
            base(graphics, bitmap, position, width, height, speed, direction)
        {
            this.aliveStatus = aliviStatus;
        }

        /// <summary>
        /// MotherShip moving
        /// </summary>
        /// <param name="mousePosition">Mouse position</param>
        public void Move(int mousePosition_X)
        {
            if ((mousePosition_X < 0) || (mousePosition_X > (GlobalVariable.boundries.Width - this.width)))
            {
                if (mousePosition_X < 0)
                {
                    this.position.X = 0;
                }
                else
                {
                    this.position.X = GlobalVariable.boundries.Width - this.width;
                }
            }
            else
            {
                this.position.X = mousePosition_X;
            }
        }

        /// <summary>
        /// override GetRectangle for transparent background area
        /// </summary>
        /// <returns>Rectangle</returns>
        public override Rectangle GetRectangle()
        {
            return new Rectangle(this.Position.X, this.Position.Y + 0b1010, this.Width - 0b1010, this.Height - 0b1010);
        }

        //properties
        public int AliveStatus { get => aliveStatus; set => aliveStatus = value; }
    }
}
