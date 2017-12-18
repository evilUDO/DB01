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
    public partial class Form1 : Form
    {
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        OleDbDataReader reader = null;
        List<Artikel> artikelList = null;
        public Form1()
        {
            InitializeComponent();
            artikelList = new List<Artikel>();
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            //Provider = Microsoft.ACE.OLEDB.12.0; 
            //Data Source = Bestellung.accdb;
            con = new OleDbConnection();
            //OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
            //builder.Provider = "Microsoft.ACE.OLEDB.12.0";
            //builder.DataSource = "Bestellung.accdb";
            con.ConnectionString = Properties.Settings.Default.DbCon;
            try
            {
                con.Open();
                toolStripStatusLabel1.Text = "Verbindung erfolgreich";
            }
            catch (InvalidOperationException inv)
            {
                MessageBox.Show("Verbindung bereits vorhanden");
            }
            catch(OleDbException ole)
            {
                MessageBox.Show(ole.Message);
            }
        }

        private void buttonCommand_Click(object sender, EventArgs e)
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * from tArtikel;";
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch(Exception)
            {
                MessageBox.Show("Zugriff auf tArtikel nicht möglich");
            }
        }

        private void buttonReader_Click(object sender, EventArgs e)
        {
            while(reader.Read() == true)
            {
                //String bez = reader.GetString(3);
                Artikel a = mkArtikelObject(reader);
                //listBoxAusgabe.Items.Add(a);
                artikelList.Add(a);
                //listBoxAusgabe.Items.Add(reader["ArtikelNr"].ToString() + ": " + reader["Bezeichnung"]);
            }
            listBoxAusgabe.DataSource = artikelList;
            reader.Close();
        }

        private Artikel mkArtikelObject(OleDbDataReader reader)
        {
            Artikel a = new Artikel();
            int i = 0;

            a.ArtikelOid = reader.GetInt32(i);
            i++;
            a.ArtikelNr = Convert.ToString(CheckDBNull(reader[i++]));
            a.ArtikelGruppe = Convert.ToInt32(CheckDBNull(reader[i++]));
            a.Bezeichnung = Convert.ToString(CheckDBNull(reader[i++]));
            a.Bestand = Convert.ToUInt16(CheckDBNull(reader[i++]));
            a.Meldebestand = Convert.ToInt16(CheckDBNull(reader[i++]));
            a.Verpackung = Convert.ToInt32(CheckDBNull(reader[i++]));
            a.VkPreis = Convert.ToDecimal(CheckDBNull(reader[i++]));
            a.LetzteEntnahme = Convert.ToDateTime(CheckDBNull(reader[i++]));


            return a;
        }

        private Object CheckDBNull(Object o)
        {
            if (o == DBNull.Value) return null;
            else return o;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (listBoxAusgabe.SelectedItem != null)
            {
                Artikel a = (Artikel)listBoxAusgabe.SelectedItem;
                Form2 frmUpdate = new Form2(a);
                frmUpdate.ShowDialog(); // modales Fenster = innerhalb der Anwendung kann kein anderes Fenster verwendet werden
                if(frmUpdate.Result == DialogResult.OK)
                {
                    updateArtikel(a);
                }
                else
                {
                    this.toolStripStatusLabel1.Text = "Änderung wurde abgebrochen";
                }
            }
            
        }

        private void updateArtikel(Artikel a)
        {
            //TODO: Command-Objekt
            OleDbCommand cmd = con.CreateCommand();
            //TODO: Parameter generieren
            cmd.Parameters.AddWithValue("ANR", a.ArtikelNr);
            cmd.Parameters.AddWithValue("BEZ", a.Bezeichnung);
            cmd.Parameters.AddWithValue("BEST", a.Bestand);
            cmd.Parameters.AddWithValue("MELDBEST", a.Meldebestand);
            cmd.Parameters.AddWithValue("VKP", a.VkPreis);
            cmd.Parameters.AddWithValue("LENT", a.LetzteEntnahme);
            //TODO: Commandtext: SQL
            String sql = "UPDATE tArtikel SET ArtikelNr = ANR, Bezeichnung = BEZ, Bestand = BEST, Meldebestand = MELDBEST, VkPreis = VKP, letzteEntnahme = LENT ";   //Bei ? statt ANR wird der erste Wert verwendet
            sql += "WHERE ArtikelOid = " + a.ArtikelOid.ToString();
            cmd.CommandText = sql;
            //TODO: Conn open
            //con.Open(); -> ist schon offen
            //TODO: Command ausführen
            try
            {
                cmd.ExecuteNonQuery();
                toolStripStatusLabel1.Text = "Update erfolgreich";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fehler beim Update");
                toolStripStatusLabel1.Text = exc.Message;
            }
        }
    }
}
