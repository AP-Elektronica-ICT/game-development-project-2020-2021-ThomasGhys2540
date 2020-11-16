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
#endregion

namespace GameDev.Source
{
    public class World
    {
        public Basic2DFormat Idlehero;

        public World()
        {
            Idlehero = new Basic2DFormat("Sprites\\IdleHero", new Vector2(300, 300), new Vector2(48, 48));
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
