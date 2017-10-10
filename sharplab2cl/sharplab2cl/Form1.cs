using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using ClassAutoLab2;//class auto
namespace sharplab2cl
{
    public partial class Form1 : Form
    {
        TcpClient tcp_client = new TcpClient("localhost", 5555);
        ASCIIEncoding ae = new ASCIIEncoding();
        List<Auto> list = new List<Auto>();
        public Form1()
        {
            InitializeComponent();
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
            listBox1.Visible = false;
            checkBox1.Checked = true;
            list = new List<Auto>();

        }
        private void operation_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (radio_view.Checked == true)
                {
                    NetworkStream ns = tcp_client.GetStream();
                    String command = "view|";
                    bf.Serialize(ns, command);
                    list = (List<Auto>)bf.Deserialize(ns);
                    this.listBox1.Items.AddRange(list.ToArray());
                    this.listBox1.MultiColumn = true;
                    this.listBox1.ColumnWidth = 243;
                    listBox1.Visible = true;

                }
                else if (radio_add.Checked == true)
                {
                    NetworkStream ns = tcp_client.GetStream();
                    String data = marka.Text;
                    String str = model.Text;
                    int y = Convert.ToInt32(year.Text);
                    String command = "add";
                    String res = "|";
                    Auto a = new Auto(data, str, y);
                    list.Add(a);
                    bf.Serialize(ns, command + res + a + res);
                    String s1 = (String)bf.Deserialize(ns);
                    richTextBox1.Text += s1;
                }
                else if (radio_create.Checked == true)
                {

                }
                else if (radio_del.Checked == true)
                {

                }
                else if (radio_find.Checked == true)
                {

                }
            }
            catch (Exception ex)
            {
                Form2 errWindow = new Form2();
                errWindow.data("Ошибка :" + ex.Message);
                errWindow.Show();
            }
        }
        private void Serialize(Stream fstr)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (list.Count > 0)
            {
                int i = 0;
                while (i < list.Count)
                {
                    bf.Serialize(fstr, list.ElementAt(i));
                    i++;
                }
            }
            //  fstr.Close();
        }
        private List<Auto> Deserealize()
        {
            FileStream fstr = new FileStream("d:\\files\\ris\\lab2.txt", FileMode.OpenOrCreate, FileAccess.Read);
            list.Clear();
            StreamReader reader = new StreamReader(fstr); // создаем «потоковый читатель» и связываем его с файловым потоком 
            reader.ReadToEnd();
            if (fstr.Position == 0)
            {
                Console.Write("файл пуст\n");
            }
            else
            {
                long length = fstr.Position;
                fstr.Seek(0, SeekOrigin.Begin);
                BinaryFormatter bf = new BinaryFormatter();
                while (fstr.Position < length)
                {
                    Auto pr = (Auto)bf.Deserialize(fstr);
                    list.Add(pr);
                }
            }
            reader.Close();
            fstr.Close();
            return list;
        }
        private void radio_add_CheckedChanged(object sender, EventArgs e)
        {
            marka.Enabled = true;
            model.Enabled = true;
            year.Enabled = true;
            listBox1.Visible = false;
        }

        private void radio_view_CheckedChanged(object sender, EventArgs e)
        {
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
            listBox1.Visible = false;
        }

        private void radio_del_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
        }

        private void radio_create_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
        }

        private void radio_find_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                richTextBox1.Visible = true;
            }
            else
            {
                richTextBox1.Visible = false; ;
            }
        }
    }
}
