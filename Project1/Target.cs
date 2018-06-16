using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Project1
{
    public class Target
    {
            float targetSpeed;
            const int BEGIN_X = 550;
            const int BEGIN_Y = 5;

            Sprite aSprite;
            Texture aTexture;
            public Target(float x, float y)
            {
                Texture aTexture = new Texture (@"arrowDef.png");
            aSprite.Texture = (aTexture);
        // aSprite.setScale(Vector2f(0.5, 0.5));
             aSprite.Position = new Vector2f(x, y);
    }

        public void resetPosition()
        {
            Random random = new Random();
            int rnd = random.Next(200, 550);
            aSprite.Position = new Vector2f(((float)rnd % (float)350) + 200, getY());
        }

        public int getX()
        {
            return BEGIN_X;
        }

        public int getY()
        {
            return BEGIN_Y;
        }

        public void setSpeed(float speed)
        {
            targetSpeed = speed;
        }

        public Sprite getSprite()
        {
            return aSprite;
        }

        public Texture getTexture()
        {
            return aTexture;
        }

        public void objMove(int move)
        {

            aSprite.Position += new Vector2f(0, move);

        }

        public Vector2f objPos()
        {

            return aSprite.Position;

        }
    }
}

