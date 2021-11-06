using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WpfDesignAndAnimationLab.Common
{
    public abstract class RandomCreator<T> : DependencyObject
    {
        public T Max { get; set; }

        public abstract T Next { get; }
    }
}
