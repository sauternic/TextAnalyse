using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextAnalyse
{
    class CTextAnalyse
    {
     //Fields
        private Stream Stream1;
        public string strText = "";
        public List<string> strList = new List<string>();
        public List<string> strWertigkeit = new List<string>();
        public List<Vork_Zeich> Vork_Zeich1 = new List<Vork_Zeich>();
        public List<Vork_Zeich> Vork_Zeich2 = new List<Vork_Zeich>();
        

        //Konstruktor
        public CTextAnalyse(Stream Stream1)
        {
            this.Stream1 = Stream1;
            Einlesen();
            Splitten();
            Wertigkeit();
            
            foreach (Vork_Zeich VZ in Vork_Zeich1)
            {
                Vork_Zeich2.Add(VZ);
            }
            Vork_Zeich2.Sort();
        }

       
        private void Einlesen()
        {
            //Um Byte-Werte Anzuschauen
            //int i;
            //int y;
            //while ((i = this.Stream1.ReadByte()) != -1)
            //{ y=i; }
            
            
            StreamReader SR = new StreamReader(this.Stream1, Encoding.UTF8); 
            this.strText = SR.ReadToEnd();

            //Ein paar Sonderzeichen die Stören Rausnehmen!! ;)
            strText = strText.Replace("\u202F", " ");
            strText = strText.Replace("\u2002", " ");
            strText = strText.Replace("\u2003", " ");
            
            strText = strText.Replace("‚", " ");
            strText = strText.Replace("‘", " ");
            strText = strText.Replace("„", " ");
            strText = strText.Replace("“", " ");
            strText = strText.Replace("—", " ");
            
            
            strText = strText.Replace("0", " ");
            strText = strText.Replace("1", " ");
            strText = strText.Replace("2", " ");
            strText = strText.Replace("3", " ");
            strText = strText.Replace("4", " ");
            strText = strText.Replace("5", " ");
            strText = strText.Replace("6", " ");
            strText = strText.Replace("7", " ");
            strText = strText.Replace("8", " ");
            strText = strText.Replace("9", " ");
        } 
  
        private void Splitten()
        {
            string[] strArr = strText.Split(new String[] { " ", "*", ";", ":", "?", "!", "+", "(",")", "[", "]", "\\", "/", "\"", ",", ".", ",", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //Umwandeln in eine List! :)
            this.strList = strArr.ToList();
            //Sortieren
            this.strList.Sort();
            
            int i = this.strList.Count;
            // Alles was kürzer als 2 Rausnehmen!!
            for (int x = 0; x < i; ++x)
            {
                if (strList[x].Length < 2)
                {
                    this.strList.RemoveAt(x);
                    --x;
                }
                //An die neue Länge Anpassen
                i = this.strList.Count;
            }
        }
        
        private void Wertigkeit()
        {
            int zahlen = 1;
            int x;
            int vergleich = 0;

            for (x = 0; x < this.strList.Count - 1; ++x)
            {
                if ((vergleich = String.Compare(strList[x], strList[x + 1])) == 0) 
                //if (this.strList[x] == this.strList[x + 1])
                {
                    ++zahlen;


                }
                else
                {
                    strWertigkeit.Add("Vorkommen:" + zahlen + "  " + strList[x]);
                    Vork_Zeich1.Add(new Vork_Zeich(zahlen, strList[x]));
                    zahlen = 1;
                }

            }
            //Für den letzten Durchgang! :)
            strWertigkeit.Add("Vorkommen:" + zahlen + "  " + strList[x]);
            Vork_Zeich1.Add(new Vork_Zeich(zahlen, strList[x]));
            zahlen = 1;
        }


        public struct Vork_Zeich : IComparable
        {
            public int Vorkommen;
            public string Zeichen;

            //Konstruktor
            public Vork_Zeich(int Vorkommen, string Zeichen)
            {
                this.Vorkommen = Vorkommen;
                this.Zeichen = Zeichen;
                
            }
      
            public int CompareTo(object obj)
            {
                Vork_Zeich VZ = (Vork_Zeich)obj;
                if (this.Vorkommen > VZ.Vorkommen)
                    return 1;
                if (this.Vorkommen < VZ.Vorkommen)
                    return -1;
                else
                    return 0;  
            }
        }
    }  
}
