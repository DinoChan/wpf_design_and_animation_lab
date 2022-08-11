using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public abstract class ValueWrapper<T> : DependencyObject
    {
        public abstract T Value { get; set; }
    }
}