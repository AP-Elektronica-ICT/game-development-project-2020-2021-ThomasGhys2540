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
        private Camera Camera2D;
        private GameBackground Background;
        private GraphicsDeviceManager Graphics;
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

            Globals.CurrentGameState = new MainMenuState(this, Graphics.GraphicsDevice);
            
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

            Camera2D = new Camera(Graphics.GraphicsDevice.Viewport);

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

                if (Globals.CurrentGameState.GetType() == typeof(MainMenuState) || Globals.CurrentGameState.GetType() == typeof(LevelSelectState) || Globals.CurrentGameState.GetType() == typeof(GameOverState) || Globals.CurrentGameState.GetType() == typeof(VictoryScreenState))
                {
                    Globals.CurrentGameState.Draw(gameTime);
                }

            Globals.SpriteDrawer.End();
            #endregion

            #region Calculate Camera ViewMatrix
            var ViewMatrix = Camera2D.GetViewMatrix(Vector2.Zero);

            if (Globals.WorldSystem != null)
            {
                Vector2 PlayerPosition = new Vector2(Globals.WorldSystem.PlayerCharacter.Hitbox.X + (Globals.WorldSystem.PlayerCharacter.Hitbox.Width / 2) - 400, 0);

                ViewMatrix = Camera2D.GetViewMatrix(PlayerPosition);
            }
            else
            {
                ViewMatrix = Camera2D.GetViewMatrix(Vector2.Zero);
            }
            #endregion

            #region Level Spritebatch Call
            Globals.SpriteDrawer.Begin(transformMatrix: ViewMatrix);

                if (Globals.CurrentGameState.GetType() != typeof(MainMenuState) || Globals.CurrentGameState.GetType() != typeof(LevelSelectState) || Globals.CurrentGameState.GetType() != typeof(GameOverState) || Globals.CurrentGameState.GetType() != typeof(VictoryScreenState))
                {
                    Globals.CurrentGameState.Draw(gameTime);
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
            if (Globals.NextGameState != null)
            {
                Globals.CurrentGameState = Globals.NextGameState;

                Globals.NextGameState = null;
            }

            Globals.CurrentGameState.Update(gameTime);
            #endregion

            base.Update(gameTime);
        }
        #endregion
    }
}
