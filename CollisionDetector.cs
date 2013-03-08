using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//gamerservices for Rectangles
using Microsoft.Xna.Framework.GamerServices;





namespace Snake
{
    class CollisionDetector
    {

        //Vector2 v2CurrentSnakePosition;
        Rectangle rSnakeSource;
        Rectangle rScreenSource;
        public bool bScreenCollision = false;

        Game1.GameState updatedGameState;




        //TO-DO
        //create types of collisions
        //  -food
        //  -powerup


        public void ScreenSize(Rectangle rscreenSource)
        {
            rScreenSource = rscreenSource;
        }

        public void SetGameState(Game1.GameState initialGameState)
        {

            updatedGameState = initialGameState;

        }





        public Game1.GameState Update(Game1.GameState gameState, Rectangle rsnakeSource)
        {
            rSnakeSource = rsnakeSource;

            IsScreenCollision(gameState, rsnakeSource);


            return updatedGameState;

        }



        public void IsScreenCollision(Game1.GameState gameState, Rectangle rsnakeSource)
        {
            //game over is you go over the screen's edge.
            //if (rsnakeSource.Intersects  (new Rectangle(0, 0, rScreenSource.Left, rScreenSource.Height))
            //    ||rsnakeSource.Intersects(new Rectangle(rScreenSource.Right, 0, rScreenSource.Right, rScreenSource.Height))
            //    ||rsnakeSource.Intersects(new Rectangle(0, 0, rScreenSource.Width, rScreenSource.Top))
            //    ||rsnakeSource.Intersects(new Rectangle(0, rScreenSource.Bottom, rScreenSource.Width, rScreenSource.Bottom))
            //    )
            //{    
            if(    rsnakeSource.Left < rScreenSource.Left
                || rsnakeSource.Right > rScreenSource.Right
                || rsnakeSource.Top < rScreenSource.Top
                || rsnakeSource.Bottom > rScreenSource.Bottom)
            {
                updatedGameState = Game1.GameState.EndGame;

            }


        }



        //we need to keep the trailingvectorlist inside 
        //    the IF statements, otherwise coordinates get added
        //        every update.
        public Vector2 IsScreenCollision(Vector2 v2currentsnakeposition, Rectangle rsnakeSource, List<Vector2> lofTrailingVectors)
        {
            Vector2 v2JumpTo = v2currentsnakeposition;

            if(rsnakeSource.Left < rScreenSource.Left)
            {
                v2JumpTo = new Vector2(rScreenSource.Right - rsnakeSource.Width, v2JumpTo.Y);
                lofTrailingVectors.Add(v2JumpTo);
            }
            else if(rsnakeSource.Right > rScreenSource.Right)
            {
                v2JumpTo = new Vector2(rScreenSource.Left, v2JumpTo.Y);
                lofTrailingVectors.Add(v2JumpTo);
            }
            else if(rsnakeSource.Top < rScreenSource.Top)
            {
                v2JumpTo = new Vector2(v2JumpTo.X, rScreenSource.Bottom - rsnakeSource.Height);
                lofTrailingVectors.Add(v2JumpTo);
            }
            else if(rsnakeSource.Bottom > rScreenSource.Bottom)
            {
                v2JumpTo = new Vector2(v2JumpTo.X, rScreenSource.Top);
                lofTrailingVectors.Add(v2JumpTo);
            }


            return v2JumpTo;
        }






    //
    }
//
}
