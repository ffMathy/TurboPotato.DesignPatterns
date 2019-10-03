using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPotato.DesignPatterns.Strategy.Strategies
{
    class ExploreStrategy : IStrategy
    {
        public void Act(Player player)
        {
            Console.WriteLine("We're walkin' here!");

            //TODO: explore stuff
        }
    }
}
