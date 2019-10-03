using System;
using TurboPotato.DesignPatterns.Strategy.Strategies;

namespace TurboPotato.DesignPatterns.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();

            while (true)
            {
                if (player.Health < 30)
                {
                    player.CurrentStrategy = new DefensiveStrategy();
                } else
                {
                    player.CurrentStrategy = new ExploreStrategy();
                }

                Console.WriteLine("Acting.");
                player.Act();
            }
        }
    }
}
