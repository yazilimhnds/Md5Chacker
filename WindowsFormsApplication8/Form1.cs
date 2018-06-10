using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security.Cryptography;







namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sifre = "";
        string durum = "0";


        private void button2_Click(object sender, EventArgs e)
        {
            durum = "2";
            sifrecoz(textBox1.Text);
            listBox1.Items.Add("md5 --" + textBox2.Text + "=" + textBox1.Text + " [Ç]");
            label3.Text = "Durum : Şifre Çözüldü";

        }


        private string sifrecoz(string text)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://localhost/hash.php?hash=" + text);
            StreamReader reader = new StreamReader(stream);
            String icerik = reader.ReadToEnd();
            string sonuc = icerik;

            textBox2.Text = icerik;
            if (icerik == "") textBox2.Text = "Hash veritabanında bulunamadı";
            return sonuc;






        }








       

        private void MD5_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (StreamReader dosyaoku = File.OpenText("veri.txt"))
            {

                string satir;
                while ((satir = dosyaoku.ReadLine()) != null)
                {
                    listBox1.Items.Add(dosyaoku.ReadLine());

                }

            }

        }





        private void kaydet()
        {
            const string _konum = "veri.txt";
            System.IO.StreamWriter kaydet = new System.IO.StreamWriter(_konum);
            foreach (var item in listBox1.Items)
            {
                kaydet.WriteLine(item);
            }
            kaydet.Close();




        }

        public static string Sifrele(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] sonuc = md5.Hash;

            StringBuilder stbuilder = new StringBuilder();
            for (int i = 0; i < sonuc.Length; i++)
            {
                stbuilder.Append(sonuc[i].ToString("X2"));
            }
            return stbuilder.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            durum = "1";
            textBox2.Text = Sifrele(textBox1.Text);
            listBox1.Items.Add(sifre = "md5 ..." + textBox1.Text + "=" + textBox2.Text + "[$]");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            kaydet();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Turkhackteam Adige tarafından kodlanmıştır ");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
                label3.Text = "Durum : Listeden Kopyalanmıştır.";

            }
            catch (Exception)
            {
            }
        }
            

            

            
                

         private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (durum =="1")
                    label3.Text = "Durum : Şifrelenen Metin Panoya kopyalandı.";
                else if (durum == "2") label3.Text= "Durum : Çözümlenen Metin Panoya kopyalandı";
                else if (durum == "3") label3.Text = "Durum : Çözümlenen Metin ve MD5 Panoya koplayanmıştır";
                Clipboard.SetText(textBox2.Text);
            }
            catch(Exception)

            {
            }



        }
    }
}










        

    


    






           


        

    

        
    

