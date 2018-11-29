namespace Sample.Helpers
{
    public static class RookieConverters
    {
        public static int LevelThreshold(int level)
        {
            switch(level)
            {
               case 1:
                    return 99;
                case 2:
                    return 249;
                case 3:
                    return 499;
                case 4:
                    return 999;
                case 5:
                    return 1749;
                default:
                    return 2999;
            }
        }
    }
}
