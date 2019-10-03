using System;
using System.Collections.Generic;
using System.Text;
using TurboPotato.DesignPatterns.State.States;

namespace TurboPotato.DesignPatterns.State
{
    class Player
    {
        public IState CurrentState { get; set; }

        public int Health { get; set; }

        public bool IsBeingAttacked { get; set; }

        public void Act()
        {
            Health -= 1;
            CurrentState?.Act(this);
        }
    }
}
