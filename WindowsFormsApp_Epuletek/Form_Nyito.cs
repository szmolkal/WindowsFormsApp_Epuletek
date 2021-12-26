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
using System.Diagnostics;
using System.Globalization;

namespace WindowsFormsApp_Epuletek
{
    public partial class Form_Nyito : Form
    {
        public Form_Nyito()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdatokBetoltese();
            ToolTip toolTip_listBox_Epuletek = new ToolTip();
            toolTip_listBox_Epuletek.IsBalloon = true;
            toolTip_listBox_Epuletek.ToolTipTitle = "Kattintás egy elemen:";
            //toolTip_listBox_Epuletek.InitialDelay = 0; //A toolTip megjelenéséig eltelt idő ezred mp-ben (1000 = 1 sec)
            toolTip_listBox_Epuletek.AutoPopDelay = 15000;
            /*toolTip_listBox_Epuletek.Show("\t\tKattintás egy elemen:\n" +
                "Egy kattintás:\n\tárkalkuláció. \n" +
                "Dupla kattintás:\n\tMegjelennek a kiválasztott cím általános épületekre vonatkozó adatai.", listBox_Epuletek, 10000);*/
            //toolTip_listBox_Epuletek.ShowAlways = true;
            toolTip_listBox_Epuletek.SetToolTip(listBox_Epuletek, "Egy kattintás:\n\tárkalkuláció. \n" +
                "Dupla kattintás:\n\tMegjelennek a kiválasztott cím általános épületekre vonatkozó adatai.");
            //toolTip_listBox_Epuletek.SetToolTip(listBox_Epuletek, "\t\tKattintás egy elemen:\n" + "Egy kattintás:\n\tárkalkuláció. \n" +
            //    "Dupla kattintás:\n\tMegjelennek a kiválasztott cím általános épületekre vonatkozó adatai.");
            
            ToolTip toolTip_label_Kalkulacio = new ToolTip();
            toolTip_label_Kalkulacio.IsBalloon = true;
            toolTip_label_Kalkulacio.ToolTipTitle = "Kalkuláció:";
            //toolTip_label_Kalkulacio.ShowAlways = true;
            //toolTip_label_Kalkulacio.InitialDelay = 0;
            toolTip_label_Kalkulacio.AutoPopDelay = 15000;
            //toolTip_label_Kalkulacio.Show("Az árkalkulációhoz kattints valamelyik elemre a listában!",label_Kalkulacio_Label, 10000);
            toolTip_label_Kalkulacio.SetToolTip(label_Kalkulacio_Label,"Az árkalkulációhoz kattints valamelyik elemre a listában!");
            
            ToolTip toolTip_textBox_ArKalkulacio = new ToolTip();
            toolTip_textBox_ArKalkulacio.IsBalloon = true;
            toolTip_textBox_ArKalkulacio.ToolTipTitle = "Kalkuláció:";
            toolTip_textBox_ArKalkulacio.AutoPopDelay = 15000;
            toolTip_textBox_ArKalkulacio.SetToolTip(label_Kalkulacio_Label,"Az árkalkulációhoz kattints valamelyik elemre a listában!");
        }

        private void AdatokBetoltese()
        {
            //-- adatok betöltése az @"C:\epuletek.csv" fájlból ----------
            if (File.Exists(@"C:\epuletek.csv")) //-- @"C:\epuletek.csv"
            {
                //-- Létezik a fájl, beolvassuk az adatokat
                using (StreamReader sr = new StreamReader(@"C:\epuletek.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        if (sor[0].Equals("csaladi"))
                        {
                            Csaladihaz uj = new Csaladihaz(
                                sor[1],
                                int.Parse(sor[2]),
                                (Anyagok)Enum.Parse(typeof(Anyagok), sor[3]),
                                DateTime.Parse(sor[4]),
                                DateTime.Parse(sor[5]),
                                int.Parse(sor[6]),
                                bool.Parse(sor[7]),
                                (TetoAnyaga)Enum.Parse(typeof(TetoAnyaga), sor[8])
                                );
                            listBox_Epuletek.Items.Add(uj);
                            Console.WriteLine("A dátumok megegyeznek: {0}",DateTime.Now.ToString("yyyy-MM-dd").Equals(uj.Kezdes.ToString("yyyy-MM-dd")));
                            if (uj.Kezdes.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
                            {
                                listBox_Esedekes_Epuletek.Items.Add(uj);
                            }
                        }
                        else
                        {
                            Tombhaz uj = new Tombhaz(
                                sor[1],
                                int.Parse(sor[2]),
                                (Anyagok)Enum.Parse(typeof(Anyagok), sor[3]),
                                DateTime.Parse(sor[4]),
                                DateTime.Parse(sor[5]),
                                int.Parse(sor[6]),
                                (Fenntartas)Enum.Parse(typeof(Fenntartas), sor[7]),
                                bool.Parse(sor[8]));
                            listBox_Epuletek.Items.Add(uj);
                            Console.WriteLine("A dátumok megegyeznek: {0}",DateTime.Now.ToString("yyyy-MM-dd").Equals(uj.Kezdes.ToString("yyyy-MM-dd")));
                            if (uj.Kezdes.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
                            {
                                listBox_Esedekes_Epuletek.Items.Add(uj);
                            }                        }
                    }
                }
            }

        }

        private void button_uj_csaladi_Click(object sender, EventArgs e)
        {
            Program.form_csaladihaz.ShowDialog();
        }

        private void button_uj_tombhaz_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button_uj_tombhaz_Click sender: {0}",sender.ToString());
            Program.form_Tombhaz.ShowDialog();
        }

        private void Save_Epuletek()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\epuletek.csv"))
                {
                    foreach (var item in listBox_Epuletek.Items)
                    {
                        if (typeof(Csaladihaz) == item.GetType())
                        {
                            sw.WriteLine(((Csaladihaz)item).toCSV());
                        }
                        else
                        {
                            sw.WriteLine(((Tombhaz)item).toCSV());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show("Sikeres mentés");
        }

        private void Form_Nyito_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("valóban kilép?","Megerősítés",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Save_Epuletek();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (listBox_Epuletek.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztott épület");
                return;
            }
            if (MessageBox.Show("Valóban törli?", "Figyelmeztetés",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                listBox_Epuletek.Items.RemoveAt(listBox_Epuletek.SelectedIndex);
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (listBox_Epuletek.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztva elem");
                return;
            }
            
            if (listBox_Epuletek.SelectedItem.GetType()== typeof(Csaladihaz))
            {
                Program.form_csaladihaz.Muvelet = "update";
                Program.form_csaladihaz.ShowDialog();
            }
            else
            {
                //-- Tömbház adatainak a módosítása
                Program.form_Tombhaz.Muvelet = "update";
                Program.form_Tombhaz.ShowDialog();
            }

        }

        private void listBox_Epuletek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Epuletek.SelectedItem.GetType()==typeof(Csaladihaz))
            {
                Csaladihaz csaladihaz = (Csaladihaz)listBox_Epuletek.SelectedItem;
                CultureInfo culture = new CultureInfo("hu-HU");
                long kalkulaltAr = (csaladihaz.Alapterulet * Convert.ToInt32(csaladihaz.OttElok) * 10000);
                //int kalkulaltAr = Int32.Parse((csaladihaz.Alapterulet * Convert.ToInt32(csaladihaz.OttElok) * 10000).ToString("#,##0"), NumberStyles.AllowThousands);
                //textBox_Arkalkulacio.Text =String.Format(culture,"{0:N0}",kalkulaltAr.ToString());
                textBox_Arkalkulacio.Text =kalkulaltAr.ToString("#,##0");
            }
            else
            {
                Tombhaz tombhaz = (Tombhaz)listBox_Epuletek.SelectedItem;
                long kalkulaltAr = tombhaz.Alapterulet * tombhaz.LakasokSzama * 8000;
                textBox_Arkalkulacio.Text = kalkulaltAr.ToString("#,##0");
            }
        }

        private void listBox_Epuletek_DoubleClick(object sender, EventArgs e)
        {
            Epulet epulet = (Epulet)listBox_Epuletek.SelectedItem;
            MessageBox.Show("Címe: " + epulet.Cim + "\n" +
                            "Alapterülete: " + epulet.Alapterulet + "\n" +
                            "Építési anyag: " + epulet.Epitesianyag + "\n" +
                            "Munkakezdés időpontja: " + epulet.Kezdes.ToString("yyyy-MM-dd") + "\n" +
                            "Befejezés időpontja: " + epulet.Befejezes.ToString("yyyy-MM-dd"));
        }

        private void listBox_Esedekes_Epuletek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Epuletek.SelectedItem.GetType() == typeof(Csaladihaz))
            {
                Csaladihaz csaladihaz = (Csaladihaz)listBox_Epuletek.SelectedItem;
                CultureInfo culture = new CultureInfo("hu-HU");
                long kalkulaltAr = (csaladihaz.Alapterulet * Convert.ToInt32(csaladihaz.OttElok) * 10000);
                //int kalkulaltAr = Int32.Parse((csaladihaz.Alapterulet * Convert.ToInt32(csaladihaz.OttElok) * 10000).ToString("#,##0"), NumberStyles.AllowThousands);
                //textBox_Arkalkulacio.Text =String.Format(culture,"{0:N0}",kalkulaltAr.ToString());
                textBox_Arkalkulacio.Text = kalkulaltAr.ToString("#,##0");
            }
            else
            {
                Tombhaz tombhaz = (Tombhaz)listBox_Epuletek.SelectedItem;
                long kalkulaltAr = tombhaz.Alapterulet * tombhaz.LakasokSzama * 8000;
                textBox_Arkalkulacio.Text = kalkulaltAr.ToString("#,##0");
            }
        }
    }
}
