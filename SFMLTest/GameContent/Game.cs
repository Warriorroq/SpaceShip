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
    class Game : GameLoop
    {
        public const int windowWidthDefault = 720;
        public const int windowHeightDefault = 480;
        public const string titleOfTheWindow = "Game";
        private Random random = new Random();
        private Input input;
        private Physics physics;
        private float time = 0.75f;
        private float delta = 0;
        public Game() : base(windowWidthDefault, windowHeightDefault, titleOfTheWindow, Color.White){

        }

        public override void Init()
        {
            input = new Input(gameTime);
            physics = new Physics(gameTime);
            physics.player = new Player(new Vector2f(40, 80), input);
            for(int i =0; i<3;i++)
                physics.Add(Factory.CreateRandomObject());

            for (int i = 0; i < 3; i++)
                physics.objects[i].shape.Scale = new Vector2f(4, 4);
        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            input.InputSides();
            physics.Collision();

            ClearObjectsFromScreen();
            MovePlayer();

            CreateMetheor();

            foreach (GameObject obj in physics.objects)
                obj.Move(gameTime.DeltaTime);

            foreach (Bullet obj in physics.bullets)
                obj.Move(gameTime.DeltaTime);

            if(physics.player != null)
                Shoot();
            
        }
        private void MovePlayer()
        {
            if (physics.player != null)
                physics.player.Move(gameTime.DeltaTime);
        }
        private void Shoot()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && physics.player.deltaTime >= physics.player.shootTime)
            {
                physics.player.deltaTime = 0;
                physics.Add(physics.player.Shoot());
            }
        }
        private void CreateMetheor()
        {
            if (delta >= time)
            {
                physics.Add(Factory.CreateRandomObject());
                delta = 0;
            }
            else
                delta += gameTime.DeltaTime;
        }
        public override void Draw(GameTime gameTime)
        {             
            foreach (GameObject obj in physics.objects)
                window.Draw(obj.shape);

            foreach (Bullet obj in physics.bullets)
                window.Draw(obj.shape);

            if(physics.player !=null)
                window.Draw(physics.player.shape);
            DrawFrameRate();
        }
        private void ClearObjectsFromScreen(){
            try
            {
                foreach (GameObject obj in physics.objects)
                {
                    if (obj.position.Y >= 480 || obj.position.X <= -30 || obj.position.X >= 800 || obj.position.Y <= -30)
                        physics.Remove(obj);
                }

                foreach (Bullet obj in physics.bullets)
                {
                    if (obj.position.Y <= 0)
                        physics.Remove(obj);
                }
            }
            catch {}
        }
        //tools
        private void DrawFrameRate()
            =>DebugUtility.Message(this, "FPS: " + (1f / gameTime.DeltaTimeUnscaled).ToString("0.00"));
    }
}
