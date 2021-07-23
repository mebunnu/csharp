using System;

namespace RockPaperScissors
{
    public static class Data
    {
        public static int PlayerWins;
        public static int BotWins;
        public static int NumberofRounds;
        public static Random random;

        static Data()
        {
            PlayerWins = 0;
            BotWins = 0;
            NumberofRounds = 0;
            random = new Random();
        }
    }

    public enum RoundWinner
    {
        draw = 0,
        player,
        bot
    }
}


