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
    class EndFlag : Object2D
    {
        #region Variables
        private Color SpriteShade;
        private float SpriteRotation;
        private int SpriteSheetSize;
        private int UpdateSpriteAnimation;
        private Rectangle Position;
        private Rectangle SpriteSheet;
        private SpriteEffects SpriteEffect;
        private Texture2D FlagSprite;
        private Vector2 DrawOrigin;
        #endregion

        #region Constructors
        public EndFlag(int X, int Y)
        {
            FlagSprite = Globals.ContentLoader.Load<Texture2D>("Sprites\\Checkpoint\\Checkpoint");
            Position = new Rectangle(X, Y, 50, 50);
            SpriteSheet = new Rectangle(0, 0, 64, 64);
            SpriteShade = Color.White;
            SpriteRotation = 0.0f;
            DrawOrigin = Vector2.Zero;
            SpriteEffect = SpriteEffects.None;
            SpriteSheetSize = 640;
            UpdateSpriteAnimation = 64;
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(FlagSprite, Position, SpriteSheet, SpriteShade, SpriteRotation, DrawOrigin, SpriteEffect, 0);
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            Animate();
            CheckVictoryCondition();
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
        private void CheckVictoryCondition()
        {
            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(Position))
            {
                Globals.ChangeGameState(new VictoryScreenState(Globals.CurrentGameState.Main, Globals.CurrentGameState.Graphics));
            }
        }
        #endregion
    }
}
