using System.Text.RegularExpressions;

using firstApp.Model;
using firstApp.Model.Interfaces;
using firstApp.Parser;
using firstApp.SourceBuilder.Interfaces;

namespace firstApp.SourceBuilder {
    class FileSourceBuilder : ISourceBuilder {
        public FileSourceBuilder() {
            
        }

        public ISource build(RawData rawData) {
            FileSource source = new FileSource(rawData.Name);
            string path = Regex.Match(rawData.Parameters["Connect"].Split('=')[1], "\\\"(.*?)\\\"").Groups[1].Value;
            source.File = path;
            return source;
        }
    }
}