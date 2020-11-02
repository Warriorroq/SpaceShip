using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
namespace SFMLTest
{
    public class Input
    {
        public float horisontal = 0;
        public float vertical = 0;
        private GameTime gTime;
        public Input(GameTime game)
            =>gTime = game;
        public void InputSides()
        {
            InputHorisontal();
            Inputvertical();
        }
        private void InputHorisontal() {

            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && horisontal > -5f)
                horisontal -= 3 * gTime.DeltaTime;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D) && horisontal < 5f)
                horisontal += 3 * gTime.DeltaTime;
            else if (horisontal > 0)
                horisontal -= 1.5f * gTime.DeltaTime;
            else
                horisontal += 1.5f * gTime.DeltaTime;

            if (Math.Abs(horisontal) < 0.001f)
                horisontal = 0;

            if (horisontal > 5f)
                horisontal = 5f;
            else if (horisontal < -5f)
                horisontal = -5f;
        }
        private void Inputvertical()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && horisontal > -5f)
                vertical -= 3 * gTime.DeltaTime;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.W) && horisontal < 5f)
                vertical += 3 * gTime.DeltaTime;
            else if (vertical > 0)
                vertical -= 1.5f * gTime.DeltaTime;
            else
                vertical += 1.5f * gTime.DeltaTime;

            if (Math.Abs(vertical) < 0.001f)
                vertical = 0;

            if (vertical > 5f)
                vertical = 5f;
            else if(vertical < -5f)
                vertical = -5f;
        }
    }
}
