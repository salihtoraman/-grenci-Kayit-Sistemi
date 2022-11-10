using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OgrenciKayitSistemi_Entity
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ogrenci_Ekle;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void OgrenciEkle()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogrenci_Ekle", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        Ogrenci_EkleDal ogrenci_EkleDal = new Ogrenci_EkleDal();
        private object contect;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ogrenci_EkleDal.GetAll();
            label7.Visible = false;
            label8.Visible = false;
            string TC = Convert.ToString(masked_TC.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"SELECT * FROM Ogrenci_Ekle");
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter daa = new SqlDataAdapter($"SELECT * FROM Ogrenci_Ekle", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();
            dataGridView1.Columns[5].Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tcm = Convert.ToString(masked_TC.Text);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand komut1 = new SqlCommand($"select *from Ogrenci_Ekle WHERE TC = '{tcm}'", baglanti);
            SqlDataReader reader = komut1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Bu TC'ye ait bir öğrenci var");
            }
            else
            {
                if (masked_TC.Text.Length < 11)
                {
                    label7.Visible = true;
                }
                else
                {
                    label7.Visible = false;
                }
                if (masked_Telefon.Text.Length < 11)
                {
                    label8.Visible = true;
                }
                else
                {
                    label8.Visible = false;
                    ogrenci_EkleDal.Add(new Ogrenci_Ekle
                    {
                        Isim = txt_Isim.Text,
                        Soyisim = txt_Soyisim.Text,
                        Telefon = Convert.ToString(masked_Telefon.Text),
                        TC = Convert.ToString(masked_TC.Text),
                        Resim = Convert.ToString(textBox1.Text)
                    });
                    MessageBox.Show("Öğrenci eklendi");
                    dataGridView1.DataSource = ogrenci_EkleDal.GetAll();
                    baglanti.Close();
                }
                baglanti.Close();
            }
            baglanti.Close();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            ogrenci_EkleDal.Update(new Ogrenci_Ekle
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Isim = txt_Isim.Text,
                Soyisim = txt_Soyisim.Text,
                Telefon = Convert.ToString(masked_Telefon.Text),
                TC = Convert.ToString(masked_TC.Text),
                Resim = Convert.ToString(textBox1.Text)
            });
            MessageBox.Show("Güncellendi");
            dataGridView1.DataSource = ogrenci_EkleDal.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenci_EkleDal.Delete(new Ogrenci_Ekle
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Isim = txt_Isim.Text,
                Soyisim = txt_Soyisim.Text,
                Telefon = Convert.ToString(masked_Telefon.Text),
                TC = Convert.ToString(masked_TC.Text),
                Resim = Convert.ToString(textBox1.Text)
            });
            MessageBox.Show("Silindi");
            dataGridView1.DataSource = ogrenci_EkleDal.GetAll();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Tıkladığın yerin ID'si YOK BİLADEEEERRRRRR");
            }
            txt_Isim.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Isim"].Value);
            txt_Soyisim.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Soyisim"].Value);
            masked_TC.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["TC"].Value);
            masked_Telefon.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefon"].Value);
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["Resim"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası ||.jpg;.nef;.png;.jpeg ||  Tüm Dosyalar |.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBox1.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void txt_Isim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txt_Soyisim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void masked_Telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void masked_TC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
