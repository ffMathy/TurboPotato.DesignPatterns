using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPotato.DesignPatterns.State.States
{
    class IdleState : IState
    {
        private readonly Random random;

        public IdleState()
        {
            this.random = new Random();
        }

        public void Act(Player player)
        {
            Console.WriteLine("We're walkin' here!");

            GetHitByMeteor(player);

            if(player.Health < 20) { 
                player.CurrentState = new LowHealthState();
            }
        }

        private void GetHitByMeteor(Player player)
        {
            var isHit = random.Next(0, 5) == 4;
            if(isHit)
            {
                player.Health -= 7;
            }
        }
    }
}
