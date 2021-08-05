using System.Text.RegularExpressions;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.Model;
using firstApp.SourceBuilder.Interfaces;

namespace firstApp.SourceBuilder {
    class DataBaseSourceBuilder : ISourceBuilder {
        public DataBaseSourceBuilder() {
            
        }

        public ISource build(string name, Dictionary<string, string> currentParams) {
            DataBaseSource source = new DataBaseSource(name);
            string[] connectSplit = currentParams["Connect"].Split(';');
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