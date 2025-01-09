using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBubbleAvalonia
{
    public class ChatBubbleCustomControl : TemplatedControl
    {
        public static readonly StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, object>(nameof(Content));

        public static readonly StyledProperty<double?> MaxWidthProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, double?>(nameof(MaxWidth));

        public static readonly StyledProperty<double?> MaxHeightProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, double?>(nameof(MaxHeight));

        public static readonly StyledProperty<double> ScaleFactorProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, double>(nameof(ScaleFactor), 1.0);

        public static readonly StyledProperty<bool> TailOnRightProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, bool>(nameof(TailOnRight), true);

        public static readonly StyledProperty<IBrush> BackgroundProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, IBrush>(nameof(Background));

        public static readonly StyledProperty<IBrush> ForegroundProperty =
            AvaloniaProperty.Register<ChatBubbleCustomControl, IBrush>(nameof(Foreground));

        static ChatBubbleCustomControl()
        {
            BackgroundProperty.OverrideDefaultValue<ChatBubbleCustomControl>(Brushes.LightGray);
            ForegroundProperty.OverrideDefaultValue<ChatBubbleCustomControl>(Brushes.Black);
        }

        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public double? MaxWidth
        {
            get => GetValue(MaxWidthProperty);
            set => SetValue(MaxWidthProperty, value);
        }

        public double? MaxHeight
        {
            get => GetValue(MaxHeightProperty);
            set => SetValue(MaxHeightProperty, value);
        }

        public double ScaleFactor
        {
            get => GetValue(ScaleFactorProperty);
            set => SetValue(ScaleFactorProperty, value);
        }

        public bool TailOnRight
        {
            get => GetValue(TailOnRightProperty);
            set => SetValue(TailOnRightProperty, value);
        }

        public IBrush Background
        {
            get => GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public IBrush Foreground
        {
            get => GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public ChatBubbleCustomControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
