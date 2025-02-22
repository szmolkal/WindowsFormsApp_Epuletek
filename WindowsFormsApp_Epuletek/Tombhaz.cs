﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Epuletek
{
    class Tombhaz : Epulet, CSV, Kalkulacio
    {
        readonly int lakasokSzama;
        Fenntartas fenntartasTipusa;
        readonly bool vanLift;

        public int LakasokSzama => lakasokSzama;

        internal Fenntartas FenntartasTipusa { get => fenntartasTipusa; set => fenntartasTipusa = value; }

        public bool VanLift => vanLift;

        public Tombhaz(string cim, int alapterulet, Anyagok epitesianyag, DateTime kezdes, DateTime befejezes, int lakasokSzama, Fenntartas fenntartasTipusa, bool vanLift) : base(cim, alapterulet, epitesianyag, kezdes, befejezes)
        {
            this.lakasokSzama = lakasokSzama;
            FenntartasTipusa = fenntartasTipusa;
            this.vanLift = vanLift;
        }

        public override string ToString()
        {
            return Cim;
        }
        public string toCSV()
        {
            return String.Join(";", "tomb", Cim, Alapterulet, Epitesianyag, Kezdes.ToString("yyyy-MM-dd"), Befejezes.ToString("yyyy-MM-dd"), lakasokSzama, fenntartasTipusa, vanLift);
        }

        public int kalkulaltAr()
        {
            return Alapterulet * lakasokSzama * 8000 + (vanLift ? 100000 : 0);
        }
    }
}
