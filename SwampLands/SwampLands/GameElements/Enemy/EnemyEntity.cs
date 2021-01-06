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
        public Boolean HasReachedBoundary;
        public Color Spriteshade;
        public int SpriteSheetSize;
        public int UpdateSpriteAnimation;
        public int Walkingspeed;
        public float SpriteRotation;
        public Rectangle HitBox;
        public Rectangle Position;
        public Rectangle Spritesheet;
        public SpriteEffects EnemySpriteEffect;
        public Texture2D Sprite;
        public Vector2 DrawOrigin;
        public Vector2 EndBoundary;
        public Vector2 StartBoundary;        
        #endregion

        #region Constructors
        public EnemyEntity(Rectangle position, Vector2 start, Vector2 end, int speed)
        {
            Position = position;
            HitBox = Position;
            StartBoundary = start;
            EndBoundary = end;
            Walkingspeed = speed;

            Spriteshade = Color.White;
            SpriteRotation = 0;
            DrawOrigin = Vector2.Zero;
            EnemySpriteEffect = SpriteEffects.None;
        }
        #endregion

        #region Methods
        #region Draw
        public void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(Sprite, Position, Spritesheet, Spriteshade, SpriteRotation, DrawOrigin, EnemySpriteEffect, 0);
        }
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {
            #region Update Hitbox
            HitBox = Position;
            #endregion

            #region Animate Sprite
            Spritesheet.X += UpdateSpriteAnimation;

            if (Spritesheet.X >= SpriteSheetSize)
            {
                Spritesheet.X = 0;
            }
            #endregion

            #region Moving the enemy
            if (!HasReachedBoundary)
            {
                Position.X += Walkingspeed;

                if (Position.X >= EndBoundary.X)
                {
                    HasReachedBoundary = true;
                    EnemySpriteEffect = SpriteEffects.None;
                }
            }
            else if (HasReachedBoundary)
            {
                Position.X -= Walkingspeed;

                if (Position.X <= StartBoundary.X)
                {
                    HasReachedBoundary = false;
                    EnemySpriteEffect = SpriteEffects.FlipHorizontally;
                }
            }
            #endregion
        }
        #endregion
        #endregion
    }
}
