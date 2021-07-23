using System;

namespace RockPaperScissors
{
    class Game
    {
        static void Main(string[] args)
        {
            #region Number of Rounds
            Console.WriteLine("How many rounds do you want to play? (should be between 0 and 10)");
            int.TryParse(Console.ReadLine(), out Data.NumberofRounds);
            while (!(Data.NumberofRounds >= 1 && Data.NumberofRounds <= 10))
            {
                Console.WriteLine("Please enter a value between 1 and 10");
                int.TryParse(Console.ReadLine(), out Data.NumberofRounds);
            }
            #endregion

            #region Game
            Console.WriteLine("Game Starts!!!");
            Play();
            #endregion

        }

        public static void Play()
        {
            RoundWinner roundWinner = RoundWinner.draw;
            for (int i = 0; i < Data.NumberofRounds; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n******ROUND {i + 1}******");
                Console.ResetColor();
                Console.WriteLine("type in \"rock\", \"paper\" or \"scissors\"");
                string playerChoice = Console.ReadLine().ToLower();

                while (!(playerChoice == "rock" || playerChoice == "paper" || playerChoice == "scissors"))
                {
                    Console.WriteLine("please enter \"rock\" or \"paper\" or \"scissors\"");
                    playerChoice = Console.ReadLine().ToLower();
                }

                int botRandom = Data.random.Next(1, 4);
                string botChoice = string.Empty;
                switch (botRandom)
                {
                    case 1:
                        botChoice = "rock";
                        break;
                    case 2:
                        botChoice = "paper";
                        break;
                    case 3:
                        botChoice = "scissors";
                        break;
                }
                Console.WriteLine($"Bot did {botChoice}");

                switch (playerChoice)
                {
                    case "rock":
                        switch (botChoice)
                        {
                            case "rock":
                                roundWinner = RoundWinner.draw;
                                break;
                            case "paper":
                                roundWinner = RoundWinner.bot;
                                break;
                            case "scissors":
                                roundWinner = RoundWinner.player;
                                break;
                        }
                        break;

                    case "paper":
                        switch (botChoice)
                        {
                            case "rock":
                                roundWinner = RoundWinner.player;
                                break;
                            case "paper":
                                roundWinner = RoundWinner.draw;
                                break;
                            case "scissors":
                                roundWinner = RoundWinner.bot;
                                break;
                        }
                        break;

                    case "scissors":
                        switch (botChoice)
                        {
                            case "rock":
                                roundWinner = RoundWinner.bot;
                                break;
                            case "paper":
                                roundWinner = RoundWinner.player;
                                break;
                            case "scissors":
                                roundWinner = RoundWinner.draw;
                                break;
                        }
                        break;
                }

                switch (roundWinner)
                {
                    case RoundWinner.draw:
                        Console.WriteLine($"This round ended in Draw, you win {Data.PlayerWins} rounds and bot win {Data.BotWins} rounds");
                        break;

                    case RoundWinner.bot:
                        Data.BotWins++;
                        Console.WriteLine($"Bot win this round, you win {Data.PlayerWins} rounds and bot win {Data.BotWins} rounds");
                        break;

                    case RoundWinner.player:
                        Data.PlayerWins++;
                        Console.WriteLine($"Yayy, You win this round, you win {Data.PlayerWins} rounds and bot win {Data.BotWins} rounds");
                        break;
                }
            }

            if (Data.PlayerWins > Data.BotWins)
            {
                Console.WriteLine($"\n\nYou win more number of rounds than bot.\n=>Number of rounds you win: {Data.PlayerWins}\n=>Number of rounds bot win: {Data.BotWins}");
            }
            else if (Data.PlayerWins < Data.BotWins)
            {
                Console.WriteLine($"\n\nBot win more number of rounds than you.\n=>Nnumber of rounds you win: {Data.PlayerWins}\n=>Number of rounds bot win: {Data.BotWins}");
            }
            else
            {
                Console.WriteLine($"\n\nThe battle ended up in a draw.\n=>Number of rounds you win: {Data.PlayerWins}\n=>Number of rounds bot win: {Data.BotWins}");
            }
        }
    }


}
