using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tehtavaa20
{
    public partial class Form1 : Form
    {
        OPISKELIJA opiskelija = new OPISKELIJA();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TietoTautlu_dataGridView.DataSource = opiskelija.haeOpiskelijat();
        }

        private void tyhjenna_button_Click(object sender, EventArgs e)
        {
            id_textBox.Text = "";
            etunim_textBox.Text = "";
            sukunim_textBox.Text = "";
            puhelin_textBox.Text = "";
            sahkoposti_textBox.Text = "";
            opiskelNum_textBox.Text = "";
        }

        private void tallena_button_Click(object sender, EventArgs e)
        {
            string enimi = etunim_textBox.Text;
            string snimi = sukunim_textBox.Text;
            string puhelin = puhelin_textBox.Text;
            string email = sahkoposti_textBox.Text;
            int oNoro = Int32.Parse(opiskelNum_textBox.Text);
            
            if (enimi.Trim().Equals("") || snimi.Trim().Equals("") || puhelin.Trim().Equals("") || email.Trim().Equals("") || oNoro.Equals(""))
            {
                MessageBox.Show("VIRHE - Vaaditut kentät - Etu- ja sukunimi, puhelin, sähköposti ja opiskelijanumero", "Tyhjä kenttä", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean lisaaAsiakas = opiskelija.lisaaOpiskelija(enimi, snimi, puhelin, email, oNoro);
                if (lisaaAsiakas)
                {
                    MessageBox.Show("Uusi opiskelija lisätty onnistuneesti", "Opiskelijan lisäys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Uutta opiskelijaa ei pystytty lisäämään", "opiskelijan lisäys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TietoTautlu_dataGridView.DataSource = opiskelija.haeOpiskelijat();
        }

        private void paivita_button_Click(object sender, EventArgs e)
        {
            string enimi = etunim_textBox.Text;
            string snimi = sukunim_textBox.Text;
            string puhelin = puhelin_textBox.Text;
            string email = sahkoposti_textBox.Text;
            int oNoro = Int32.Parse(opiskelNum_textBox.Text);
            int oid = Int32.Parse(id_textBox.Text);

            if (oid.Equals("") || enimi.Trim().Equals("") || snimi.Trim().Equals("") || puhelin.Trim().Equals("") || email.Trim().Equals("") || oNoro.Equals(""))
            {
                MessageBox.Show("VIRHE - Vaaditut kentät - ID, Etu- ja sukunimi, puhelin, sähköposti ja opiskelijanumero", "Tyjä kenttä", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean lisaaAsiakas = opiskelija.muokkaaOpiskelijaa(oid, enimi, snimi, puhelin, email, oNoro);
                if (lisaaAsiakas)
                {
                    MessageBox.Show("Opiskelija päivitetty onnistuneesti", "Opiskelijan päivitys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opiskelijaa ei pystytty päivittämään", "Opiskelina päivitys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TietoTautlu_dataGridView.DataSource = opiskelija.haeOpiskelijat();
        }

        private void TietoTautlu_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[0].Value.ToString();
            etunim_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[1].Value.ToString();
            sukunim_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[2].Value.ToString();
            puhelin_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[3].Value.ToString();
            sahkoposti_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[4].Value.ToString();
            opiskelNum_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[5].Value.ToString();
        }

        private void poista_button_Click(object sender, EventArgs e)
        {
            string ktunnus = id_textBox.Text;
            if (opiskelija.poistaOpiskelija(ktunnus))
            {
                TietoTautlu_dataGridView.DataSource = opiskelija.haeOpiskelijat();
                MessageBox.Show("Opisekelija poistettu onnistuneesti", "Opiskelijan poisto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Opiskelija ei pystytty poistamaan", "Opiskelijan poisto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tyhjenna_button.PerformClick();
        }

        private void TietoTautlu_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[0].Value.ToString();
            etunim_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[1].Value.ToString();
            sukunim_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[2].Value.ToString();
            puhelin_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[3].Value.ToString();
            sahkoposti_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[4].Value.ToString();
            opiskelNum_textBox.Text = TietoTautlu_dataGridView.CurrentRow.Cells[5].Value.ToString();
        }




        // http://localhost:8012/phpmyadmin




    }
}
