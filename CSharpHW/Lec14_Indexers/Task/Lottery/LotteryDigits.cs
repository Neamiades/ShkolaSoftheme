using System;
using System.Linq;

namespace Lottery
{
    class LotteryDigits
    {
        private readonly int[] _digits = new int[6];
        private readonly Random _random = new Random();

        public LotteryDigits() => GenerateNewDigits();

        public int this[int idx] => _digits[idx];

        public void GenerateNewDigits()
        {
            for (int i = 0; i < _digits.Length; i++)
            {
                _digits[i] = _random.Next(1, 10);
            }
        }

        public bool ValidateStrNumbers(string[] strDigits)
        {
            return strDigits.Length == 6 && strDigits.All(d => int.TryParse(d, out int x) && x > 0 && x < 10);
        }

        public bool CheckNum(string[] strDigits)
        {
            for (int i = 0; i < _digits.Length; i++)
            {
                if (int.Parse(strDigits[i]) != this[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
