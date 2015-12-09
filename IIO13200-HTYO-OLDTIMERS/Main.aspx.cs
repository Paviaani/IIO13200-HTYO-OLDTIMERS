using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace IIO13200_HTYO_OLDTIMERS
{
    public partial class Main1 : System.Web.UI.Page
    {
        private Random rnd1 = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            //lbTest.Text = scrLevyt.Data.ToString();

            //lbTest.Text = doc.InnerXml.ElementAt(2).ToString();
            //lbTest.Text = doc.DocumentElement.ChildNodes[0].InnerXml.ToString();
            InitSystem();
        }

        private void InitSystem()
        {
            //open file and random one quesson
            XmlDocument docQ = new XmlDocument();
            XmlDocument docA = new XmlDocument();
            docQ.Load(Server.MapPath("~/App_Data/Questions.xml"));
            docA.Load(Server.MapPath("~/App_Data/Answers.xml"));
            int maxQ = docQ.DocumentElement.ChildNodes.Count;
            int rndNum = randomNumber(0, maxQ-1);
            rndNum = 0;

            string str = docQ.DocumentElement.ChildNodes[rndNum].Attributes.GetNamedItem("ID").Value;
            str += " - ";
            str += docQ.DocumentElement.ChildNodes[rndNum].InnerText;

            lbTest.Text = str;
            btnAns1.Text = docA.DocumentElement.ChildNodes[rndNum].ChildNodes[0].InnerText;
            btnAns2.Text = docA.DocumentElement.ChildNodes[rndNum].ChildNodes[1].InnerText;
            btnAns3.Text = docA.DocumentElement.ChildNodes[rndNum].ChildNodes[2].InnerText;
            btnAns4.Text = docA.DocumentElement.ChildNodes[rndNum].ChildNodes[3].InnerText;
        }


        //Function to generate random number
        private int randomNumber(int min, int max)
        {
            return rnd1.Next(min, max + 1);
        }
    }
}