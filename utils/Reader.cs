using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.SourceBuilder.Interfaces;


namespace firstApp.Readers {
    class Reader {
        private string filePath;
        private StreamReader sr;
        private List<ISource> result;
        private Dictionary<string, ISourceBuilder> settings;
        private string tempLine;

        public Reader(string filePath, Dictionary<string, ISourceBuilder> settings) {
            this.filePath = filePath;
            this.settings = settings;
        }

        public List<ISource> getData() {
            string name = "";
            Dictionary<string, string> currentParams = new Dictionary<string, string>();
            this.sr = new StreamReader(this.filePath);
            this.tempLine = sr.ReadLine();
            while (this.tempLine != null)
            {
                if (this.tempLine != "") {
                    if (currentParams.ContainsKey("Connect")) {
                        string[] connectSettings = currentParams["Connect"].Split('=');
                        ISourceBuilder sourceBuilder;
                        if (this.settings.ContainsKey(connectSettings[0])) {
                            sourceBuilder = this.settings[connectSettings[0]];
                            ISource source = sourceBuilder.build(name, currentParams);
                        }
                    }
                    currentParams = new Dictionary<string, string>();
                }
                if (this.tempLine[0] == '[' && this.tempLine[this.tempLine.Length - 1] == ']') {
                    this.tempLine = this.tempLine.Substring(1, this.tempLine.Length - 2);
                    name = this.tempLine;
                }
                else {
                    this.getParams(currentParams);
                }
                this.tempLine = sr.ReadLine();
            }
            sr.Close();




            return null;
        }

        private void getParams(Dictionary<string, string> additionalParams) {
            while (this.tempLine != "" && this.tempLine != null)
            {
                string[] spl = this.tempLine.Split('=', 2);
                additionalParams.Add(spl[0], spl[1]);
                this.tempLine = sr.ReadLine();
            }
        }
}
}