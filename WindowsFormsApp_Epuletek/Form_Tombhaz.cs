using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Epuletek
{
    public partial class Form_Tombhaz : Form
    {
        public string Muvelet = "uj";
        public Form_Tombhaz()
        {
            InitializeComponent();
        }

        private void Form_Tombhaz_Load(object sender, EventArgs e)
        {
            Tombhaz kiv;
            if (Muvelet.Equals("update")) //A Muvelet a From_Nyito.cs-ben a button_Update_Click-ben kap értéket
            {
                if (Program.form_Nyito.listBox_Epuletek.SelectedItem != null)
                {
                    if (Program.form_Nyito.listBox_Epuletek.SelectedItem.GetType().Name.Equals("Tombhaz"))
                    {
                        kiv = (Tombhaz)Program.form_Nyito.listBox_Epuletek.SelectedItem;
                        this.textBox_Cim.Text = kiv.Cim;
                        this.textBox_Cim.ReadOnly = true;
                        this.numericUpDown_Alapterulet.Value = kiv.Alapterulet;
                        this.comboBox_Epitesianyag.Text = kiv.Epitesianyag.ToString();
                        this.comboBox_FenntartasTipusa.Text = kiv.FenntartasTipusa.ToString();
                        this.Text = "Form_Tombhaz -- adatmódosítás";
                        this.button1.Text = "Módosít";

                        /*foreach (string item in Enum.GetNames(typeof(Anyagok)))
                        {
                            Console.WriteLine("Form_Tombhaz_Load (Enum.GetNames(typeof(Anyagok)): {0}", item);
                            int index = comboBox_Epitesianyag.Items.Add(item);
                            if (kiv.Epitesianyag.ToString().Equals(item))
                            {
                                this.comboBox_Epitesianyag.SelectedIndex = index;
                            }
                        }
                        foreach (string item in Enum.GetNames(typeof(Fenntartas)))
                        {
                            int index=comboBox_FenntartasTipusa.Items.Add(item);
                            if (kiv.FenntartasTipusa.ToString().Equals(item))
                            {
                            this.comboBox_FenntartasTipusa.SelectedIndex = index;
                            }
                        }*/
                    }
                    else
                    {
                        string MessageBoxMessage = "A kiválasztott elem '" + Program.form_Nyito.listBox_Epuletek.SelectedItem.GetType().Name + "' nem tömbház, válassz új elemet!";
                        MessageBox.Show(MessageBoxMessage);
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }
                }
                Muvelet = "uj";
            }
            else
            {
                this.textBox_Cim.Text = null;
                this.numericUpDown_Alapterulet.Value = numericUpDown_Alapterulet.Minimum;
                this.numericUpDown_LakasokSzama.Value = numericUpDown_LakasokSzama.Minimum;
                this.checkBox1.Checked = false;
                this.Text = "Form_Tombhaz -- Új tömbház felvétele";
                if (comboBox_Epitesianyag.Items.Count == 0)
                {
                    foreach (string item in Enum.GetNames(typeof(Anyagok)))
                    {
                        Console.WriteLine("Form_Tombhaz_Load (Enum.GetNames(typeof(Anyagok)): {0}", item);
                        // int index = comboBox_Epitesianyag.Items.Add(item);
                        comboBox_Epitesianyag.Items.Add(item);

                    }
                }

                if (comboBox_FenntartasTipusa.Items.Count == 0)
                {
                    foreach (string item in Enum.GetNames(typeof(Fenntartas)))
                    {
                        // int index=comboBox_FenntartasTipusa.Items.Add(item);
                        comboBox_FenntartasTipusa.Items.Add(item);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e) //-- A Rögíztés gomb kattintás eseménye
        {
            foreach (Control item in this.Controls.OfType<TextBox>())
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    MessageBox.Show(String.Format("Egyetlen mező sem maradhat üresen!"));
                    item.Select();
                    return;
                }
            }
            
            foreach (Control item in this.Controls.OfType<NumericUpDown>())
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    MessageBox.Show(String.Format("Egyetlen mező sem maradhat üresen!"));
                    item.Select();
                    return;
                }
            }
            
            foreach (Control item in this.Controls.OfType<DateTimePicker>())
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    MessageBox.Show(String.Format("Egyetlen mező sem maradhat üresen!"));
                    item.Select();
                    return;
                }
            }
            
            foreach (Control item in this.Controls.OfType<ComboBox>())
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    MessageBox.Show(String.Format("Egyetlen mező sem maradhat üresen!"));
                    item.Select();
                    return;
                }
            }
            
            foreach (Control item in this.Controls.OfType<Button>())
            {
                
            }

                Anyagok anyag = (Anyagok)Enum.Parse(typeof(Anyagok), comboBox_Epitesianyag.SelectedItem.ToString());
                string szoveg = comboBox_FenntartasTipusa.SelectedItem.ToString();
                Type tipus = typeof(Fenntartas);
                Fenntartas fenntartas = (Fenntartas)Enum.Parse(tipus, szoveg);
                Tombhaz uj = new Tombhaz(
                    textBox_Cim.Text,
                    (int)numericUpDown_Alapterulet.Value,
                    anyag,
                    dateTimePicker_Kezdes.Value,
                    dateTimePicker_Befejezes.Value,
                    (int)numericUpDown_LakasokSzama.Value,
                    fenntartas,
                    checkBox1.Checked);
                int index = Program.form_Nyito.listBox_Epuletek.SelectedIndex;
            if (Muvelet.Equals("update")) {
                Program.form_Nyito.listBox_Epuletek.Items.RemoveAt(index);
                Program.form_Nyito.listBox_Epuletek.Items.Insert(index, uj);
                this.DialogResult = DialogResult.Cancel;
            }
            else {
                Program.form_Nyito.listBox_Epuletek.Items.Add(uj);
                textBox_Cim.Text = null;
                numericUpDown_Alapterulet.Value = numericUpDown_Alapterulet.Minimum;
                comboBox_Epitesianyag.SelectedIndex = -1;
                numericUpDown_LakasokSzama.Value = numericUpDown_LakasokSzama.Minimum;
                comboBox_FenntartasTipusa.SelectedIndex = -1;
                textBox_Cim.Select();                
            }

            // Nincs értelme a mezőket kiüríten/beállítani, mert adatokat módosítani csak úgy lehet, ha a nyitó formon kiválasztjuk a módosítandó adatot, ahhoz pedig be kell zárni a  módosító űrlapot.

            //textBox_Cim.Text = "";
            //numericUpDown_Alapterulet.Value = numericUpDown_Alapterulet.Minimum;
            //comboBox_Epitesianyag.SelectedIndex = -1;
            //numericUpDown_LakasokSzama.Value = numericUpDown_LakasokSzama.Minimum;
            //comboBox_FenntartasTipusa.SelectedIndex = -1;
            //checkBox1.Checked = false;
        }
    }
}
