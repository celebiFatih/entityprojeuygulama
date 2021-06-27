﻿using System;
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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label3.Text = db.TBLURUN.Count().ToString();
            label5.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();//=> bir lambda ifadesidir. durumu true olanları getir.
            label7.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label13.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            label21.Text = db.TBLSATIS.Sum(x => x.FIYAT).ToString();
            label11.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();//desc:z->a//firstordefault en üsttekini sadece bir kaydı getir
            label9.Text = (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();//asc:a->z
            label15.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            label17.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            label23.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}