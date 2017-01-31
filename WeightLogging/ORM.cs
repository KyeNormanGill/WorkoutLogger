using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLogging
{
    class ORM
    {
        public static string ReadFile(string path)
        {
            string readText = File.ReadAllText(path);
            return readText;
        }

        public static void WriteFile(string path, string text)
        {
            string createText = text;
            File.WriteAllText(path, createText);
        }
    }
}
