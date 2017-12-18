using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationDB1
{
    public partial class Form2 : Form
    {
        private Artikel selArtikel;
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

        public Artikel SelArtikel
        {
            get
            {
                return selArtikel;
            }

            private set
            {
                selArtikel = value;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Artikel artikel):this()
        {
            SelArtikel = artikel;
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.textBoxArtikelOid.Text = SelArtikel.ArtikelOid.ToString();
            this.textBoxArtikelnummer.Text = SelArtikel.ArtikelNr;
            this.textBoxArtikelgruppe.Text = SelArtikel.ArtikelGruppe.ToString();
            this.textBoxArtikelbezeichnung.Text = SelArtikel.Bezeichnung;
            this.textBoxBestand.Text = SelArtikel.Bestand.ToString();
            this.textBoxMeldebestand.Text = SelArtikel.Meldebestand.ToString();
            this.textBoxVerpackung.Text = SelArtikel.Verpackung.ToString();
            this.textBoxVkPreis.Text = SelArtikel.VkPreis.ToString();
            this.textBoxLetzteEntnahme.Text = SelArtikel.LetzteEntnahme.ToShortDateString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelArtikel.ArtikelNr = textBoxArtikelnummer.Text;
            SelArtikel.Bezeichnung = textBoxArtikelbezeichnung.Text;
            SelArtikel.Bestand = Convert.ToUInt16(textBoxBestand.Text);
            SelArtikel.Meldebestand = Convert.ToInt16(textBoxMeldebestand.Text);
            SelArtikel.VkPreis = Convert.ToDecimal(textBoxVkPreis.Text);
            SelArtikel.LetzteEntnahme = Convert.ToDateTime(textBoxLetzteEntnahme.Text);
            this.Close();
        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            this.Close();
        }
    }
}
