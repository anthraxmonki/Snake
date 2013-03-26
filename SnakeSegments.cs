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


        public void LoadContent(ContentManager theContentManager, string sSpriteFileName, float fscale)
        {

            base.LoadContent(theContentManager, sSpriteFileName, fscale);
        }





        public void UpdateSnakeSegmentTrail(GameTime theGameTime, Vector2 listOfTrailingVector)
        {



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
