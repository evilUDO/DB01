using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplicationDB1
{
    public partial class FormInsert : Form
    {
        private Artikel a = null;
        private OleDbConnection con = null;
        private List<ArtikelGruppe> listeGruppe = new List<ArtikelGruppe>();
        private List<Verpackung> listeVerpackung = new List<Verpackung>();
        private DialogResult result = DialogResult.OK;

        public DialogResult Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        public FormInsert()
        {
            InitializeComponent();
        }

        public FormInsert(OleDbConnection connection, Artikel artikel):this()
        {
            a = artikel;
            con = connection;
            fuelleCombobox();
            InitializeControls();
        }

        private void fuelleCombobox()
        {
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from tArtGruppe;";
            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ArtikelGruppe grp = new ArtikelGruppe();
                grp.Id = reader.GetInt32(0);
                grp.Bezeichnung = reader.GetString(1);
                listeGruppe.Add(grp);
            }
            reader.Close();
            cmd.CommandText = "Select * from tVerpackung;";
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Verpackung ver = new Verpackung();
                ver.Id = reader.GetInt32(0);
                ver.Bezeichnung = reader.GetString(1);
                listeVerpackung.Add(ver);
            }
        }

        private void InitializeControls()
        {
            comboBoxArtGruppe.DataSource = listeGruppe;
            comboBoxVerpackung.DataSource = listeVerpackung;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            a.ArtikelNr = textBoxArtikelnummer.Text;
            a.ArtikelGruppe = Convert.ToInt32(comboBoxArtGruppe.SelectedText);
            a.Bezeichnung = textBoxArtikelbezeichnung.Text;
            a.Bestand = Convert.ToUInt16(textBoxBestand.Text);
            a.Meldebestand = Convert.ToInt16(textBoxMeldebestand.Text);
            a.Verpackung = Convert.ToInt32(comboBoxVerpackung.SelectedText);
            a.VkPreis = Convert.ToDecimal(textBoxVkPreis.Text);
            a.LetzteEntnahme = dateTimePickerletzteEntnahme.Value;
            this.Close();
        }
    }
}
