using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace handelskalkulation
{
    public partial class frm_handelskalkulation : Form
    {
        // // klassenweite Variablen für Vorwärtskalkulation
        double nettolisteneinkaufspreis = 262.15;
        double lieferantenrabattsatz = 3;
        double lieferantenrabatt;
        double zieleinkaufspreis = 0;
        double lieferskontosatz = 2;
        double lieferskonto;
        double bareinkaufspreis;
        double bezugskosten = 7.35;
        double einstandspreis;
        double handlungskostensatz = 13.25;
        double handlungskosten;
        double selbstkostenpreis;
        double gewinnsatz = 25;
        double gewinn;
        double barverkaufspreis;
        double kundenskontosatz = 2;
        double kundenskonto;
        double zielverkaufspreis;
        double kundenrabattsatz = 3;
        double kundenrabatt;
        double nettolistenverkaufspreis;
        double umsatzsteuersatz = 19;
        double umsatzsteuer;
        double bruttoverkaufspreis;

        // // klassenweite Variablen für Rückwärtskalkulation
        double r_nettolisteneinkaufspreis = 262.15;
        double r_lieferantenrabattsatz = 3;
        double r_lieferantenrabatt;
        double r_zieleinkaufspreis = 0;
        double r_lieferskontosatz = 2;
        double r_lieferskonto;
        double r_bareinkaufspreis;
        double r_bezugskosten = 7.35;
        double r_einstandspreis;
        double r_handlungskostensatz = 13.25;
        double r_handlungskosten;
        double r_selbstkostenpreis;
        double r_gewinnsatz = 25;
        double r_gewinn;
        double r_barverkaufspreis;
        double r_kundenskontosatz = 2;
        double r_kundenskonto;
        double r_zielverkaufspreis;
        double r_kundenrabattsatz = 3;
        double r_kundenrabatt;
        double r_nettolistenverkaufspreis;
        double r_umsatzsteuersatz = 19;
        double r_umsatzsteuer;
        double r_bruttoverkaufspreis = 454.6415;

        // // klassenweite Variablen für Differenzkalkulation
        double d_nettolisteneinkaufspreis = 262.15;
        double d_lieferantenrabattsatz = 3;
        double d_lieferantenrabatt;
        double d_zieleinkaufspreis = 0;
        double d_lieferskontosatz = 2;
        double d_lieferskonto;
        double d_bareinkaufspreis;
        double d_bezugskosten = 7.35;
        double d_einstandspreis;
        double d_handlungskostensatz = 13.25;
        double d_handlungskosten;
        double d_selbstkostenpreis;
        double d_gewinnsatz;
        double d_gewinn;
        double d_barverkaufspreis;
        double d_kundenskontosatz = 2;
        double d_kundenskonto;
        double d_zielverkaufspreis;
        double d_kundenrabattsatz = 3;
        double d_kundenrabatt;
        double d_nettolistenverkaufspreis;
        double d_umsatzsteuersatz = 19;
        double d_umsatzsteuer;
        double d_bruttoverkaufspreis = 454.6415;

        public frm_handelskalkulation()
        {
            InitializeComponent();

            // variable Werte in Textboxen für Vorwärtskalkulation
            tb_nettolisteneinkaufspreis.Text = nettolisteneinkaufspreis.ToString();
            tb_lieferantenrabattsatz.Text = lieferantenrabattsatz.ToString();
            tb_lieferskontosatz.Text = lieferskontosatz.ToString();
            tb_bezugskosten.Text = bezugskosten.ToString();
            tb_handlungskostensatz.Text = handlungskostensatz.ToString();
            tb_gewinnsatz.Text = gewinnsatz.ToString();
            tb_kundenskontosatz.Text = kundenskontosatz.ToString();
            tb_kundenrabattsatz.Text = kundenrabattsatz.ToString();
            tb_umsatzsteuersatz.Text = umsatzsteuersatz.ToString();

            // variable Werte in Textboxen für Rückwärtskalkulation
            tb_r_lieferantenrabattsatz.Text = r_lieferantenrabattsatz.ToString();
            tb_r_lieferskontosatz.Text = r_lieferskontosatz.ToString();
            tb_r_bezugskosten.Text = r_bezugskosten.ToString();
            tb_r_handlungskostensatz.Text = r_handlungskostensatz.ToString();
            tb_r_gewinnsatz.Text = r_gewinnsatz.ToString();
            tb_r_kundenskontosatz.Text = r_kundenskontosatz.ToString();
            tb_r_kundenrabattsatz.Text = r_kundenrabattsatz.ToString();
            tb_r_umsatzsteuersatz.Text = r_umsatzsteuersatz.ToString();
            tb_r_bruttoverkaufspreis.Text = r_bruttoverkaufspreis.ToString();

            // variable Werte in Textboxen für Differenzkalkulation
            tb_d_nettolisteneinkaufspreis.Text = d_nettolisteneinkaufspreis.ToString();
            tb_d_lieferantenrabattsatz.Text = d_lieferantenrabattsatz.ToString();
            tb_d_lieferskontosatz.Text = d_lieferskontosatz.ToString();
            tb_d_bezugskosten.Text = d_bezugskosten.ToString();
            tb_d_handlungskostensatz.Text = d_handlungskostensatz.ToString();
            tb_d_kundenskontosatz.Text = d_kundenskontosatz.ToString();
            tb_d_kundenrabattsatz.Text = d_kundenrabattsatz.ToString();
            tb_d_umsatzsteuersatz.Text = d_umsatzsteuersatz.ToString();
            tb_d_bruttoverkaufspreis.Text = d_bruttoverkaufspreis.ToString();
            tb_d_bruttoverkaufspreis.Text = d_bruttoverkaufspreis.ToString();

        }

        // Formel für von hundert (Addition) -> operation = "+" und von hundert (Subtraktion -> operation = "-"
        private double von_hundert_operation(double gegebener_wert,double satz,string operation)
        {
            // Addition?
            if (operation == "+")
            {
                return gegebener_wert * (1 + satz / 100);
            }

            // Subtraktion?
            else if (operation == "-")
            {
                return gegebener_wert * (1 - satz / 100);
            }

            else
            {
                return 0;
            }

        }

        // Formel für in hundert -> operation = "+" und auf hundert -> operation = "-"
        private double in_hundert_operation(double gegebener_wert, double satz, string operation)
        {
            // in hundert?
            if (operation == "+")
            {
                return gegebener_wert / (1 - satz / 100);
            }

            // auf hundert?
            else if (operation == "-")
            {
                return gegebener_wert / (1 + satz / 100);
            }

            else
            {
                return 0;
            }
        }

        // Formel für prozentualen Anteil
        private double prozentualer_anteil(double gegebener_wert, double satz)
        {
            return gegebener_wert * (satz / 100);         
        }

        // Formel für Anteil in Prozent
        private double prozentualer_satz(double anteil, double von)
        {
            return anteil/von*100;
        }

        // Formel für Addition -> operation "+" und für Subtraktion -> operation = "-"
        private double arithm_operation(double operand_1, double operand_2, string operation)
        {
            // Addition
            if (operation == "+")
            {
                return operand_1 + operand_2;
            }

            // Subtraktion
            else if (operation == "-")
            {
                return operand_1 - operand_2;
            }
            else
            {
                return 0;
            }
        }

        private void btn_vorwaertskalkulation_Click(object sender, EventArgs e)
        {
            // ******************************************************
            // **** Zieleinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            nettolisteneinkaufspreis = Convert.ToDouble(tb_nettolisteneinkaufspreis.Text);
            lieferantenrabattsatz = Convert.ToDouble(tb_lieferantenrabattsatz.Text);
            
            // Berechnungen
            zieleinkaufspreis = von_hundert_operation(nettolisteneinkaufspreis, lieferantenrabattsatz, "-");
            lieferantenrabatt = prozentualer_anteil(nettolisteneinkaufspreis, lieferantenrabattsatz);
            
            // Textboxwerte aktualisieren
            tb_lieferantenrabatt.Text = String.Format("{0:,0.00}", lieferantenrabatt);
            tb_zieleinkaufspreis.Text = String.Format("{0:,0.00}", zieleinkaufspreis) ;
            tb_zieleinkaufspreis_2.Text = tb_zieleinkaufspreis.Text;

            // ******************************************************
            // **** Bareinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            lieferskontosatz = Convert.ToDouble(tb_lieferskontosatz.Text);

            // Berechnungen
            bareinkaufspreis = von_hundert_operation(zieleinkaufspreis, lieferskontosatz, "-");
            lieferskonto = prozentualer_anteil(zieleinkaufspreis, lieferskontosatz);

            // Textboxwerte aktualisieren
            tb_lieferskonto.Text = String.Format("{0:,0.00}",lieferskonto );
            tb_bareinkaufspreis.Text = String.Format("{0:,0.00}", bareinkaufspreis);
            tb_bareinkaufspreis_2.Text = tb_bareinkaufspreis.Text;

            // ******************************************************
            // **** Einstandspreis
            // ******************************************************

            // Textboxwerte lesen
            bezugskosten = Convert.ToDouble(tb_bezugskosten.Text);

            // Berechnungen
            einstandspreis = arithm_operation(bareinkaufspreis, bezugskosten, "+");

            // Textboxwerte aktualisieren
            tb_einstandspreis.Text = String.Format("{0:,0.00}", einstandspreis);
            tb_einstandspreis_2.Text = tb_einstandspreis.Text;

            // ******************************************************
            // **** Selbstkostenpreis
            // ******************************************************
            
            // Textboxwerte lesen
            handlungskostensatz = Convert.ToDouble(tb_handlungskostensatz.Text);

            // Berechnungen
            selbstkostenpreis = von_hundert_operation(einstandspreis, handlungskostensatz, "+");
            handlungskosten = prozentualer_anteil(einstandspreis, handlungskostensatz);

            // Textboxwerte aktualisieren
            tb_handlungskosten.Text = String.Format("{0:,0.00}", handlungskosten);
            tb_selbstkostenpreis.Text = String.Format("{0:,0.00}", selbstkostenpreis);
            tb_selbstkostenpreis_2.Text = tb_selbstkostenpreis.Text;

            // ******************************************************
            // **** Barverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            gewinnsatz = Convert.ToDouble(tb_gewinnsatz.Text);

            // Berechnungen
            barverkaufspreis = von_hundert_operation(selbstkostenpreis, gewinnsatz, "+");
            gewinn = prozentualer_anteil(selbstkostenpreis, gewinnsatz);

            // Textboxwerte aktualisieren
            tb_gewinn.Text = String.Format("{0:,0.00}", gewinn);
            tb_barverkaufspreis.Text = String.Format("{0:,0.00}", barverkaufspreis);
            tb_barverkaufspreis_2.Text = tb_barverkaufspreis.Text;

            // ******************************************************
            // **** Zielverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            kundenskontosatz = Convert.ToDouble(tb_kundenskontosatz.Text);

            // Berechnungen
            zielverkaufspreis = in_hundert_operation(barverkaufspreis, kundenskontosatz, "+");
            kundenskonto = prozentualer_anteil(zielverkaufspreis, kundenskontosatz);

            // Textboxwerte aktualisieren
            tb_kundenskonto.Text = String.Format("{0:,0.00}", kundenskonto);
            tb_zielverkaufspreis.Text = String.Format("{0:,0.00}", zielverkaufspreis);
            tb_zielverkaufspreis_2.Text = tb_zielverkaufspreis.Text;

            // ******************************************************
            // **** Nettolistenverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            kundenrabattsatz = Convert.ToDouble(tb_kundenrabattsatz.Text);

            // Berechnungen
            nettolistenverkaufspreis = in_hundert_operation(zielverkaufspreis, kundenrabattsatz, "+");
            kundenrabatt = prozentualer_anteil(nettolistenverkaufspreis, kundenrabattsatz);

            // Textboxwerte aktualisieren
            tb_kundenrabatt.Text = String.Format("{0:,0.00}", kundenrabatt);
            tb_nettolistenverkaufspreis.Text = String.Format("{0:,0.00}", nettolistenverkaufspreis);
            tb_nettolistenverkaufspreis_2.Text = tb_nettolistenverkaufspreis.Text;

            // ******************************************************
            // **** Bruttoverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            umsatzsteuersatz = Convert.ToDouble(tb_umsatzsteuersatz.Text);

            // Berechnungen
            bruttoverkaufspreis = von_hundert_operation(nettolistenverkaufspreis, umsatzsteuersatz, "+");
            umsatzsteuer = prozentualer_anteil(nettolistenverkaufspreis, umsatzsteuersatz);

            // Textboxwerte aktualisieren
            tb_umsatzsteuer.Text = String.Format("{0:,0.00}", umsatzsteuer);
            tb_bruttoverkaufspreis.Text = String.Format("{0:,0.00}", bruttoverkaufspreis);
        }

        private void btn_rueckwaertskalkulation_Click(object sender, EventArgs e)
        {
            // ******************************************************
            // **** Nettolistenverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            r_bruttoverkaufspreis = Convert.ToDouble(tb_r_bruttoverkaufspreis.Text);
            r_umsatzsteuersatz = Convert.ToDouble(tb_r_umsatzsteuersatz.Text);

            // Berechnungen
            r_nettolistenverkaufspreis = in_hundert_operation(r_bruttoverkaufspreis, r_umsatzsteuersatz, "-");
            r_umsatzsteuer = prozentualer_anteil(r_nettolistenverkaufspreis, r_umsatzsteuersatz);

            // Textboxwerte aktualisieren
            tb_r_umsatzsteuer.Text = String.Format("{0:,0.00}", r_umsatzsteuer);
            tb_r_nettolistenverkaufspreis.Text = String.Format("{0:,0.00}", r_nettolistenverkaufspreis);
            tb_r_nettolistenverkaufspreis_2.Text = tb_r_nettolistenverkaufspreis.Text;

            // ******************************************************
            // **** Zielverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            r_kundenrabattsatz = Convert.ToDouble(tb_r_kundenrabattsatz.Text);

            // Berechnungen
            r_zielverkaufspreis = von_hundert_operation(r_nettolistenverkaufspreis, r_kundenrabattsatz, "-");
            r_kundenrabatt = prozentualer_anteil(r_nettolistenverkaufspreis, r_kundenrabattsatz);

            // Textboxwerte aktualisieren
            tb_r_kundenrabatt.Text = String.Format("{0:,0.00}", r_kundenrabatt);
            tb_r_zielverkaufspreis.Text = String.Format("{0:,0.00}", r_zielverkaufspreis);
            tb_r_zielverkaufspreis_2.Text = tb_r_zielverkaufspreis.Text;

            // ******************************************************
            // **** Barverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            r_kundenskontosatz = Convert.ToDouble(tb_r_kundenskontosatz.Text);

            // Berechnungen
            r_barverkaufspreis = von_hundert_operation(r_zielverkaufspreis, r_kundenskontosatz, "-");
            r_kundenskonto = prozentualer_anteil(r_zielverkaufspreis, r_kundenskontosatz);

            // Textboxwerte aktualisieren
            tb_r_kundenskonto.Text = String.Format("{0:,0.00}", r_kundenskonto);
            tb_r_barverkaufspreis.Text = String.Format("{0:,0.00}", r_barverkaufspreis);
            tb_r_barverkaufspreis_2.Text = tb_r_barverkaufspreis.Text;

            // ******************************************************
            // **** Selbstkostenpreis
            // ******************************************************

            // Textboxwerte lesen
            r_gewinnsatz = Convert.ToDouble(tb_r_gewinnsatz.Text);

            // Berechnungen
            r_selbstkostenpreis = in_hundert_operation(r_barverkaufspreis, r_gewinnsatz, "-");
            r_gewinn = prozentualer_anteil(r_selbstkostenpreis, r_gewinnsatz);

            // Textboxwerte aktualisieren
            tb_r_gewinn.Text = String.Format("{0:,0.00}", r_gewinn);
            tb_r_selbstkostenpreis.Text = String.Format("{0:,0.00}", r_selbstkostenpreis);
            tb_r_selbstkostenpreis_2.Text = tb_r_selbstkostenpreis.Text;

            // ******************************************************
            // **** Einstandspreis
            // ******************************************************

            // Textboxwerte lesen
            r_handlungskostensatz = Convert.ToDouble(tb_r_handlungskostensatz.Text);

            // Berechnungen
            r_einstandspreis = in_hundert_operation(r_selbstkostenpreis, r_handlungskostensatz, "-");
            r_handlungskosten = prozentualer_anteil(r_einstandspreis, r_handlungskostensatz);

            // Textboxwerte aktualisieren
            tb_r_handlungskosten.Text = String.Format("{0:,0.00}", r_handlungskosten);
            tb_r_einstandspreis.Text = String.Format("{0:,0.00}", r_einstandspreis);
            tb_r_einstandspreis_2.Text = tb_r_einstandspreis.Text;

            // ******************************************************
            // **** Bareinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            r_bezugskosten = Convert.ToDouble(tb_r_bezugskosten.Text);

            // Berechnungen
            r_bareinkaufspreis = arithm_operation(r_einstandspreis, r_bezugskosten, "-");

            // Textboxwerte aktualisieren
            tb_r_bareinkaufspreis.Text = String.Format("{0:,0.00}", r_bareinkaufspreis);
            tb_r_bareinkaufspreis_2.Text = tb_r_bareinkaufspreis.Text;

            // ******************************************************
            // **** Zieleinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            r_lieferskontosatz = Convert.ToDouble(tb_r_lieferskontosatz.Text);

            // Berechnungen
            r_zieleinkaufspreis = in_hundert_operation(r_bareinkaufspreis, r_lieferskontosatz, "+");
            r_lieferskonto = prozentualer_anteil(r_zieleinkaufspreis, r_lieferskontosatz);

            // Textboxwerte aktualisieren
            tb_r_lieferskonto.Text = String.Format("{0:,0.00}", r_lieferskonto);
            tb_r_zieleinkaufspreis.Text = String.Format("{0:,0.00}", r_zieleinkaufspreis);
            tb_r_zieleinkaufspreis_2.Text = tb_r_zieleinkaufspreis.Text;

            // ******************************************************
            // **** Nettolisteneinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            r_lieferantenrabattsatz = Convert.ToDouble(tb_r_lieferantenrabattsatz.Text);

            // Berechnungen
            r_nettolisteneinkaufspreis = in_hundert_operation(r_zieleinkaufspreis, r_lieferantenrabattsatz, "+");
            r_lieferantenrabatt = prozentualer_anteil(r_nettolisteneinkaufspreis, r_lieferantenrabattsatz);

            // Textboxwerte aktualisieren
            tb_r_lieferantenrabatt.Text = String.Format("{0:,0.00}", r_lieferantenrabatt);
            tb_r_nettolisteneinkaufspreis.Text = String.Format("{0:,0.00}", r_nettolisteneinkaufspreis);
        }

        private void btn_differenzkalkulation_Click(object sender, EventArgs e)
        {
            // Vorwärtskalkulation bis Selbstkostenpreis
            // ******************************************************
            // **** Zieleinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            d_nettolisteneinkaufspreis = Convert.ToDouble(tb_d_nettolisteneinkaufspreis.Text);
            d_lieferantenrabattsatz = Convert.ToDouble(tb_d_lieferantenrabattsatz.Text);

            // Berechnungen
            d_zieleinkaufspreis = von_hundert_operation(d_nettolisteneinkaufspreis, d_lieferantenrabattsatz, "-");
            d_lieferantenrabatt = prozentualer_anteil(d_nettolisteneinkaufspreis, d_lieferantenrabattsatz);

            // Textboxwerte aktualisieren
            tb_d_lieferantenrabatt.Text = String.Format("{0:,0.00}", d_lieferantenrabatt);
            tb_d_zieleinkaufspreis.Text = String.Format("{0:,0.00}", d_zieleinkaufspreis);
            tb_d_zieleinkaufspreis_2.Text = tb_d_zieleinkaufspreis.Text;

            // ******************************************************
            // **** Bareinkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            d_lieferskontosatz = Convert.ToDouble(tb_d_lieferskontosatz.Text);

            // Berechnungen
            d_bareinkaufspreis = von_hundert_operation(d_zieleinkaufspreis, d_lieferskontosatz, "-");
            d_lieferskonto = prozentualer_anteil(d_zieleinkaufspreis, d_lieferskontosatz);

            // Textboxwerte aktualisieren
            tb_d_lieferskonto.Text = String.Format("{0:,0.00}", d_lieferskonto);
            tb_d_bareinkaufspreis.Text = String.Format("{0:,0.00}", d_bareinkaufspreis);
            tb_d_bareinkaufspreis_2.Text = tb_d_bareinkaufspreis.Text;

            // ******************************************************
            // **** Einstandspreis
            // ******************************************************

            // Textboxwerte lesen
            d_bezugskosten = Convert.ToDouble(tb_d_bezugskosten.Text);

            // Berechnungen
            d_einstandspreis = arithm_operation(d_bareinkaufspreis, d_bezugskosten, "+");

            // Textboxwerte aktualisieren
            tb_d_einstandspreis.Text = String.Format("{0:,0.00}", d_einstandspreis);
            tb_d_einstandspreis_2.Text = tb_d_einstandspreis.Text;

            // ******************************************************
            // **** Selbstkostenpreis
            // ******************************************************

            // Textboxwerte lesen
            d_handlungskostensatz = Convert.ToDouble(tb_d_handlungskostensatz.Text);

            // Berechnungen
            d_selbstkostenpreis = von_hundert_operation(d_einstandspreis, d_handlungskostensatz, "+");
            d_handlungskosten = prozentualer_anteil(d_einstandspreis, d_handlungskostensatz);

            // Textboxwerte aktualisieren
            tb_d_handlungskosten.Text = String.Format("{0:,0.00}", d_handlungskosten);
            tb_d_selbstkostenpreis.Text = String.Format("{0:,0.00}", d_selbstkostenpreis);
            tb_d_selbstkostenpreis_2.Text = tb_d_selbstkostenpreis.Text;


            // Rückwärtskalkulation bis Barverkaufspreis
            // ******************************************************
            // **** Nettolistenverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            d_bruttoverkaufspreis = Convert.ToDouble(tb_d_bruttoverkaufspreis.Text);
            d_umsatzsteuersatz = Convert.ToDouble(tb_d_umsatzsteuersatz.Text);

            // Berechnungen
            d_nettolistenverkaufspreis = in_hundert_operation(d_bruttoverkaufspreis, d_umsatzsteuersatz, "-");
            d_umsatzsteuer = prozentualer_anteil(d_nettolistenverkaufspreis, d_umsatzsteuersatz);

            // Textboxwerte aktualisieren
            tb_d_umsatzsteuer.Text = String.Format("{0:,0.00}", d_umsatzsteuer);
            tb_d_nettolistenverkaufspreis.Text = String.Format("{0:,0.00}", d_nettolistenverkaufspreis);
            tb_d_nettolistenverkaufspreis_2.Text = tb_d_nettolistenverkaufspreis.Text;

            // ******************************************************
            // **** Zielverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            d_kundenrabattsatz = Convert.ToDouble(tb_d_kundenrabattsatz.Text);

            // Berechnungen
            d_zielverkaufspreis = von_hundert_operation(d_nettolistenverkaufspreis, d_kundenrabattsatz, "-");
            d_kundenrabatt = prozentualer_anteil(d_nettolistenverkaufspreis, d_kundenrabattsatz);

            // Textboxwerte aktualisieren
            tb_d_kundenrabatt.Text = String.Format("{0:,0.00}", d_kundenrabatt);
            tb_d_zielverkaufspreis.Text = String.Format("{0:,0.00}", d_zielverkaufspreis);
            tb_d_zielverkaufspreis_2.Text = tb_d_zielverkaufspreis.Text;

            // ******************************************************
            // **** Barverkaufspreis
            // ******************************************************

            // Textboxwerte lesen
            d_kundenskontosatz = Convert.ToDouble(tb_d_kundenskontosatz.Text);

            // Berechnungen
            d_barverkaufspreis = von_hundert_operation(d_zielverkaufspreis, d_kundenskontosatz, "-");
            d_kundenskonto = prozentualer_anteil(d_zielverkaufspreis, d_kundenskontosatz);

            // Textboxwerte aktualisieren
            tb_d_kundenskonto.Text = String.Format("{0:,0.00}", d_kundenskonto);
            tb_d_barverkaufspreis.Text = String.Format("{0:,0.00}", d_barverkaufspreis);
            tb_d_barverkaufspreis_2.Text = tb_d_barverkaufspreis.Text;

            // ******************************************************
            // **** Gewinn und Gewinnsatz
            // ******************************************************
            // Berechnungen
            d_gewinn = arithm_operation(d_barverkaufspreis, d_selbstkostenpreis,"-");
            d_gewinnsatz = prozentualer_satz(d_gewinn, d_selbstkostenpreis);

            // Textboxwerte aktualisieren
            tb_d_gewinn.Text = String.Format("{0:,0.00}", d_gewinn);
            tb_d_gewinnsatz.Text = String.Format("{0:,0.00}", d_gewinnsatz);
        }
    }
}
