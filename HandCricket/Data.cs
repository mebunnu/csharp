using System;

namespace HandCricket
{
    public static class Data
    {
        public static int playerScore;
        public static int botScore;
        public static int overs;
        public static int wickets;
        public static string toss;
        public static Random random;

        static Data()
        {
            playerScore = 0;
            botScore = 0;
            overs = 0;
            wickets = 0;
            toss = string.Empty;
            random = new Random();
        }
    }
}


