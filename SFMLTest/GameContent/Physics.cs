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
    public class Physics{
        private GameTime time;
        public List<GameObject> objects = new List<GameObject>();
        public List<Bullet> bullets = new List<Bullet>();
        public Player player;
        public Physics(GameTime time)
        {
            this.time = time;
        }
        private void CollisionObjs(Bullet obj1,GameObject obj2)
        {
            
            if (obj1.shape.GetGlobalBounds().Intersects(obj2.shape.GetGlobalBounds()))
                Remove(obj2);
            
        }
        private void CollisionObjs(Player obj1, GameObject obj2)
        {

            if (obj1.shape.GetGlobalBounds().Intersects(obj2.shape.GetGlobalBounds()))
                player = null;
        }
        public void Collision()
        {
            for (int i = 0; i < bullets.Count; i++)
                for (int j = 0; j < objects.Count; j++)
                    CollisionObjs(bullets[i], objects[j]);

            for(int i = 0; i < objects.Count; i++)
                if(player !=null)
                    CollisionObjs(player,objects[i]);
        }

        public void Add(GameObject obj)
            => objects.Add(obj);

        public void Add(Bullet obj)
            => bullets.Add(obj);

        public void Remove(Bullet obj)
            => bullets.Remove(obj);

        public void Remove(GameObject obj)
            => objects.Remove(obj);     
    }
}
