using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();//kategori tablosundaki verileri kategori isimli degiskene listele
            //burada var butun degiskenleri ustune aliyor. tablodan gelen veri tipleri tam olarak belli olmadigindan
            //burdaka tolist() sql comment select*from
            dataGridView1.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //tablodan turettiğimiz nesne ile tablonun içerisinde bulunan sutuna ulasacak
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = txtAd.Text;
            db.TBLKATEGORI.Add(t);//add():insert into//t den gelen degerleri
            db.SaveChanges();//executenonquery
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);//silecegi id degerini girecek//textbox tan alacak silecegi id//sql kategori id si int oldugu için int olarka tanımlandı
            var ktgr = db.TBLKATEGORI.Find(x);//ktgr degiskenine kategori tabloasundan x id degerini al
            db.TBLKATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Gerçeklerştirildi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            ktgr.AD = txtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme gerçekleştirildi");
        }
    }
}
