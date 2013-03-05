using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;




namespace Snake
{
    class Snake : Sprite
    {

        private MovingState mMovingState;
        private enum MovingState
        {
            NotMoving,
            MovingLeft,
            MovingRight,
            MovingUp,
            MovingDown
        }


        public void LoadContent(ContentManager theContentManager, string sSpriteFileName, float fscale)
        {

            base.LoadContent(theContentManager, sSpriteFileName, fscale);
        }



        public override void Update(GameTime theGameTime)
        {
            KeyboardState ksCurrentState = Keyboard.GetState();

            CheckInput(ksCurrentState);
            UpdateMovement(ksCurrentState, theGameTime);



            base.Update(theGameTime);
        }









        public void UpdateMovement(KeyboardState currentKeyboardState, GameTime theGameTime)
        {

            //LEFT
            if (mMovingState == MovingState.MovingLeft)
            {
                v2MovingDirection += new Vector2((int)(-160 * theGameTime.ElapsedGameTime.TotalSeconds), 0);
            }


            //RIGHT
            if (mMovingState == MovingState.MovingRight)
            {
                v2MovingDirection += new Vector2((int)(160 * theGameTime.ElapsedGameTime.TotalSeconds), 0);
            }


            //UP
            if (mMovingState == MovingState.MovingUp)
            {
                v2MovingDirection += new Vector2(0, (int)(-160 * theGameTime.ElapsedGameTime.TotalSeconds));
            }


            //DOWN
            if (mMovingState == MovingState.MovingDown)
            {
                v2MovingDirection += new Vector2(0, (int)(160 * theGameTime.ElapsedGameTime.TotalSeconds));
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








        public override void Draw(SpriteBatch theSpriteBatch)
        {
            base.Draw(theSpriteBatch);
        }









    }
}
