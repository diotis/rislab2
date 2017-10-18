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
using System.Runtime.Serialization.Formatters.Binary;
using ClassAutoLab2;//class auto
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //public delegate void ServerInfo(String myString);
        //public ServerInfo myDelegate;

        private readonly SynchronizationContext syncContext;

        int fileCount = 0;
        String fileName = "d:\\files\\ris\\lab2.txt";
        TcpListener listener = null;
        Socket socket = null;

        public Form1(){
            InitializeComponent();
            //myDelegate = new ServerInfo(info);
            syncContext = SynchronizationContext.Current;
        }

        public RichTextBox rtb() {
            return rtb1;
        }

        public void info(String str) {
            //syncContext.Post();
            rtb1.Text += str + "\n";
        }
      
        private void Run()
        {
            fileCount++;
            NetworkStream ns = new NetworkStream(socket);
            ThreadClass threadClass = new ThreadClass();
            threadClass.Start(ns, fileName, fileCount, this);

            //while (!threadClass.getCheck())
            //{
            //    Thread.Sleep(10);
            //    thread.Join();
            //}
        }
        

        private void start(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 5555);
                listener.Start();
                while (true) {
                    socket = listener.AcceptSocket();
                    if (socket.Connected)
                    {
                        Thread thread = new Thread(new ThreadStart(Run));
                        thread.Start();
                    }
                }
            } catch (Exception ex) {
                info(ex.Message);
            }
        }
    }

    public class ThreadClass
    {

        private bool check = false;
        private int num;

        public int getNum(){
            return num;
        }
        public void setNum(int n){
            num = n;
        }
        public bool getCheck() {
            return check;
        }
        Form1 form = null;
        NetworkStream ns = null;
        String fileName = null;
        List<Auto> list = new List<Auto>();

        public void Start(NetworkStream ns, String fileName, int fileCount, Form1 form)
        {
            this.ns = ns;
            this.fileName = fileName;
            this.num = fileCount;
            this.form = form;
            //Thread thread = new Thread(new ThreadStart(ThreadOperations));
            //thread.Start();
            //return thread;
            ThreadOperations();
        }

        void ThreadOperations()
        {
            //form.BeginInvoke((Action)(() =>
            //{
            //    this.form.rtb().Text = "Клиент подключился к системе";
            //}));
            //form.info("Клиент подключился к системе");
            //form.BeginInvoke(form.myDelegate, new Object[] { "Клиент подключился к системе" });

            //var settextAction = new Action(() => { form.rtb().Text = "Обновляем данные"; });
            //if (form.rtb().InvokeRequired)
            //    form.rtb().Invoke(settextAction);
            //else settextAction();

            BinaryFormatter bf = new BinaryFormatter();
            String s1;
            String cmd = "";

            while (cmd != "exit")
            {
                s1 = (String)bf.Deserialize(ns);
                int i = s1.IndexOf("|", 0);
                cmd = s1.Substring(0, i);
                if (cmd.CompareTo("view") == 0)
                {
                    list = Deserealize();
                    bf.Serialize(ns, list);
                    //form.info("Список отправлен клиенту");
                }
                if (cmd.CompareTo("add") == 0)
                {
                    int n = s1.IndexOf("|", i + 1);
                    String msg = s1.Substring(i + 1, n - i - 1);
                    FileStream fstr = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    fstr.Seek(0, SeekOrigin.End);
                    Auto help = new Auto();

                    n = msg.IndexOf(" ");
                    String marka = msg.Substring(0, n);
                    i = n + 1;
                    n = msg.IndexOf(" ", i);
                    String model = msg.Substring(i, n - i);
                    i = msg.Length - n - 1;
                    String y = msg.Substring(n + 1, i);
                    help.setData(marka, model, Convert.ToInt32(y));
                    bf.Serialize(fstr, help);
                    fstr.Close();
                    bf.Serialize(ns, "Элемент добавлен!");
                    //form.info("Клиент добавил новый элемент списка");
                }
                if (cmd.CompareTo("del") == 0)
                {
                    int n = s1.IndexOf("|", i + 1);
                    int del = Convert.ToInt32(s1.Substring(i + 1, n - i - 1));
                    list.RemoveAt(del);
                    Serialize();
                    bf.Serialize(ns, "Элемент " + (del+1) + " удален!");
                    //form.info("Клиент удалил элемент №" + (del + 1));
                }
                if (cmd.CompareTo("edit") == 0)
                {
                    bf.Serialize(ns, "go");
                    list = (List<Auto>)bf.Deserialize(ns);
                    Serialize();
                    bf.Serialize(ns, "Отредактировано!");
                    //form.info("Клиент отредактировал элемент списка");
                }
            }
            //form.info("Клиент завершил работу");
            check = true;
        }
        private void Serialize()
        {
            FileStream fstr = new FileStream("d:\\files\\ris\\lab2.txt", FileMode.Create, FileAccess.Write);
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
            fstr.Close();
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
    }
}
