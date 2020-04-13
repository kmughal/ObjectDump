# Introduction

Create dump of object while debugging
In order to use this follow these steps:

- Add reference for this from nuget https://www.nuget.org/packages/ObjectDump/1.0.0
- See below code snippets how to use this:

```
            var list = new List<IPerson>();
            for (var i = 1; i < 10000; i++) list.Add(new Person { Name = "FAKE", Age = i });
            Debug.Dump.SaveDumpInFile(list);
            Task.Factory.StartNew(async () => await Debug.Dump.WriteDumpInStandardOutput(list, Console.Out)).Wait();
            Debug.Dump.SaveDumpInClipboard(list);
```

Feel free to change / fork this.
