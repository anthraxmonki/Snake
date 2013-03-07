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

        int iCounter = 0;
        int iReferenceTime = 0;

        Vector2 v2Left  = new Vector2(-40,   0);
        Vector2 v2Right = new Vector2( 40,   0);
        Vector2 v2Up    = new Vector2(  0, -40);
        Vector2 v2Down  = new Vector2(  0,  40);
        Vector2 v2MovementVector;



        public List<SnakeSegments> lOfSnakeSegments = new List<SnakeSegments>();
        ContentManager theSnakeSegmentContentManager;

        List<MovingState> lOfMovingStates = new List<MovingState>();
        List<Vector2> lOfTrailingVectors = new List<Vector2>();

        public static bool bFoodPelletCollision = false;


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


            theSnakeSegmentContentManager = theContentManager;
            foreach (SnakeSegments SnakeSegment in lOfSnakeSegments)
            {
                SnakeSegment.LoadContent(theContentManager, sSpriteFileName, fscale);
            }





            base.LoadContent(theContentManager, sSpriteFileName, fscale);
        }








        //
        //
        //
        //
        //
        public override void Update(GameTime theGameTime)
        {
            KeyboardState ksCurrentState = Keyboard.GetState();

            if (bFoodPelletCollision == true)
            {
                GrowSnake();
                bFoodPelletCollision = false;
            }


            CheckInput(ksCurrentState);
            UpdateMovement(ksCurrentState, theGameTime);




            //this update logic creates the snake's tail
            int j = (lOfTrailingVectors.Count - lOfSnakeSegments.Count) - 1;
            for(int i = lOfSnakeSegments.Count- 1; i >= 0; i--)
            {

                //int j = lOfTrailingVectors.Count - lOfSnakeSegments.Count;
                lOfSnakeSegments[i].Update(theGameTime, lOfTrailingVectors[j]);

                j++;


            }







            base.Update(theGameTime);
        }







        public void GrowSnake()
        {

            //if (mMovingState == MovingState.MovingRight)
            //{
            //    v2MovementVector = v2Left;
            //}
            //else if (mMovingState == MovingState.MovingLeft)
            //{
            //    v2MovementVector = v2Right;
            //} 
            //else if (mMovingState == MovingState.MovingUp)
            //{
            //    v2MovementVector = v2Down;
            //} 
            //else if (mMovingState == MovingState.MovingDown)
            //{
            //    v2MovementVector = v2Up;
            //}




                SnakeSegments oSnakeSegment = new SnakeSegments();
                oSnakeSegment.LoadContent(theSnakeSegmentContentManager, "SnakeSegment", 1.0f);

                lOfSnakeSegments.Add(oSnakeSegment);



            //if (lOfSnakeSegments.Count >= 1)
            //{
            //    SnakeSegments oSnakeSegment = new SnakeSegments();

            //    for(int i = 0; i < lOfSnakeSegments.Count; i++)
            //    {
            //        //oSnakeSegment.LoadContent(theSnakeSegmentContentManager, "SnakeSegment", 1.0f,
            //        //    new Vector2(lOfSnakeSegments[i].v2MovingDirection.X + 100, 10));
            //        oSnakeSegment.LoadContent(theSnakeSegmentContentManager, "SnakeSegment", 1.0f, v2MovingDirection + v2MovementVector);


            //    }

            //    lOfSnakeSegments.Add(oSnakeSegment);
            //}

            //else
            //{
            //    SnakeSegments oSnakeSegment = new SnakeSegments();
            //    oSnakeSegment.LoadContent(theSnakeSegmentContentManager, "SnakeSegment", 1.0f,
            //        (v2MovingDirection + v2MovementVector));

            //    lOfSnakeSegments.Add(oSnakeSegment);
            //}

        }





        public void UpdateMovement(KeyboardState currentKeyboardState, GameTime theGameTime)
        {


            if (iReferenceTime + iCounter <= theGameTime.TotalGameTime.TotalSeconds)
            {
                iCounter = 1;
                iReferenceTime = (int)theGameTime.TotalGameTime.TotalSeconds;

                //LEFT
                if (mMovingState == MovingState.MovingLeft)
                {
                    v2MovingDirection += new Vector2(-40, 0);
                }


                //RIGHT
                if (mMovingState == MovingState.MovingRight)
                {
                    v2MovingDirection += new Vector2(40, 0);
                }


                //UP
                if (mMovingState == MovingState.MovingUp)
                {
                    v2MovingDirection += new Vector2(0, -40);
                }


                //DOWN
                if (mMovingState == MovingState.MovingDown)
                {
                    v2MovingDirection += new Vector2(0, 40);
                }


                lOfTrailingVectors.Add(v2MovingDirection);


            }




            ////LEFT
            //if (mMovingState == MovingState.MovingLeft)
            //{
            //    v2MovingDirection += new Vector2((int)(-160 * theGameTime.ElapsedGameTime.TotalSeconds), 0);
            //}


            ////RIGHT
            //if (mMovingState == MovingState.MovingRight)
            //{
            //    v2MovingDirection += new Vector2((int)(160 * theGameTime.ElapsedGameTime.TotalSeconds), 0);
            //}


            ////UP
            //if (mMovingState == MovingState.MovingUp)
            //{
            //    v2MovingDirection += new Vector2(0, (int)(-160 * theGameTime.ElapsedGameTime.TotalSeconds));
            //}


            ////DOWN
            //if (mMovingState == MovingState.MovingDown)
            //{
            //    v2MovingDirection += new Vector2(0, (int)(160 * theGameTime.ElapsedGameTime.TotalSeconds));
            //}

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

            for (int i = 0; i < lOfSnakeSegments.Count; i++)
            {
                lOfSnakeSegments[i].Draw(theSpriteBatch);
            }



            base.Draw(theSpriteBatch);
        }









    }
}
