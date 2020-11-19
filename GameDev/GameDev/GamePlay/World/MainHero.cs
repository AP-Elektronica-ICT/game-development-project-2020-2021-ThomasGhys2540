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

namespace GameDev.GamePlay.World
{
    public class MainHero: Basic2DFormat
    {
        public MainHero(string Path, Vector2 Pos, Vector2 Dim, Rectangle spritesheet, int spritesize, int SpriteAmount): base(Path, Pos, Dim, spritesheet, spritesize, SpriteAmount)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("Q"))
            {
                position = new Vector2(position.X - 1, position.Y);
            }
            else if (Globals.keyboard.GetPress("D"))
            {
                position = new Vector2(position.X + 1, position.Y);
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
