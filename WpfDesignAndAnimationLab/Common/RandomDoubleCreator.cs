using System;

namespace WpfDesignAndAnimationLab.Common
{
    public class RandomDoubleCreator : RandomCreator<double>
    {
        private readonly Random _random = new();

        public override double Next => _random.NextDouble() * _random.Next(Convert.ToInt32(Math.Round(Max)));
    }
}