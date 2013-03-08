using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;





namespace Snake
{

    class Food : Sprite
    {
        int iStartTime = 0;
        int iRefreshFood = 3;
        public int iFoodEaten = 0;

        int iScreenWidth;
        int iScreenHeight;



        Random oRandomX = new Random();
        Random oRandomY = new Random();


        public void LoadContent(ContentManager theContentManager, string sFileName, float fFileScale, int iscreenWidth, int iscreenHeight)
        {

            iScreenWidth  = iscreenWidth;
            iScreenHeight = iscreenHeight;

            base.LoadContent(theContentManager, sFileName, fFileScale);

            //Reset the food location from the default Sprite position
            CreateFood();

        }







        public void Update(GameTime theGameTime, Rectangle rsnakeSource)
        {

            //v2MovingPosition is the Current position.

            if (rsnakeSource.Intersects(rSpriteSource) == true)
            {

                CreateFood();             
                ReinitializeCountdown(theGameTime);
                iFoodEaten += 1;

                Snake.bFoodPelletCollision = true;
            }




            if ((iStartTime + iRefreshFood) < (int)theGameTime.TotalGameTime.TotalSeconds)
            {
                ReinitializeCountdown(theGameTime);
                CreateFood();
            }



            base.Update(theGameTime);
        }




        public void ReinitializeCountdown(GameTime theGameTime)
        {
            iStartTime = (int)theGameTime.TotalGameTime.TotalSeconds;
 
        }


        public void CreateFood()
        {
            //Later we'll need to make sure food is not created on any snake rectangle or obstacle rectangle
            //create a piece of food anywhere on the screen
            
            v2MovingDirection = new Vector2(
                oRandomX.Next(0, (iScreenWidth  - rSpriteSource.Width )),
                oRandomY.Next(0, (iScreenHeight - rSpriteSource.Height))
                );

            //if(this.rSpriteSource.Intersects(rsnakeSource))
            //{
            //    CreateFood(rsnakeSource);
            //}


        }








        public void Draw(SpriteBatch theSpriteBatch)
        {


 

            base.Draw(theSpriteBatch);
        }



    //
    }
//
}
