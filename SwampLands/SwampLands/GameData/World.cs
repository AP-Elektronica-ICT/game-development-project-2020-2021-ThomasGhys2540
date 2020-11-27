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
        List<Platform> WorldObjects;
        MainHero PlayerCharacter;
        #endregion

        #region Constructors
        public World(List<Platform> worldPlatforms)
        {
            #region Instantiate World Variables
            WorldObjects = new List<Platform>();
            PlayerCharacter = new MainHero();
            #endregion

            #region Instantiate Global Variables
            Globals.IsPaused = false;
            #endregion

            #region Create Platforms
            foreach(Platform platform in worldPlatforms)
            {
                WorldObjects.Add(platform);
            }
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
            #endregion

            #region Draw Hero
            PlayerCharacter.Draw(gameTime);
            #endregion
        }
        #endregion

        #region Update
        public virtual void Update(GameTime gameTime)
        {
            #region Update Hero
            PlayerCharacter.Update(gameTime);
            #endregion
        }
        #endregion
    }
}
