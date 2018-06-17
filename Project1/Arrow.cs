using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


    public class Arrow
    {

        const int BEGIN_X = 84;
        const int BEGIN_Y = 340;

        static int getBeginX()
        {
        return BEGIN_X;
        }

    static int getBeginY()
        {
        return BEGIN_Y;
        }

    float angle = 0;

    RectangleShape arrow = new RectangleShape();
        private bool released = false;
        Sprite aSprite = new Sprite()
        {
            Position = new Vector2f(getBeginX(), getBeginY()),
            Texture = new Texture(@"arrowDef.png")
    };
     
        float beginX, beginY;

        Vector2f currVelo;
        float maxSpeed;
       
        public Arrow (float x, float y) //= Arrow(0.0;0.0); maxSpeed(10.0)
    {
        angle = 0;
    }


    public void release()
    {
    released = true;
}

    public Sprite getSprite()
    {
        return aSprite;
    }

    void changeAngleUp()
    {
        Project1.Bow.angle -= (float)2.5;
    }

    void changeAngleDown()
    {
        angle += (float)2.5;
    }

    public void setAngle(float angle)
    {
        aSprite.Rotation = (angle);
    }
    public void resetPosition()
    {
        aSprite.Position = new Vector2f(getBeginX(), getBeginY());
        released = false;
    }

    public bool ifReleased()
    {
        return released;
    }

  
}

