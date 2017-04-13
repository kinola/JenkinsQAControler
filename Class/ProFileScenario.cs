using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsControls.Class
{
    class ProFileScenario
    {
        public Dictionary<string, string> steps = null;

        private IniData _data;

        public ProFileScenario(IniData data)
        {
            steps = new Dictionary<string, string>();
            this._data = data;
            Initialize();
        }

        private void Initialize()
        {
            var scenario = this._data["SCENARIO-AUTO"];
            foreach (var value in scenario)
            {
                steps.Add(value.Value.Split(',')[0], value.Value.Split(',')[1]);
            }
        }
    }
}
