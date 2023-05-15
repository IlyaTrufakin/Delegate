using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void StringDelegate(string str);
    public delegate int CalcDelegate(int a, int b);
    public delegate bool PredicateDelegate(int a);

    internal class Program
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static int Add(int a, int b) { return a + b; }
        public static int Sub(int a, int b) { return a - b; }
        public static int Mul(int a, int b) { return a * b; }
        public static bool isEven(int a) { return a % 2 == 0; }
        public static bool isOdd(int a) { return (a % 2 != 0); }
        public static bool isPrime(int a)
        {
            if (a < 2)
                return false;

            int threshold = Convert.ToInt32(Math.Sqrt(Math.Abs(a)));
            for (int i = 2; i <= threshold; i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
        public static bool isFibonacchi(int a)
        {
            int k = 0;
            int t = 1;
            int temp;

            if (a < 0)
            {
                while (t > a)
                {
                    temp = k;
                    k = t;
                    t -= temp;
                }
            }
            else
            {
                while (t < a)
                {
                    temp = k;
                    k = t;
                    t += temp;
                }
            }

            return t == a;
        }








        static void Main(string[] args)
        {
            // Task 1
            //Створіть додаток, який відображає текстове повідомлення. Використовуйте механізми делегатів.
            //Делегат має повертати void та приймати один параметр типу string (текст повідомлення).
            //Для тестування додатка створіть різні методи виклику через делегат.
            StringDelegate myStringDelegate = PrintMessage;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("String delegate testing...");
            myStringDelegate("test message");
            myStringDelegate.Invoke("Test message via invoke");




            //Task 2
            //Створіть додаток для виконання арифметичних операцій. Підтримувані операції:
            //■ Додавання двох чисел;
            //■ Віднімання двох чисел;
            //■ Множення двох чисел.
            //Код програми обов’язково має використати механізм делегатів.
            //Task 4
            //Реалізуйте додаток із другого практичного завдання за допомогою виклику Invoke.

            CalcDelegate[] myCalcDelegate = { Add, Sub, Mul };
            int selectedOperation = 1;
            do
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("Delegate testing...");
                Console.Write("\nEnter integer number A: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter integer number B: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n1 - for adding A and B");
                Console.WriteLine("2 - for sub B from A");
                Console.WriteLine("3 - for multipluing A and B");
                Console.Write("4 - for quit\nSelect an operations: ");
                selectedOperation = Convert.ToInt32(Console.ReadLine());
                if (selectedOperation > 0 && selectedOperation < 4)
                {
                    Console.WriteLine("Result: " + myCalcDelegate[selectedOperation - 1].Invoke(a, b));
                }

            } while (selectedOperation != 4);


            //Task 3
            //Створіть додатки для виконання арифметичних операцій. Підтримувані операції:
            //Перевірка числа на парність;
            //Перевірка числа на непарність;
            //Перевірка на просте число;
            //Перевірка на число Фібоначчі.
            //Обов’язково використовуйте делегат типу Predicate.

            //PredicateDelegate[] myPredicateDelegate = { isEven, isOdd, isSimple, isFibonacchi };
            PredicateDelegate[] myPredicateDelegate = { num => num % 2 == 0, num => num % 2 != 0, isPrime, isFibonacchi };// с лямбдами вместо методов

            do
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Predicate delegate testing...");
                Console.Write("Enter integer number A: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n1 - parity check");
                Console.WriteLine("2 - odd number check");
                Console.WriteLine("3 - check if a number is prime");
                Console.WriteLine("4 - checking if a number is fibonacci");
                Console.Write("5 - for quit\nSelect an operations: ");
                selectedOperation = Convert.ToInt32(Console.ReadLine());
                if (selectedOperation > 0 && selectedOperation < 5)
                {
                    Console.WriteLine("Result: " + myPredicateDelegate[selectedOperation - 1](a));
                }

            } while (selectedOperation != 5);
        }
    }
}
