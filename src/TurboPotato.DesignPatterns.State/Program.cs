using System;
using TurboPotato.DesignPatterns.State.States;

namespace TurboPotato.DesignPatterns.State
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.CurrentState = new IdleState();

            while (true)
            {
                Console.WriteLine("Acting.");
                player.Act();
            }
        }
    }
}
