using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BotyRenamer : Form
    {
        public BotyRenamer()
        {
            InitializeComponent();       
        }

        private void VisualizeNN_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        //variables
        string[] source; string[] destination; string replacement = "";

        //BUTTON1 
        private void button1_Click(object sender, EventArgs e)
        {       

            OpenFileDialog v1 = new OpenFileDialog();
            v1.Multiselect = true;
            v1.Title = "BotyRenamer";
            v1.ShowDialog();

            richTextBox1.Text = "";
            source = new string[v1.FileNames.Length];
            destination = new string[v1.FileNames.Length];

            int counter = 0;
            foreach (String file in v1.FileNames)
            {
                richTextBox1.Text = richTextBox1.Text + " " + file;

                source[counter] = file;
                counter=counter+1;         
            }

        }//button1 function ends

        //BUTTON2
        private void button2_Click_1(object sender, EventArgs e)
        {
             replacement = richTextBox2.Text;

            if (replacement.Length>0 && source !=null) 
            {
                for (int i = 0; i < source.Length; i++)
                {      
                    string actual = source[i];
                    string result = "";

                    result = Regex.Replace(actual, @"[\w.]+\.", replacement+$"{i + 1}"+".");    //richTextBox2.Text +"számozás" az legyen a destination tömb minden egyes elemének az utolsó \ és a .kiterjesztés közötti része
                    destination[i] = result;
                    try
                    {
                        File.Move(source[i], destination[i]);
                        richTextBox1.Text = "Sikeres művelet";
                    }
                    catch (Exception)
                    {
                        richTextBox1.Text = "Az újabb művelethez válasszon ismét fájlokat!";
                    }         
                }             
            }

            else if (replacement.Length == 0) 
            {
                richTextBox1.Text = "Adjon meg nevet!";
            }

            else if (source == null)
            {
                richTextBox1.Text = "Válasszon ki fáljokat!";
            }

        }//button2 function ends

    }

}
