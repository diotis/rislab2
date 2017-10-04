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
namespace sharplab2cl
{
    public partial class Form1 : Form
    {
        //TcpClient tcp_client = new TcpClient("localhost", 5555);
        //ASCIIEncoding ae = new ASCIIEncoding();
        public Form1()
        {
            InitializeComponent();
            marka.Enabled = false;
            model.Enabled = false;
            year.Enabled = false;
            listBox1.Visible = false;
            checkBox1.Checked = true;

        }
        private void operation_Click(object sender, EventArgs e)
        {
            //Если выбран RadioButton просмотра информции то…
            if (radio_view.Checked == true)
            {
                ////Создаем объект класса NetworkStream и ассоциируем его объектом класса TcpClient
                //NetworkStream ns = tcp_client.GetStream();
                //String command = "view";
                //String res = command + "|";
                ////Создаем переменные типа byte[] для отправки запроса и получения результата

                //byte[] sent = ae.GetBytes(res);
                //byte[] recieved = new byte[256];
                ////Отправляем запрос на сервер
                //ns.Write(sent, 0, sent.Length);
                ////Получаем результат выполнения запроса с сервера
                //ns.Read(recieved, 0, recieved.Length);
                ////Отображаем полученный результат в клиентском RichTextBox
                //richTextBox1.Text = ae.GetString(recieved);
                //String status = "=>Command sent:view data";
                ////Отображаем служебную информацию в клиентском ListBox
                //listBox1.Items.Add(status);
            }
            else if (radio_add.Checked == true)
            {
                try {
                    String data = marka.Text;
                    String str = model.Text;
                    int y = Convert.ToInt32(year.Text);
                    richTextBox1.Text += "Добавлено\n";
                } catch (Exception ex)
                {
                    //richTextBox1.Text += ex.Message+"\n";
                    Form2 errWindow = new Form2();
                    errWindow.data("Ошибка :" + ex.Message);
                    errWindow.Show();

                }
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
            else {
                richTextBox1.Visible = false; ;
            }
        }
    }
}
