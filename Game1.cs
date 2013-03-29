using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace Snake
{


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rectangle rScreenSize;

        SpriteFont fKootenay;


        Texture2D tGameStateEnd;




        Snake oSnake;
        //SnakeSegments oSnakeSegments;
        Food  oFood1;
        Food  oFood2;
        Food  oFood3;

        CollisionDetector oCollisionDetector;









        public static GameState mCurrentGameState;
        public enum GameState
        {
            ContinueToRunGame,
            EndGame
        }









        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth  = 800;
            this.graphics.PreferredBackBufferHeight = 600;

            rScreenSize = new Rectangle(0, 0, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);


        }





        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            //IsMouseVisible = true;

            mCurrentGameState = GameState.ContinueToRunGame;

            oCollisionDetector = new CollisionDetector();
            oCollisionDetector.ScreenSize(rScreenSize);
            oCollisionDetector.SetGameState(mCurrentGameState);





            oSnake = new Snake();
            oFood1 = new Food();
            oFood2 = new Food();
            oFood3 = new Food();

            base.Initialize();
        }



        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            fKootenay = Content.Load<SpriteFont>("fKootenay");

            tGameStateEnd = Content.Load<Texture2D>("EndGameScreen");


 
            oSnake.LoadContent(this.Content, "SnakeSegment", 1.0f);
            //SnakeFood is 20x20
            oFood1.LoadContent(this.Content, "SnakeFood", 1.40f, rScreenSize.Width, rScreenSize.Height);
            oFood2.LoadContent(this.Content, "SnakeFood", 1.20f, rScreenSize.Width, rScreenSize.Height);
            oFood3.LoadContent(this.Content, "SnakeFood", 1.0f,  rScreenSize.Width, rScreenSize.Height);

        }




        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }













        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();



            oSnake.Update(gameTime);
            oFood1.Update(gameTime, oSnake.rSpriteSource);
            oFood2.Update(gameTime, oSnake.rSpriteSource);
            oFood3.Update(gameTime, oSnake.rSpriteSource);


            //Uncomment to EndGame when Snake crosses the screen boundary.
            //mCurrentGameState = oCollisionDetector.Update(mCurrentGameState, oSnake.rSpriteSource);
            oSnake.v2MovingDirection = oCollisionDetector.IsScreenCollision(oSnake.v2MovingDirection, 
                oSnake.rSpriteSource,
                oSnake.lOfTrailingVectors);

            base.Update(gameTime);
        }








        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);

            spriteBatch.Begin();
            if (IsMouseVisible == true)
            {
                spriteBatch.DrawString(fKootenay, "Mouse X: " + Mouse.GetState().X + "Mouse Y: " + Mouse.GetState().Y, new Vector2(10, 10), Color.Red);

            }





            if (mCurrentGameState == GameState.ContinueToRunGame)
            {


                oSnake.Draw(spriteBatch);
                oFood1.Draw(spriteBatch);
                oFood2.Draw(spriteBatch);
                oFood3.Draw(spriteBatch);
                spriteBatch.DrawString(fKootenay, "Snake Food Eaten: " + Food.iFoodEaten, new Vector2(10, 10), Color.Red);
                //spriteBatch.DrawString(fKootenay, "Main  Snake Coordinates: X" + oSnake.v2MovingDirection.X + "  Y" + oSnake.v2MovingDirection.Y, new Vector2(10, 50), Color.Red); 

            }



 






            if (mCurrentGameState == GameState.EndGame)
            {
                spriteBatch.Draw(tGameStateEnd, Vector2.Zero, Color.Brown);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }







    }
}
