using System;
using System.Collections;
using System.Collections.Generic;

namespace TurboPotato.DesignPatterns.Observer
{
    class StringSubject
    {
        private readonly ICollection<Action<string>> observers;

        public StringSubject()
        {
            observers = new HashSet<Action<string>>();
        }

        public void Subscribe(Action<string> observer)
        {
            observers.Add(observer);
        }

        public void UpdateString(string newString)
        {
            foreach(var observer in observers)
                observer(newString);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stringSubject = new StringSubject();
            stringSubject.Subscribe(x => Console.WriteLine("1: " + x));
            stringSubject.Subscribe(x => Console.WriteLine("2: " + x));

            stringSubject.UpdateString("Hello world");

            stringSubject.Subscribe(x => Console.WriteLine("3: " + x));

            stringSubject.UpdateString("How are you doing?");
        }
    }
}
