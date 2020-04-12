namespace DumpConsole
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IPerson
    {
        string Name { get; set; }
        int Age { set; get; }
    }

    class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IPerson>();
            for (var i = 1; i < 10000; i++) list.Add(new Person { Name = "FAKE", Age = i });
            Debug.Dump.SaveDumpInFile(list);
            Task.Factory.StartNew(async () => await Debug.Dump.WriteDumpInStandardOutput(list, Console.Out)).Wait();
            Debug.Dump.SaveDumpInClipboard(list);
        }
    }
}
