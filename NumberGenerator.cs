using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberApp
{
    public interface INumberGenerator
    {
        int GenerateNamber(int minValue, int maxValue);
    }

    public class NumberGenerator : INumberGenerator
    {
        public int GenerateNamber(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue+1);
        }
    }
}
