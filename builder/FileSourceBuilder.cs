using System.Text.RegularExpressions;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.Model;

namespace firstApp.SourceBuilder {
    class FileSourceBuilder : BaseSource {
        public FileSourceBuilder() : base() {
            
        }

        public override ISource build(string name, Dictionary<string, string> currentParams) {
            FileSource source = new FileSource(name);
            string path = Regex.Match(currentParams["Connect"].Split('=')[1], "\\\"(.*?)\\\"").Groups[1].Value;
            source.File = path;
            return source;
        }
    }
}