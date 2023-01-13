using ElectronicCashier.Screens;

namespace ElectronicCashier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartScreen startScreen = new StartScreen();
            startScreen.StartScreenVisual();
            startScreen.StartScreenFunction();
        }
    }
}