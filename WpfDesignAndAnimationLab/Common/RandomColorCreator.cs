using System;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Common
{
    public class RandomColorCreator : RandomCreator<Color>
    {
        private readonly Random _random;

        public RandomColorCreator()
        {
            var tick = DateTime.Now.Ticks;
            _random = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        }

        public override Color Next => Color.FromRgb((byte)_random.Next(255), (byte)_random.Next(255), (byte)_random.Next(255));
    }
}