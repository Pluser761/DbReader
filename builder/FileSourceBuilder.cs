using System.Text.RegularExpressions;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.Model;
using firstApp.SourceBuilder.Interfaces;

namespace firstApp.SourceBuilder {
    class FileSourceBuilder : ISourceBuilder {
        public FileSourceBuilder() {
            
        }

        public ISource build(string name, Dictionary<string, string> currentParams) {
            FileSource source = new FileSource(name);
            string path = Regex.Match(currentParams["Connect"].Split('=')[1], "\\\"(.*?)\\\"").Groups[1].Value;
            source.File = path;
            return source;
        }
    }
}