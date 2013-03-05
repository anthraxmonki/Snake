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
            //if (rSnakeSource.Intersects(rScreenSource) == true)
            //{
            //    gameState = Game1.GameState.EndGame;
            //}



            if (rsnakeSource.Intersects  (new Rectangle(0, 0, rScreenSource.Left, rScreenSource.Height))
                ||rsnakeSource.Intersects(new Rectangle(rScreenSource.Right, 0, rScreenSource.Right, rScreenSource.Height))
                ||rsnakeSource.Intersects(new Rectangle(0, 0, rScreenSource.Width, rScreenSource.Top))
                ||rsnakeSource.Intersects(new Rectangle(0, rScreenSource.Bottom, rScreenSource.Width, rScreenSource.Bottom))
                )
            {       
                updatedGameState = Game1.GameState.EndGame;

            }



        }





    //
    }
//
}
