using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fileName = "d:\\files\\ris\\lab2.txt";
            int fileCount = 0;
            TcpListener listener = null;
            Socket socket = null;
            NetworkStream ns = null;
            ASCIIEncoding ae = null;
            listener = new TcpListener(IPAddress.Any, 5555);
            // Активация listen’ера
            listener.Start();
            socket = listener.AcceptSocket();
            if (socket.Connected)
            {
                ns = new NetworkStream(socket);
                ae = new ASCIIEncoding();
                //Создаем новый экземпляр класса ThreadClass
                ThreadClass threadClass = new ThreadClass();
                //Создаем новый поток
                Thread thread = threadClass.Start(ns, fileName, fileCount, this);
            }
        }
    }
    public class ThreadClass
    {
        Form1 form = null;
        NetworkStream ns = null;
        ASCIIEncoding ae = null;
        String fileName = null;
        int fileCount = 0;

        public Thread Start(NetworkStream ns, String fileName, int fileCount, Form1 form)
        {
            this.ns = ns;
            ae = new ASCIIEncoding();
            this.fileName = fileName;
            this.fileCount = fileCount;
            this.form = form;
            //Создание нового экземпляра класса Thread 
            Thread thread = new Thread(new ThreadStart(ThreadOperations));
            //Запуск потока
            thread.Start();
            return thread;
        }
        void ThreadOperations()
        {
            //Создаем новую переменную типа byte[]
            byte[] received = new byte[256];
            //С помощью сетевого потока считываем в переменную received данные от клиента
            ns.Read(received, 0, received.Length);
            String s1 = ae.GetString(received);
            int i = s1.IndexOf("|", 0);
            String cmd = s1.Substring(0, i);
            if (cmd.CompareTo("view") == 0)
            {
                // Создаем переменную типа byte[] для отправки ответа клиенту
                byte[] sent = new byte[256];

                //Создаем объект класса FileStream для последующего чтения информации из файла
                FileStream fstr = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fstr);
                //Запись в переменную sent содержания прочитанного файла
                sent = ae.GetBytes(sr.ReadToEnd());
                sr.Close();
                fstr.Close();
                //Отправка информации клиенту
                ns.Write(sent, 0, sent.Length);
            }
        }
    }
}
