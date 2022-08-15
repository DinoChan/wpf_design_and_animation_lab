using System.Collections.ObjectModel;

namespace WpfDesignAndAnimationLab.Common
{
    public class RepeatCollection : Collection<object>
    {
        private int _offset;

        public object Next
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                var result = this[_offset];
                _offset++;
                if (_offset > Count - 1)
                {
                    _offset = 0;
                }

                return result;
            }
        }
    }
}