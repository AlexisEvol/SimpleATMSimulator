using ElectronicCashier.DTOs;

namespace ElectronicCashier.Screens
{
    internal class MainScreen
    {
        public void MainScreenVisual()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("- 1. Deposit money.                      -");
            Console.WriteLine("- 2. Extract money.                      -");
            Console.WriteLine("- 3. Show all transactions.              -");
            Console.WriteLine("------------------------------------------");
        }
        public void MainScreenFunction(User user)
        {
            int selectedOption = int.Parse(Console.ReadLine());
            //Crear un objeto User que nos vendrá dado por parámetro

            switch (selectedOption)
            {
                case 1:
                    {
                        //Escribir en el JSON el nuevo valor del dinero
                    }
                    break;

                case 2:
                    {
                        //Escribir en el JSON el nuevo valor del dinero
                    }
                    break;

                case 3:
                    {
                        //Leer la lista del User de transacciones y imprimirla por pantalla
                    }
                    break;
            }
        }
    }
}
