using GuessNumberApp;
using System;

class Program
{
    static void Main()
    {
        GuessNumberUI guessNumberUI = new GuessNumberUI();
        Settings settings = guessNumberUI.GetSettings();

        NumberGenerator numberGenerator = new NumberGenerator();
        Game gameGuessNumber = new Game(settings, numberGenerator, guessNumberUI);

        gameGuessNumber.GameInit();
        gameGuessNumber.GamePlay();
    }
}