using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;






namespace Snake
{
    class SnakeSegments : Sprite
    {

        int iCounter = 0;
        int iReferenceTime = 0;

        public void LoadContent(ContentManager theContentManager, string sSpriteFileName, float fscale)
        {

            base.LoadContent(theContentManager, sSpriteFileName, fscale);
           // v2MovingDirection = snakeSegmentPosition;
        }





        public void Update(GameTime theGameTime, Vector2 listOfTrailingVector)
        {

            //TO-DO
            //Figure out how to move the snake by Miliseconds
            //   to be able to adjust the snakes speed better
            //



            if (iReferenceTime + iCounter <= theGameTime.TotalGameTime.TotalSeconds)
            {
                iCounter = 1;
                iReferenceTime = (int)theGameTime.TotalGameTime.TotalSeconds;

                v2MovingDirection = listOfTrailingVector;
            }


            v2MovingDirection = listOfTrailingVector;


            base.Update(theGameTime);
        }






        public void Draw(SpriteBatch theSpriteBatch)
        {






            base.Draw(theSpriteBatch);
        }







    //
    }   
//
}
