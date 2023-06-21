using System.Windows;
using System.Windows.Controls;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Controls
{
    [TemplateVisualState(Name = VisualStates.StateHidden, GroupName = VisualStates.GroupVisibility)]
    [TemplateVisualState(Name = VisualStates.StateHidden, GroupName = VisualStates.GroupVisibility)]
    [TemplateVisualState(Name = VisualStates.StateHidden, GroupName = VisualStates.GroupVisibility)]
    [TemplateVisualState(Name = VisualStates.StateHidden, GroupName = VisualStates.GroupVisibility)]
    public class WobbleContentControl : ContentControl
    {
        public const string StateCenter = "Center";
        public const string StateDown = "Down";
        public const string StateLeft = "Left";
        public const string StateRight = "Right";
        public const string StateUp = "Up";

        /// <summary>
        /// 标识 Direction 依赖属性。
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register(nameof(Direction), typeof(Direction), typeof(WobbleContentControl), new PropertyMetadata(Direction.Left));

        public WobbleContentControl()
        {
            this.DefaultStyleKey = typeof(WobbleContentControl);
        }

        /// <summary>
        /// 获取或设置Direction的值
        /// </summary>
        public Direction Direction
        {
            get => (Direction)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        public void Wobble()
        {
            switch (Direction)
            {
                case Direction.Left:
                    Wobble(StateLeft);
                    break;

                case Direction.Right:
                    Wobble(StateRight);
                    break;

                case Direction.Up:
                    Wobble(StateUp);
                    break;

                case Direction.Down:
                    Wobble(StateDown);
                    break;

                default: break;
            }
        }

        public void Wobble(string state)
        {
            VisualStateManager.GoToState(this, StateCenter, false);
            VisualStateManager.GoToState(this, state, true);
        }
    }
}