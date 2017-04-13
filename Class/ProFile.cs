using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsControls.Class
{
    class ProFile
    {
        Dictionary<string, string> scenario = null;
        FileIniDataParser parser = null;
        IniData data = null;

        public enum BooleanCheck { YES, NO };

        List<string> obsoleteSections = new List<string>() { "PARAMETRES_035" };
        List<string> obsoleteSteps = new List<string>() { "90035" };

        public ProFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new Exception($"Fichier {file} innacessible");
            }

            parser = new FileIniDataParser();
            data = parser.ReadFile(file);

            var proFileScn = new ProFileScenario(data);
            scenario = proFileScn.steps;
        }

        public BooleanCheck ExistSection(string section)
        {
            return data[section].Count() > 0 ? BooleanCheck.YES : BooleanCheck.NO;
        }

        public BooleanCheck IsObseleteStep(string step)
        {
            return obsoleteSteps.Contains(step) ? BooleanCheck.YES : BooleanCheck.NO;
        }

        public BooleanCheck IsObseleteSection(string section)
        {
            return obsoleteSections.Contains(section) ? BooleanCheck.YES : BooleanCheck.NO;
        }
    }
}
