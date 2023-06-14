using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GestionRendezVous
{
    public partial class MainWindow : Form
    {
        protected DatabaseConnection connection;
        private Button selectedButtonPage;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // STYLE DE PANEL DE FILTRE
            SetupRadius(10);
            setShadowBorder(panel5, 10);
            //end Style
            // initialisation de la base de donnée 
            connection = new DatabaseConnection("localhost", "rdvcomptable", "root", "");
            // get all data from the database in a datagridView
            connection.OpenConnection();
            List<Dictionary<string, object>> results = GetAllMyAppoints();
            // afficher dans le tableau 
            setDataTableAppoints(results);


            connection.CloseConnection();
        }

        private void ToogleRowTabColor()
        {
            for (int x = 0; x < DataTableAppoints.RowCount; x++)
            {
                if (x % 2 == 0)
                {
                    DataTableAppoints.Rows[x].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#C8E3D2");
                }
                else
                {
                    DataTableAppoints.Rows[x].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A2D6E1");
                }
            }
        }
        private void setDataTableAppoints(List<Dictionary<string, object>> result)
        {
            DataTableAppoints.Columns.Clear();

            // Créer les colonnes en fonction des clés des dictionnaires
            foreach (string key in result[0].Keys)
            {
                DataTableAppoints.Columns.Add(key, key); // Nom de la colonne et en-tête de la colonne
            }
            foreach (Dictionary<string, object> so in result)
            {
                // formatage de la dates et de  l'heures 
                DateTime dates = (DateTime)so["dates"];
                so["dates"] = dates.ToString("dd-MMM -yyy");
            }

            foreach (Dictionary<string, object> dictionary in result)
            {
                DataGridViewRow row = new DataGridViewRow();
                foreach (KeyValuePair<string, object> kvp in dictionary)
                {

                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    cell.Value = kvp.Value;
                    row.Cells.Add(cell);
                }
                DataTableAppoints.Rows.Add(row);
                ToogleRowTabColor();
            }
        }

        /**
         * Afficher dans la console une List<Dictionary<string,object>>
         */
        private void ConsoleDebugList(List<Dictionary<string, object>> results)
        {
            // Affiche les résultats dans la console
            foreach (Dictionary<string, object> result in results)
            {
                foreach (KeyValuePair<string, object> kvp in result)
                {
                    string columnName = kvp.Key;
                    object columnValue = kvp.Value;
                    Console.WriteLine($"{columnName}: {columnValue}");
                }
                Console.WriteLine(">----------------------<");
            }

        }

        private void SetupRadius(int borderRadius)
        {
            // Définissez la valeur du rayon du coin arrondi
            int rectangleWidth = panel5.Width; // Utilisez la largeur actuelle du contrôle Panel
            int rectangleHeight = panel5.Height; // Utilisez la hauteur actuelle du contrôle Panel

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); // Coin supérieur gauche
            path.AddArc(rectangleWidth - borderRadius, 0, borderRadius, borderRadius, 270, 90); // Coin supérieur droit
            path.AddArc(rectangleWidth - borderRadius, rectangleHeight - borderRadius, borderRadius, borderRadius, 0, 90); // Coin inférieur droit
            path.AddArc(0, rectangleHeight - borderRadius, borderRadius, borderRadius, 90, 90); // Coin inférieur gauche
            path.CloseAllFigures();

            panel5.Region = new System.Drawing.Region(path);
        }


        /* methode de get pour  tout les donnée*/
        private List<Dictionary<string, object>> GetAllMyAppoints()
        {
            List<Dictionary<string, object>> resultats = new List<Dictionary<string, object>>();
            string AllDataSqlQuery = "SELECT clients.nom AS client ,comptables.nom AS comptable,rendezvous.date AS dates , rendezvous.heure AS heures , rendezvous.statut AS Descriptions"
                                    + " FROM clients"
                                    + " INNER JOIN rendezvous"
                                    + " ON clients.client_id = rendezvous.client_id"
                                    + " INNER JOIN comptables"
                                    + " ON comptables.comptable_id = rendezvous.comptable_id";

            using (MySqlCommand cmd = new MySqlCommand(AllDataSqlQuery, connection.GetConnection()))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // creer une Dictonary vide  
                    while (reader.Read())
                    {
                        Dictionary<string, object> rows = new Dictionary<string, object>();
                        // ajout des donner dans la liste 
                        for (int x = 0; x < reader.FieldCount; x++)
                        {
                            string ColName = reader.GetName(x);
                            object Values = reader.GetValue(x);
                            rows[ColName] = Values;
                        }
                        // recuperation dans chaque liste de toute les donner  de chaque lignes 
                        resultats.Add(rows);
                    }
                }
            }
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
        public static void afficherChild()
        {
            Console.WriteLine("test affichage depuis le Main");
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


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Recherche dans les programmes du comptable

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            // RECHERCHE PAR LE NUMERO DU RENDEZVOUS
            string rdv_id = TextBoxSearch.Text;
            int rdv_int;
            bool success = int.TryParse(rdv_id, out rdv_int); // Conversion en entier

            connection.OpenConnection();

            if (success)
            {
                // Conversion réussie, la valeur entière est disponible dans la variable 'number'
                string sqlSearchQuery = "SELECT clients.nom AS client ,comptables.nom AS comptable,rendezvous.date AS dates , rendezvous.heure AS heures , rendezvous.statut AS Descriptions"
                        + " FROM clients"
                        + " INNER JOIN rendezvous"
                        + " ON clients.client_id = rendezvous.client_id"
                        + " INNER JOIN comptables"
                        + " ON comptables.comptable_id = rendezvous.comptable_id"
                        + $" WHERE rendezvous.rdv_id ='{rdv_id}'";
                using (MySqlCommand cmd = new MySqlCommand(sqlSearchQuery, connection.GetConnection()))
                {
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Dictionary<string, object> rows = new Dictionary<string, object>();
                            for (int x = 0; x < rd.FieldCount; x++)
                            {
                                string OBjectKey = rd.GetName(x);
                                object OBjectValue = rd.GetValue(x);
                                rows[OBjectKey] = OBjectValue;
                            }
                            results.Add(rows);
                        }
                    }
                }
            }
            else
            {
                // recherche par nom 
                string ClientName = TextBoxSearch.Text;
                Console.WriteLine("on a ajouter une chaine de caractere : ", ClientName);
                string sqlQuery = "SELECT clients.nom AS client ,comptables.nom AS comptable,rendezvous.date AS dates , rendezvous.heure AS heures , rendezvous.statut AS Descriptions"
                        + " FROM clients"
                        + " INNER JOIN rendezvous"
                        + " ON clients.client_id = rendezvous.client_id"
                        + " INNER JOIN comptables"
                        + " ON comptables.comptable_id = rendezvous.comptable_id"
                        + " WHERE clients.nom LIKE @clientName";
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@clientName", ClientName + "%");
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Dictionary<string, object> rows = new Dictionary<string, object>();
                            for (int x = 0; x < rd.FieldCount; x++)
                            {
                                string ObjectKey = rd.GetName(x);
                                object Values = rd.GetValue(x);
                                rows[ObjectKey] = Values;
                            }
                            results.Add(rows);
                        }
                    }
                }
            }
            connection.CloseConnection();
            // gestion de resulat du recherche 
            if (results.Count == 0)
            {
                MessageResult MR = new MessageResult();
                MR.ShowDialog();
            }
            else
            {
                setDataTableAppoints(results);
            }
        }

        private void comboBoxDay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<Dictionary<string, object>> resultat = new List<Dictionary<string, object>>();
            string DaySelected = comboBoxDay.Text;
            Console.WriteLine($"Selected Data table : {DaySelected}");
            // selection pt jours 
            string SqlQuery = "SELECT clients.nom AS client ,comptables.nom AS comptable,rendezvous.date AS dates , rendezvous.heure AS heures , rendezvous.statut AS Descriptions"
                        + " FROM clients"
                        + " INNER JOIN rendezvous"
                        + " ON clients.client_id = rendezvous.client_id"
                        + " INNER JOIN comptables"
                        + " ON comptables.comptable_id = rendezvous.comptable_id"
                        + " WHERE DAYNAME(rendezvous.date) LIKE @day";
            connection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(SqlQuery, connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@day", DaySelected);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        for (int x = 0; x < rd.FieldCount; x++)
                        {
                            string ObjectKey = rd.GetName(x);
                            object Value = rd.GetValue(x);
                            result[ObjectKey] = Value;
                        }
                        resultat.Add(result);
                    }
                }
            }
            connection.CloseConnection();
            // traitement des resultat du recherche 
            if (resultat.Count == 0)
            {
                MessageResult MR = new MessageResult();
                MR.ShowDialog();
            }
            else
            {
                setDataTableAppoints(resultat);
            }
        }

        private void comboBoxEver_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // filter avee le jours 
            string DaySelected = comboBoxDay.Text;
            string daydescription = comboBoxEver.Text;
            List<Dictionary<string, object>> resultat = new List<Dictionary<string, object>>();
            Console.WriteLine($"Selected Data table : {DaySelected}");
            // selection pt jours 
            string SqlQuery = "SELECT clients.nom AS client ,comptables.nom AS comptable,rendezvous.date AS dates , rendezvous.heure AS heures , rendezvous.statut AS Descriptions"
                        + " FROM clients"
                        + " INNER JOIN rendezvous"
                        + " ON clients.client_id = rendezvous.client_id"
                        + " INNER JOIN comptables"
                        + " ON comptables.comptable_id = rendezvous.comptable_id"
                        + $" WHERE DAYNAME(rendezvous.date) LIKE '{DaySelected}' AND";

            // filter par matin ou midi ou soir      
            switch (daydescription)
            {
                case "Morning":
                    SqlQuery += " TIME(rendezvous.heure) BETWEEN '00:00:00' AND '11:59:59'";
                    break;
                case "Afternoon":
                    SqlQuery += " TIME(rendezvous.heure) BETWEEN '12:00:00' AND '17:59:59'";
                    break;
                case "Evening":
                    SqlQuery += " TIME(rendezvous.heure) BETWEEN '18:00:00' AND '23:59:59'";
                    break;
                default:
                    break;
            }
            Console.WriteLine(SqlQuery);

            connection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(SqlQuery, connection.GetConnection()))
            {
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        for (int x = 0; x < rd.FieldCount; x++)
                        {
                            string ObjectKey = rd.GetName(x);
                            object Value = rd.GetValue(x);
                            result[ObjectKey] = Value;
                        }
                        resultat.Add(result);
                    }
                }
            }
            connection.CloseConnection();
            // 
            if (resultat.Count == 0)
            {
                comboBoxEver.SelectedText = "";
                MessageResult MR = new MessageResult();
                MR.ShowDialog();
            }
            else
            {
                setDataTableAppoints(resultat);
            }
        }
        private void setShadowBorder(Panel panel, int rayonBordure)
        {
            panel.BorderStyle = BorderStyle.None;

            // Créer un panneau d'ombre
            Panel ombrePanel = new Panel();
            ombrePanel.BackColor = ColorTranslator.FromHtml("#2c2c2c");
            ombrePanel.Location = new Point(panel.Location.X + 2, panel.Location.Y + 2);
            ombrePanel.Size = panel.Size;
            ombrePanel.Padding = new Padding(3);
            ombrePanel.Margin = new Padding(-3);

            // Appliquer le Border Radius à l'ombrePanel
            System.Drawing.Drawing2D.GraphicsPath ombrePath = new System.Drawing.Drawing2D.GraphicsPath();
            ombrePath.AddRectangle(new Rectangle(0, 0, ombrePanel.Width, ombrePanel.Height));
            ombrePath.AddEllipse(rayonBordure, rayonBordure, ombrePanel.Width - (rayonBordure * 2), ombrePanel.Height - (rayonBordure * 2));
            ombrePanel.Region = new System.Drawing.Region(ombrePath);

            // Ajouter le panneau d'ombre derrière le panneau principal
            panel.Parent.Controls.Add(ombrePanel);
            panel.Parent.Controls.SetChildIndex(ombrePanel, panel.Parent.Controls.IndexOf(panel));

            // Réorganiser les contrôles pour que le panneau principal soit au-dessus de l'ombre
            panel.BringToFront();
        }
    }
}

