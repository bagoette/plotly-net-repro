using Plotly.NET;
using Plotly.NET.CSharp;
using Plotly.NET.ImageExport;
using Plotly.NET.LayoutObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        try
        {
            RunPlotlyTests();
        }
        catch (Exception ex)
        {
            var a = ex;
        }
    }

    private static void RunVideoConverter()
    {
        var filenames = new[] { "PokerCoaching-1.mp4", "PokerCoaching-2.mp4" };

        var mpg = new FFMpegConverter();
        var settings = new ConcatSettings();

        mpg.ConcatMedia(filenames, "Combined.mp4", Format.mp4, settings);

        var a = 1;
    }

    private static void RunPlotlyTests()
    {
        var combined = trace1.Concat(trace2);

        var max = combined.Max();
        var min = combined.Min();

        var range = max - min;

        var half = max - (range / 2);
        var buffer = range * 0.1;

        var topStart = half + buffer;
        var botStart = half - buffer;

        var topColor = Color.fromRGB(255, 0, 0);
        var topRect = Shape.init<DateTime, DateTime, double, double>(
            FillColor: topColor,
            ShapeType: StyleParam.ShapeType.Rectangle,
            Line: Line.init(Color: topColor),
            Opacity: 0.15,
            X0: dates.First(),
            X1: dates.Last(),
            Y0: max + buffer,
            Y1: topStart);

        var botColor = Color.fromRGB(0, 255, 0);
        var botRect = Shape.init<DateTime, DateTime, double, double>(
            FillColor: botColor,
            ShapeType: StyleParam.ShapeType.Rectangle,
            Line: Line.init(Color: botColor),
            Opacity: 0.15,
            X0: dates.First(),
            X1: dates.Last(),
            Y0: botStart,
            Y1: min - buffer);

        var tempChart = Plotly.NET.CSharp.Chart
            .Line<DateTime, double, string>(dates, trace1, Name: "Temperature", ShowLegend: false);

        var tankChart = Plotly.NET.CSharp.Chart
            .Line<DateTime, double, string>(dates, trace2, Name: "Tank Voltage", ShowLegend: false);

        Plotly.NET.Chart
            .Combine(new[] { tempChart, tankChart })
            //.SingleStack<IEnumerable<GenericChart.GenericChart>>(Pattern: StyleParam.LayoutGridPattern.Coupled)
            //.Invoke(new[] { tempChart, tankChart })
            .WithShape(topRect)
            .WithShape(botRect)
            .WithYAxisStyle<double, double, string>("Voltage")
            .WithXAxisStyle<DateTime, DateTime, string>("Timestamp", AxisType: StyleParam.AxisType.Date)
            .SaveSVG("SingleChart", Width: 1000);
    }

    private static readonly List<DateTime> dates = new()
    {
        DateTime.Parse("2022-11-08T20:06:16.826Z"),
        DateTime.Parse("2022-11-08T20:06:16.827Z"),
        DateTime.Parse("2022-11-08T20:06:16.839Z"),
        DateTime.Parse("2022-11-08T20:06:16.863Z"),
        DateTime.Parse("2022-11-08T20:06:32.433Z"),
        DateTime.Parse("2022-11-08T20:06:32.619Z"),
        DateTime.Parse("2022-11-08T20:06:32.847Z"),
        DateTime.Parse("2022-11-08T20:06:32.926Z"),
        DateTime.Parse("2022-11-08T20:06:32.946Z"),
        DateTime.Parse("2022-11-08T20:06:48.416Z"),
        DateTime.Parse("2022-11-08T20:06:48.615Z"),
        DateTime.Parse("2022-11-08T20:06:48.633Z"),
        DateTime.Parse("2022-11-08T20:06:48.676Z"),
        DateTime.Parse("2022-11-08T20:06:48.822Z"),
        DateTime.Parse("2022-11-08T20:06:48.869Z"),
        DateTime.Parse("2022-11-08T20:06:48.933Z"),
        DateTime.Parse("2022-11-08T20:06:48.985Z"),
        DateTime.Parse("2022-11-08T21:50:21.883Z"),
        DateTime.Parse("2022-11-08T21:50:22.046Z"),
        DateTime.Parse("2022-11-08T21:50:22.119Z"),
        DateTime.Parse("2022-11-08T21:50:22.470Z"),
        DateTime.Parse("2022-11-08T21:50:22.572Z"),
        DateTime.Parse("2022-11-08T21:50:38.072Z"),
        DateTime.Parse("2022-11-08T21:50:44.577Z"),
        DateTime.Parse("2022-11-08T21:50:44.628Z"),
        DateTime.Parse("2022-11-08T21:50:45.143Z"),
        DateTime.Parse("2022-11-08T21:50:45.213Z"),
        DateTime.Parse("2022-11-08T21:50:45.355Z"),
    };

    private static readonly List<double> trace1 = new()
    {
        23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0,
        23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0, 23.0,
        23.0, 23.0
    };

    private static readonly List<double> trace2 = new()
    {
        14.0, 14.0, 12.0, 14.0, 14.0, 14.0, 14.0, 14.0, 14.0, 14.0, 14.0, 12.0, 12.0,
        12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0, 12.0,
        12.0, 12.0,
    };
}