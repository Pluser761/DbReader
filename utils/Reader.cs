using System;
using System.IO;
using System.Collections.Generic;

using firstApp.Interfaces;

namespace firstApp.Reader {
    class Reader {
        private string filePath;
        private StreamReader sr;
        private List<ISource> result;
        private Dictionary<string, ISource> settings;

        public Reader(string filePath, Dictionary<string, ISource> settings) {
            this.filePath = filePath;
            this.settings = settings;
        }

        public List<ISource> getData() {
            this.sr = new StreamReader(this.filePath);
            result = null;
            string line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return null;
        }

        private void getParams() {
            
        }
}
}