# 210318
C# 2일차 메모장 만들기

```
Form1.cs
using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
 //       int Count(char deli, string str)    // str 문자열의 deli 구분자의 개수 + 1
 //       {
 //           string[] Strs = str.Split(deli);
 //           int n = Strs.Length;
 //           return n - 1;
 //       }
 //       string GetToKen(int index, char deli, string str)
 //       {
 //           string[] Strs = str.Split(deli);
 ////           int n = Strs.Length;
 //           string ret = Strs[index];
 //           return ret;
 //       }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();   // C++  DoModal
            if (ret == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;        // full path
                string fName1 = openFileDialog1.SafeFileName;   // file name only
                StreamReader sr = new StreamReader(fName);      // class 를 선언할때는 new keyword를 이용해서 생상자를 표시해주어야 한다
                                                                // 즉 c:FILE*    c++:CFile에 대응되는 C#에서 read를 위한 file open class이다.
                string buf = sr.ReadToEnd();
                tbMemo.Text = buf;
                sr.Close();
                int n = myLib.Count('\\', fName);       // fName에서의 '\\' 갯수
                string fName2 = myLib.GetToKen(n, '\\', fName);   // fName에서 마지막 문자열
                this.Text += $"     [{fName2}]";  // == 파일명
            }
        }

        // Save As...
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            DialogResult ret = saveFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return;

            string fName = saveFileDialog1.FileName;
            StreamWriter sw = new StreamWriter(fName);

            string buf = tbMemo.Text;
            sw.Write(buf);
            sw.Close();
        }

        //  1. file open 후 Memo 창에 표시한 경우 - 확인(o) 수정(x)
        //  2. New 메뉴 선택 후 문서 편집         - file명 없음
        //  3. 기존 문서 중 일부 수정             - open file명 있음

        int txtChanged = 0;
        private void tbMemo_TextChanged(object sender, EventArgs e)
        {
            
            if (true) txtChanged = 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtChanged == 1) 
            {

            }
        }

        private void mnuViewFont_Click(object sender, EventArgs e)
        {
            DialogResult ret = fontDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return;

            Font fnt = fontDialog1.Font;
            tbMemo.Font = fnt;

            //sbLabel1.Text = fnt.Name;
            //sbLabel2.Text = fnt.Size;
            SetFontInfo();

        }
        private void SetFontInfo()
        {
            sbLabel1.Text = tbMemo.Font.Name + $",  {tbMemo.Font.Height}";
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            tbMemo.Text = null;
        }

        private void mnuLinechange_Click(object sender, EventArgs e)
        {
            tbMemo.WordWrap = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetFontInfo();
        }
    }
}

```


```
myLib.cs
namespace myLibrary
{
    class myLib
    {
        public static int Count(char deli, string str)    // str 문자열의 deli 구분자의 개수 + 1
        {
            string[] Strs = str.Split(deli);
            int n = Strs.Length;
            return n - 1;
        }
        public static string GetToKen(int index, char deli, string str)
        {
            string[] Strs = str.Split(deli);
            string ret = Strs[index];
            return ret;
        }
    }
}

```








