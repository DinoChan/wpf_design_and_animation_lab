using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDesignAndAnimationLab.Common
{
    public abstract class Increaser<T>
    {
        public T Start { get; set; }

        public T Step { get; set; }

        public abstract T Next { get; }
    }
}
