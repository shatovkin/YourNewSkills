using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace NewSkills.Controller
{
    public class LicenseServiceController
    {
        public int getLincenceRequest(string licenseNumber)
        {
            if (!licenseNumber.Equals("empty"))
            {
                int numberOne = int.Parse(licenseNumber.Substring(3, 1));
                int numberTwo = int.Parse(licenseNumber.Substring(8, 1));
                int numberThree = int.Parse(licenseNumber.Substring(11, 1));
                int numberFour = int.Parse(licenseNumber.Substring(17, 1));

                return numberOne + numberTwo - numberThree + numberFour + 19804;
            }
            return 0; 
        }

        public string getBookHyperLink(string bookNumber)
        {
            try
            {
                //Create a request and get Response in a xml
                WebClient webClient = new WebClient();
                webClient.QueryString.Add("bookNumber", bookNumber);
                var result = webClient.DownloadString("http://autorization.yournewskills.ru/LicenseService.asmx/getBookHyperLinkRequest");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);

                var bookHyperLink = xmlDoc.GetElementsByTagName("HyperLink")[0].InnerText;

                return bookHyperLink;
            }
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                return "";
            } 
        }
    }
}
