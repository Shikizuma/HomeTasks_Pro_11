namespace HomeTasks_Pro_11
{
    /*
        Завдання 2

        Створіть консольну програму, 
        яка в різних потоках зможе отримати доступ до 2-х файлів. 
        Вважайте з цих файлів вміст і спробуйте записати отриману інформацію в третій файл. 
        Читання/запис мають здійснюватися одночасно у кожному з дочірніх потоків. 
        Використовуйте блокування потоків для того, щоб досягти коректного запису в кінцевий файл.
     */
    internal class Program
    {
        static object locker = new object();

        static void Main(string[] args)
        {
            
            Thread thread = new Thread(() => ReadFileAndWriteToAnother("TextFile1.txt"));
            Thread thread2 = new Thread(() => ReadFileAndWriteToAnother("TextFile2.txt"));
            thread.Start();
            thread2.Start();
        }

        static void ReadFileAndWriteToAnother(string path)
        {
            
            string res;
            using (StreamReader sr = new StreamReader(path)) 
            {
                res = sr.ReadToEnd();
            }

            lock(locker)
            {
                using (StreamWriter sr = new StreamWriter("text.txt", true))
                {
                    sr.WriteLine(res);
                }
            }
        }
    }
}