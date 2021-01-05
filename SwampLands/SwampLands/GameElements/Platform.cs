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
    enum Rotation { Horizontal, Vertical}
    
    class Platform : Object2D
    {
        #region Variables
        public Rectangle HitBox;
        
        private List<PlatformTiles> PlatformParts;
        private Texture2D BottomTile;
        private Texture2D MiddleTile;
        private Texture2D LeftTile;
        private Texture2D RightTile;
        private Vector2 SpriteDimensions;
        #endregion

        #region Constructors
        public Platform(Vector2 position, int platformTileLength, Rotation rotation)
        {
            #region Initialise Platform Variables
            PlatformParts = new List<PlatformTiles>();

            BottomTile = Globals.ContentLoader.Load<Texture2D>("Sprites\\Platform\\BottomTile");
            MiddleTile = Globals.ContentLoader.Load<Texture2D>("Sprites\\Platform\\StraightTile");
            LeftTile = Globals.ContentLoader.Load<Texture2D>("Sprites\\Platform\\LeftCornerTile");
            RightTile = Globals.ContentLoader.Load<Texture2D>("Sprites\\Platform\\RightCornerTile");

            SpriteDimensions = new Vector2(50, 50);
            HitBox = Rectangle.Empty;
            #endregion

            #region Create Platform
            switch (rotation)
            {
                case Rotation.Horizontal:
                    #region onfigure Platform
                    if (platformTileLength == 1)
                    {
                        PlatformParts.Add(new PlatformTiles(MiddleTile, position, SpriteDimensions));
                    }
                    else if (platformTileLength == 2)
                    {
                        PlatformParts.Add(new PlatformTiles(LeftTile, position, SpriteDimensions));
                        PlatformParts.Add(new PlatformTiles(RightTile, new Vector2(position.X + SpriteDimensions.X, position.Y), SpriteDimensions));
                    }
                    else
                    {
                        PlatformParts.Add(new PlatformTiles(LeftTile, position, SpriteDimensions));

                        for (int i = 1; i < (platformTileLength - 1); i++)
                        {
                            PlatformParts.Add(new PlatformTiles(MiddleTile, new Vector2(position.X + (SpriteDimensions.X * i), position.Y), SpriteDimensions));
                        }

                        PlatformParts.Add(new PlatformTiles(RightTile, new Vector2(position.X + (SpriteDimensions.X * (platformTileLength -1)), position.Y), SpriteDimensions));
                    }
                    #endregion

                    #region Set Platform HitBox
                    HitBox = new Rectangle((int)position.X, (int)position.Y, (int)(SpriteDimensions.X * platformTileLength), (int)SpriteDimensions.Y);
                    #endregion
                    break;
                case Rotation.Vertical:
                    #region Configure Platform
                    if (platformTileLength == 1)
                    {
                        PlatformParts.Add(new PlatformTiles(MiddleTile, position, SpriteDimensions));
                    }
                    else
                    {
                        PlatformParts.Add(new PlatformTiles(MiddleTile, position, SpriteDimensions));

                        for (int i = 1; i < (platformTileLength); i++)
                        {
                            PlatformParts.Add(new PlatformTiles(BottomTile, new Vector2(position.X, position.Y + (SpriteDimensions.Y * i)), SpriteDimensions));
                        }
                    }
                    #endregion

                    #region Set Platform HitBox
                    HitBox = new Rectangle((int)position.X, (int)position.Y, (int)SpriteDimensions.X, (int)(SpriteDimensions.Y * platformTileLength));
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            foreach (PlatformTiles _Tiles in PlatformParts)
            {
                _Tiles.Draw(gameTime);
            }
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {

        }
        #endregion
    }
}
