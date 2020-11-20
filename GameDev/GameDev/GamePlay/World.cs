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
        public UserInterface UI;

        public World()
        {
            Hero = new MainHero(new Vector2(300, 500), new Vector2(48, 48), new Rectangle(0, 0, 32, 32));

            UI = new UserInterface();

            Globals.Coinage = 0;
        }

        public virtual void Update()
        {
            Hero.Update();

            UI.Update();
        }

        public virtual void Draw()
        {
            Hero.Draw();

            UI.Draw();
        }
    }
}
