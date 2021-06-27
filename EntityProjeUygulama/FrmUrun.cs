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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.KATEGORI,
                                            x.TBLKATEGORI.AD,//kategorilerin ıd sı degil ismi gelmesi için//x in bagli bulundugu tablonun baglı bulundugu tabloları da görebiliriyoruz. burada x tblurun de tblurun navigation property de  gözüken tablolar tblsatıs ve tbl kategori o yzuden burada tbl kategorideki ad ı cağırdıgımızda ıd yerine kategorı adı gorunecektir.
                                            x.DURUM
                                        }
                                        ).ToList();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = txtAd.Text;
            t.MARKA = txtMarka.Text;
            t.STOK = short.Parse(txtStok.Text);
            t.KATEGORI = int.Parse(cmbKategori.SelectedValue.ToString());
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.DURUM = true;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün ekleme işleme tamamlandı");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi gerçekleştirildi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = txtAd.Text;
            urun.STOK = short.Parse(txtStok.Text);
            urun.MARKA = txtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi gerçkelştirildi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                               ).ToList();
            cmbKategori.ValueMember = "ID";//arkaplanda calısacak deger
            cmbKategori.DisplayMember = "AD";//gorunecek alan
            cmbKategori.DataSource = kategoriler;//veri kaynagı
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}
