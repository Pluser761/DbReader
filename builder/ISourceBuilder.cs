using System.Collections.Generic;

using firstApp.Model.Interfaces;

namespace firstApp.SourceBuilder.Interfaces {
    interface ISourceBuilder {
        public string ToString();
        public ISource build(string name, Dictionary<string, string> currentParams);
    }
}