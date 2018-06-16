using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Project1
{
    public class Game
    {
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

        int a = 0;
        int score;
        float angle;
        int diff;
        int lives;

        Event event1 = new Event();

        public RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Archer the Game");


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


            


            while (window.WaitAndDispatchEvents() ) //wait for event
            {

                vector.y = -ARROW_SPEED * (-sin((float)PI * (angle / 180)));
                vector.x = ARROW_SPEED * cos((float)PI * (angle / 180));



                if (event1.type == Event::Closed || Event::KeyPressed && event.key.code == Keyboard.Escape)
                    state = GameState.END;
                //game escape

                if (Event.KeyPressed && event1.key.code == Keyboard::Up)
                {
                    if (angle - 1.5 >= MAX_ANGLE)
                    {
                        angle -= 1.5;
                        luk.setAngle(angle);
                        if (!strzala.ifReleased())
                        {

                            strzala.setAngle(angle); //lift bow  and arrow up
                        

                    
                

                if (Event::KeyPressed && event1.key.code == Keyboard::Down)
                {
                    if (angle + 1.5 <= MIN_ANGLE)
                    {
                        angle += 1.5;
                        luk.setAngle(angle);

                        if (!strzala.ifReleased())
                        {
                            strzala.setAngle(angle); //lift bow and arrow down

                        
                    
                

                if (Event.KeyPressed && event1.key.code == Keyboard::Space)
                {

                    strzala.release();



                    if (strzala.aSprite.getPosition().x < 0 || strzala.aSprite.getPosition().x > window.getSize().x)
                    {
                        strzala = null;
                        strzala = new Arrow(84, 340);
                        strzala.resetPosition();
                        strzala.setAngle(angle);
                        window.draw(strzala.getSprite());
                    
                    if (strzala.aSprite.getPosition().y < 0 || strzala.aSprite.getPosition().y > window.getSize().y)
                    {
                        strzala = null;
                        strzala = new Arrow(84, 340);
                        strzala.resetPosition();
                        strzala.setAngle(angle);
                        window.draw(strzala.getSprite());
                    

                

            

            if (Collision::PixelPerfectTest(strzala.getSprite(), obiekt.getSprite()))
            {
                score++;

                strzala.resetPosition();
                obiekt.resetPosition();

                if (score % 3 == 0 && time > 1)
                    time--;


            


            window.clear();
            window.draw(backgroundSprite);
            window.draw(gracz.getSpirte());
            window.draw(luk.getSprite());
            window.draw(strzala.getSprite());

            obiekt.objMove(3);
            //      if (a==0)
            //    {
            if (obiekt.aSprite.getPosition().y < 600)
            {

                obiekt.objMove(5 - time);

                a++;

            
            if (obiekt.aSprite.getPosition().y >= 600)
            {
                obiekt.resetPosition();
                lives--;
                if (lives == 0)
                    state = Game.GameState.GAME_OVER;
            

            
            else if (czas(clock()) % time != 0) { a = 0; 

            if (strzala.ifReleased())
            {

                strzala.aSprite.move(vector);
            


            window.draw(strzala.getSprite());
            window.draw(obiekt.getSprite());
            window.draw(title);
            window.draw(punkty);
            window.display();

            elapsed = mainClock.getElapsedTime(); //get time measured
            sleep((milliseconds(1000 / FRAMERATE) - mainClock.getElapsedTime()));

            if (lives == 0)
                state = GameState.GAME_OVER;

        

        

    void gameOver()
        {
            Texture backgroundTexture =new Texture (@"jungle.png");
            backgroundSprite.Texture = (backgroundTexture); //load texture
            Text title;
            Text title2;
            Text powrot;
            title.setStyle(Bold);
            title.setPosition(300, 50);
            title.setString("Koniec Gry");
            title.setFont((ConstFont)font);
            title.setCharacterSize(40);

            String points;
            stringstream ss;
            ss << score;
            points += ss.str();
            points += " punktow";

            title2.setStyle(Text::Bold);
            title2.setPosition(300, 190);
            title2.setString(points);
            title2.setFont(font);
            title2.setCharacterSize(40);

            powrot.setStyle(Text::Bold);
            powrot.setPosition(325, 400);
            powrot.setString("Powrot");
            powrot.setFont(font);
            powrot.setCharacterSize(40);

            while (state == GameState.GAME_OVER)
            {

                Vector2f mouse(Mouse::getPosition(window));

                
                while (window.pollEvent(event1))
                {
                    if (event.type == Event.Closed || Event::KeyPressed && event.key.code == Keyboard::Escape)
                    state = END;

                else if (powrot.getGlobalBounds().contains(mouse) && event.type == Event::MouseButtonReleased
                        && event.key.code == Mouse::Left)
                    state = MENU;


                }


                if (powrot.getGlobalBounds().contains(mouse))
                    powrot.setColor(Red);
                else powrot.setColor(White);

                window.clear();
                window.draw(title);
                window.draw(title2);
                window.draw(powrot);
                window.setVisible(true);

                window.display();
            
        

        void options()
          {
    
            Text title1 = new Text("Archer The Game", font, 80);
            title1.Style = (Text.Styles.Bold);
            Text title2 = new Text("Options", font,60);
            title1.Position = (800 / 2 - title1.getGlobalBounds().width / 2, 20);
            title2.Position = (800 / 2 - title2.getGlobalBounds().width / 2, 120);


            Text poziom;
            Text powrot;

            String str1[] = [ "Easy", "Normal", "Hard" ];

            poziom.setFont((ConstFont)font);
            poziom.setCharacterSize(65);

            poziom.setString(str1[0]);
            poziom.setPosition(800 / 2 - poziom.getGlobalBounds().width / 2, 250);

            powrot.setFont((ConstFont)font);
            powrot.setCharacterSize(65);

            powrot.String = new Text("Back");
            powrot.Position = (1280 / 2 - poziom.getGlobalBounds().width / 2, 250 + 2 * 120);

            while (Game.state == Game.GameState.OPTIONS)
            {
                Vector2f mouse = new Vector2f(Mouse.GetPosition);

                Event event;

                while (window.pollEvent(event))
                {
                    if (event.type == Event::Closed || Event::KeyPressed && event.key.code == Keyboard::Escape)
                    Game.state = Game.GameState.END;

                else if (powrot.getGlobalBounds().contains(mouse) && event.type == Event::MouseButtonReleased
                        && event.key.code == Mouse::Left)
                    state = MENU;

                }

                if (powrot.getGlobalBounds().contains(mouse))
                    powrot.Color = (Color.Red);
                else powrot.Color = (Color.White);

                poziom.String = new String(str1[diff]);

                if (poziom.GetGlobalBounds().Contains(mouse))
                    poziom.setColor(Color::Red);
                else poziom.setColor(Color::White);

                if (poziom.getGlobalBounds().contains(mouse) && event.type == Event::MouseButtonReleased && event.key.code == Mouse::Button::Left)
            {
                    if (diff == 2) diff = 0;
                    else diff++;
                    poziom.setString(str1[diff]);
                    poziom.setPosition(800 / 2 - poziom.getGlobalBounds().width / 2, 250);
                }

                window.clear();

                window.draw(title1);
                window.draw(title2);
                window.draw(poziom);
                window.draw(powrot);

                window.display();


            



        

        public void Menu()
        { 



            Text title = new Text("Archer The Game",font,80);
            title.setStyle(Bold);

            // cout<<diff<<endl;

            title.setPosition(800 / 2 - title.getGlobalBounds().width / 2, 20);

            const int ile = 3;

            Text tekst[ile];

            String str[] = { "Play", "Options", "Exit" };

            for (int i = 0; i < ile; i++)
            {


                tekst[i].setFont(font);
                tekst[i].setCharacterSize(65);

                tekst[i].setString(str[i]);
                tekst[i].setPosition(1280 / 2 - tekst[i].getGlobalBounds().width / 2, 250 + i * 120);

            }

            while (state == MENU)
            {

                Event event;

                Vector2f mouse(Mouse::getPosition(window));

                while (window.pollEvent(event))
                {
                    if (event.type == Event::Closed || Event::KeyPressed && event.key.code == Keyboard::Escape)
                    state = END;

                else if (tekst[2].getGlobalBounds().contains(mouse) && event.type == Event::MouseButtonReleased
                        && event.key.code == Mouse::Left)
                    state = END;
                    if (tekst[0].getGlobalBounds().contains(mouse) && event.type == Event::MouseButtonReleased && event.key.code == Mouse::Left)
                    state = GAME;
                    if (tekst[1].getGlobalBounds().contains(mouse) && event.type == Event::MouseButtonReleased && event.key.code == Mouse::Left)
                    state = OPTIONS;

                }
                for (int i = 0; i < ile; i++)
                    if (tekst[i].getGlobalBounds().contains(mouse))
                        tekst[i].setColor(Color::Red);
                    else tekst[i].setColor(Color::White);

                window.clear();

                window.draw(title);
                for (int i = 0; i < ile; i++)
                    window.draw(tekst[i]);
                window.display();
            

        

         int czas (clock_t t)
         {
            return static_cast<int>(t) / CLOCKS_PER_SEC;
         }

    }
}
