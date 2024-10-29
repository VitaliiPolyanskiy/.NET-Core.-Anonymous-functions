using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Anonymous_methods
{
    // Лямбда-выражения представляют упрощенную запись анонимных методов. 
    // Лямбда-выражения позволяют создать лаконичные методы, которые могут
    // возвращать некоторое значение, и которые можно передать 
    // в качестве параметров в другие методы.

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

                AsyncCallback callback = ar =>
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


