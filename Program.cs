using System;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.SourceBuilder.Interfaces;
using firstApp.SourceBuilder;
using firstApp.Readers;

namespace firstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISourceBuilder> settings = new Dictionary<string, ISourceBuilder>() {
                { "File", new FileSourceBuilder() },
                { "Srvr", new DataBaseSourceBuilder() }
            };
 
            Reader reader = new Reader("data.txt", settings);
            List<ISource> list = reader.getData();

            foreach (ISource source in list) {
                Console.WriteLine(source);
            }
        }
    }
}
