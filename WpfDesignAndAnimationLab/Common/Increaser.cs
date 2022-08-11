using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public abstract class Increaser<T> : DependencyObject
    {
        public abstract T Next { get; }
        public virtual T Start { get; set; }

        public T Step { get; set; }
    }
}