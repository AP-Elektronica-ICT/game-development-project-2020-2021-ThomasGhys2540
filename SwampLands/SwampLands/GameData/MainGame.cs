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
#endregion

namespace SwampLands
{
    public class MainGame : Game
    {
        #region Variables
        private GameBackground Background;
        private GraphicsDeviceManager Graphics;
        private State CurrentGameState;
        private State NextGameState;
        #endregion

        #region Constructors
        public MainGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion

        #region Load Content
        protected override void LoadContent()
        {
            Globals.ContentLoader = this.Content;
            Globals.SpriteDrawer = new SpriteBatch(GraphicsDevice);

            Background = new GameBackground("Sprites\\Backgrounds\\Forest");

            CurrentGameState = new MainMenuState(this, Graphics.GraphicsDevice);
            
            base.LoadContent();
        }
        #endregion

        #region Initialise Content
        protected override void Initialize()
        {
            Globals.ScreenWidth = 1600;
            Globals.ScreenHeight = 900;

            Graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            Graphics.PreferredBackBufferHeight = Globals.ScreenHeight;

            Graphics.ApplyChanges();
            
            base.Initialize();
        }
        #endregion

        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);

            #region Normal SpriteBatch Call
            Globals.SpriteDrawer.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                Background.Draw();

                if (CurrentGameState.GetType() == typeof(MainMenuState))
                {
                    CurrentGameState.Draw(gameTime);
                }

            Globals.SpriteDrawer.End();
            #endregion

            base.Draw(gameTime);
        }
        #endregion

        #region Update
        protected override void Update(GameTime gameTime)
        {
            #region GameState Update
            if (NextGameState != null)
            {
                CurrentGameState = NextGameState;

                NextGameState = null;
            }

            CurrentGameState.Update(gameTime);
            #endregion

            base.Update(gameTime);
        }
        #endregion

        #region Methods
        public void ChangeGameState(State changeTo)
        {
            NextGameState = changeTo;
        }
        #endregion
    }
}
