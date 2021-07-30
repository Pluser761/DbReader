using System;
using System.Collections.Generic;

using firstApp.SourceBuilder.Interfaces;
using firstApp.Readers;
using firstApp.SourceBuilder;

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
            reader.getData();
        }
    }
}
