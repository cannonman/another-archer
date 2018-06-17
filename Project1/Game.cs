#region Biblioteki
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
#endregion

namespace Project1
{
    public class Game
    {
        #region Deklaracje
        const int FRAMERATE = 30;

        public enum GameState { MENU, OPTIONS, GAME, GAME_OVER, END, TARGETHIT};
        GameState state;

        Font font = new Font(@"arial.ttf");

        Sprite backgroundSprite = new Sprite();

        Texture backgroundTexture = new Texture(@"jungle.png");
        double x;
        bool kolizja;

        int time;
        Clock mainClock;
        Time elapsed;

        Vector2f mousePos;
        Vector2f playerPos;
        Vector2f aimDir;
        Vector2f aimDirNorm;
        Vector2f vector;

        Player gracz;
        Bow luk;
        Arrow strzala = new Arrow(84, 340);
        Target obiekt = new Target(550, 10);
        const double ARROW_SPEED = 10.0;
        const int MAX_ANGLE = -40;
        const int MIN_ANGLE = 10;
        int a = 0;
        int score;
        float angle;
        int diff;
        int lives;

        Event event1 = new Event();

        public RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Archer the Game");
        #endregion

        Game() { 
            state = GameState.END;

            Player gracz = new Player(-50, 200);

        Bow luk = new Bow(84, 340);

        luk.reset();

        strzala.resetPosition();

        diff = 0;
        time = 5;

        angle = 0;

        state = GameState.MENU;
        }

        void gameStart()
         {

        backgroundTexture = new Texture(@"jungle.png");
        backgroundSprite.Texture = (backgroundTexture); //load texture
        score = 0;
        switch (diff)
        {
            case 0:
                time = 6;
                break;
            case 1:
                time = 5;
                break;
            case 2:
                time = 4;
                break;
                //default: time=5;
        }

        lives = 5;
        while (state == GameState.GAME)
        {


            mainClock.Restart(); //start time measure
            Text title = new Text("Archer the Game",font,30);
            String points;
            points = "Punkty: ";
            points += score;
            points += " Zycia: ";
            points += lives;
            Text punkty = new Text(points , font,15);
            title.Style = (Text.Styles.Bold);
            title.Position = new Vector2f(800 / 2 - title.GetGlobalBounds().Width / 2, 20); //setting window options
            punkty.Position = new Vector2f (10, 10);


            


            while (window.IsOpen) //wait for event
            {

                vector.Y = -(double)ARROW_SPEED * (Math.Sin((double)Math.PI * (angle / 180)));
                vector.X = (double)ARROW_SPEED * Math.Cos((double)Math.PI * (angle / 180));



                if (event1.Type == EventType.Closed || Keyboard.IsKeyPressed && (event1.Key.Code == Keyboard.Key.Escape))
                    state = GameState.END;
                //game escape

                if (Keyboard.IsKeyPressed && event1.Key.Code == Keyboard.Key.Up)
                {
                    if (angle - 1.5 >= MAX_ANGLE)
                    {
                        angle -= 1.5;
                        luk.setAngle(angle);
                        if (!strzala.ifReleased())
                        {

                            strzala.setAngle(angle); //lift bow  and arrow up
                        }
                    }}
                    
                

                if (Keyboard.IsKeyPressed && event1.Key.Code == Keyboard.Key.Down)
                {
                    if (angle + 1.5 <= MIN_ANGLE)
                    {
                        angle += (float)1.5;
                        luk.setAngle(angle);

                        if (!strzala.ifReleased())
                        {
                            strzala.setAngle(angle); //lift bow and arrow down
                        }   
                    }
                }        
                    
                

                if (Keyboard.IsKeyPressed && event1.Key.Code == Keyboard.Key.Space)
                {

                    strzala.release();



                    if (strzala.getSprite().Position.X < 0 || strzala.getSprite().Position.X > window.Size.X)
                    {
                        strzala = null;
                        strzala = new Arrow(84, 340);
                        strzala.resetPosition();
                        strzala.setAngle(angle);
                        window.Draw(strzala.getSprite());
                        }
                    if (strzala.getSprite().Position.Y < 0 || strzala.getSprite().Position.Y > window.Size.Y)
                    {
                        strzala = null;
                        strzala = new Arrow(84, 340);
                        strzala.resetPosition();
                        strzala.setAngle(angle);
                        window.Draw(strzala.getSprite());
                    }

                }
            }
            

            if (Collision::PixelPerfectTest(strzala.getSprite(), obiekt.getSprite()))
            {
                score++;

                strzala.resetPosition();
                obiekt.resetPosition();

                if (score % 3 == 0 && time > 1)
                    time--;

                }
            


            window.Clear();
            window.Draw(backgroundSprite);
            window.Draw(gracz.getSpirte());
            window.Draw(luk.getSprite());
            window.Draw(strzala.getSprite());

            obiekt.objMove(3);
            //      if (a==0)
            //    {
            if (obiekt.getSprite().Position.Y < 600)
            {

                obiekt.objMove(5 - time);

                a++;
                }
            
            if (obiekt.getSprite().Position.Y >= 600)
            {
                obiekt.resetPosition();
                lives--;
                if (lives == 0)
                    state = Game.GameState.GAME_OVER;
            
                }
            
     //       else if (czas() % time != 0) { a = 0; }

            if (strzala.ifReleased())
            {

                strzala.getSprite().Position = (vector + strzala.getSprite().Position);
            
               }

            window.Draw(strzala.getSprite());
            window.Draw(obiekt.getSprite());
            window.Draw(title);
            window.Draw(punkty);
            window.Display();

            elapsed = mainClock.ElapsedTime; //get time measured
            Sleep((Time.FromMilliseconds(1000 / FRAMERATE) - mainClock.ElapsedTime));

            if (lives == 0)
                state = GameState.GAME_OVER;

        }}

        void gameOver()
        {
            Texture backgroundTexture =new Texture (@"jungle.png");
            backgroundSprite.Texture = (backgroundTexture); //load texture
            Text title = new Text();
            Text title2 = new Text();
            Text powrot = new Text();
            title.Style = (Text.Styles.Bold);
            title.Position = new Vector2f(300, 50);
            title.DisplayedString = (@"Koniec Gry");
            title.Font = (font);
            title.CharacterSize = (40);


            title2.Style = (Text.Styles.Bold);
            title2.Position = new Vector2f(300, 190);
            title2.DisplayedString = new String(score + (string)" punktow");
            title2.Font = (font);
            title2.CharacterSize = (40);

            powrot.Style = (Text.Styles.Bold);
            powrot.Position = new Vector2f(325.0, 400.0);
            powrot.String = new String ("Powrot");
            powrot.Font = (font);
            powrot.CharacterSize = (40);

            while (state == GameState.GAME_OVER)
            {
             //TUTAJ MYSZKA NIE DZIAŁA
             //   Vector2f mouse();

                
                while (window.IsOpen)
                                                                                    {
                    if (event1.Type == EventType.Closed || Keyboard.IsKeyPressed && event1.Key == Keyboard.Key.Escape)
                    state = GameState.END;

                else if (powrot.GetGlobalBounds().Contains(mouse) && event1.Type == Mouse.IsButtonPressed
                        && event1.Key.Code == Mouse.Button.Left)
                    state = GameState.MENU;


                }


                if (powrot.GetGlobalBounds().Contains(mouse))
                    powrot.Color = (Color.Red);
                else powrot.Color = (Color.White);

                window.Clear();
                window.Draw(title);
                window.Draw(title2);
                window.Draw(powrot);
                window.SetVisible(true);

                window.Display();
            }
        }

        void options()
          {
    
            Text title1 = new Text("Archer The Game", font, 80);
            title1.Style = (Text.Styles.Bold);
            Text title2 = new Text("Options", font,60);
            title1.Position = new Vector2f ((800 / 2) - title1.GetGlobalBounds().Width / 2, 20);
            title2.Position = new Vector2f ((800 / 2) - title2.GetGlobalBounds().Width / 2, 120);


            Text poziom = new Text();
            Text powrot = new Text();

            powrot.DisplayedString = ("Back");

            String[] str1 = { "Easy", "Normal", "Hard" };

            poziom.Font = (font);
            poziom.CharacterSize = (65);

            poziom.DisplayedString = (str1[0]);
            poziom.Position = new Vector2f(800 / 2 - poziom.GetGlobalBounds().Width / 2, 250);

            powrot.Font = (font);
            powrot.CharacterSize = (65);

            powrot.Position = new Vector2f(1280 / 2 - poziom.GetGlobalBounds().Width / 2, 250 + 2 * 120);

            while (Game.state == GameState.OPTIONS)
            {
                Vector2f mouse = new Vector2f(Mouse.GetPosition.x, Mouse.GetPosition.y);

                Event event1;

                while (window.IsOpen )
                {
                    if (event1.Type == window.Closed || Keyboard.IsKeyPressed && event1.Key.Code == Keyboard.Key.Escape)
                    Game.state = Game.GameState.END;

                else if (powrot.GetGlobalBounds().Contains(mouse) && event1.Type == Mouse.IsButtonPressed
                        && event1.Key.Code == Mouse.Button.Left)
                    state = GameState.MENU;

                }

                if (powrot.GetGlobalBounds().Contains(mouse))
                    powrot.Color = (Color.Red);
                else powrot.Color = (Color.White);

                poziom.DisplayedString = (str1[diff]);

                if (poziom.GetGlobalBounds().Contains(mouse))
                    poziom.Color = (Color.Red);
                else poziom.Color = (Color.White);

                if (poziom.GetGlobalBounds().Contains(mouse) && event1.Type == Mouse.IsButtonPressed && event1.Key.Code == Mouse.Button.Left)
            {
                    if (diff == 2) diff = 0;
                    else diff++;
                    poziom.SetString(str1[diff]);
                    poziom.Position = (800 / 2 - poziom.GetGlobalBounds().Width / 2, 250);
                }

                window.Clear();

                window.Draw(title1);
                window.Draw(title2);
                window.Draw(poziom);
                window.Draw(powrot);

                window.Display();

}}
            
        void Menu()
        { 



            Text title = new Text("Archer The Game",font,80);
            title.SetStyle(Text.Styles.Bold);

            // cout<<diff<<endl;

            title.SetPosition(800 / 2 - title.GetGlobalBounds().width / 2, 20);

            const int ile = 3;

            Text[] tekst;
            tekst = new Text[ile];
                                              



            String[] str = { "Play", "Options", "Exit" };

            for (int i = 0; i < ile; i++)
            {


                tekst[i].SetFont(font);
                tekst[i].SetCharacterSize(65);

                tekst[i].SetString(str[i]);
                tekst[i].SetPosition(1280 / 2 - tekst[i].GetGlobalBounds().Width / 2, 250 + i * 120);

            }

            while (state == MENU)
            {

                Event event1;

                Vector2f mouse(Mouse.GetPosition window);

                while (window.IsOpen)
                                                                                                    {
                    if (event1.Type == window.Closed || Keyboard.IsKeyPressed && event1.Key== Keyboard.Key.Escape)
                    state = GameState.END;

                else if (tekst[2].GetGlobalBounds().Contains(mouse) && event1.Type == Mouse.IsButtonPressed
                        && event1.Key.Code == Mouse.Button.Left)
                    state = GameState.END;
                    if (tekst[0].GetGlobalBounds().contains(mouse) && event1.Type == Mouse.IsButtonPressed && event1.Key.Code == Mouse.Button.Left)
                    state = GameState.GAME;
                    if (tekst[1].GetGlobalBounds().contains(mouse) && event1.Type == Mouse.IsButtonPressed && event1.Key.Code == Mouse.Button.Left)
                    state = GameState.OPTIONS;

                }
                for (int i = 0; i < ile; i++)
                    if (tekst[i].GetGlobalBounds().Contains(mouse))
                        tekst[i].SetColor(Color.Red);
                    else tekst[i].SetColor(Color.White);

                window.Clear();

                window.Draw(title);
                for (int i = 0; i < ile; i++)
                    window.Draw(tekst[i]);
                window.Display();
            

        

         
    }
}

         void runGame()
        {

        while (state != GameState.END)
        {
            switch (state)
            {
                case GameState.MENU:
                    Menu();
                    break;
                case GameState.GAME:
                    gameStart();
                    break;
                case GameState.OPTIONS:
                    options();
                    break;
                case GameState.GAME_OVER:
                    gameOver();
                    break;

            }
        }

         }

         
   

       
}}












