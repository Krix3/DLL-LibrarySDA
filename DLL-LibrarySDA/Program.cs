using FibonacciLibrary;
using System;

namespace FibonacciLibrary
{
    public static class Fibonacci
    {
        private static ulong previous;  // Предыдущее значение
        private static ulong current;   // Текущее значение
        private static uint index;      // Текущая позиция в последовательности

        // Инициализация последовательности
        public static void fibonacci_init(ulong a, ulong b)
        {
            previous = a;
            current = b;
            index = 1;
        }

        // Создание следующего значения в последовательности
        public static bool fibonacci_next()
        {
            try
            {
                checked
                {
                    ulong next = previous + current;
                    previous = current;
                    current = next;
                    index++;
                    return true;
                }
            }
            catch (OverflowException)
            {
                return false;
            }
        }

        // Получение текущего значения в последовательности
        public static ulong fibonacci_current()
        {
            return current;
        }

        // Получение текущей позиции в последовательности
        public static uint fibonacci_index()
        {
            return index;
        }
    }
}



////////Пример использования библиотеки:////////



using System;
using FibonacciLibrary;

namespace FibonacciApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация последовательности
            Fibonacci.fibonacci_init(0, 1);

            // Вывод первых 10 чисел Фибоначчи
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Index: {Fibonacci.fibonacci_index()}, Value: {Fibonacci.fibonacci_current()}");
                if (!Fibonacci.fibonacci_next())
                {
                    Console.WriteLine("Переполнение последовательности");
                    break;
                }
            }
        }
    }
}

