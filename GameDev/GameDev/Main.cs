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

namespace GameDev
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private Background background;
        private State CurrentState;
        private State NextState;
        Camera2d camera2d;
        

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
            
            camera2d = new Camera2d(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.contentManager = this.Content;
            Globals.spriteBatch  = new SpriteBatch(GraphicsDevice);

            Globals._World = new World(new List<Sprites>());

            CurrentState = new MainMenuState(this, _graphics.GraphicsDevice);

            background = new Background("Sprites\\Forest", new Vector2(Globals.ScreenWidth/2, Globals.ScreenHeight/2), new Vector2(Globals.ScreenWidth, Globals.ScreenHeight));
        }

        protected override void Update(GameTime gameTime)
        {
            if (NextState != null)
            {
                CurrentState = NextState;

                NextState = null;
            }

            CurrentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                background.Draw();

                if (CurrentState.GetType() == typeof(MainMenuState) || CurrentState.GetType() == typeof(LevelSelectState) || CurrentState.GetType() == typeof(PauseMenuState))
                {
                    CurrentState.Draw(gameTime);
                }

            Globals.spriteBatch.End();

            var viewMatrix = camera2d.GetViewMatrix(new Vector2(0, 0));

           if (Globals._World.Hero.position != null)
           {
                Vector2 Heropos = new Vector2(Globals._World.Hero.position.X + (Globals._World.Hero.dimensions.X / 2) - 400, 0);


                viewMatrix = camera2d.GetViewMatrix(Heropos);
           }
           else
            {
                viewMatrix = camera2d.GetViewMatrix(new Vector2(0, 0));
            }
            
            Globals.spriteBatch.Begin(transformMatrix: viewMatrix);

                if (CurrentState.GetType() != typeof(MainMenuState) && CurrentState.GetType() != typeof(LevelSelectState) && CurrentState.GetType() != typeof(PauseMenuState))
                {                
                    CurrentState.Draw(gameTime);
                }

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ChangeState(State ChangeTo)
        {
            NextState = ChangeTo;
        }
    }
}
