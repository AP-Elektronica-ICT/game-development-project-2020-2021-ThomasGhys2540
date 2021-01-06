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
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
        #endregion
    }
}
