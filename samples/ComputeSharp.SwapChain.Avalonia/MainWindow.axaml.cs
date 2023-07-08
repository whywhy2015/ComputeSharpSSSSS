using System.Diagnostics;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Platform;
using ComputeSharp.SwapChain.Backend;
using ComputeSharp.SwapChain.Shaders;
using TerraFX.Interop.Windows;

namespace ComputeSharp.SwapChain.Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}

public sealed class ShaderPanel : NativeControlHost
{
    private readonly Win32Application application = Win32ApplicationFactory<ColorfulInfinity>.Create(static time => new((float)time.TotalSeconds));

    private Thread? renderThread;

    protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
    {
        IPlatformHandle platformHandle = base.CreateNativeControlCore(parent);

        this.application.OnInitialize((HWND)platformHandle.Handle);

        this.renderThread = new Thread(static args =>
        {
            ShaderPanel @this = (ShaderPanel)args!;

            Stopwatch startStopwatch = Stopwatch.StartNew();

            while (true)
            {
                @this.application.OnUpdate(startStopwatch.Elapsed);
            }
        });

        this.application.OnResize();

        this.renderThread.Start(this);

        return platformHandle;
    }
}
