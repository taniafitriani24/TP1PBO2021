using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_pbo
{
    class TambahData
    {
            public TambahData(int setKode, string setNama, int setHarga, string setJenis)
            {
                kode = setKode;
                nama = setNama;
                harga = setHarga;
                jenis = setJenis;
                
            }
        public int kode { get; set; }
        public string nama { get; set; }
        public int harga { get; set; }
        public string jenis { get; set; }
       

    }
    class FilterHarga
    {
        string value;
        public FilterHarga(string str)
        {
            this.value = str;
        }
        public int getMinHarga()
        {
            int nilai = 0;
            if (this.value == "<= 500.000")
            {
                nilai = 500000;
            }
            else if (this.value == "1.000.000 - 1.500.000")
            {
                nilai = 1000000;
            }
            else if (this.value == "> 1.500.000")
            {
                nilai = 1510000;
            }
            return nilai;
        }

        public int getHighHarga()
        {
            int nilai = 0;
            if (this.value == "<= 500.000")
            {
                nilai = 500000;
            }
            else if (this.value == "1.000.000 - 1.500.000")
            {
                nilai = 1500000;
            }
            else if (this.value == "> 1.500.000")
            {
                nilai = 2000000;
            }
            return nilai;
        }
    }


}

