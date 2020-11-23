using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать класс Игра с событиями Атака и Лечить.В main создать
//некоторое количество игровых объектов. Подпишите объекты на
//события произвольным образом. Реакция на события у разных
//объектов может быть разной (без изменения,
//увеличивается/уменьшается уровень жизни). Проверить состояния
//игровых объектов после наступления событий, возможно не
//однократном.

namespace lab_9
{
    class Game
    {
        public delegate void Message(string message);
        public event Message Heal;
        public event Message Attack;
        int Health;
        public Game(int health)
        {
            Health = health;
        }
        public void MoreHealth(int health)
        {
            if (Heal != null && Attack != null)
            {
                Health += health;
                if (Health == 100 || Health > 100)
                {
                    Heal("Heal...");
                    Heal("Health is full!");
                    Health = 100;
                }
                else
                {
                    Heal("Heal...");
                    Heal("Health: " + Health);
                }
            }
            else
            {
                Console.WriteLine("Error(((");
            }
        }
        public void LessHealth(int health)
        {
            if (Heal != null && Attack != null)
            {
                Health -= health;
                if (Health == 0 || Health < 0)
                {
                    Heal("Attack...");
                    Heal("Player is dead...");
                    Health = 0;
                }
                else
                {
                    Heal("Attack...");
                    Heal("Health: " + Health);
                }
            }
            else
            {
                Console.WriteLine("Error(((");
            }
        }
        public static void Out(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        public static string AddSymbols(string str)
        {
            return str += " :)";
        }
        public static string AddBeginning(string str, Func<string, string> addsymb)
        {
            string str1 = addsymb(str);
            Console.WriteLine(str1);
            return str1.Insert(0, "Say: ");
        }
        public static string Upper(string str, Func<string, string> addsymb, Func<string, Func<string, string>, string> addbegin)
        {
            string str1 = addbegin(str, addsymb);
            Console.WriteLine(str1);
            return str1.ToUpper();
        }
        public static void DeleteExcessSpases (string str)
        {
            str = str.Replace("   ", " ");
            str = str.Replace("  ", " ");
            Console.WriteLine(str);
        }
        public static void DeletePunctationMarks(string str)
        {
            str = str.Replace(".", String.Empty);
            str = str.Replace(",", String.Empty);
            str = str.Replace(";", String.Empty);
            str = str.Replace(":", String.Empty);
            str = str.Replace("?", String.Empty);
            str = str.Replace("!", String.Empty);
            Console.WriteLine(str);
        }


        delegate int Expression(int x, int y);


        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~Dalegate and Lambda~~~~~~~~~~");
            Expression ex = (x, y) => (x + y) * 2;
            int a = ex(2, 3);
            Console.WriteLine(a);

            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~PLAYER1~~~~~~~~~~");
            Game player1 = new Game(100);
            player1.Heal += Game.Out;
            player1.Attack += Game.Out;
            player1.LessHealth(25);
            player1.LessHealth(10);
            player1.MoreHealth(30);
            player1.Attack -= Game.Out;
            player1.MoreHealth(30);

            Console.WriteLine("~~~~~~~~~~PLAYER2~~~~~~~~~~");
            Game player2 = new Game(100);
            player2.Heal += Game.Out;
            player2.Attack += Game.Out;
            player2.LessHealth(25);
            player2.MoreHealth(30);
            player2.LessHealth(10);
            player2.MoreHealth(30);
            player2.LessHealth(100);

            Console.WriteLine("~~~~~~~~~~PLAYER3~~~~~~~~~~");
            Game player3 = new Game(100);
            player3.Heal += Game.Out;
            player3.Attack += Game.Out;
            player3.LessHealth(25);
            player3.LessHealth(10);
            player3.MoreHealth(30);
            player3.MoreHealth(30);

            Console.WriteLine("~~~~~~~~~~PLAYER4~~~~~~~~~~");
            Game player4 = new Game(100);
            player4.Heal += Game.Out;
            player4.Attack += Game.Out;
            player4.LessHealth(50);
            player4.LessHealth(10);
            player4.MoreHealth(30);
            player4.MoreHealth(10);


            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~STRING~~~~~~~~~~");
            string str = "H,ello   wor.ld  !!!";
            Console.WriteLine(str);
            Func<string, string> addSymb = AddSymbols;
            Func<string, Func<string, string>, string> addBegin = AddBeginning;
            Func<string, Func<string, string>, Func<string, Func<string, string>, string>, string> uppStr = Upper;
            string str1 = uppStr(str, addSymb, addBegin);
            Console.WriteLine(str1);

            Console.WriteLine();
            Action<string> uppStr1 = DeleteExcessSpases;
            uppStr1(str1);
            uppStr1 = DeletePunctationMarks;
            uppStr1(str1);
        }
    }
}
