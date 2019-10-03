using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPotato.DesignPatterns.State.States
{
    class LowHealthState : IState
    {
        public void Act(Player player)
        {
            Console.WriteLine("Oh noes, we have low health");
            
            //let's heal a bit
            player.Health += 3;

            if(player.Health > 50)
            {
                player.CurrentState = new IdleState();
            }
        }
    }
}
