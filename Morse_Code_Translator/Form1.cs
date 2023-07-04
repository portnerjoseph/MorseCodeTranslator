using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Morse_Code_Translator
{
    public partial class Form1 : Form
    {
        public string[] morse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", ".-.-", ".--.-", "----", "..-..", "--.--", "---.", "..--", ".-.-.-", "--..--", "---...", "..--..", ".----.", "-....-", "-..-.", ".-..-.", ".--.-.", "-...-" };
        public string[] text = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Ä", "Á", "Ch", "É", "Ñ", "Ö", "Ü", ".", ",", ":", "?", "'", "‐", "/", "\"", "@", "=" };
        public Dictionary<string, string> morseToText;
        public Dictionary<string, string> textToMorse;

        public Form1()
        {
            InitializeComponent();
            morseToText = arrToDic(morse, text);
            textToMorse = arrToDic(text, morse);
        }

        private Dictionary<string,string> arrToDic(string[] arr1,string[] arr2)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            for (int x = 0; x < Math.Min(arr1.Length, arr2.Length); x++)
            {
                if (!temp.ContainsKey(arr1[x]))
                    temp.Add(arr1[x], arr2[x]);
            }
            return temp;
 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
    
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            string[] temp = richTextBox1.Text.Split(' ');
            string output = "";
            for(int x=0;x<temp.Length;x++)
            {
                output += toMorse(temp[x])+ " | ";
            }
            richTextBox2.Text = output.TrimEnd();
        }
        public string toMorse(string str)
        {
            str.Trim();
            string output = "";
            for (int x = 0; x < str.Length; x++)
                if (textToMorse.ContainsKey(""+char.ToUpper(str[x])))
                    output += textToMorse["" + char.ToUpper(str[x])]+" ";
            return output.TrimEnd();

        }
       

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            richTextBox4.Text = "";
            string[] temp = Regex.Split(richTextBox3.Text, "\\s|\\|");
            string output = "";
            for (int x = 0; x < temp.Length; x++)
            {
               
                output += toWords(temp[x]) + " ";
            }
            richTextBox4.Text = output.TrimEnd();
        }
        public string toWords(string str)
        {
            str.Trim();
            string output = "";
            string[] temp = str.Split(' ');
            for (int x = 0; x < temp.Length; x++)
                if (morseToText.ContainsKey(temp[x]))
                    output += morseToText[temp[x]];
            return output.TrimEnd();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox4.Text);
        }

    }
}
