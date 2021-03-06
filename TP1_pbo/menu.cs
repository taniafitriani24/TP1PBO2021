using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_pbo
{
    public partial class menu : Form
    {
        List<TambahData> dataBarang = new List<TambahData>();
        public menu()
        {
            InitializeComponent();
            BuatProses();
            setDataBarang(this.dataBarang);
            ProsesTampil(null, 0, 0);
        }

        void BuatProses()
        {
            string jenis = null;
            int min = 0;
            int max = 0;

            button4.Click += new EventHandler((object sender, EventArgs e) =>
            {
                ProsesTampil(jenis, min, max);
            });

            comboBox1.SelectedIndexChanged += new EventHandler((object sender, EventArgs e) =>
            {
                ComboBox value = (ComboBox)sender;
                value.DropDownStyle = ComboBoxStyle.DropDownList;
                FilterHarga fH = new FilterHarga(value.SelectedItem.ToString());
                min = fH.getMinHarga();
                max = fH.getHighHarga();
            });

            comboBox2.SelectedIndexChanged += new EventHandler((object sender, EventArgs e) =>
            {
                ComboBox value = (ComboBox)sender;
                value.DropDownStyle = ComboBoxStyle.DropDownList;
                jenis = value.SelectedItem.ToString().ToLower();
            });
        }
        
        Panel tampilProduk(int setKode, string setNama, string setJenis, int setHarga)
        {
            Panel box = new Panel();
            Label nama = new Label();
            Label jenis = new Label();
            Label harga = new Label();
            Button btnBeli = new Button();
            PictureBox foto_Produk = new PictureBox();

            box.BackColor = System.Drawing.Color.White;
            box.Controls.Add(foto_Produk);
            box.Controls.Add(btnBeli);
            box.Controls.Add(harga);
            box.Controls.Add(nama);
            box.Controls.Add(jenis);
            box.Location = new System.Drawing.Point(4, 3);
            box.Name = "panel5";
            box.Size = new System.Drawing.Size(210, 210);
            box.TabIndex = 0;

            nama.AutoSize = true;
            nama.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nama.Location = new System.Drawing.Point(22, 120);
            nama.Name = "label1";
            nama.Size = new System.Drawing.Size(79, 13);
            nama.TabIndex = 0;
            nama.Text = setNama.ToString();

            jenis.AutoSize = true;
            jenis.Font = new System.Drawing.Font("Tahoma", 7.80F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            jenis.Location = new System.Drawing.Point(22, 130);
            jenis.Name = "label3";
            jenis.Size = new System.Drawing.Size(79, 13);
            jenis.TabIndex = 0;
            jenis.Text = setJenis.ToString();

            harga.AutoSize = true;
            harga.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            harga.Location = new System.Drawing.Point(22, 145);
            harga.Name = "label2";
            harga.Size = new System.Drawing.Size(41, 13);
            harga.TabIndex = 1;
            harga.Text = setHarga.ToString();
            
            btnBeli.BackColor = System.Drawing.Color.LimeGreen;
            btnBeli.FlatAppearance.BorderSize = 0;
            btnBeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBeli.Location = new System.Drawing.Point(102, 167);
            btnBeli.Name = setKode.ToString();
            btnBeli.Size = new System.Drawing.Size(75, 23);
            btnBeli.TabIndex = 2;
            btnBeli.Text = "Beli";
            btnBeli.UseVisualStyleBackColor = false;
            btnBeli.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBeli.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Button btn = (Button)sender;
                int kode = int.Parse(btn.Name);
                menu_detail(kode);
            });

            foto_Produk.BackgroundImage = global::TP1_pbo.Properties.Resources.dia;
            foto_Produk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            foto_Produk.Location = new System.Drawing.Point(15, 21);
            foto_Produk.Name = "pictureBox1";
            foto_Produk.Size = new System.Drawing.Size(171, 84);
            foto_Produk.TabIndex = 3;
            foto_Produk.TabStop = false;
            return box;
        }

        private void ProsesTampil(string jenis, int min, int max)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var obj in this.dataBarang)
            {
                if (obj.jenis == jenis)
                {
                    if (obj.harga >= min && obj.harga <= max)
                    {
                        flowLayoutPanel1.Controls.Add(tampilProduk(obj.kode, obj.nama, obj.jenis, obj.harga));
                    }
                    else if (min == 0)
                    {
                        flowLayoutPanel1.Controls.Add(tampilProduk(obj.kode, obj.nama, obj.jenis, obj.harga));
                    }
                }
                else if (jenis == null)
                {
                    if (obj.harga >= min && obj.harga <= max)
                    {
                        flowLayoutPanel1.Controls.Add(tampilProduk(obj.kode, obj.nama, obj.jenis, obj.harga));
                    }
                    else if (min == 0)
                    {
                        flowLayoutPanel1.Controls.Add(tampilProduk(obj.kode, obj.nama, obj.jenis, obj.harga));
                    }
                }
            }
        }

        void setDataBarang(List<TambahData> dataBarang)
        {
            dataBarang.Add(new TambahData(1, "lanccalote", 1000000, "cincin"));
            dataBarang.Add(new TambahData(2, "Rosemary", 1500000, "cincin"));
            dataBarang.Add(new TambahData(3, "Amarina", 2000000, "kalung"));
            dataBarang.Add(new TambahData(4, "Elfaza", 1100000, "gelang"));
            dataBarang.Add(new TambahData(5, "junaizah", 500000, "gelang"));
        }

        void tampil_detail(int setKode, string setNama, string setJenis, int setHarga)
        {
            Panel box = new Panel();
            Label nama = new Label();
            Label jenis = new Label();
            Label harga = new Label();
            Button btnBeli = new Button();
            PictureBox foto_Produk = new PictureBox();

            box.BackColor = System.Drawing.Color.White;
            box.Controls.Add(foto_Produk);
            box.Controls.Add(btnBeli);
            box.Controls.Add(harga);
            box.Controls.Add(nama);
            box.Controls.Add(jenis);
            box.Location = new System.Drawing.Point(15, 15);
            box.Name = "panel5";
            box.Size = new System.Drawing.Size(250, 210);
            box.TabIndex = 0;

            harga.AutoSize = true;
            harga.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            harga.Location = new System.Drawing.Point(22, 145);
            harga.Name = "label2";
            harga.Size = new System.Drawing.Size(41, 13);
            harga.TabIndex = 0;
            harga.Text = setHarga.ToString();

            foto_Produk.BackgroundImage = global::TP1_pbo.Properties.Resources.dia;
            foto_Produk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            foto_Produk.Location = new System.Drawing.Point(50, 21);
            foto_Produk.Name = "pictureBox1";
            foto_Produk.Size = new System.Drawing.Size(150, 84);
            foto_Produk.TabIndex = 0;
            foto_Produk.TabStop = false;

            nama.AutoSize = true;
            nama.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nama.Location = new System.Drawing.Point(22, 120);
            nama.Name = "label1";
            nama.Size = new System.Drawing.Size(79, 13);
            nama.TabIndex = 0;
            nama.Text = setNama.ToString();

            jenis.AutoSize = true;
            jenis.Font = new System.Drawing.Font("Tahoma", 7.80F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            jenis.Location = new System.Drawing.Point(22, 130);
            jenis.Name = "label3";
            jenis.Size = new System.Drawing.Size(79, 13);
            jenis.TabIndex = 0;
            jenis.Text = setJenis.ToString();

            btnBeli.BackColor = System.Drawing.Color.Yellow;
            btnBeli.FlatAppearance.BorderSize = 0;
            btnBeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBeli.Location = new System.Drawing.Point(132, 167);
            btnBeli.Name = setKode.ToString();
            btnBeli.Size = new System.Drawing.Size(75, 23);
            btnBeli.TabIndex = 2;
            btnBeli.Text = "Beli";
            btnBeli.UseVisualStyleBackColor = false;
            btnBeli.Cursor = System.Windows.Forms.Cursors.Hand;

            flowLayoutPanel1.Controls.Add(box);
        }
        void menu_detail(int setKode)
        {
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button5.Click += new EventHandler((object sender, EventArgs e) =>
            {
                ProsesTampil(null, 0, 0);
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
            });

            flowLayoutPanel1.Controls.Clear();
            foreach (var obj in this.dataBarang)
            {
                if (obj.kode == setKode)
                {
                    tampil_detail(obj.kode, obj.nama, obj.jenis, obj.harga);
                }
            }

        }
        private void menu_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
            ProsesTampil(null, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login me = new login();
            me.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.amazon.com");
        }
    }
}
