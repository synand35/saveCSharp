using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;




namespace GestionRendezVous
{
    public partial class MainWindow : Form
    {
        protected DatabaseConnection connection;
        private Button selectedButtonPage;
        private MySqlCommand cmd;
        Form1 frm1;
        Form2 frm2;
        public MainWindow()
        {
            InitializeComponent();
            connection = new DatabaseConnection("localhost", "rdvcomptable", "root", "");

            ListeRendezVous();
            //if (Liste.ColumnCount == 0) {
            //}
            //else
            //{

            //Liste.Columns[0].Width = 50;
            //Liste.Columns[1].Width = 80;
            //Liste.Columns[2].Width = 120;
            //Liste.Columns[3].Width = 100;
            //Liste.Columns[4].Width = 100;
            //Liste.Columns[5].Width = 60;
            //}

            SetPanelBorderRadius(panel4, 5);
            AddPanelBorderShadow(panel4, Color.Gray, 2);
            AddPanelShadow(panel4);

            RoundedTextBox textBox = new RoundedTextBox();
            textBox.CornerRadius = 10;
            textBox.BorderColor = Color.Red;
            textBox.BorderWidth = 2;

            Liste.CellContentDoubleClick += Liste_CellClick;
        }

        private void Liste_CellClick(object sender, DataGridViewCellEventArgs e) {

            if (e.ColumnIndex ==7 && e.RowIndex >= 0) // buttonColumnIndex est l'index de la colonne de boutons
            {
                // Exemple : Afficher un message avec l'index de la 
                DataGridViewRow selectedRow = Liste.Rows[e.RowIndex];
                // Accéder aux valeurs des cellules de la ligne sélectionnée
                string NumeroRdv = selectedRow.Cells["N°"].Value.ToString();
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer  le rendez vous  numero "+ NumeroRdv + "?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {            
                    supprimer(NumeroRdv);
                    Liste.Refresh();
                    MessageBox.Show("Le rendez-vous Numero" + NumeroRdv + "a été supprmier");
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("La suppression a été annulée");
                }

            }
            if (e.ColumnIndex ==6 && e.RowIndex >= 0) // buttonColumnIndex est l'index de la colonne de boutons
            {
                // Exemple : Afficher un message avec l'index de la 
                DataGridViewRow selectedRow = Liste.Rows[e.RowIndex];
                // Accéder aux valeurs des cellules de la ligne sélectionnée
                string NumeroRdv = selectedRow.Cells["N°"].Value.ToString();
                string NumCli = selectedRow.Cells["N°_client"].Value.ToString();
                string NumCompt = selectedRow.Cells["N°_Comptable"].Value.ToString();
                DateTime Date =(DateTime) selectedRow.Cells["Date"].Value;
                string Heure = selectedRow.Cells["Heure"].Value.ToString();
                
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier  le rendez vous  numero " + NumeroRdv + "?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Form2.SetId(NumeroRdv, NumCli, NumCompt, Date, Heure);
                    frm2 = new Form2();
                   
                   frm2.ShowDialog();
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("La modificaion a été annulée");
                }
            }
        }

        public static  void ListeRendezVous()
        {
            String querryListeREndezvous ="Select rdv_id as N°,client_id as N°_client,comptable_id as N°_Comptable,date as Date,heure as Heure, satut as Statu from rendezvous order by date ASC";
           MainWindow.Liste.DataSource = DatabaseConnection.StaticRecupererDonnees(querryListeREndezvous);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // initialisation de la base de donnée 
            connection = new DatabaseConnection("localhost", "rdvcomptable", "root", "");

        }
            // initiation des donnée dans la table 

        // methode de get pour  tout les donnée
        private List<Dictionary<string, object>> GetAllMyAppoints()
        {
            connection.OpenConnection();
            Dictionary<string, object> result = new Dictionary<string,object>();
            // recuperer tout les donnée
            List<Dictionary<string, object>> resultats = connection.ExecuteSelectQuery("clients");

            connection.CloseConnection();
            return resultats;
        }


        private void TakeMeetingBtn_Click(object sender, EventArgs e)
        {
            TabController.SelectedTab = TabController.TabPages["TakeMeetingPage"];
            ChangeButtonBackGround(sender);
        }
        private void ChangeButtonBackGround(object sender)
        {
            Button clickedButton = (Button)sender;

            if (selectedButtonPage != null)
            {
                selectedButtonPage.BackColor = Color.Transparent;
                selectedButtonPage.ForeColor = Color.White;
            }
            // changer la background du selection en 
            clickedButton.BackColor = Color.DimGray;
            clickedButton.ForeColor = Color.WhiteSmoke;
            selectedButtonPage = clickedButton;
        }

        private void MyAppointBtn_Click(object sender, EventArgs e)
        {
            TabController.SelectedTab = TabController.TabPages["MyAppointsPage"];
            ChangeButtonBackGround(sender);
        }

        private void ClientBtn_Click(object sender, EventArgs e)
        {
            TabController.SelectedTab = TabController.TabPages["ClientPage"];
            ChangeButtonBackGround(sender);
        }
        private void Afficherclient()
        {
            connection.OpenConnection();

            MySqlCommand comand = new MySqlCommand("SELECT * FROM clients",connection.GetConnection());
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            using (MySqlDataReader reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        object value = reader.GetValue(i);

                        row[columnName] = value;
                    }

                    results.Add(row);
                }
                ClientData.DataSource = results;
            }


            connection.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            frm1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(Search.Text.Length>0)
            {
                String Recherche = "Select rdv_id as Numero,client_id as Num_du_client,comptable_id as Num_du_Comptable,date as Date,heure as Heure, satut as Statu from rendezvous where rdv_id like'%"+Search.Text +"%'";
                Liste.DataSource = connection.RecupererDonnees(Recherche);

 
            }
            else
            {
                ListeRendezVous();
            }
        }
        private void SetPanelBorderRadius(Panel panel, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, panel.Width, panel.Height);
            int diameter = radius * 2;

            // Créer le chemin graphique avec des coins arrondis
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();

            // Appliquer le chemin graphique au panel
            panel.Region = new Region(path);
        }
        private void AddPanelBorderShadow(Panel panel, Color shadowColor, int shadowSize)
        {
            panel.BorderStyle = BorderStyle.None;
            panel.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    shadowColor, shadowSize, ButtonBorderStyle.Solid,
                    shadowColor, shadowSize, ButtonBorderStyle.Solid,
                    shadowColor, shadowSize, ButtonBorderStyle.Solid,
                    shadowColor, shadowSize, ButtonBorderStyle.Solid);
            };
        }
        private void AddPanelShadow(Panel panel)
        {
            panel.Padding = new Padding(10); // Augmente la marge intérieure du panel pour laisser de la place à l'ombre

            panel.Paint += (sender, e) =>
            {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(100, Color.Black)))
                {
                    var shadowRect = new Rectangle(
                        panel.Location.X + panel.Width + 5, // Ajustez la position de l'ombre en fonction de vos préférences
                        panel.Location.Y + 5, // Ajustez la position de l'ombre en fonction de vos préférences
                        10, // Ajustez la largeur de l'ombre en fonction de vos préférences
                        panel.Height - 10 // Ajustez la hauteur de l'ombre en fonction de vos préférences
                    );

                    e.Graphics.FillRectangle(shadowBrush, shadowRect);
                }
            };
        }
        private void supprimer( string IdDelete)
        {
            connection = new DatabaseConnection("localhost", "rdvcomptable", "root", "");
            connection.OpenConnection();
            string queryDelete = "delete from rendezvous where rdv_id ='" + IdDelete+ "'";
            cmd = new MySqlCommand(queryDelete, connection.GetConnection());
            cmd.ExecuteNonQuery();
            MainWindow.ListeRendezVous();
            connection.CloseConnection();
        }
    }
}

