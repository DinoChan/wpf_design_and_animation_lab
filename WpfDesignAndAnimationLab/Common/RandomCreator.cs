using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public abstract class RandomCreator<T> : DependencyObject
    {
        public T Max { get; set; }

        public abstract T Next { get; }
    }
}