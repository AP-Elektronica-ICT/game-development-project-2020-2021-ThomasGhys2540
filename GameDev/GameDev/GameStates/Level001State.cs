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
using GameDev.Source;
using GameDev.GamePlay;
using GameDev.GamePlay.WorldData;
using GameDev.GameStates;
#endregion

namespace GameDev.GameStates
{
    public class Level001State: State
    {
        public Level001State(Main main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            Globals._World.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            Globals._World.Draw();
        }
    }
}
