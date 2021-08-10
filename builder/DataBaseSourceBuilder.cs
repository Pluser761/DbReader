using System.Text.RegularExpressions;

using firstApp.Model;
using firstApp.Model.Interfaces;
using firstApp.Parser;
using firstApp.SourceBuilder.Interfaces;

namespace firstApp.SourceBuilder {
    class DataBaseSourceBuilder : ISourceBuilder {
        public DataBaseSourceBuilder() {
            
        }

        public ISource build(RawData rawData) {
            DataBaseSource source = new DataBaseSource(rawData.Name);
            string[] connectSplit = rawData.Parameters["Connect"].Split(';');
            string host = Regex.Match(connectSplit[0], "\\\"(.*?)\\\"").Groups[1].Value;
            string baseName = Regex.Match(connectSplit[1], "\\\"(.*?)\\\"").Groups[1].Value;
            string port = "";
            if (host.Contains(':')) {
                string[] hostSplit = host.Split(':');
                host = hostSplit[0];
                port = hostSplit[1];
            }
            source.BaseName = baseName;
            source.Host = host;
            source.Port = port;
            return source;
        }
    }
}