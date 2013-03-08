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



        //doubles as v2CurrentPosition
        public Vector2 v2MovingDirection;
    


        public Rectangle rSpriteSize;
        public Rectangle rSpriteSource;
        public float fSpriteScale;


        public float fSpriteScaleSizeSourceGetSet
        {
            get { return fSpriteScale; }
            set{
                fSpriteScale  = value;
                rSpriteSize   = new Rectangle(0, 0, (int)(tSprite.Width * fSpriteScale), (int)(tSprite.Height * fSpriteScale));
                rSpriteSource = rSpriteSize;
            }


        }








        public virtual void LoadContent(ContentManager theContentManager, string sSpriteFileName, float fscale)
        {

            tSprite = theContentManager.Load<Texture2D>(sSpriteFileName);
            v2MovingDirection = new Vector2(360, 280);
            fSpriteScaleSizeSourceGetSet = fscale;

        }




        public virtual void Update(GameTime theGameTime)
        {

            rSpriteSource = new Rectangle((int)v2MovingDirection.X, (int)v2MovingDirection.Y, rSpriteSize.Width, rSpriteSize.Height);

        }



        public virtual void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(tSprite, v2MovingDirection, rSpriteSource, Color.White, 0f, Vector2.Zero, fSpriteScale, SpriteEffects.None, 1f);

        }




















    }
}
