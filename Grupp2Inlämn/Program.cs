using System;

namespace Grupp2Inlämn
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount sa = new SavingsAccount();
            Console.WriteLine(sa.getInfo());
        }
    }
}
