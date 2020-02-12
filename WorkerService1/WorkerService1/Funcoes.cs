using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WorkerService1
{
    static class Funcoes
    {

        public static void AppendToFile(string FileName, string Value)
        {
            if (!File.Exists(FileName))
            {
                using StreamWriter sw = File.CreateText(FileName);
            }

            using (StreamWriter sw = File.AppendText(FileName))
            {
                sw.WriteLine(Value);
            }
        }
    }
}
