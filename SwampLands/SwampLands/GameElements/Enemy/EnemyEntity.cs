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
    public abstract class EnemyEntity
    {
        #region Variables
        protected Boolean HasReachedBoundary;
        protected Color SpriteShade;
        protected float SpriteRotation;
        protected int SpriteSheetSize;
        protected int UpdateSpriteAnimation;
        protected int Walkingspeed;
        protected Rectangle Position;
        protected Rectangle SpriteSheet;
        protected SpriteEffects SpriteEffect;
        protected Texture2D Sprite;
        protected Vector2 DrawOrigin;
        protected Vector2 EndBoundary;
        protected Vector2 StartBoundary;

        public Rectangle HitBox;
        #endregion

        #region Constructors
        public EnemyEntity(Rectangle position, Vector2 start, Vector2 end, int speed)
        {
            HasReachedBoundary = false;
            SpriteShade = Color.White;
            SpriteRotation = 0;
            Walkingspeed = speed;
            HitBox = position;
            Position = position;
            SpriteEffect = SpriteEffects.None;
            DrawOrigin = Vector2.Zero;
            StartBoundary = start;
            EndBoundary = end;
            
        }
        #endregion

        #region Draw
        public void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(Sprite, Position, SpriteSheet, SpriteShade, SpriteRotation, DrawOrigin, SpriteEffect, 0);
        }
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {
            HitBox = Position;
            Animate();
            Movement();
        }
        #endregion

        #region Methods
        private void Animate()
        {
            SpriteSheet.X += UpdateSpriteAnimation;

            if (SpriteSheet.X >= SpriteSheetSize)
            {
                SpriteSheet.X = 0;
            }
        }
        private void Movement()
        {
            if (!HasReachedBoundary)
            {
                Position.X += Walkingspeed;

                if (Position.X >= EndBoundary.X)
                {
                    HasReachedBoundary = true;
                    SpriteEffect = SpriteEffects.None;
                }
            }
            else if (HasReachedBoundary)
            {
                Position.X -= Walkingspeed;

                if (Position.X <= StartBoundary.X)
                {
                    HasReachedBoundary = false;
                    SpriteEffect = SpriteEffects.FlipHorizontally;
                }
            }
        }
        #endregion
    }
}
