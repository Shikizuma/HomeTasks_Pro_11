namespace Task4
{
    internal class Program
    {
        static int counter = 0;

        static object block = new object();

        static void Function()
        {
            for (int i = 0; i < 50; ++i)
            {
              
                Monitor.Enter(block); 

             
                Console.WriteLine(++counter);

             
                Monitor.Exit(block);
            }
        }

        static void Main()
        {
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            foreach (Thread thread in threads)
                thread.Start();

            // Delay
            Console.ReadKey();
        }
    }
}