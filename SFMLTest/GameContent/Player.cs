using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace SFMLTest
{
    public class Player
    {
        public Vector2f position = new Vector2f(400,400);
        public RectangleShape shape;
        private Input input;
        public float shootTime = 0.4f;
        public float deltaTime = 0f;
        public Player(Vector2f size,Input input) 
        {
            this.input = input;
            shape = new RectangleShape(size);
            shape.Position = position;
            shape.FillColor = Color.Black;
        }
        public void Move(float delta)
        {
            position = new Vector2f(position.X + input.horisontal * 20f * delta, position.Y + input.vertical * 20f * -delta);
            shape.Position = position;
            deltaTime += delta;
        }
        public Bullet Shoot()
           =>new Bullet(shape.Size / 4f, new Vector2f(shape.Position.X + shape.Size.X/2f, shape.Position.Y));
        
    }
}
