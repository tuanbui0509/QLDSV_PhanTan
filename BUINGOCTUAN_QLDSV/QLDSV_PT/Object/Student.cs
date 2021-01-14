using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV_PT.Object
{
    class Student
    {
        private string MASV;
        private string HO;
        private string TEN;
        private string MALOP;
        private bool PHAI;
        private DateTime NGAYSINH;
        private string NOISINH;
        private string DIACHI;
        private string GHICHU;
        private bool NGHIHOC;

        public Student()
        {
        }

        public Student(string mASV, string hO, string tEN, string mALOP, bool pHAI, DateTime nGAYSINH,
            string nOISINH, string dIACHI, string gHICHU, bool nGHIHOC)
        {
            MASV = mASV;
            HO = hO;
            TEN = tEN;
            MALOP = mALOP;
            PHAI = pHAI;
            NGAYSINH = nGAYSINH;
            NOISINH = nOISINH;
            DIACHI = dIACHI;
            GHICHU = gHICHU;
            NGHIHOC = nGHIHOC;
        }

        public string MASV1 { get => MASV; set => MASV = value; }
        public string HO1 { get => HO; set => HO = value; }
        public string MALOP1 { get => MALOP; set => MALOP = value; }
        public bool PHAI1 { get => PHAI; set => PHAI = value; }
        public string TEN1 { get => TEN; set => TEN = value; }
        public DateTime NGAYSINH1 { get => NGAYSINH; set => NGAYSINH = value; }
        public string NOISINH1 { get => NOISINH; set => NOISINH = value; }
        public string GHICHU1 { get => GHICHU; set => GHICHU = value; }
        public bool NGHIHOC1 { get => NGHIHOC; set => NGHIHOC = value; }
        public string DIACHI1 { get => DIACHI; set => DIACHI = value; }
    }
}
