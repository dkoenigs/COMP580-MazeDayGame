using System;
using System.Threading;
using System.Diagnostics;

namespace RallyRacingGame {
    



    
    class ExecuteGame {
        static void Main(string[] args) {
            Console.WriteLine("----Welcome to Rally Racing----");
            Console.WriteLine("Press <s> to start a new game");
            Game currGame = new Game();
            currGame.setUpGame();
        }
    }

    
    class Game {

        int score;

        public void setUpGame() {
            this.score = 0;
            this.score = runGame();
            Console.WriteLine("End score: ", this.score);
        }


        private int runGame() {
            
            Console.WriteLine("here");
            int scoreCounter = 0;
            int directionToggle = 0; // 0:Left | 1:Right (Change .Next() range if we want more options)
            Random ranNum = new Random();
            bool stopFlag = false;

            while (!stopFlag) {

                directionToggle = ranNum.Next(0, 2);
                Console.WriteLine(directionToggle);

                if (directionToggle == 0) { //Left
                    Console.WriteLine("Co-driver: \"Turn Left\"");

                } else { //Right
                    Console.WriteLine("Co-driver: \"Turn Right\"");

                }

                // Stopwatch stopwatch = new Stopwatch();
                // stopwatch.start();

                for (int i=5;i>= 0;i--) {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Turn taken!");
            }

            return scoreCounter;
        }
        
    }






}