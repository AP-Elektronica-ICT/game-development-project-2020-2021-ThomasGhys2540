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
    public enum Direction { Vertical, Horizontal}
    
    class MovingPlatform
    {
        #region Variables
        public Rectangle Hitbox;

        private Boolean HasReachedEndBoundary;
        private Color SpriteShade;
        private Direction DirectionMovement;
        private float Offset = 30;
        private float SpriteRotation;
        private int PlatformSpeed;
        private int SpriteSheetSize;
        private int UpdateSpriteAnimation;
        private Rectangle Position;
        private Rectangle SpriteSheet;
        private SpriteEffects SpriteEffect;
        private Texture2D PlatformSprite;
        private Vector2 DrawOrigin;
        private Vector2 StartBoundary;
        private Vector2 EndBoundary;
        #endregion

        #region Constructors
        public MovingPlatform(Vector2 startposition, Vector2 startboundary, Vector2 endboundary, Direction direction, int speed = 5, int platformsize = 100)
        {
            PlatformSprite = Globals.ContentLoader.Load<Texture2D>("Sprites\\Platform\\MovingPlatform");
            Position = new Rectangle((int)startposition.X, (int)startposition.Y, platformsize, 25);
            SpriteSheet = new Rectangle(0, 0, 32, 8);
            SpriteShade = Color.White;
            SpriteRotation = 0.0f;
            DrawOrigin = Vector2.Zero;
            SpriteEffect = SpriteEffects.None;
            SpriteSheetSize = 256;
            UpdateSpriteAnimation = 32;

            StartBoundary = startboundary;
            EndBoundary = endboundary;
            DirectionMovement = direction;
            PlatformSpeed = speed;
        }
        #endregion

        #region Draw
        public void Draw(GameTime gameTime)
        {
            Globals.SpriteDrawer.Draw(PlatformSprite, Position, SpriteSheet, SpriteShade, SpriteRotation, DrawOrigin, SpriteEffect, 0);
        }
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {
            #region Update Hitbox
            Hitbox = Position;
            #endregion

            #region Animate Platform
            SpriteSheet.X += UpdateSpriteAnimation;

            if (SpriteSheet.X >= SpriteSheetSize)
            {
                SpriteSheet.X = 0;
            }
            #endregion

            #region Update platform position
            switch (DirectionMovement)
            {
                case Direction.Horizontal:
                    if (!HasReachedEndBoundary)
                    {
                        Position.X += PlatformSpeed;

                        #region Move Hero
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(Hitbox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > Hitbox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < Hitbox.Right + Offset)
                            {
                                Globals.WorldSystem.PlayerCharacter.Configuration.X += PlatformSpeed;
                            }
                        }
                        #endregion

                        if (Position.X >= EndBoundary.X)
                        {
                            HasReachedEndBoundary = true;
                        }
                    }
                    else if (HasReachedEndBoundary)
                    {
                        Position.X -= PlatformSpeed;

                        #region Move Hero
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(Hitbox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > Hitbox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < Hitbox.Right + Offset)
                            {
                                Globals.WorldSystem.PlayerCharacter.Configuration.X -= PlatformSpeed;
                            }
                        }
                        #endregion

                        if (Position.X <= StartBoundary.X)
                        {
                            HasReachedEndBoundary = false;
                        }
                    }
                    break;
                case Direction.Vertical:
                    if (!HasReachedEndBoundary)
                    {
                        Position.Y += PlatformSpeed;

                        #region Move Hero
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(Hitbox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > Hitbox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < Hitbox.Right + Offset)
                            {
                                Globals.WorldSystem.PlayerCharacter.Configuration.Y += PlatformSpeed;
                            }
                        }
                        #endregion

                        if (Position.Y >= EndBoundary.Y)
                        {
                            HasReachedEndBoundary = true;
                        }
                    }
                    else if (HasReachedEndBoundary)
                    {
                        Position.Y -= PlatformSpeed;

                        #region Move Hero
                        if (Globals.WorldSystem.PlayerCharacter.Hitbox.Intersects(Hitbox))
                        {
                            if (Globals.WorldSystem.PlayerCharacter.Hitbox.Top < Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Bottom > Hitbox.Top &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Left > Hitbox.Left - Offset &&
                                Globals.WorldSystem.PlayerCharacter.Hitbox.Right < Hitbox.Right + Offset)
                            {
                                Globals.WorldSystem.PlayerCharacter.Configuration.Y -= PlatformSpeed;
                            }
                        }
                        #endregion

                        if (Position.Y <= StartBoundary.Y)
                        {
                            HasReachedEndBoundary = false;
                        }
                    }
                    break;
                default:
                    break;
            }
            #endregion
        }
        #endregion
    }
}
