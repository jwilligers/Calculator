using PolyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MajorProject
{
    class FunctionTable:Dictionary<string,string>
    {
        public FunctionTable()
        {
            addBuiltinFunctions();
        }
        public bool exists(string name)
        {
            return ContainsKey(name);
        }
        public string lookUpEquation(string name)
        {
            return this[name+"(x)"];
        }
        public void setValue(string name, string equation)
        {
            this[name] = equation;
        }
        public void addBuiltinFunctions()
        {
            /*this.Add("sin", "sin(val1)");
            this.Add("cos", "cos(val1)");
            this.Add("tan", "tan(val1)");*/
        }
        
        public string replaceAllFunctions(string body)
        {
            string result = "";


            using (StringReader reader = new StringReader(body))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        result += replaceAllFunctionsLine(line) + "\r\n";
                    }

                } while (line != null);
            }

            return body;
        }
        public string replaceAllFunctionsLine(string line)
        {
            if (line.Length>0 && line.Trim()[0] == '!') { 
                return line;
            }
            foreach (KeyValuePair<string, string> entry in this)
            {
                line = swapString(line, entry.Key);
            }
            return line;
        }
        public string swapString(string line, string function)
        {
            string swappedString = line.Replace(function, lookUpEquation(function).Replace("x", getArgument(line, function)));
            if (line != swappedString)
            {
                Console.WriteLine(line + " " + swappedString);
            }
            return swappedString;
        }
        public string getArgument(string line, string functionName) {

            return getBetween(line, functionName+"(", ")");
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
    }
}