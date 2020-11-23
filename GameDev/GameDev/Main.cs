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
        private Camera camera;
        private State CurrentState;
        private State NextState;
        

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
            
            camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.contentManager = this.Content;
            Globals.spriteBatch  = new SpriteBatch(GraphicsDevice);

            Globals._World = new World();

            CurrentState = new MainMenuState(this, _graphics.GraphicsDevice);

            background = new Background("Sprites\\FarBackground", new Vector2(Globals.ScreenWidth/2, Globals.ScreenHeight/2), new Vector2(Globals.ScreenWidth, Globals.ScreenHeight));
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

            /*Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                background.Draw();

                if (CurrentState.GetType() == typeof(MainMenuState) || CurrentState.GetType() == typeof(LevelSelectState) || CurrentState.GetType() == typeof(PauseMenuState))
                {
                    CurrentState.Draw(gameTime);
                }

            Globals.spriteBatch.End();*/
            //Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);


            background.Draw();

            if (CurrentState.GetType() == typeof(MainMenuState) || CurrentState.GetType() == typeof(LevelSelectState) || CurrentState.GetType() == typeof(PauseMenuState))
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
