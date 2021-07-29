using System;
using System.Collections.Generic;

using firstApp.Interfaces;
using firstApp.Sources;

namespace firstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISource> settings = new Dictionary<string, ISource>() {
                { "File", new FileSource() },
                { "Srvr", new DataBaseSource() }
            };

            
        }
    }
}
