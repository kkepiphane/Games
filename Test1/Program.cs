using System;
using System.Xml.Schema;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Actor Monster = new Actor("Monster");
            Actor Hero = new Actor("Hero");
            Arena Arena1 = new Arena(Hero, Monster, new Random());
            Arena1.Run();
        }
    }

    internal class Arena
    {
        private Actor Hero { get; set; }
        private Actor Monster { get; set; }
        private readonly Random rand;

        public Arena(Actor hero, Actor monster, Random rand)
        {
            Hero = hero;
            Monster = monster;
            this.rand = rand;

        }
        public void Run()
        {
            Random rand = new Random();
            do
            {
                MakePunch(rand.Next(0, 10));
                

            } while (AllActorsAlive);

            Console.WriteLine($"{GetWinner()} win");
            Console.ReadKey();
        }

        private void MakePunch(int punch)
        {
            var message = punch % 2 == 0 ? Hero.GetAttacked(punch) : Monster.GetAttacked(punch);
            Console.WriteLine(message);

        }
        private string GetWinner()
        {
            if (AllActorsAlive)
            {
                return string.Empty;
            }
            if (Hero.IsAlive)
                return Hero.Name;
            return Monster.Name;
        }

        private bool AllActorsAlive => Hero.IsAlive && Monster.IsAlive;

    }


    internal class Actor
    {
        public int Life { get; set; } = 10;
        public string Name { get; set; }
        public bool IsAlive => Life > 0;
        public Actor(string name)
        {
            Life = 10;
            Name = name;
        }
        public string GetAttacked(int attack)
        {
            Life -= attack;
            return $"{Name} was damaged and lost {attack} health and now has {Life} health.";
        }
    }

}
