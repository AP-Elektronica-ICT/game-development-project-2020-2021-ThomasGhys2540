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
using GameDev.GamePlay.World;
#endregion

namespace GameDev.Source
{
    public class World
    {
        public MainHero Idlehero;
        public MainHero RunningHero;

        public World()
        {
            Idlehero = new MainHero("Sprites\\IdleHero", new Vector2(300, 300), new Vector2(48, 48), new Rectangle(0, 0, 32, 32), 32, 352);
        }

        public virtual void Update()
        {
            Idlehero.Update();
        }

        public virtual void Draw()
        {
            Idlehero.Draw();
        }
    }
}
