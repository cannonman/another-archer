using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Project1
{
    public class Bow
    {
        float bowAngle;
        Sprite bSprite = new Sprite();
        Texture bTexture;
        public static float angle = 0;

        public Bow(int i, int i1)
        {

        }
        
        public Sprite getSprite()
        {
            return bSprite;
        }

        void changeAngleUp()
        {
            bSprite.Rotation -= ((float)-2.5);
            angle -= (float)2.5;
        }

        void changeAngleDown()
        {
            bSprite.Rotation += ((float)2.5);
            angle += (float)2.5;
        }

        public void setAngle(float angle)
        {
            bSprite.Rotation = (angle);
        }

        public void reset()
        {
            bSprite.Rotation = (0);
        }

        public static float getAngle()
        {
            return angle;
        }
    }
}
