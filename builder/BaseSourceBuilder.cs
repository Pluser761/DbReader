using System.IO;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.SourceBuilder.Interfaces;

namespace firstApp.SourceBuilder
{
    abstract class BaseSource : ISourceBuilder {
        private Dictionary<string, string> additionalFields;

        public BaseSource() {
            
        }

        public abstract ISource build(string name, Dictionary<string, string> currentParams);
    }
}