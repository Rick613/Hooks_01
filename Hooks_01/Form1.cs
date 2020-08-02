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
using Hooks;

namespace Hooks_01
{
    public partial class Form1 : Form
    {
        
        Hook hHook = new Hook();
        int d;
        //static string  address = textBox1.Text.ToString();
        //public static string result2 = @"C:\Users\fk104\Desktop\测试文件.txt";
        //StreamWriter sw = File.AppendText(result2); //保存到指定路径
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("程序需要以管理员身份运行");
            hHook.GetKeysCode = new GetKeysCodeEventHandler(getKeysCodes);
            hHook.KeyDownEvent += new KeyEventHandler(KeysDownEvent);
            hHook.KeyUpEvent += new KeyEventHandler(KeysUpEvent);
            //hHook.KeyPressEvent += new KeyPressEventArgs(KeysPressEvent);
            //public event KeyPressEventHandler KeyPressEvent;
            //string result1 = @"C:\Users\fk104\Desktop\测试文件.txt";//结果保存到桌面
            //FileStream fs = new FileStream(result1, FileMode.Append);
            //StreamWriter wr = null;
            //wr = new StreamWriter(fs);
            //wr.WriteLine("测试！");
            //wr.Close();
        }

        public void getKeysCodes(int code)
        {
            richTextBox1.Text += ((Keys)code+"\t");

            //string result1 = @"C:\Users\fk104\Desktop\测试文件.txt";//结果保存到桌面
            //FileStream fs = new FileStream(result1, FileMode.Append);
            //StreamWriter wr = null;
            //wr = new StreamWriter(fs);
            //wr.WriteLine((Keys)code + " ");
            //wr.Close();
        }
        private void KeysDownEvent(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            d = DateTime.Now.Millisecond;
            richTextBox1.Text += ("检测到按下\t" + d+"\t");

            //string result1 = @"C:\Users\fk104\Desktop\测试文件.txt";//结果保存到桌面
            //FileStream fs = new FileStream(result1, FileMode.Append);
            //StreamWriter wr = null;
            //wr = new StreamWriter(fs);
            //wr.WriteLine("检测到按下 " + d);
            //wr.Close();


        }
        private void KeysUpEvent(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            int u = DateTime.Now.Millisecond;
            richTextBox1.Text += ("检测到弹起\t"+ u+"\t"+ "时间差为：" + (u - d) + "\n");
            //richTextBox1.Text += ("时间差为：" + (u-d)+"\n");

            //string result1 = @"C:\Users\fk104\Desktop\测试文件.txt";//结果保存到桌面
            //FileStream fs = new FileStream(result1, FileMode.Append);
            //StreamWriter wr = null;
            //wr = new StreamWriter(fs);
            //wr.WriteLine("检测到弹起 " + u + " " + "时间差为：" + (u - d) + " ");
            //wr.Close();
            
        }
        

        private void Button1_Click(object sender, EventArgs e)
        {
            hHook.Hook_Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            hHook.Hook_Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string result = richTextBox1.Text.ToString(); //输入文本
            //StreamWriter sw = File.AppendText(textBox1.Text.ToString()); //保存到指定路径
            StreamWriter sw = File.AppendText(@"C:\Users\测试文件.txt"); //保存到指定路径
            sw.Write(result);
            sw.Flush();
            sw.Close();
        }
    }
}
