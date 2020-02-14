
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace AutoComplete
{
   
    public class fileop
    {
        public List<pair> parse_file()
        {
            OpenFileDialog ff = new OpenFileDialog();
            ff.ShowDialog();
            FileStream FS = new FileStream(ff.FileName, FileMode.Open);

            //FileStream FS = new FileStream("E:\\FCIS\\FCIS_Projects\\3 th\\AutoComplete\\AutoComplete\\bin\\Debug\\Search_Links_(Large).txt", FileMode.Open);
            StreamReader SR = new StreamReader(FS);
            string file = SR.ReadToEnd();
            const char newline_delimeter = '\n';
            const char inline_delimeter = ',';
            FS.Close();
            SR.Close();
            string[] blocks = file.Split(new char[] { newline_delimeter }, StringSplitOptions.RemoveEmptyEntries);
            string[] tmp_line = new string[2];
            List<pair> iline = new List<pair>();

            for (int i = 0; i < blocks.Count(); i++)
            {
                if (i == 0)
                    continue;
                int j = 0;
                tmp_line = blocks[i].Split(new char[] { inline_delimeter }, StringSplitOptions.RemoveEmptyEntries);
                pair tmp = new pair(long.Parse(tmp_line[j]), tmp_line[j + 1]);
                iline.Add(tmp);
            }
            return iline;

        }
       // E:\College\AutoComplete\AutoComplete
        public string[] parse_Dictionary()
        {
            OpenFileDialog ff = new OpenFileDialog();
            ff.ShowDialog();
            FileStream FS = new FileStream(ff.FileName, FileMode.Open);
           // FileStream FS = new FileStream("E:\\FCIS\\FCIS_Projects\\3 th\\AutoComplete\\AutoComplete\\bin\\Debug\\Dictionary (Large).txt", FileMode.Open);
            StreamReader SR = new StreamReader(FS);
            string file = SR.ReadToEnd();
            const char newline_delimeter = '\n';
            FS.Close();
            SR.Close();
            string[] blocks = file.Split(new char[] { newline_delimeter }, StringSplitOptions.RemoveEmptyEntries);
            return blocks;

        }
        public string[] parse_line( string sentence)
        {
            const char space_delimeter = ' ';
            string[] words = sentence.Split(new char[] { space_delimeter }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}
