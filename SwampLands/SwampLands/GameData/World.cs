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
    class World
    {
        #region Variables
        public EndFlag Checkpoint;
        public List<Platform> WorldObjects;
        public List<MovingPlatform> WorldMovingPlatforms;
        public MainHero PlayerCharacter;
        #endregion

        #region Constructors
        public World(List<Platform> worldPlatforms, Vector2 checkpoint, List<MovingPlatform> movingPlatforms)
        {
            #region Instantiate World Variables
            WorldObjects = new List<Platform>();
            PlayerCharacter = new MainHero();
            WorldMovingPlatforms = new List<MovingPlatform>();
            #endregion

            #region Instantiate Global Variables
            Globals.IsPaused = false;
            #endregion

            #region Create Platforms
            foreach(Platform platform in worldPlatforms)
            {
                WorldObjects.Add(platform);
            }

            foreach (MovingPlatform platform in movingPlatforms)
            {
                WorldMovingPlatforms.Add(platform);
            }
            #endregion

            #region SetCheckpoint
            Checkpoint = new EndFlag((int)checkpoint.X, (int)checkpoint.Y);
            #endregion
        }
        #endregion

        #region Draw
        public virtual void Draw(GameTime gameTime)
        {
            #region Draw World Platforms
            foreach (Platform platform in WorldObjects)
            {
                platform.Draw(gameTime);
            }

            foreach (MovingPlatform platform in WorldMovingPlatforms)
            {
                platform.Draw(gameTime);
            }
            #endregion

            #region Draw Hero
            PlayerCharacter.Draw(gameTime);
            #endregion

            #region Draw Checkpoint
            Checkpoint.Draw(gameTime);
            #endregion
        }
        #endregion

        #region Update
        public virtual void Update(GameTime gameTime)
        {
            #region Update Hero
            PlayerCharacter.Update(gameTime);
            #endregion

            #region Update World Objects
            foreach (Platform platform in WorldObjects)
            {
                platform.Update(gameTime);
            }

            foreach (MovingPlatform platform in WorldMovingPlatforms)
            {
                platform.Update(gameTime);
            }
            #endregion

            #region Update Checkpoint
            Checkpoint.Update(gameTime);
            #endregion
        }
        #endregion
    }
}
