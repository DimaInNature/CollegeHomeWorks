using System;
using Work2.Services;

namespace Work2
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskSwitcher.Switch(ValidationService.InputValidator());

            Console.ReadKey();
        }
    }
}