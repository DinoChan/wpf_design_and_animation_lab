using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public abstract class ValueWrapper<T> : DependencyObject
    {
        public abstract T Value { get; set; }
    }
}
