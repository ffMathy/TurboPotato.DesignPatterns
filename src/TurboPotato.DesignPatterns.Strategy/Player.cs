﻿using System;
using System.Collections.Generic;
using System.Text;
using TurboPotato.DesignPatterns.Strategy.Strategies;

namespace TurboPotato.DesignPatterns.Strategy
{
    class Player
    {
        public IStrategy CurrentStrategy { get; set; }

        public int Health { get; set; }

        public bool IsBeingAttacked { get; set; }

        public void Act()
        {
            Health -= 1;
            CurrentStrategy?.Act(this);
        }
    }
}
