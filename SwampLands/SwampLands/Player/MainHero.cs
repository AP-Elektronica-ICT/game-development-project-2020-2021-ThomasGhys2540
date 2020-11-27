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
    class MainHero
    {
        #region Variables
        private Color SpriteShade;
        private float SpriteRotation;
        private int SpriteSheetSize;
        private int UpdateSpriteAnimation;
        private Rectangle Configuration;
        private Rectangle SpriteSheet;
        private SpriteEffects HeroSpriteEffect;
        private Texture2D HeroSprite;
        private Texture2D IdleSprite;
        private Texture2D RunningSprite;
        private Vector2 DrawOrigin;
        #endregion

        #region Constructors
        public MainHero()
        {
            #region Initialise SpriteTextures
            IdleSprite = Globals.ContentLoader.Load<Texture2D>("Sprites\\Hero\\IdleHero");
            RunningSprite = Globals.ContentLoader.Load<Texture2D>("Sprites\\Hero\\RunHero");
            #endregion

            #region Hero configuration
            HeroSprite = IdleSprite;
            Configuration = new Rectangle(200, 700, 32, 32);
            SpriteSheet = new Rectangle(0, 0, 32, 32);
            SpriteShade = Color.White;
            SpriteRotation = 0.0f;
            DrawOrigin = Vector2.Zero;
            HeroSpriteEffect = SpriteEffects.None;

            UpdateSpriteAnimation = 32;
            #endregion
        }
        #endregion

        #region Draw
        public virtual void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(HeroSprite, Configuration, SpriteSheet, SpriteShade, SpriteRotation, DrawOrigin, HeroSpriteEffect, 0);
        }
        #endregion

        #region Update
        public virtual void Update(GameTime gameTime)
        {
            #region Idle Animation Settings
            if (Keyboard.GetState().IsKeyUp(Keys.Q) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                HeroSprite = IdleSprite;

                SpriteSheetSize = 352;
            }
            #endregion

            #region Animate Sprite
            SpriteSheet.X += UpdateSpriteAnimation;
            
            if (SpriteSheet.X == SpriteSheetSize)
            {
                SpriteSheet.X = 0;
            }
            #endregion
        }
        #endregion
    }
}
