using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace NewSkills
{
    public class KeyGenerator
    {

        //Function to get a random number 
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();


        public static void writeLicenseKeyToFile()
        {
            HashSet<string> listOfKeys = new HashSet<string>();

            for (int i = 0; i < 10000; i++)
            {
                listOfKeys.Add(generateLicenseKeyes()); 
            }
            writeKeysToFile(listOfKeys);
        }

      
        private static string generateLicenseKeyes()
        {
            lock (syncLock)
            { // synchronize

                int numberOne = random.Next(1000, 9999);
                int numberTwo = random.Next(1000, 9999);
                int numberThree = random.Next(1000, 9999);
                int numberFore = random.Next(1000, 9999);

                string result = numberOne + "-" + numberTwo + "-" + numberThree + "-" + numberFore; 

                return result.Trim();
            }
        }


        private static void writeKeysToFile(HashSet<String> keys)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string filePath = "C:\\Users\\dsh\\Documents\\Visual Studio 2015\\Projects\\NewSkills\\NewSkills\\View\\LicenseKeys.txt";


            foreach (var key in keys)
            {
                // Create a file to write to.
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(String.Format("INSERT INTO[dbo].[LicenseKeys] ([LicenseKey],[LicenseKeyUsed]) VALUES('" + key + "', 0);\n"));
                }
            }
        }
    }
}