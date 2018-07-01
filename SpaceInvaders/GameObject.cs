/*
 The GameObject class is a base class that hold a few common state and behaviour.
 */
using System.Drawing;

namespace SpaceInvaders
{
    public abstract class GameObject
    {
        //Field
        protected Graphics graphics;
        protected Bitmap bitmap;
        protected Point position;
        protected int width;
        protected int height;
        protected int speed;
        protected Direction direction;

        //Constructor
        public GameObject(Graphics graphics, Bitmap bitmap, Point position, int width, int height, int speed, Direction direction)
        {
            this.graphics = graphics;
            this.bitmap = bitmap;
            this.position = position;
            this.width = width;
            this.height = height;
            this.speed = speed;
            this.direction = direction;
        }

        /// <summary>
        /// Get Rectangle of single GameObject
        /// </summary>
        /// <returns>Rectangle</returns>
        public virtual Rectangle GetRectangle()
        {
            return new Rectangle(this.position.X, this.position.Y, this.width, this.height);
        }

        /// <summary>
        /// Common Draw method
        /// </summary>
        public void Draw()
        {
            graphics.DrawImage(bitmap, position.X, position.Y, Width, Height);
        }

        /// <summary>
        /// virtual Move method
        /// </summary>
        public virtual void Move()
        {
            switch (this.direction)
            {
                case Direction.Up:
                    this.position.Y -= this.speed;
                    break;
                case Direction.Down:
                    this.position.Y += this.speed;
                    break;
                case Direction.Left:
                    this.position.X -= this.speed;
                    break;
                case Direction.Right:
                    this.position.X += this.speed;
                    break;
            }

            if (this.position.X <= 0)
            {
                this.position.X = 0;
            }
            if (this.position.X >= GlobalVariable.boundries.Width)
            {
                this.position.X = GlobalVariable.boundries.Width;
            }
            if (this.position.Y <= 0)
            {
                this.position.Y = 0;
            }
            if (this.position.Y >= GlobalVariable.boundries.Height)
            {
                this.position.Y = GlobalVariable.boundries.Height;
            }
        }

        //Properties
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Direction Direction { get => direction; set => direction = value; }
        public int Speed { get => speed; set => speed = value; }
        public Point Position { get => position; set => position = value; }
    }
}
