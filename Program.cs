using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAnalyse
{
    /*
        Anleitung:

        Es müssen nur das Eingabe File und das Ausgabe File,
        angegeben werden.
            
    */
    class Program
    {

        static void Main(string[] args)
        {
            //Eingabe File Angeben im ersten Argument:
            Stream fs = new FileStream("C:\\Ausgabe\\Zu_analysierenden_Text.txt", FileMode.Open);

            CTextAnalyse TA = new CTextAnalyse(fs);

            int x = 0;
            string[] strArr = new string[TA.Vork_Zeich1.Count];
           
            
            foreach (CTextAnalyse.Vork_Zeich VZ in TA.Vork_Zeich1)
            { 
                strArr[x] = ("Vorkommen: " + VZ.Vorkommen + "   " + "Wort: " + VZ.Zeichen);
               
                x++;
            }
            File.WriteAllLines("C:\\Ausgabe\\Analyse1.txt", strArr, Encoding.UTF8);

           
            x = 0;
            foreach (CTextAnalyse.Vork_Zeich VZ in TA.Vork_Zeich2)
            {
                strArr[x] = ("Vorkommen: " + VZ.Vorkommen + "   " + "Wort: " + VZ.Zeichen);
                
                x++;
            }
            //Ausgabe File Angeben im ersten Argument:
            File.WriteAllLines("C:\\Ausgabe\\Ausgabe.txt", strArr,Encoding.UTF8);
        }
    }
}
