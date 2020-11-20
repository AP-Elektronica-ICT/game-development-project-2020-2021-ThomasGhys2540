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
#endregion

namespace GameDev
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;

        private World world;
        private Background background;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.ScreenWidth = 1600;
            Globals.ScreenHeight = 900;

            _graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Globals.ScreenHeight;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.contentManager = this.Content;
            Globals.spriteBatch  = new SpriteBatch(GraphicsDevice);

            world = new World();
            background = new Background("Sprites\\FarBackground", new Vector2(Globals.ScreenWidth/2, Globals.ScreenHeight/2), new Vector2(Globals.ScreenWidth, Globals.ScreenHeight));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                background.Draw();

            Globals.spriteBatch.End();

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                
                world.Draw();

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
