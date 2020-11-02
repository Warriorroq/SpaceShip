using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
namespace SFMLTest
{
    public class GameObject
    {
        public Vector2f position = new Vector2f(0,0);
        public Vector2f moveDirection;
        public ConvexShape shape = new ConvexShape();
        public string tag;
        public GameObject(Vector2f position,Vector2f[] poses)
        {
            this.position = position;
            CreateShape(poses);
        }
        private void CreateShape(Vector2f[] poses)
        {
            if (poses.Length < 3)
                return;

            shape = new ConvexShape((uint)poses.Length);

            for (uint i = 0; i < poses.Length; i++)
                shape.SetPoint(i, poses[i]);

            shape.FillColor = Color.Black;
            shape.Position = position;            
        }
        public void Rotate(float angle)
        {
            if (angle < 0)
                shape.Rotation = -angle + 180;
            else
                shape.Rotation = angle;
        }
        public float GetRotation()
            => shape.Rotation >= 180f ? shape.Rotation - 360f : shape.Rotation;
        public void Move(float time)
        {
            position += moveDirection * time;
            shape.Position = position;
        }
    }
}
