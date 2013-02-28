using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;




namespace Snake
{


    class Sprite
    {


        Texture2D tSprite;
        //Vector2   v2StartPosition;

        Vector2 v2MovingDirection;








        Rectangle rSpriteSize;
        Rectangle rSpriteSource;
        float fSpriteScale;


        float fSpriteScaleSizeSourceGetSet
        {
            get { return fSpriteScale; }
            set{
                fSpriteScale  = value;
                rSpriteSize   = new Rectangle(0, 0, (int)(tSprite.Width * fSpriteScale), (int)(tSprite.Height * fSpriteScale));
                rSpriteSource = rSpriteSize;
            }


        }



        private MovingState mMovingState;
        private enum MovingState
        {
            NotMoving,
            MovingLeft,
            MovingRight,
            MovingUp,
            MovingDown
        }




        //Rectangle rSpriteSizeGetSet
        //{
            
        //    get { return rSpriteSize;  }
        //    set { rSpriteSize = new Rectangle(0, 0, (int)(tSprite.Width * fSpriteScale), (int)(tSprite.Height * fSpriteScale)); }
 
        //}








        public void LoadContent(ContentManager theContentManager, string sSpriteFileName, float fscale)
        {

            tSprite = theContentManager.Load<Texture2D>(sSpriteFileName);
            //v2StartPosition = new Vector2(400 - (tSprite.Width / 2), 300 - (tSprite.Height / 2));
            v2MovingDirection = new Vector2(400 - (tSprite.Width / 2), 300 - (tSprite.Height / 2));
            fSpriteScaleSizeSourceGetSet = fscale;
            //mMovingState = MovingState.MovingRight;
            mMovingState = MovingState.NotMoving;




            //oSnakeInput = new SnakeInput();
        }




        public void Update(GameTime theGameTime)
        {
            KeyboardState ksCurrentState = Keyboard.GetState();

            CheckInput(ksCurrentState);
            UpdateMovement(ksCurrentState, theGameTime);

        }









        public void UpdateMovement(KeyboardState currentKeyboardState, GameTime theGameTime)
        {

            //LEFT
            if (mMovingState == MovingState.MovingLeft)
            {
                v2MovingDirection += new Vector2((int)(-60 * theGameTime.ElapsedGameTime.TotalSeconds), 0);
            }


            //RIGHT
            if (mMovingState == MovingState.MovingRight)
            {
                v2MovingDirection += new Vector2((int)(60 * theGameTime.ElapsedGameTime.TotalSeconds), 0);
            }


            //UP
            if (mMovingState == MovingState.MovingUp)
            {
                v2MovingDirection += new Vector2(0, (int)(-60 * theGameTime.ElapsedGameTime.TotalSeconds));
            }


            //DOWN
            if (mMovingState == MovingState.MovingDown)
            {
                v2MovingDirection += new Vector2(0, (int)(60 * theGameTime.ElapsedGameTime.TotalSeconds));
            }

        }





        public void CheckInput(KeyboardState ksCurrentKeyboardState)
        {


            if (ksCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
            {
                if (mMovingState == MovingState.MovingRight)
                {
                    return;
                }
                else
                {
                    mMovingState = MovingState.MovingLeft;
                }

            }





            //RIGHTRIGHTRIGHTRIGHTRIGHT
            if (ksCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
            {
                if (mMovingState == MovingState.MovingLeft)
                {
                    return;
                }
                else
                {
                    mMovingState = MovingState.MovingRight;
                    //Update(theGameTime, mMovingState);
                }
            }


            //UPUPUPUPUPUPUPUP
            if (ksCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
            {
                if (mMovingState == MovingState.MovingDown)
                {
                    return;
                }
                else
                {
                    mMovingState = MovingState.MovingUp;
                    //Update(theGameTime, mMovingState);
                }
            }


            //DOWNDOWNDOWNDOWNDOWNDOWN
            if (ksCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
            {
                if (mMovingState == MovingState.MovingUp)
                {
                    return;
                }
                else
                {
                    mMovingState = MovingState.MovingDown;
                    //Update(theGameTime, mMovingState);
                }
            }

        }






        //this method is never called.
        //    didn't implement the way I thought it would
        //protected void Update(GameTime theGametime, MovingState newMovingState)
        //{
        //    if (mMovingState == MovingState.MovingLeft)
        //    {
        //        v2MovingDirection += new Vector2((int)(-60 * theGametime.ElapsedGameTime.TotalSeconds), 0);
        //    }

        //    if (mMovingState == MovingState.MovingRight)
        //    {
        //        v2MovingDirection += new Vector2((int)(60 * theGametime.ElapsedGameTime.TotalSeconds), 0);
        //    }




        //}








        public void Draw(SpriteBatch theSpriteBatch)
        {


            theSpriteBatch.Draw(tSprite, v2MovingDirection, rSpriteSource, Color.White, 0f, Vector2.Zero, fSpriteScale, SpriteEffects.None, 1f);

        }




















    }
}
