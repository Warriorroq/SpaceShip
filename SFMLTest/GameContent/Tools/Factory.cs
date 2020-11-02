using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLTest
{
    public static class Factory
    {
        private static Random random = new Random();
        public static GameObject CreateRandomObject()
        {
            Vector2f pos = new Vector2f(random.Next(400), 1);
            uint countOfdots = (uint)random.Next(10);
            Vector2f dot = new Vector2f(0, 0);
            Vector2f[] dots = new Vector2f[countOfdots];

            for(int i = 0;i<countOfdots;i++)
            {
                dot = RandomDot(dot);
                dots[i] = dot;
            }

            GameObject obj = new GameObject(pos, dots);
            if(random.NextDouble() < 0.3f)
                obj.moveDirection = GiveDirection(10);
            else 
                obj.moveDirection = GiveDirection(50);

            return obj;
        }
        public static Player CreatePlayer(Vector2f size, Input input)
            =>new Player(size, input);
        
        private static Vector2f GiveDirection(int x)
            => new Vector2f(random.Next(0,x),random.Next(0,50));
        
        private static Vector2f RandomDot(Vector2f lastVec)
            => new Vector2f(lastVec.X - random.Next(-30,30), lastVec.Y - random.Next(-30,30));
        
    }
}
