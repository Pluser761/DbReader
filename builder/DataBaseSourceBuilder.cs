using System.Collections.Generic;

using firstApp.Model.Interfaces;

namespace firstApp.SourceBuilder {
    class DataBaseSourceBuilder : BaseSource {
        public DataBaseSourceBuilder() : base() {
            
        }

        public override ISource build(string name, Dictionary<string, string> currentParams) {
            return null;
        }
    }
}