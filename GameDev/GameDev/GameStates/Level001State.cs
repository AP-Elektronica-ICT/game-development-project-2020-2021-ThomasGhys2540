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
        public List<Platform> Objects;
        
        public Level001State(Main main, GraphicsDevice graphicsDevice) : base(main, graphicsDevice)
        {
            Objects = new List<Platform>();

            #region Platform1
            List<Sprites> PlatformComponents = new List<Sprites>();
            
            PlatformComponents.Add(new Sprites("Sprites\\LeftCornerTile", new Vector2(-32, 700), new Vector2(32, 32), new Rectangle(0, 0, 32, 32)));
            for (int i = 0; i <= 320; i += 32)
            {
                PlatformComponents.Add(new Sprites("Sprites\\StraightTile", new Vector2(i, 700), new Vector2(32, 32), new Rectangle(0, 0, 32, 32)));
            }
            PlatformComponents.Add(new Sprites("Sprites\\RightCornerTile", new Vector2(352, 700), new Vector2(32, 32), new Rectangle(0, 0, 32, 32)));

            Platform Platform1 = new Platform(PlatformComponents, "horizontal");
            Objects.Add(Platform1);
            #endregion

            Globals._World = new World(Objects);
        }

        public override void Update(GameTime gameTime)
        {
            Globals._World.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals._World.Draw();
        }
    }
}
