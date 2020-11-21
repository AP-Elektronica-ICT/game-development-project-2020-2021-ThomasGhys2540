#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameDev.Source.Engine;
using GameDev.GamePlay.WorldData;
#endregion

namespace GameDev.Source
{
    public class World
    {
        public MainHero Hero;

        public World()
        {
            Hero = new MainHero(new Vector2(300, 500), new Vector2(48, 48), new Rectangle(0, 0, 32, 32));

            Globals.Coinage = 0;
            Globals.IsPaused = false;
        }

        public virtual void Update()
        {
            if (!Globals.IsPaused)
            {
                Hero.Update();
            }
            else
            {

            }

            Keyboard.GetState();
            if (Keyboard.HasBeenPressed(Keys.P))
            {
                Globals.IsPaused = !Globals.IsPaused;
            }
        }

        public virtual void Draw()
        {
            Hero.Draw();
        }
    }
}
