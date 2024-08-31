using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberApp
{
    interface IGuessNumberGUI
    {
        public Settings GetSettings();
        public int GetGuessedNumber(Settings settings);
        public void ShowSuccessMessage(int tryCount);
        public void ShowLargerThenKeyNumberMessage();
        public void ShowSmallerThenKeyNumberMessage();
        public void ShowGreetingMessage(Settings settings);
        public void ShowFailureMessage(int tryCount);
    }
    public class GuessNumberUI : IGuessNumberGUI
    {
        public Settings GetSettings()
        {
            var settings = new Settings();
                        
            settings.MinValue = InputInt("Минимальное значение: ");                        
            settings.MaxValue = InputInt("Максимальное значение: ", value => value >= settings.MinValue, "Максимальное значение должно быть не меньше минимального.");            
            settings.MaxTry = InputInt("Число попыток: ", value => value > 0, "Число попыток должно быть больше нуля.");

            return settings;
        }

        public int GetGuessedNumber(Settings settings)
        {
            return (InputInt("Введите вашу догадку: ", value => value >= settings.MinValue && value<=settings.MaxValue, $"Догадка должна быть в диапазоне от {settings.MinValue} до {settings.MaxValue}."));
        }

        private int InputInt(string message, Func<int, bool> validation = null, string errorMessage = null)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (validation == null || validation(value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine(errorMessage);                        
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод.");                    
                }
            }
        }

        public void ShowSuccessMessage(int tryCount)
        {
            Console.WriteLine($"Число угадано с {tryCount} попытки.");
        }

        public void ShowFailureMessage(int tryCount)
        {
            Console.WriteLine($"Число не угадано за {tryCount} попыток. Конец игры.");
        }

        public void ShowLargerThenKeyNumberMessage()
        {
            Console.WriteLine($"Ваше число больше загаданного. Попробуйте снова.");
        }

        public void ShowGreetingMessage(Settings settings)
        {
            Console.WriteLine($"Угадайте число в диапазоне от {settings.MinValue} до {settings.MaxValue} включительно за {settings.MaxTry} попыток.");
        }

        public void ShowSmallerThenKeyNumberMessage()
        {
            Console.WriteLine($"Ваше число меньше загаданного. Попробуйте снова.");
        }
    }
}
