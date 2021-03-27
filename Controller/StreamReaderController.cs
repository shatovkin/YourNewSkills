using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace NewSkills.Controller
{
    class StreamReaderController
    {
        public string[] file { get; set; }
        public static string WholeSampleText { get; set; }
        public StreamReaderController(string fileName)
        {

            string sampleText = "";

            if (Properties.Settings.Default.TypingText == 0)
            {
                sampleText = getFileContent("inputText1", "txt");
            }
            else if (Properties.Settings.Default.TypingText == 1)
            {
                sampleText = getFileContent("inputText2", "txt");
            }
            else if (Properties.Settings.Default.TypingText == 2)
            {
                sampleText = getFileContent("inputText3", "txt");
            }
            else if (Properties.Settings.Default.TypingText == 3)
            {
                sampleText = getFileContent("inputText4", "txt");
            }
            else if (Properties.Settings.Default.TypingText == 4)
            {
                sampleText = getFileContent("inputText5", "txt");
            }
            else if (Properties.Settings.Default.TypingText == 5)
            {
                sampleText = getFileContent("inputText6", "txt");
            }

            WholeSampleText = sampleText;
            file = sampleText.Split('\n');
        }


        public static void writeLetter(char letter, int hashCode)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string filePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith("logs.txt"));

            // Create a file to write to.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(String.Format("\nLetter " + letter + ": Hashcode:" + hashCode + "\n"));
            }
        }


        public void writeLogs(string className, Exception exeption)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string filePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith("logs.txt"));

            // Create a file to write to.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(exeption, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                sw.WriteLine(String.Format("\nClass:" + className + " Exception: " + exeption.ToString() + "Line: " + line + "\n"));
            }
        }

        public static string getFileContent(string fileName, string fileExtension)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string name = "NewSkills.Resources." + fileName + "." + fileExtension;

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
