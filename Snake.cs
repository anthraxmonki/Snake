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
        int iSpeed = 0;

        Vector2 v2Left  = new Vector2(-40,   0);
        Vector2 v2Right = new Vector2( 40,   0);
        Vector2 v2Up    = new Vector2(  0, -40);
        Vector2 v2Down  = new Vector2(  0,  40);



        public List<SnakeSegments> lOfSnakeSegments = new List<SnakeSegments>();
        ContentManager theSnakeSegmentContentManager;

        List<MovingState> lOfMovingStates = new List<MovingState>();
        public List<Vector2> lOfTrailingVectors = new List<Vector2>();

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







        public override void Update(GameTime theGameTime)
        {
            KeyboardState ksCurrentState = Keyboard.GetState();

            if (bFoodPelletCollision == true)
            {
                GrowSnake();
                bFoodPelletCollision = false;
                iSpeed += 25;
            }


            CheckInput(ksCurrentState);
            UpdateMovement(ksCurrentState, theGameTime);
            UpdateTrail(theGameTime);
            CheckTrailCollision();

            base.Update(theGameTime);
        }


        //we use lOfsnakeSegments.Count - 2
        //    because the snake's head updates
        //    before the tail-end moves,
        //    resulting in the eating of a tail
        //    that will be moved out of the way once the tail
        //    is updated.
        public void CheckTrailCollision()
        {
            for (int i = lOfSnakeSegments.Count - 2; i >= 0; i--)
            {
                Vector2 v2TailPositions = lOfSnakeSegments[i].v2MovingDirection;
                if (v2MovingDirection == v2TailPositions)
                {
                    TrailCollisionTrue();
                }
            }
        }


        public void TrailCollisionTrue()
        {
            Game1.mCurrentGameState = Game1.GameState.EndGame;
        }


        //takes the furthest vector back
        //    that is relevant to the trail
        //Then iterate backwards through each tail segment sprite
        //    and assign each a Vector2 coordinate.
        public void UpdateTrail(GameTime theGameTime)
        {
            int j = (lOfTrailingVectors.Count - lOfSnakeSegments.Count) - 1;
            for (int i = lOfSnakeSegments.Count - 1; i >= 0; i--)
            {
                lOfSnakeSegments[i].UpdateSnakeSegmentTrail(theGameTime, lOfTrailingVectors[j]);
                j++;
            }
        }





        //Instantiat a new snakesegment sprite
        //    add it to a list which si the snakes tail
        public void GrowSnake()
        {
            SnakeSegments oSnakeSegment = new SnakeSegments();
            oSnakeSegment.LoadContent(theSnakeSegmentContentManager, "SnakeSegment", 1.0f);

            lOfSnakeSegments.Add(oSnakeSegment);

        }




        //Update movement each second
        //Declare timer variables,
        //     then move the direction pressed -- use TotalTime vs ElapseTime
        //
        public void UpdateMovement(KeyboardState currentKeyboardState, GameTime theGameTime)
        {

            if (iReferenceTime + iCounter - iSpeed <= theGameTime.TotalGameTime.TotalMilliseconds)
            {
                iCounter = 500;
                iReferenceTime = (int)theGameTime.TotalGameTime.TotalMilliseconds;

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

        }





        public void CheckInput(KeyboardState ksCurrentKeyboardState)
        {

            //LEFTLEFTLEFTLEFTLEFT
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
