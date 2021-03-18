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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        bool status = false;
        //bool변수에는 1,0이 아닌  true, false를 넣어야 함
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (status)
            {
                btnTest.Text = "버튼테스트 1";
            }
            else
            {
                btnTest.Text = "버튼테스트 2";
            }
            status = !status;
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return;     // 파일이 선택되지 않으면 리턴

            string fName = openFileDialog1.FileName;    // File full path
            StreamReader sr = new StreamReader(fName);
            string buf = sr.ReadToEnd();
            sr.Close();
            tbMemo.Text = buf;
            
            //sr.Read();
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            DialogResult ret = saveFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel) return;     // 파일이 선택되지 않으면 리턴

            string fName = saveFileDialog1.FileName;    // File full path
            StreamWriter sw = new StreamWriter(fName);  // save 이므로 Write
                                                        // StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            string buf = tbMemo.Text;                   // 굳이 필요 없는 단계임
            sw.Write(buf);                              // 한줄로 sw.Write(tbMemo.text); 로 쓸 수 있음
            sw.Close();                                 // 닫기 필수
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string src = tb1.Text;		// c++ CString
            string dst = src.ToUpper();	// CString str; 
            tb2.Text = dst;				// str.Format("%d", n);
            int n = src.Length;			// SetWindowTest(str);
            //string etc = "문자열의 길이는 " + n + "입니다";
            string etc = $"변환된 문자열은 \"{dst}\"이고 문자열의 길이는 {n,5:c} 입니다";    // 5는 자릿수 x->16진수로 찍어라
            tb3.Text = etc;
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();   // 처음에 생성자를 호출해야함
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                tb4.Text = frm2.cb1.Text + "\r\n" +
                           frm2.cb2.Text + "\r\n" +
                           frm2.cb3.Text;
            }            
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}