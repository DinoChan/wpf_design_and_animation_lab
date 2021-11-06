using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Common
{
    public class RandomColorCreator : RandomCreator<Color>
    {
        public RandomColorCreator()
        {
            long tick = DateTime.Now.Ticks;
            _random =new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        }
        private Random _random ;

        public override Color Next => Color.FromRgb((byte)_random.Next(255), (byte)_random.Next(255), (byte)_random.Next(255));
    }
}
