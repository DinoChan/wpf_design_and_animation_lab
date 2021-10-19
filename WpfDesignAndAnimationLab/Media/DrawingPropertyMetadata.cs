using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;

namespace WpfDesignAndAnimationLab.Media
{
    internal class DrawingPropertyMetadata : FrameworkPropertyMetadata
    {
        private DrawingPropertyMetadataOptions options;

        private PropertyChangedCallback propertyChangedCallback;

        static DrawingPropertyMetadata()
        {
            DrawingPropertyMetadata.DrawingPropertyChanged += new EventHandler<DrawingPropertyChangedEventArgs>((object sender, DrawingPropertyChangedEventArgs args) => {
                IShape shape = sender as IShape;
                if (shape != null && args.Metadata.AffectsRender)
                {
                    InvalidateGeometryReasons invalidateGeometryReason = InvalidateGeometryReasons.PropertyChanged;
                    if (args.IsAnimated)
                    {
                        invalidateGeometryReason |= InvalidateGeometryReasons.IsAnimated;
                    }
                    shape.InvalidateGeometry(invalidateGeometryReason);
                }
            });
        }

        public DrawingPropertyMetadata(object defaultValue) : this(defaultValue, DrawingPropertyMetadataOptions.None, null)
        {
        }

        public DrawingPropertyMetadata(PropertyChangedCallback propertyChangedCallback) : this(DependencyProperty.UnsetValue, DrawingPropertyMetadataOptions.None, propertyChangedCallback)
        {
        }

        public DrawingPropertyMetadata(object defaultValue, DrawingPropertyMetadataOptions options) : this(defaultValue, options, null)
        {
        }

        public DrawingPropertyMetadata(object defaultValue, DrawingPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback) : base(defaultValue, (FrameworkPropertyMetadataOptions)options, DrawingPropertyMetadata.AttachCallback(defaultValue, options, propertyChangedCallback))
        {
        }

        private DrawingPropertyMetadata(DrawingPropertyMetadataOptions options, object defaultValue) : base(defaultValue, (FrameworkPropertyMetadataOptions)options)
        {
        }

        private static PropertyChangedCallback AttachCallback(object defaultValue, DrawingPropertyMetadataOptions options, PropertyChangedCallback propertyChangedCallback)
        {
            DrawingPropertyMetadata drawingPropertyMetadatum = new DrawingPropertyMetadata(options, defaultValue)
            {
                options = options,
                propertyChangedCallback = propertyChangedCallback
            };
            return new PropertyChangedCallback(drawingPropertyMetadatum.InternalCallback);
        }

        private void InternalCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DrawingPropertyMetadata.DrawingPropertyChanged != null)
            {
                EventHandler<DrawingPropertyChangedEventArgs> eventHandler = DrawingPropertyMetadata.DrawingPropertyChanged;
                DrawingPropertyChangedEventArgs drawingPropertyChangedEventArg = new DrawingPropertyChangedEventArgs()
                {
                    Metadata = this
                };
                ValueSource valueSource = DependencyPropertyHelper.GetValueSource(sender, e.Property);
                drawingPropertyChangedEventArg.IsAnimated = valueSource.IsAnimated;
                eventHandler(sender, drawingPropertyChangedEventArg);
            }
            if (this.propertyChangedCallback != null)
            {
                this.propertyChangedCallback(sender, e);
            }
        }

        public static event EventHandler<DrawingPropertyChangedEventArgs> DrawingPropertyChanged;
    }
}
