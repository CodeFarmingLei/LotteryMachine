using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace 抽奖机
{
    public partial class FormMain : Form
    {
        //随机显示文本文件内的姓名
        string[] name = { "张三","李四","王五","赵六","徐七" };
        //记录空值
        int count = 1;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //用于显示按钮中文字
            if (button1.Text == "开始")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i].Equals(label1.Text))        //如果姓名数组[i]=当前输出文本
                    {
                        name[i] = "";           //姓名数组[i]=空文本
                        break;                     //退出循环
                    }
                }
                count++;                            //记录不为空的数值
                button1.Text = "结束"; timer1.Start();
            }
            else
            {
                //更新状态栏信息
                richTextBox1.Text = richTextBox1.Text + "第" + count + "名中奖用户是:" + label1.Text + "\n";
                button1.Text = "开始"; timer1.Stop();
            }

            //当仅剩最后一个人时提示抽奖结束并禁用控件
            if (count == name.Length)
            {
                //循环查找最后一个不为空的姓名并添加
                for (int i = 0; i < name.Length; i++)
                {
                    if (!(name[i].Equals("")))
                    {
                        //更新最后一名中奖人员状态栏信息
                        richTextBox1.Text = richTextBox1.Text + "第" + count + "名中奖用户是:" + name[i] + "\n";
                        break;
                    }
                }
                button1.Text = "抽奖结束";
                button1.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //随机显示字符串数组文字
            Random r = new Random();
            int i = r.Next(0, name.Length);

            for (int j=0;j<name.Length;j++)
            {
                if (name[i].Equals(""))                //如果姓名数组[i]=空文本
                {
                    continue;                             //继续循环查找
                }
                else
                {
                    label1.Text = name[i];          //输出当前文本
                    break;                                  //退出循环
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //主窗口加载时计时器开始
            timer1.Start();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //用于显示按钮中文字
                if (button1.Text == "开始")
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[i].Equals(label1.Text))        //如果姓名数组[i]=当前输出文本
                        {
                            name[i] = "";           //姓名数组[i]=空文本
                            break;                     //退出循环
                        }
                    }
                    count++;                            //记录不为空的数值
                    button1.Text = "结束"; timer1.Start();

                    //当仅剩最后一个人时提示抽奖结束并禁用控件
                    if (count == name.Length)
                    {
                        //循环查找最后一个不为空的姓名并添加
                        for (int i=0;i<name.Length;i++)
                        {
                            if (!(name[i].Equals("")))
                            {
                                //更新最后一名中奖人员状态栏信息
                                richTextBox1.Text = richTextBox1.Text + "第" + count + "名中奖用户是:" + name[i] + "\n";
                                break;
                            }
                        }

                        button1.Text = "抽奖结束";
                        button1.Enabled = false;
                    }
                }
                else
                {
                    //更新状态栏信息
                    richTextBox1.Text = richTextBox1.Text + "第" + count + "名中奖用户是:" + label1.Text + "\n";
                    button1.Text = "开始"; timer1.Stop();
                }

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
