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
            int rndNum = randomNumber(1, maxQ);
            int Qindex = findNode(rndNum, docQ);

            string str = docQ.DocumentElement.ChildNodes[Qindex].Attributes.GetNamedItem("ID").Value;
            str += " - ";
            str += docQ.DocumentElement.ChildNodes[Qindex].InnerText;

            lbTest.Text = str;

            fillAnswers(Qindex, docA);

        }

        //Function to find XMLNode index with given ID
        private int findNode(int index, XmlDocument doc)
        {
            int count = doc.DocumentElement.ChildNodes.Count;
            for (int i=0; i<count;i++)
            {
                if (doc.DocumentElement.ChildNodes[i].Attributes.GetNamedItem("ID").Value == index.ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        //Function to randomice answers
        private void fillAnswers(int index, XmlDocument doc)
        {
            int count = doc.DocumentElement.ChildNodes[index].ChildNodes.Count;
            List<int> luvut = new List<int>();
            int newNum = 0;
            int itIsLoop = 0;
            //Randomice 4 number (node index values)
            while(luvut.Count < 4 && itIsLoop < 10000)
            {
                newNum = randomNumber(0, count-1);
                itIsLoop++;

                if ( !luvut.Contains(newNum))  //If not all ready exist
                {
                    if (luvut.Count == 3)   //if last round check for correct asnwer
                    {
                        for (int k = 0; k < count; k++)
                        {
                            if (doc.DocumentElement.ChildNodes[index].ChildNodes[k].Attributes.GetNamedItem("att").Value == "True")
                            {
                                if (luvut.Contains(k))
                                {
                                    luvut.Add(newNum);
                                }
                                else
                                {
                                    luvut.Add(k);  //add missing answer
                                }
                            }
                        }
                    }
                    else
                    {
                        luvut.Add(newNum);  //add new number
                    }
                    
                }
            }

            btnAns1.Text = doc.DocumentElement.ChildNodes[index].ChildNodes[luvut[0]].InnerText;
            btnAns2.Text = doc.DocumentElement.ChildNodes[index].ChildNodes[luvut[1]].InnerText;
            btnAns3.Text = doc.DocumentElement.ChildNodes[index].ChildNodes[luvut[2]].InnerText;
            btnAns4.Text = doc.DocumentElement.ChildNodes[index].ChildNodes[luvut[3]].InnerText;

        }




        //Function to generate random number
        private int randomNumber(int min, int max)
        {
            return rnd1.Next(min, max + 1);
        }
    }
}