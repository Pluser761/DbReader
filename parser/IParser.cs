using System.Collections.Generic;
using System.IO;

namespace firstApp.Parser.Interfaces {
    interface IParser {
        StreamReader StreamReader { get; set; }
        public List<RawData> getData();
    }
}
