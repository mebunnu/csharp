using System;

namespace HandCricket
{
    class Game
    {
        static void Main(string[] args)
        {
            #region Set Overs
            Console.WriteLine("Hi, Welcome to Handcricket Bot.\nPlease set number of overs (should be between 1 and 10)");
            int.TryParse(Console.ReadLine(), out Data.overs);
            while (!(Data.overs >= 1 && Data.overs <= 10))
            {
                Console.WriteLine("Please enter value between 1 and 10");
                int.TryParse(Console.ReadLine(), out Data.overs);
            }
            #endregion

            #region Set Wickets
            Console.WriteLine("Please set the number of Wickets (should be between 1 and 10)");
            int.TryParse(Console.ReadLine(), out Data.wickets);
            while (!(Data.wickets >= 1 && Data.wickets <= 10))
            {
                Console.WriteLine("Please enter value between 1 and 10");
                int.TryParse(Console.ReadLine(), out Data.wickets);
            }
            #endregion

            #region Toss
            Console.WriteLine("Toss Time, heads or tails? (type in \"heads\" or \"tails\")");
            Data.toss = Console.ReadLine().ToLower();
            while (!(Data.toss == "heads" || Data.toss == "tails"))
            {
                Console.WriteLine("Please type in heads or tails");
                Data.toss = Console.ReadLine().ToLower();
            }

            int tossDecider = Data.random.Next(11);
            string decision = string.Empty;

            if(tossDecider <= 5)
            {
                Console.WriteLine("You have won the toss what do you decide? bat or bowl? (type in \"bat\" or \"bowl\")");

                decision = Console.ReadLine().ToLower();

                while(!(decision == "bat" || decision == "bowl"))
                {
                    Console.WriteLine("Please type in \"bat\" or \"bowl\"");
                    decision = Console.ReadLine().ToLower();
                } 

                if(decision == "bat")
                {
                    Console.WriteLine("\nFirst Innings Started");
                    Data.playerScore = Innings(true);
                    Console.WriteLine($"\nSecond Innings Started and {Data.playerScore + 1} is the target for the bot");
                    Data.botScore = Innings(false, Data.playerScore);
                }
                else
                {
                    Console.WriteLine("\nFirst Innings Started");
                    Data.botScore = Innings(false);
                    Console.WriteLine($"\nSecond Innings Started and {Data.botScore + 1} is the target for the player");
                    Data.playerScore = Innings(true, Data.botScore);
                }
            }
            else
            {
                int botDecider = Data.random.Next(11);
                decision = botDecider <= 5 ? "bat" : "bowl";
                Console.WriteLine($"You have lost the toss and bot has decided to {decision} first");


                if(decision == "bat")
                {
                    Console.WriteLine("\nFirst Innings Started");
                    Data.botScore = Innings(false);
                    Console.WriteLine($"\nSecond Innings Started and {Data.botScore + 1} is the target for the player");
                    Data.playerScore = Innings(true, Data.botScore);
                }
                else
                {
                    Console.WriteLine("\nFirst Innings Started");
                    Data.playerScore = Innings(true);
                    Console.WriteLine($"\nSecond Innings Started and {Data.playerScore + 1} is the target for the bot");
                    Data.botScore = Innings(false, Data.playerScore);
                }
            }
            #endregion

            #region Result 
            if(Data.playerScore > Data.botScore)
            {
                Console.WriteLine("Player Wins");
            }
            else if(Data.playerScore < Data.botScore)
            {
                Console.WriteLine("Bot Wins");
            }
            else
            {
                Console.WriteLine("The Match ended in a draw");
            }
            #endregion
        }
        
        #region Innings
        public static int Innings(bool isPlayerInnings, int? target = null)
        {
            Console.WriteLine("Start sending your Actions (should be between 0 and 6)");
            int wicketCounter = 0;
            int totalNumberofBalls = Data.overs * 6;
            float decimalOverCounter = 0.0f;
            short overCounter = 0;
            float overCounterHelper = 1.0f;
            int score = 0;

            for(short i = 1; i <= totalNumberofBalls;  i++)
            {
                if(wicketCounter == Data.wickets)
                {
                    break;
                }

                if(target != null)
                {
                    if(score > target)
                    {
                        break;
                    }
                }

                int botAction = Data.random.Next(7);
                int playerAction = -1;
                int.TryParse(Console.ReadLine(), out playerAction);
                while (!(playerAction >= 0 && playerAction <= 6))
                {
                    Console.WriteLine("You can only choose between 0 and 6..");
                    int.TryParse(Console.ReadLine(), out playerAction);
                }

                //Change of Overs 
                if (decimalOverCounter / 0.5f == overCounterHelper)
                {
                    decimalOverCounter += 0.5f;
                    overCounter = (short)decimalOverCounter;
                    overCounterHelper += 2;
                }
                else
                {
                    decimalOverCounter += 0.1f;
                    decimalOverCounter = MathF.Round(decimalOverCounter, 2);
                }

                string commentary = string.Empty;

                if (playerAction != botAction)
                {
                    commentary = $"Bot did {botAction}\n";
                    score += isPlayerInnings ? playerAction : botAction;
                    commentary += $"Score - {score}/{wicketCounter} from {(i % 6 == 0 ? overCounter : decimalOverCounter)} Overs";
                }
                else
                {
                    commentary = $"OUTTTTTTT, Bot did {botAction}\n";
                    wicketCounter += 1;
                    commentary += $"Score - {score}/{wicketCounter} from {(i % 6 == 0 ? overCounter : decimalOverCounter)} Overs";
                }


                Console.WriteLine(commentary);
            }

            return score;
        }
        #endregion
    }
}





