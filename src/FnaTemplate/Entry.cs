using FnaTemplate._Driver;

namespace FnaTemplate;

file class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        FnaBootstrap.Bootstrap();
        
        var main = new Main();
        main.Run();
    }
}