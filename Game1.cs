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



        //Sprite oSnakeSprite;
        Snake oSnake;




        CollisionDetector oCollisionDetector;









        public GameState mCurrentGameState;
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

            IsMouseVisible = true;

            mCurrentGameState = GameState.ContinueToRunGame;

            oCollisionDetector = new CollisionDetector();
            oCollisionDetector.ScreenSize(rScreenSize);
            oCollisionDetector.SetGameState(mCurrentGameState);





            oSnake = new Snake();



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



            //oSnakeSprite.LoadContent(this.Content, "SnakeSegment", 1.0f);
            oSnake.LoadContent(this.Content, "SnakeSegment", 1.0f);




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





            mCurrentGameState = oCollisionDetector.Update(mCurrentGameState, oSnake.rSpriteSource);






            //if (oCollisionDetector.bScreenCollision == true)
            //{
            //    mCurrentGameState = GameState.EndGame;
            //}

            //this passes and returns the Gamestate










            //this code works
            //mCurrentGameState = oCollisionDetector.IsScreenCollision(mCurrentGameState);



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


            }



 






            if (mCurrentGameState == GameState.EndGame)
            {
                spriteBatch.Draw(tGameStateEnd, Vector2.Zero, Color.Brown);
                //spriteBatch.End();
                //return;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }







    }
}
