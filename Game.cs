using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberApp
{
    enum GuessResult 
    { 
        TooSmall, Correct, TooLarge
    }    
    public class Game
    {
        readonly NumberGenerator _numberGenerator;
        readonly Settings _settings;
        readonly GuessNumberUI _guessNumberUI;
        int _keyNumber;
        int _tryCount;

        public Game (Settings settings, NumberGenerator numberGenerator, GuessNumberUI guessNumberUI)
        {
            _numberGenerator = numberGenerator;
            _settings = settings;
            _guessNumberUI = guessNumberUI;
        }

        public void GameInit()
        {
            _tryCount = 0;
            _keyNumber = _numberGenerator.GenerateNamber(_settings.MinValue,_settings.MaxValue);            ;
        }

        private GuessResult GuessNumber(int number) 
        {
            _tryCount++;

             if(number==_keyNumber)
                return GuessResult.Correct;
             else if(number< _keyNumber) 
                return GuessResult.TooSmall;
             else 
                return GuessResult.TooLarge;        
        }

        public void GamePlay()
        {
            _guessNumberUI.ShowGreetingMessage(_settings);

            while (_tryCount<_settings.MaxTry)
            {                
                switch(GuessNumber(_guessNumberUI.GetGuessedNumber(_settings)))
                {
                    case GuessResult.Correct:
                        _guessNumberUI.ShowSuccessMessage(_tryCount);
                        return;                        
                    case GuessResult.TooSmall:
                        _guessNumberUI.ShowSmallerThenKeyNumberMessage();
                        break;
                    case GuessResult.TooLarge:
                        _guessNumberUI.ShowLargerThenKeyNumberMessage();
                        break;
                }
            }

            _guessNumberUI.ShowFailureMessage(_tryCount);
        }

    }
}
