using System;

namespace Work2.Services
{
    public class ValidationService
    {
        public static int InputValidator()
        {
            string value;
            int result;

            do
            {
                value = Console.ReadLine();
            }
            while (!int.TryParse(value, out result));

            return result;
        }
    }
}
