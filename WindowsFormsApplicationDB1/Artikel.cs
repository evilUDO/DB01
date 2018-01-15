using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDB1
{
    public class Artikel
    {
        private Int32 artikelOid;
        private String artikelNr;
        private Int32 artikelGruppe;
        private String bezeichnung;
        private UInt16 bestand;
        private Int16 meldebestand;
        private Int32 verpackung;
        private Decimal vkPreis;
        private DateTime letzteEntnahme;
        public delegate void Bestellmeldung(String meldung);
        public Bestellmeldung onUpdateError;

        public int ArtikelOid
        {
            get
            {
                return artikelOid;
            }

            set
            {
                artikelOid = value;
            }
        }

        public string ArtikelNr
        {
            get
            {
                return artikelNr;
            }

            set
            {
                artikelNr = value;
            }
        }

        public int ArtikelGruppe
        {
            get
            {
                return artikelGruppe;
            }

            set
            {
                artikelGruppe = value;
            }
        }

        public string Bezeichnung
        {
            get
            {
                return bezeichnung;
            }

            set
            {
                bezeichnung = value;
            }
        }

        public ushort Bestand
        {
            get
            {
                return bestand;
            }

            set
            {
                bestand = value;
                if(bestand <= this.Meldebestand)
                {
                    if(onUpdateError != null)
                    {
                        onUpdateError("Meldebestand erreicht!!");
                    }
                }
            }
        }

        public short Meldebestand
        {
            get
            {
                return meldebestand;
            }

            set
            {
                meldebestand = value;
            }
        }

        public int Verpackung
        {
            get
            {
                return verpackung;
            }

            set
            {
                verpackung = value;
            }
        }

        public decimal VkPreis
        {
            get
            {
                return vkPreis;
            }

            set
            {
                vkPreis = value;
            }
        }

        public DateTime LetzteEntnahme
        {
            get
            {
                return letzteEntnahme;
            }

            set
            {
                letzteEntnahme = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.ArtikelOid, this.Bezeichnung);
        }

        public Artikel()
        {
            this.ArtikelNr = String.Empty;
            this.ArtikelGruppe = 0;
            this.Bezeichnung = String.Empty;
            this.Verpackung = 0;
            this.Meldebestand = 0;
            this.VkPreis = 0m;
            this.LetzteEntnahme = DateTime.MinValue; // kann mit ? in der Variable mit null versehen werden
            this.Bestand = 0;
        }
    }
}
