using System.IO;
using System.Collections.Generic;

namespace firstApp.Parser.Interfaces {
    interface IParser {
        StreamReader StreamReader { get; set; }
        public List<RawData> getData();
    }
}
