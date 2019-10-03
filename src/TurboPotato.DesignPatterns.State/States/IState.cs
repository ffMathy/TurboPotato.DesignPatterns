using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPotato.DesignPatterns.State.States
{
    interface IState
    {
        void Act(Player player);
    }
}
