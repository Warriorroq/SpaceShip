using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
namespace SFMLTest
{
    public class Bullet
    {
        public RectangleShape shape = new RectangleShape();
        public Vector2f position = new Vector2f(400, 400);

        public Vector2f velocity = new Vector2f(0,-300);
        public Bullet(Vector2f size,Vector2f pos)
        {
            shape = new RectangleShape(size);
            shape.Position = pos;
            position = pos;
            shape.FillColor = Color.Red;
        }
        public void Move(float delta)
        {
            position.Y += velocity.Y * delta;
            position.X += velocity.X * delta;
            shape.Position = position;
        }
    }
}
