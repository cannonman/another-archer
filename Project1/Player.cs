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
    public class Player
    {

        const int startX = -50;
        const int startY = 200;
        Vector2f pozycja;
        RectangleShape ksztalt;
        Sprite pSprite;
        Texture pTexture = new Texture("@pirate.png");
        Text tekst;

       public Player(float startX, float startY)
        {
        pSprite.Texture = (pTexture);

        pSprite.Position = new Vector2f(startX, startY);

        pozycja = new Vector2f(startX, startY);
    }

    Sprite getSpirte()
    {
        return pSprite;
    }
}
}
