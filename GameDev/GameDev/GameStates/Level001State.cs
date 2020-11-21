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
        private World world;

        public Level001State(Main main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            world = new World();
        }

        public override void Update(GameTime gameTime)
        {
            world.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            world.Draw();
        }
    }
}
