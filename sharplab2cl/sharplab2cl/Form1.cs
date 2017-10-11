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
            listBox.Visible = false;
            checkBox1.Checked = true;
            list = new List<Auto>();

        }
        private void clearAdd()
        {
            marka.Text = "";
            model.Text = "";
            year.Text = "";
        }
        private void operation_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                NetworkStream ns = tcp_client.GetStream();

                if (radio_view.Checked == true)
                {
                    String command = "view|";
                    bf.Serialize(ns, command);
                    this.listBox.Items.Clear();
                    list = (List<Auto>)bf.Deserialize(ns);
                    this.listBox.Items.AddRange(list.ToArray());
                    this.listBox.MultiColumn = true;
                    this.listBox.ColumnWidth = 243;
                    listBox.Visible = true;

                }
                else if (radio_add.Checked == true)
                {
                    String data = marka.Text;
                    String str = model.Text;
                    int y = Convert.ToInt32(year.Text);

                    Auto a = new Auto(data, str, y);
                    list.Add(a);
                    bf.Serialize(ns, "add|" + a + "|");
                    String s1 = (String)bf.Deserialize(ns);
                    richTextBox1.Text += (s1+"\n");
                    clearAdd();
                }
                else if (radio_create.Checked == true)
                {
                    int i = listBox.SelectedIndex;
                    if (marka.Enabled == false)
                    {
                        if (i != -1)
                        {
                            Auto help = (Auto)listBox.SelectedItem;
                            marka.Text = help.marka;
                            model.Text = help.model;
                            year.Text = help.year.ToString();
                            marka.Enabled = true;
                            model.Enabled = true;
                            year.Enabled = true;
                        }
                        else
                        {
                            throw new Exception("Выберите элемент из списка!");
                        }
                    }
                    else {
                        list.ElementAt(i).marka = marka.Text;
                        list.ElementAt(i).model = model.Text;
                        list.ElementAt(i).year = Convert.ToInt32(year.Text);

                        bf.Serialize(ns, "edit|");
                        String s1 = (String)bf.Deserialize(ns);
                        if (s1 == "go")
                        {
                            bf.Serialize(ns, list);

                            clearAdd();

                            listBox.Items.Clear();

                            s1 = (String)bf.Deserialize(ns);
                            richTextBox1.Text += (s1 + "\n");
                        }
                        else {
                            throw new Exception("Ошибка редактрования");
                        }
                    }
                }
                else if (radio_del.Checked == true)
                {
                    int i = listBox.SelectedIndex;
                    if (i != -1)
                    {
                        bf.Serialize(ns, "del|" + i + "|");
                        String s1 = (String)bf.Deserialize(ns);
                        this.listBox.Items.Clear();
                        richTextBox1.Text += (s1 + "\n");
                    }
                    else {
                        throw new Exception("Выберите элемент из списка!");
                    }
                }
                else if (radio_find.Checked == true)
                {
                    if (list.Count > 0)
                    {
                        List<Auto> help;
                        if (marka.Text != "")
                        {
                            help = list.FindAll(x => x.marka.Contains(marka.Text));

                            if (model.Text != "")
                            {
                                help = help.FindAll(x => x.model.Contains(model.Text));
                            }
                            this.listBox.Items.Clear();
                            this.listBox.Items.AddRange(help.ToArray());
                            this.listBox.Visible = true;
                        }
                    }
                    else
                    {
                        throw new Exception("Список пуст!");
                    }
                }
            }
            catch (Exception ex)
            {
                Form2 errWindow = new Form2();
                errWindow.data("Ошибка :" + ex.Message);
                errWindow.Show();
            }
        }
       
        private void radio_add_CheckedChanged(object sender, EventArgs e)
        {
            marka.Enabled = true;
            model.Enabled = true;
            year.Enabled = true;
            listBox.Visible = false;
        }

        private void radio_view_CheckedChanged(object sender, EventArgs e)
        {
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
            listBox.Visible = false;
            clearAdd();
        }

        private void radio_del_CheckedChanged(object sender, EventArgs e)
        {
            listBox.Visible = true;
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
        }

        private void radio_create_CheckedChanged(object sender, EventArgs e)
        {
            listBox.Visible = true;
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
        }

        private void radio_find_CheckedChanged(object sender, EventArgs e)
        {
            listBox.Visible = false;
            marka.Enabled = true;
            model.Enabled = true;
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

        private void closed(object sender, FormClosedEventArgs e)
        {
            NetworkStream ns = tcp_client.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ns, "exit|");
        }
    }
}
