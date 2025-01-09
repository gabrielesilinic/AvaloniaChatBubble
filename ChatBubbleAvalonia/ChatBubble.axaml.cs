using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Metadata;

namespace ChatBubbleAvalonia;

// Custom control representing a chat bubble with various customizable properties
public partial class ChatBubble : TemplatedControl
{
    // Define styled properties for binding and customization in XAML

    // Property to hold the content displayed within the chat bubble
    public static readonly StyledProperty<object> ContentProperty =
        AvaloniaProperty.Register<ChatBubble, object>(nameof(Content));

    // Property to set the background color of the chat bubble
    public static readonly StyledProperty<IBrush> BackgroundProperty =
        AvaloniaProperty.Register<ChatBubble, IBrush>(nameof(Background), Brushes.LightBlue);

    // Property to control the scaling of the chat bubble
    public static readonly StyledProperty<double> ScaleProperty =
        AvaloniaProperty.Register<ChatBubble, double>(nameof(Scale), 1.0);

    // Property to set the maximum width of the chat bubble
    public static readonly StyledProperty<double> MaxWidthProperty =
        AvaloniaProperty.Register<ChatBubble, double>(nameof(MaxWidth), 400);

    // Property to set the maximum height of the chat bubble
    public static readonly StyledProperty<double> MaxHeightProperty =
        AvaloniaProperty.Register<ChatBubble, double>(nameof(MaxHeight), 200);

    // Property to define the corner radius of the chat bubble for rounded edges
    public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
        AvaloniaProperty.Register<ChatBubble, CornerRadius>(nameof(CornerRadius), new CornerRadius(12));

    // Property to define the orientation of the chat bubble's tail ("Left" or "Right")
    public static readonly StyledProperty<string> TailOrientationProperty =
        AvaloniaProperty.Register<ChatBubble, string>(nameof(TailOrientation), "Left");

    // Define direct properties for template binding and calculated values

    // Property to hold the geometry that defines the bubble's shape, including the tail
    public static readonly DirectProperty<ChatBubble, Geometry> BubblePathProperty =
        AvaloniaProperty.RegisterDirect<ChatBubble, Geometry>(
            nameof(BubblePath), o => o.BubblePath);

    // Property to determine the horizontal alignment of the bubble's tail
    public static readonly DirectProperty<ChatBubble, HorizontalAlignment> TailHorizontalAlignmentProperty =
        AvaloniaProperty.RegisterDirect<ChatBubble, HorizontalAlignment>(
            nameof(TailHorizontalAlignment), o => o.TailHorizontalAlignment);

    // Constructor for initializing the chat bubble
    public ChatBubble()
    {
        InitializeComponent();
    }

    // Properties to expose the styled properties for use in code and XAML

    [Content]
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public IBrush Background
    {
        get => GetValue(BackgroundProperty);
        set => SetValue(BackgroundProperty, value);
    }

    public double Scale
    {
        get => GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }

    public double MaxWidth
    {
        get => GetValue(MaxWidthProperty);
        set => SetValue(MaxWidthProperty, value);
    }

    public double MaxHeight
    {
        get => GetValue(MaxHeightProperty);
        set => SetValue(MaxHeightProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public string TailOrientation
    {
        get => GetValue(TailOrientationProperty);
        set => SetValue(TailOrientationProperty, value);
    }

    // Calculate the horizontal alignment of the bubble's tail based on its orientation
    public HorizontalAlignment TailHorizontalAlignment => TailOrientation.ToLower() switch
    {
        "left" => HorizontalAlignment.Left,
        "right" => HorizontalAlignment.Right,
        _ => HorizontalAlignment.Left, // Default to left alignment if input is invalid
    };

    // Geometry defining the shape of the chat bubble, including the tail
    public Geometry BubblePath => GetBubblePath();

    // Private method to calculate the geometry of the chat bubble's shape and tail
    private Geometry GetBubblePath()
    {
        if (TailOrientation.ToLower() == "left")
        {
            // Geometry for a bubble with the tail on the top-left corner
            return Geometry.Parse(
                "M10.178719,13.678761 L10,120 Q10,130 20,130 L300,130 Q310,130 310,120 L310,10 Q310,0 300,0 L20,0 Q10,0 -4.2591108,0.13230088 z"
            );
        }
        else if (TailOrientation.ToLower() == "right")
        {
            // Geometry for a bubble with the tail on the bottom-right corner
            return Geometry.Parse(
                "M324.09163,10.198 Q305.57768,10 300,10 L20,10 Q10,10 10,20 L10,120 Q10,130 20,130 L300,130 Q310,130 310,120 L309.28812,25.348 z"
            );
        }

        // Default geometry for a bubble with no tail
        return Geometry.Parse(
            "M20,10 Q10,10 10,20 L10,120 Q10,130 20,130 L300,130 Q310,130 310,120 L310,20 Q310,10 300,10 Z"
        );
    }
}
