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
        public Rectangle Configuration;
        public Rectangle Hitbox;

        private Boolean HasJumped;
        private CollisionDetection CollisionManager;
        private Color SpriteShade;
        private float Gravity;
        private float JumpForce;
        private float SpriteRotation;
        private int BaseSpeed;
        private int GravityModifier;
        private int Speed;
        private int SpriteSheetSize;
        private int UpdateSpriteAnimation;
        private Rectangle SpriteSheet;
        private SpriteEffects HeroSpriteEffect;
        private Texture2D HeroSprite;
        private Texture2D IdleSprite;
        private Texture2D RunningSprite;
        private Vector2 DrawOrigin;
        private Vector2 Velocity;
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
            Configuration = new Rectangle(100, 700, 32, 32);
            SpriteSheet = new Rectangle(0, 0, 32, 32);
            SpriteShade = Color.White;
            SpriteRotation = 0.0f;
            DrawOrigin = Vector2.Zero;
            HeroSpriteEffect = SpriteEffects.None;

            UpdateSpriteAnimation = 32;
            Hitbox = Configuration;
            CollisionManager = new CollisionDetection();
            Gravity = 9.81f;
            BaseSpeed = 10;
            GravityModifier = 100;
            HasJumped = false;
            JumpForce = -6;
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
            #region update Hitbox
            Hitbox = Configuration;
            #endregion

            #region time
            var _Time = gameTime.ElapsedGameTime.TotalSeconds;
            #endregion

            #region Gravity
            if (CollisionManager.HasCollidedBottom("platform"))
            {
                Velocity.Y = 0;
                HasJumped = false;
            }
            else
            {
                Velocity.Y += Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            #endregion

            #region Sprinting
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Speed = BaseSpeed * 2;
            }
            else
            {
                Speed = BaseSpeed;
            }
            #endregion

            #region IdleSprite
            if (Keyboard.GetState().IsKeyUp(Keys.Q) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                SpriteSheetSize = 352;
                HeroSprite = IdleSprite;

                Velocity.X = 0;
            }
            #endregion

            #region Running Sprite          
            #region Running Right
            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyUp(Keys.Q))
            {
                HeroSprite = RunningSprite;
                HeroSpriteEffect = SpriteEffects.None;
                SpriteSheetSize = 384;

                if (CollisionManager.HasCollidedRight("platform"))
                {
                    Velocity.X = 0;
                }
                else
                {
                    Velocity.X = Speed;
                }
            }
            #endregion

            #region Running Left
            if (Keyboard.GetState().IsKeyDown(Keys.Q) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                HeroSprite = RunningSprite;
                HeroSpriteEffect = SpriteEffects.FlipHorizontally;
                SpriteSheetSize = 384;

                if (CollisionManager.HasCollidedLeft("platform"))
                {
                    Velocity.X = 0;
                }
                else
                {
                    Velocity.X = -Speed;
                }
            }
            #endregion
            #endregion

            #region Jumping
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !HasJumped || Keyboard.GetState().IsKeyDown(Keys.Z) && !HasJumped)
            {
                HasJumped = true;

                Velocity.Y = JumpForce;
            }

            if (CollisionManager.HasCollidedTop("platform"))
            {
                Velocity.Y -= JumpForce / 3;
            }
            #endregion

            #region Movement Update
            Configuration.X += (int)(Velocity.X);
            Configuration.Y += (int)(Velocity.Y * _Time * GravityModifier);
            #endregion

            #region HeroDeath
            #region OutOfBounds
            if (Hitbox.Bottom > Globals.ScreenHeight || Hitbox.Top < -25)
            {
                Globals.ChangeGameState(new GameOverState(Globals.CurrentGameState.Main, Globals.CurrentGameState.Graphics));
            }
            #endregion
            #endregion

            #region Animate Sprite
            SpriteSheet.X += UpdateSpriteAnimation;
            
            if (SpriteSheet.X >= SpriteSheetSize)
            {
                SpriteSheet.X = 0;
            }
            #endregion
        }
        #endregion
    }
}
