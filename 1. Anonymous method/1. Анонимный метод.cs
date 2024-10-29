using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Anonymous_methods
{
    // Иногда основанием для существования метода служит то обстоятельство, 
    // что он должен быть вызван только один раз посредством делегата. 
    // В подобных случаях можно воспользоваться анонимной функцией, чтобы не создавать отдельный метод.
    // Анонимная функция, по существу, представляет собой безымянный кодовый блок, 
    // передаваемый конструктору делегата. 
    // Преимущество анонимной функции состоит, в частности, в ее простоте. 
    // Благодаря ей отпадает необходимость объявлять отдельный метод, 
    // единственное назначение которого состоит в том, что он передается делегату.

    class Demo
    {
        public void UserInput()
        {
            string s;
            do
            {
                Console.WriteLine("Введите строку.");
                s = Console.ReadLine();
            } while (s.Length != 0);
        }

        public void AsyncRead()
        {
            FileInfo[] fi;
            try
            {
                DirectoryInfo di = new DirectoryInfo("../../../");
                fi = di.GetFiles("*.cs");
                long length = fi[0].Length;
                byte[] buf = new byte[length];

                FileStream f = new FileStream(fi[0].FullName, FileMode.Open, FileAccess.Read, FileShare.Read, buf.Length, true);
                // файл открывается в асинхронном режиме
                AsyncCallback callback = delegate(IAsyncResult ar) // содержит сведения о завершении операции
                {
                    int bytes = f.EndRead(ar);
                    Thread.Sleep(5000);
                    string str = Encoding.UTF8.GetString(buf);
                    Console.WriteLine(str);
                    Console.WriteLine("Считано " + bytes);
                    f.Close();
                };
                f.BeginRead(buf, 0, buf.Length, callback, null);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }

    class MainClass
    {
        public static void Main()
        {
            Demo d = new Demo();
            d.AsyncRead();
            d.UserInput();
        }
    }
}


