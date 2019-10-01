using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPotato.DesignPatterns.Strategy.Strategies
{
    class LowHealthStrategy : IStrategy
    {
        public void Act(Player player)
        {
            Console.WriteLine("Oh noes, we have low health");

            //TODO: move away from enemy if an enemy is too close.
            //TODO: try to heal if enemies are far away.
        }
    }
}
