using System;
using System.Numerics;
using System.Threading;

22
//----- block array -----
// 1 : walls
// 2 : number 1
// 3 : number 2
// 4 : number 3
// 5 : mine
// 6 : enemy x
// 7 : enemy y
// 8 : player 


namespace WallsANDmines3
{
    class Program
    {
        static void gameStarting()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n                 _  _                          _              _                   \n                | || |                        | |            (_)                  \n__      __ __ _ | || | ___    __ _  _ __    __| |  _ __ ___   _  _ __    ___  ___ \n\\ \\ /\\ / // _` || || |/ __|  / _` || '_ \\  / _` | | '_ ` _ \\ | || '_ \\  / _ \\/ __|\n \\ V  V /| (_| || || |\\__ \\ | (_| || | | || (_| | | | | | | || || | | ||  __/\\__ \\\n  \\_/\\_/  \\__,_||_||_||___/  \\__,_||_| |_| \\__,_| |_| |_| |_||_||_| |_| \\___||___/\n                                                                                  \n                                                                                  \n\n");




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress ENTER to start the game");

            Console.WriteLine("Press TAB to How To Play");

            Console.WriteLine("Press C to see credits");

            ConsoleKeyInfo a = Console.ReadKey(true);




            if (a.Key == ConsoleKey.Tab)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME INFORMATION \n\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You are in a labyrinth whose walls are constantly changing.\n" +
                    "There are X and Y enemies following you. You can drop mines to defeat them.\n" +
                    "Enemies spawn every 30 seconds. You must collect numbers while avoiding the enemies.\n" +
                    "Numbers give you energy and score. New numbers are displayed every 2 seconds.");

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HOW TO PLAY  \n\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("This is you -->  P");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("These are our enemies -->  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("X  -  Y");
                Console.ResetColor();
                Console.Write("This is mine -->  ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("+");
                Console.ResetColor();
                Console.Write("These are numbers -->");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" 1 ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" 2 ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" 3 ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("KEYBOARD CONTROLS  \n\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You can move with the arrow keys. You lose energy with every move.\nWhen you run out of energy, you slow down. so be careful");
                Console.WriteLine("You can drop mines with the spacebar. Your mines are limited, use them carefully\n\n");
                Console.WriteLine("Press any key to start the game...");
                Console.ReadKey();
                Console.Clear();

            }
            else if (a.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return;
            }

            else if (a.Key == ConsoleKey.C)
            {
                Console.Clear();
                Console.WriteLine("Çağrı Aydın\nEsma Oruç\nSelda Nur Turgut\nBaşar Babacan");
                Console.ReadKey();
                Console.Clear();
                return;
            }

        }

        static void Difficulty(ref int energy, ref int mine, ref int enemytime, ref int startingx , ref int startingy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please select difficulty level.\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1 - BEGINNER     (300 energy 5 mines)");
            Console.WriteLine("2 - NORMAL       (200 energy 0 mines)");
            Console.WriteLine("3 - HARD         (100 energy 0 mines)");
            Console.WriteLine("4 - CUSTOM MODE  (Make your own rules)");


            ConsoleKeyInfo a = Console.ReadKey(true);


            if (a.Key == ConsoleKey.D1)
            {
                energy = 300;
                mine = 5;
                enemytime = 30; // düşmanların gelme süresi
            }

            if (a.Key == ConsoleKey.D2)
            {
                energy = 200;
                mine = 0;
                enemytime = 20;
            }

            if (a.Key == ConsoleKey.D3)
            {
                energy = 100;
                mine = 0;
                enemytime = 10;
            }

            if (a.Key == ConsoleKey.D4)
            {
                Console.Clear();
                Console.WriteLine("Please enter your energy");
                energy = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter your mine count");
                mine = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many seconds do enemies spawn?");
                enemytime = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("how many X should the game start with?");
                startingx = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("how many Y should the game start with?");
                startingy = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
        }

        static void Walls(int x, int y, int pattern, int[,] block, int[,] patternofwall)
        {
            for (int i = x; i < x + 4; i++) 
            {
                for (int k = y; k < y + 4; k++)
                {
                    if (block[i, k] == 1)
                    {
                        block[i, k] = 0;
                        Console.SetCursorPosition(k, i);
                        Console.Write(" ");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            switch (pattern)
            {
                case 0:

                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 0;
                    break;
                case 1:
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 1;
                    break;
                case 2:
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 2;
                    break;
                case 3:
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 3;
                    break;
                case 4:
                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 4;
                    break;
                case 5:
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 5;
                    break;
                case 6:
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 6;
                    break;
                case 7:
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 7;
                    break;
                case 8:
                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 8;
                    break;
                case 9:
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 9;
                    break;
                case 10:
                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 10;
                    break;
                case 11:
                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 11;
                    break;
                case 12:
                    Console.SetCursorPosition(y, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    block[x, y] = 1; block[x + 1, y] = 1; block[x + 2, y] = 1; block[x + 3, y] = 1;
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 12;
                    break;
                case 13:
                    Console.SetCursorPosition(y, x);
                    Console.Write("████");
                    Console.SetCursorPosition(y + 3, x);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 1);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 2);
                    Console.Write("█");
                    Console.SetCursorPosition(y + 3, x + 3);
                    Console.Write("█");
                    Console.SetCursorPosition(y, x + 3);
                    Console.Write("████");
                    block[x, y] = 1; block[x, y + 1] = 1; block[x, y + 2] = 1; block[x, y + 3] = 1;
                    block[x, y + 3] = 1; block[x + 1, y + 3] = 1; block[x + 2, y + 3] = 1; block[x + 3, y + 3] = 1;
                    block[x + 3, y] = 1; block[x + 3, y + 1] = 1; block[x + 3, y + 2] = 1; block[x + 3, y + 3] = 1;
                    patternofwall[(x - 2) / 5, (y - 2) / 5] = 13;
                    break;
            }
            Console.ResetColor();
        }

        static void Scores(int numberX, int numberY, int prob, int[,] block)
        {
            if (prob < 6)  // %60
            {
                Console.SetCursorPosition(numberX, numberY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1");
                Console.ResetColor();

                block[numberY, numberX] = 2;

            }

            else if (prob >= 6 && prob < 9)  // %30
            {
                Console.SetCursorPosition(numberX, numberY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2");
                Console.ResetColor();

                block[numberY, numberX] = 3;
            }
            else if (prob >= 9)  // %10
            {
                Console.SetCursorPosition(numberX, numberY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("3");
                Console.ResetColor();
                block[numberY, numberX] = 4;

            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int enemytime =30;
            int time = 0;
            int energy = 200;
            int score = 0;
            int mine = 0;     
            int kills = 0;
            int startingx = 2;
            int startingy = 2;


            gameStarting();
            Difficulty(ref energy, ref mine, ref enemytime , ref startingx, ref startingy);
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("█████████████████████████████████████████████████████");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█                                                   █");
            Console.WriteLine("█████████████████████████████████████████████████████");

            Console.ResetColor();
            Random rand = new Random();
            int random_x = rand.Next(0, 53); // player coordinates
            int random_y = rand.Next(0, 23);



            int cursorx = 2, cursory = 1;   // position of cursor
            ConsoleKeyInfo cki;               // required for readkey
            int prevx = cursorx;
            int prevy = cursory;







            int[,] block = new int[23, 53];
            int[,] patternofwall = new int[4, 10];



            for (int i = 0; i < block.GetLength(0); i++) // at first, all elements of block array is 0
            {
                for (int k = 0; k < block.GetLength(1); k++)
                {
                    block[i, k] = 0;
                }
            }
            for (int i = 0; i < block.GetLength(1); i++) // assigning the edges of the playground to the array
            {
                block[0, i] = 1;
                block[22, i] = 1;
            }
            for (int i = 0; i < block.GetLength(0); i++) // assigning the edges of the playground to the array
            {
                block[i, 0] = 1;
                block[i, 52] = 1;
            }





            //generating walls
            for (int i = 2; i < 22; i = i + 5)
            {
                for (int k = 2; k < 52; k = k + 5)
                {
                    Random rnd = new Random();
                    int pattern = rnd.Next(0, 14);
                    Walls(i, k, pattern, block, patternofwall);
                }
            }

            while (block[random_y, random_x] == 1) // reassign random if player spawned in wall place
            {
                random_x = rand.Next(0, 53);
                random_y = rand.Next(0, 23);

            }
            cursorx = random_x;
            cursory = random_y;

            // add 1 2 3   
            for (int i = 0; i < 20; i++)
            {
                int numberX;
                int numberY;
                int prob;

                while (true)
                {
                    Random rnd = new Random();
                    numberX = rnd.Next(1, 53);
                    numberY = rnd.Next(1, 23);
                    prob = rnd.Next(0, 10);
                    if (block[numberY, numberX] != 1) // if there is no wall where the number is
                    {
                        break;
                    }
                }
                Scores(numberX, numberY, prob, block);
            }


            //genereating 2 x for beggining (numbers vary according to difficulty level)
            for (int i = 0; i < startingx; i++)
            {
                Random rnd_x = new Random();
                int x_x = rnd_x.Next(1, 52);
                int x_y = rnd_x.Next(1, 22);
                while (block[x_y, x_x] != 0 | Math.Sqrt(Math.Pow((cursorx - x_x), 2) + Math.Pow((cursory - x_y), 2)) < 10)
                {
                    x_x = rnd_x.Next(1, 52);
                    x_y = rnd_x.Next(1, 22);
                }
                block[x_y, x_x] = 6;
            }
            //generating 2 y for beggining
            for (int i = 0; i < startingy; i++)
            {
                Random rnd_y = new Random();
                int y_x = rnd_y.Next(1, 52);
                int y_y = rnd_y.Next(1, 22);
                while (block[y_y, y_x] != 0 | Math.Sqrt(Math.Pow((cursorx - y_x), 2) + Math.Pow((cursory - y_y), 2)) < 10)
                {
                    y_x = rnd_y.Next(1, 52);
                    y_y = rnd_y.Next(1, 22);
                }
                block[y_y, y_x] = 7;
            }

            int counter_for_new_x_y = 0;
            int counter_for_walls = 0;
            while (true)
            {

                block[cursory, cursorx] = 8;

                counter_for_walls++;
                counter_for_new_x_y++;

                bool wall_flag = true;
                // wall changing
                while (wall_flag == true)
                {
                    int wall_x = 0;
                    int wall_y = 0;

                    if (counter_for_walls >= 1)
                    {
                        Random rnd_walls = new Random();
                        int wall_number = rnd_walls.Next(0, 40);
                        if (wall_number < 10)
                        {
                            wall_x = 0;
                            wall_y = wall_number;
                        }
                        else if (wall_number > 9 && wall_number < 20)
                        {
                            wall_x = 1;
                            wall_y = wall_number - 10;
                        }
                        else if (wall_number > 19 && wall_number < 30)
                        {
                            wall_x = 2;
                            wall_y = wall_number - 20;
                        }
                        else if (wall_number > 29 && wall_number < 40)
                        {
                            wall_x = 3;
                            wall_y = wall_number - 30;
                        }
                        int x = ((wall_x * 5) + 2);
                        int y = ((wall_y * 5) + 2);

                        int randomed_wall = 0;
                        int current_wall = patternofwall[wall_x, wall_y];
                        if (current_wall < 4 || current_wall > 9)
                        {
                            Random rnd_3elements = new Random();
                            int element_of_3 = rnd_3elements.Next(0, 4);
                            if (current_wall == 0)
                            {
                                if (element_of_3 == 0 & block[x, y] <= 1 & block[x + 1, y] <= 1 & block[x + 2, y] <= 1 & block[x + 3, y] <= 1)
                                {
                                    randomed_wall = 4;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1 & block[x + 3, y] <= 1 & block[x + 3, y + 1] <= 1 & block[x + 3, y + 2] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 7;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2 & block[x, y + 3] <= 1 & block[x + 1, y + 3] <= 1 & block[x + 2, y + 3] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 8;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 1)
                            {
                                if (element_of_3 == 0 & block[x, y] <= 1 & block[x, y + 1] <= 1 & block[x, y + 2] <= 1 & block[x, y + 3] <= 1)
                                {
                                    randomed_wall = 4;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1 & block[x, y + 3] <= 1 & block[x + 1, y + 3] <= 1 & block[x + 2, y + 3] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 5;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2 & block[x + 3, y] <= 1 & block[x + 3, y + 1] <= 1 & block[x + 3, y + 2] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 6;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 2)
                            {
                                if (element_of_3 == 0 & block[x, y] <= 1 & block[x + 1, y] <= 1 & block[x + 2, y] <= 1 & block[x + 3, y] <= 1)
                                {
                                    randomed_wall = 6;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1 & block[x, y] <= 1 & block[x, y + 1] <= 1 & block[x, y + 2] <= 1 & block[x, y + 3] <= 1)
                                {
                                    randomed_wall = 7;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2 & block[x, y + 3] <= 1 & block[x + 1, y + 3] <= 1 & block[x + 2, y + 3] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 9;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 3)
                            {
                                if (element_of_3 == 0 & block[x, y] <= 1 & block[x + 1, y] <= 1 & block[x + 2, y] <= 1 & block[x + 3, y] <= 1)
                                {
                                    randomed_wall = 5;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1 & block[x, y] <= 1 & block[x, y + 1] <= 1 & block[x, y + 2] <= 1 & block[x, y + 3] <= 1)
                                {
                                    randomed_wall = 8;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2 & block[x + 3, y] <= 1 & block[x + 3, y + 1] <= 1 & block[x + 3, y + 2] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 9;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 10)
                            {
                                if (element_of_3 == 0)
                                {
                                    randomed_wall = 4;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1)
                                {
                                    randomed_wall = 5;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2)
                                {
                                    randomed_wall = 8;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 11)
                            {
                                if (element_of_3 == 0)
                                {
                                    randomed_wall = 4;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1)
                                {
                                    randomed_wall = 7;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2)
                                {
                                    randomed_wall = 6;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 12)
                            {
                                if (element_of_3 == 0)
                                {
                                    randomed_wall = 9;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1)
                                {
                                    randomed_wall = 5;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2)
                                {
                                    randomed_wall = 6;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 13)
                            {
                                if (element_of_3 == 0)
                                {
                                    randomed_wall = 7;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 1)
                                {
                                    randomed_wall = 8;
                                    wall_flag = false;
                                }
                                if (element_of_3 == 2)
                                {
                                    randomed_wall = 9;
                                    wall_flag = false;
                                }
                            }
                        }
                        else if (current_wall < 10 & current_wall > 3)
                        {
                            Random rnd_4elements = new Random();
                            int element_of_4 = rnd_4elements.Next(0, 5);
                            if (current_wall == 8)//could be 8 3 
                            {
                                if (element_of_4 == 0)
                                {
                                    randomed_wall = 0;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 1 & block[x, y] <= 1 & block[x + 1, y] <= 1 & block[x + 2, y] <= 1 & block[x + 3, y] <= 1)
                                {
                                    randomed_wall = 10;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 2 & block[x + 3, y] <= 1 & block[x + 3, y + 1] <= 1 & block[x + 3, y + 2] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 13;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 3)
                                {
                                    randomed_wall = 3;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 9) //could be 9 3 
                            {
                                if (element_of_4 == 0)
                                {
                                    randomed_wall = 2;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 1 & block[x, y] <= 1 & block[x + 1, y] <= 1 & block[x + 2, y] <= 1 & block[x + 3, y] <= 1)
                                {
                                    randomed_wall = 12;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 2 & block[x, y] <= 1 & block[x, y + 1] <= 1 & block[x, y + 2] <= 1 & block[x, y + 3] <= 1)
                                {
                                    randomed_wall = 13;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 3)
                                {
                                    randomed_wall = 3;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 5)
                            {
                                if (element_of_4 == 0)
                                {
                                    randomed_wall = 1;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 1)
                                {
                                    randomed_wall = 3;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 2 & block[x, y] <= 1 & block[x, y + 1] <= 1 & block[x, y + 2] <= 1 & block[x, y + 3] <= 1)
                                {
                                    randomed_wall = 10;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 3 & block[x + 3, y] <= 1 & block[x + 3, y + 1] <= 1 & block[x + 3, y + 2] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 12;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 7)
                            {
                                if (element_of_4 == 0)
                                {
                                    randomed_wall = 0;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 1)
                                {
                                    randomed_wall = 2;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 2 & block[x, y] <= 1 & block[x + 1, y] <= 1 & block[x + 2, y] <= 1 & block[x + 3, y] <= 1)
                                {
                                    randomed_wall = 11;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 3 & block[x, y + 3] <= 1 & block[x + 1, y + 3] <= 1 & block[x + 2, y + 3] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 13;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 4)
                            {
                                if (element_of_4 == 0)
                                {
                                    randomed_wall = 0;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 1)
                                {
                                    randomed_wall = 1;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 2 & block[x, y + 3] <= 1 & block[x + 1, y + 3] <= 1 & block[x + 2, y + 3] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 10;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 3 & block[x + 3, y] <= 1 & block[x + 3, y + 1] <= 1 & block[x + 3, y + 2] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 11;
                                    wall_flag = false;
                                }
                            }
                            if (current_wall == 6)
                            {
                                if (element_of_4 == 0)
                                {
                                    randomed_wall = 2;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 1)
                                {
                                    randomed_wall = 1;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 2 & block[x, y + 3] <= 1 & block[x + 1, y + 3] <= 1 & block[x + 2, y + 3] <= 1 & block[x + 3, y + 3] <= 1)
                                {
                                    randomed_wall = 12;
                                    wall_flag = false;
                                }
                                if (element_of_4 == 3 & block[x, y] <= 1 & block[x, y + 1] <= 1 & block[x, y + 2] <= 1 & block[x, y + 3] <= 1)
                                {
                                    randomed_wall = 11;
                                    wall_flag = false;
                                }
                            }
                        }
                        Walls(((wall_x * 5) + 2), ((wall_y * 5) + 2), randomed_wall, block, patternofwall);
                    }
                }   
                wall_flag = true;


                //add new x or y every 150 time unit (every 30 seconds)
                if (counter_for_new_x_y % (5 * enemytime) == 0) //adding x 
                {
                    Random flipcoin = new Random();
                    int coin = flipcoin.Next(0, 2);
                    if (coin == 0)
                    {
                        Random rnd_x = new Random();
                        int x_x = rnd_x.Next(1, 52);
                        int x_y = rnd_x.Next(1, 22);
                        while (block[x_y, x_x] != 0 | Math.Sqrt(Math.Pow((cursorx - x_x), 2) + Math.Pow((cursory - x_y), 2)) < 10) 
                        {
                            x_x = rnd_x.Next(1, 52);
                            x_y = rnd_x.Next(1, 22);
                        }
                        block[x_y, x_x] = 6;
                    }
                    if (coin == 1) //adding y
                    {
                        Random rnd_y = new Random();
                        int y_x = rnd_y.Next(1, 52);
                        int y_y = rnd_y.Next(1, 22);
                        while (block[y_y, y_x] != 0 | Math.Sqrt(Math.Pow((cursorx - y_x), 2) + Math.Pow((cursory - y_y), 2)) < 10)
                        {
                            y_x = rnd_y.Next(1, 52);
                            y_y = rnd_y.Next(1, 22);
                        }
                        block[y_y, y_x] = 7;
                    }
                }


                //x and y movements
                for (int i = 0; i < block.GetLength(0); i++)
                {
                    for (int k = 0; k < block.GetLength(1); k++)
                    {
                        if (block[i, k] == 6)
                        {
                            Console.SetCursorPosition(k, i);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            if (cursorx - k < 0 & block[i, k - 1] != 1 & block[i, k - 1] != 7 & block[i, k - 1] != 6) //left movment
                            {
                                if (block[i, k - 1] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k - 1, i);
                                    Console.Write("X");
                                    block[i, k - 1] = 6;
                                    block[i, k] = 0;
                                }
                                else if (block[i, k - 1] == 5) // If the enemy comes to the same square with the mine
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k - 1, i);
                                    Console.Write(" ");
                                    block[i, k - 1] = 0;
                                    kills++;
                                    score += 300;
                                    block[i, k] = 0;
                                }
                            }
                            else if (cursorx - k > 0 & block[i, k + 1] != 1 & block[i, k + 1] != 7 & block[i, k + 1] != 6) //right movment
                            {
                                if (block[i, k + 1] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k + 1, i);
                                    Console.Write("X");
                                    block[i, k + 1] = 6;
                                    block[i, k] = 0;
                                    k++;
                                }
                                else if (block[i, k + 1] == 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k + 1, i);
                                    Console.Write(" ");
                                    block[i, k + 1] = 0;
                                    score += 300;
                                    kills++;
                                    block[i, k] = 0;
                                    k++;
                                }
                            }
                            else if (cursory - i < 0 & block[i - 1, k] != 1 & block[i - 1, k] != 6 & block[i - 1, k] != 7)//moving up
                            {
                                if (block[i - 1, k] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i - 1);
                                    Console.Write("X");
                                    block[i - 1, k] = 6;
                                    block[i, k] = 0;
                                }
                                else if (block[i - 1, k] == 5) 
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i - 1);
                                    Console.Write(" ");
                                    block[i - 1, k] = 0;
                                    score += 300;
                                    kills++;
                                    block[i, k] = 0;
                                }
                            }
                            else if (cursory - i > 0 & block[i + 1, k] != 1 & block[i + 1, k] != 6 & block[i + 1, k] != 7)//moving down
                            {
                                if (block[i + 1, k] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i + 1);
                                    Console.Write("X");
                                    block[i + 1, k] = 6;
                                    block[i, k] = 0;
                                    i++;
                                }
                                else if (block[i + 1, k] == 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i + 1);
                                    Console.Write(" ");
                                    block[i + 1, k] = 0;
                                    score += 300;
                                    kills++;
                                    block[i, k] = 0;
                                    i++;
                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        if (block[i, k] == 7)
                        {
                            Console.SetCursorPosition(k, i);
                            Console.Write("Y");
                            if (cursory - i < 0 & block[i - 1, k] != 1 & block[i - 1, k] != 6 & block[i - 1, k] != 7)//moving up
                            {
                                if (block[i - 1, k] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i - 1);
                                    Console.Write("Y");
                                    block[i - 1, k] = 7;
                                    block[i, k] = 0;
                                }
                                else if (block[i - 1, k] == 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i - 1);
                                    Console.Write(" ");
                                    block[i - 1, k] = 0;
                                    score += 300;
                                    kills++;
                                    block[i, k] = 0;
                                }
                            }
                            else if (cursory - i > 0 & block[i + 1, k] != 1 & block[i + 1, k] != 6 & block[i + 1, k] != 7)//moving down
                            {
                                if (block[i + 1, k] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i + 1);
                                    Console.Write("Y");
                                    block[i + 1, k] = 7;
                                    block[i, k] = 0;
                                    i++;
                                }
                                else if (block[i + 1, k] == 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k, i + 1);
                                    Console.Write(" ");
                                    block[i + 1, k] = 0;
                                    score += 300;
                                    kills++;
                                    block[i, k] = 0;
                                    i++;
                                }
                            }
                            else if (cursorx - k < 0 & block[i, k - 1] != 1 & block[i, k - 1] != 7 & block[i, k - 1] != 6) //moving left
                            {
                                if (block[i, k - 1] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k - 1, i);
                                    Console.Write("Y");
                                    block[i, k - 1] = 7;
                                    block[i, k] = 0;
                                }
                                else if (block[i, k - 1] == 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k - 1, i);
                                    Console.Write(" ");
                                    block[i, k - 1] = 0;
                                    score += 300;
                                    kills++;
                                    block[i, k] = 0;
                                }
                            }
                            else if (cursorx - k > 0 & block[i, k + 1] != 1 & block[i, k + 1] != 7 & block[i, k + 1] != 6) //moving right
                            {
                                if (block[i, k + 1] != 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k + 1, i);
                                    Console.Write("Y");
                                    block[i, k + 1] = 7;
                                    block[i, k] = 0;
                                    k++;
                                }
                                else if (block[i, k + 1] == 5)
                                {
                                    Console.SetCursorPosition(k, i);
                                    Console.Write(" ");
                                    Console.SetCursorPosition(k + 1, i);
                                    Console.Write(" ");
                                    block[i, k + 1] = 0;
                                    block[i, k] = 0;
                                    score += 300;
                                    kills++;
                                    k++;
                                }
                            }
                        }
                    }
                }
                Console.ResetColor();
                if (Console.KeyAvailable)
                {       // true: there is a key in keyboard buffer
                    cki = Console.ReadKey(true);       // true: do not write character

                    while (Console.KeyAvailable) 
                    {
                        Console.ReadKey(true);
                    }

                    if (cki.Key == ConsoleKey.RightArrow && block[cursory, cursorx + 1] != 1)
                    {   // key and boundary control

                        prevx = cursorx; // We hold the player's previous position for mine
                        prevy = cursory;

                        Console.SetCursorPosition(cursorx, cursory);           // delete X (old position)
                        Console.WriteLine(" ");
                        cursorx++;

                        if (energy > 0)   // speed is halved when energy is 0
                            energy--;
                        else if (energy == 0)
                            Thread.Sleep(100);

                        if (block[cursory, cursorx] == 2)  //1 
                        {
                            score += 10;
                        }

                        if (block[cursory, cursorx] == 3)  //2
                        {
                            score += 30;
                            energy += 50;
                        }
                        if (block[cursory, cursorx] == 4)  //3
                        {
                            score += 90;
                            energy += 200;
                            mine += 1;
                        }
                    }
                    if (cki.Key == ConsoleKey.LeftArrow && block[cursory, cursorx - 1] != 1)
                    {
                        prevx = cursorx;
                        prevy = cursory;
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(" ");
                        cursorx--;
                        if (energy > 0)
                            energy--;
                        else if (energy == 0)
                            Thread.Sleep(100);

                        if (block[cursory, cursorx] == 2)  //1 
                        {
                            score += 10;
                        }

                        if (block[cursory, cursorx] == 3)  //2
                        {
                            score += 30;
                            energy += 50;
                        }
                        if (block[cursory, cursorx] == 4)  //3
                        {
                            score += 50;
                            energy += 200;
                            mine += 1;
                        }
                    }
                    if (cki.Key == ConsoleKey.UpArrow && block[cursory - 1, cursorx] != 1)
                    {
                        prevx = cursorx;
                        prevy = cursory;
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(" ");
                        cursory--;
                        if (energy > 0)
                            energy--;
                        else if (energy == 0)
                            Thread.Sleep(100);

                        if (block[cursory, cursorx] == 2)  //1 
                        {
                            score += 10;
                        }

                        if (block[cursory, cursorx] == 3)  //2
                        {
                            score += 30;
                            energy += 50;
                        }
                        if (block[cursory, cursorx] == 4)  //3
                        {
                            score += 50;
                            energy += 200;
                            mine += 1;
                        }
                    }
                    if (cki.Key == ConsoleKey.DownArrow && block[cursory + 1, cursorx] != 1)
                    {
                        prevx = cursorx;
                        prevy = cursory;
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(" ");
                        cursory++;
                        if (energy > 0)
                            energy--;
                        else if (energy == 0)
                            Thread.Sleep(100);

                        if (block[cursory, cursorx] == 2)  //1 
                        {
                            block[cursory, cursorx] = 0;
                            score += 10;
                        }

                        if (block[cursory, cursorx] == 3)  //2
                        {
                            block[cursory, cursorx] = 0;
                            score += 30;
                            energy += 50;
                        }
                        if (block[cursory, cursorx] == 4)  //3
                        {
                            block[cursory, cursorx] = 0;
                            score += 50;
                            energy += 200;
                            mine += 1;
                        }
                    }

                    else if (cki.Key == ConsoleKey.Spacebar && block[prevy, prevx] != 1)
                    {
                        if (mine > 0)
                        {
                            Console.SetCursorPosition(prevx, prevy);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("+");
                            Console.ResetColor();
                            mine--;
                            block[prevy, prevx] = 5;
                        }
                        else
                        {
                            Console.SetCursorPosition(3, 30);
                            Console.WriteLine("You don't have any mines!");
                        }
                    }

                    if (cki.Key == ConsoleKey.Escape) break;
                }

                Console.SetCursorPosition(cursorx, cursory);    // refresh X (current position)
                Console.ForegroundColor = ConsoleColor.White;

                // If the player comes to the same square with the mine or enemy  
                if (block[cursory, cursorx] == 5 | block[cursory, cursorx] == 6 | block[cursory, cursorx] == 7)
                {
                    Console.WriteLine(" ");
                    Console.Clear();
                    Console.SetCursorPosition(40, 1);
                    Console.WriteLine("Score\t: {0}", score);
                    Console.SetCursorPosition(40, 3);
                    Console.WriteLine("Time Survived\t: {0}", time / 5);
                    Console.SetCursorPosition(40, 5);
                    Console.WriteLine("Kills\t: {0}", kills);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("                                    \n███▀▀▀██ ███▀▀▀███ ███▀█▄█▀███ ██▀▀▀\n██    ██ ██     ██ ██   █   ██ ██   \n██   ▄▄▄ ██▄▄▄▄▄██ ██   ▀   ██ ██▀▀▀\n██    ██ ██     ██ ██       ██ ██   \n███▄▄▄██ ██     ██ ██       ██ ██▄▄▄\n                                    \n███▀▀▀███ ▀███  ██▀ ██▀▀▀ ██▀▀▀▀██▄ \n██     ██   ██  ██  ██    ██     ██ \n██     ██   ██  ██  ██▀▀▀ ██▄▄▄▄▄▀▀ \n██     ██   ██  █▀  ██    ██     ██ \n███▄▄▄███    ▀█▀    ██▄▄▄ ██     ██▄\n                                    \n        ██               ██         \n      ████▄   ▄▄▄▄▄▄▄   ▄████       \n         ▀▀█▄█████████▄█▀▀          \n           █████████████            \n           ██▀▀▀███▀▀▀██            \n           ██   ███   ██            \n           █████▀▄▀█████            \n            ███████████             \n        ▄▄▄██  █▀█▀█  ██▄▄▄         \n        ▀▀██           ██▀▀         \n          ▀▀           ▀▀           \n                                    ");
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }
                else
                    Console.WriteLine("P");
                Console.ResetColor();

                if (time % 10 == 0) // add number in every 2 seconds
                {
                    int numberX;
                    int numberY;
                    int prob;
                    while (true)
                    {
                        Random rnd = new Random();
                        numberX = rnd.Next(1, 53);
                        numberY = rnd.Next(1, 23);
                        prob = rnd.Next(0, 10);
                        if (block[numberY, numberX] != 1 && block[numberY, numberX] != 2 && block[numberY, numberX] != 3 && block[numberY, numberX] != 4 && block[numberY, numberX] != 5) // if there is no wall, number, mine where the number is
                        {
                            break;
                        }
                    }
                    Scores(numberX, numberY, prob, block);
                }

                Console.ForegroundColor = ConsoleColor.White;

                time++;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(55, 0);
                Console.WriteLine("Time\t: {0}", time / 5);
                Console.SetCursorPosition(55, 2);
                Console.WriteLine("Energy\t: {0}", energy);
                Console.SetCursorPosition(55, 2);
                Console.WriteLine("                     ");
                Console.SetCursorPosition(55, 2);
                Console.WriteLine("Energy\t: {0}", energy);
                Console.SetCursorPosition(55, 4);
                Console.WriteLine("Score\t: {0}", score);
                Console.SetCursorPosition(55, 6);
                Console.WriteLine("                     ");
                Console.SetCursorPosition(55, 6);
                Console.WriteLine("Mines\t: {0}", mine);
                Console.SetCursorPosition(55, 8);
                Console.WriteLine("Kills\t: {0}", kills);
                Console.ResetColor();

                Thread.Sleep(200);    
            }
        }
    }
}