using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
using System.Text.RegularExpressions;


namespace GestionRendezVous
{
    public partial class MainWindow : Form
    {
        protected DatabaseConnection connection;
        private Button selectedButtonPage;
        private object telephone;
        private string ListCliDataGrid_Rows;
        private int client_id;

        public MainWindow()
        {
            connection = new DatabaseConnection("localhost", "rdvcomptable", "root", "");
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
            //string query = "SELECT * FROM clients";
            connection.OpenConnection();
            List<Dictionary<string, object>> results = GetAllMyAppoints();
            // afficher dans le tableau 
            setDataTableAppoints(results);
           List<Dictionary<string, object>> afficher = connection.ExecuteSelectQuery("clients");
           setlistDataGrid(afficher);
           connection.CloseConnection();


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
        // initiation des donnée dans la table 

        // methode de get pour  tout les donnée
        private void setlistDataGrid(List<Dictionary<string, object>> afficher)
            {
                DataTableAppoints.Columns.Add(key, key); // Nom de la colonne et en-tête de la colonne
            }
            foreach (Dictionary<string, object> so in result)
            ListCliDataGrid.Columns.Clear();
            foreach (string key in afficher[0].Keys)
            {
                // formatage de la dates et de  l'heures 
                DateTime dates = (DateTime)so["dates"];
                so["dates"] = dates.ToString("dd-MMM -yyy");
                ListCliDataGrid.Columns.Add(key, key);
            }

            foreach (Dictionary<string, object> dictionary in result)
            foreach (Dictionary<string, object> dictionary in afficher)
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
                ListCliDataGrid.Rows.Add(row);

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
            connection.OpenConnection();
            Dictionary<string, object> result = new Dictionary<string, object>();
            // recuperer tout les donnée
            List<Dictionary<string, object>> resultats = connection.ExecuteSelectQuery("clients");

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

        public bool validation(string email)
        {
            string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

        private void pictureBox2_Click(object sender, EventArgs e)
            if (regex.IsMatch(email))
        {
            Application.Exit();
                return false;
        }


        // Recherche dans les programmes du comptable

        private void pictureBox3_Click_1(object sender, EventArgs e)
            else
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            // RECHERCHE PAR LE NUMERO DU RENDEZVOUS
            string rdv_id = TextBoxSearch.Text;
            int rdv_int;
            bool success = int.TryParse(rdv_id, out rdv_int); // Conversion en entier

            connection.OpenConnection();

            if (success)
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
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
            string name = nom.Text;
            string prename = prenom.Text;
            string mail = email.Text;
            string tele = tel.Text;
            if (nom.Text=="" || prenom.Text=="" || email.Text==""|| tel.Text=="")
                {
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                MessageBox.Show("Completez le formulaire SVP!!");
            }
            else if (name.Length < 2 || prename.Length < 2 || mail.Length < 10 || tele.Length != 10)
                    {
                        while (rd.Read())
                MessageBox.Show("Veuillez vérifier les donnéés");
            }
            else if (validation(mail))
                        {
                            Dictionary<string, object> rows = new Dictionary<string, object>();
                            for (int x = 0; x < rd.FieldCount; x++)
                MessageBox.Show("Email invalider");
            }
            else if(tele.Length == 11)
                            {
                                string OBjectKey = rd.GetName(x);
                                object OBjectValue = rd.GetValue(x);
                                rows[OBjectKey] = OBjectValue;
                MessageBox.Show("veuillez verifier votre numero de telephone svp");
                            }
                        }
                    }

        private void ListCliDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowI = (int)ListCliDataGrid.SelectedCells[0].RowIndex;
            Console.WriteLine(ListCliDataGrid.Rows[rowI].Cells[0].Value);
            nom.Text = ListCliDataGrid.Rows[rowI].Cells[1].Value.ToString();
            prenom.Text = ListCliDataGrid.Rows[rowI].Cells[2].Value.ToString();
            email.Text = ListCliDataGrid.Rows[rowI].Cells[3].Value.ToString();
            tel.Text = ListCliDataGrid.Rows[rowI].Cells[4].Value.ToString();
            client_id =(int) ListCliDataGrid.Rows[rowI].Cells[0].Value;
                }
            }
            else
       

        private void button3_Click(object sender, EventArgs e)
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
            string name = nom.Text;
            string prename = prenom.Text;
            string mail = email.Text;
            string tele = tel.Text;
            if (name.Length < 2 || prename.Length < 2 || mail.Length < 10 || tele.Length != 10)
                            {
                                string ObjectKey = rd.GetName(x);
                                object Values = rd.GetValue(x);
                                rows[ObjectKey] = Values;
                MessageBox.Show("Veuillez vérifier les donnéés");
                            }
                            results.Add(rows);
            else if (validation(mail))
            {
                MessageBox.Show("Email invalider");
                        }
            else if (tele.Length == 11)
            {
                MessageBox.Show("veuillez verifier votre numero de telephone svp");
                    }
            else
            {
                string query = $"UPDATE clients SET nom='{name}',prenom='{prename}',email='{mail}',telephone='{tele}' WHERE client_id='{client_id}'";
                connection.OpenConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection.GetConnection();
                cmd.ExecuteNonQuery();
                connection.CloseConnection();
                connection.OpenConnection();
                setlistDataGrid(connection.ExecuteSelectQuery("clients"));
                connection.CloseConnection();
                MessageBox.Show("Client modifié!!");
                }
            nom.Text = "";
            prenom.Text = "";
            email.Text = "";
            tel.Text = "";
            }
            connection.CloseConnection();
            // gestion de resulat du recherche 
            if (results.Count == 0)

        private void button2_Click(object sender, EventArgs e)
        {
            string name = nom.Text;
            string prename = prenom.Text;
            string mail = email.Text;
            string tele = tel.Text;
            if (name.Length < 2 || prename.Length < 2 || mail.Length < 10 || tele.Length != 10)
            {
                MessageResult MR = new MessageResult();
                MR.ShowDialog();
                MessageBox.Show("Veuillez vérifier les donnéés");
            }
            else
            {
                setDataTableAppoints(results);
                string query = $"DELETE FROM clients WHERE client_id='{client_id}'";
                connection.OpenConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection.GetConnection();
                cmd.ExecuteNonQuery();
                connection.CloseConnection();
                connection.OpenConnection();
                setlistDataGrid(connection.ExecuteSelectQuery("clients"));
                connection.CloseConnection();
                MessageBox.Show("Client supprimé");
            }
            nom.Text = "";
            prenom.Text = "";
            email.Text = "";
            tel.Text = "";
            }

        private void button4_Click(object sender, EventArgs e)
        { }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
    
        }

        private void comboBoxDay_SelectedIndexChanged_1(object sender, EventArgs e)
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            string recherche = seach.Text;
            if (seach.Text == "")
            {
                MessageBox.Show("AJouter les données à rechercher");
            }
            else
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
                string query = "SELECT * FROM clients WHERE nom LIKE '" + recherche + "%' OR prenom LIKE '%" + recherche + "%' OR client_id LIKE '%" + recherche + "%' ";
                List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            connection.OpenConnection();
            using (MySqlCommand cmd = new MySqlCommand(SqlQuery, connection.GetConnection()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@day", DaySelected);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        for (int x = 0; x < rd.FieldCount; x++)
                            Dictionary<string, object> row = new Dictionary<string, object>();

                            for (int i = 0; i < rd.FieldCount; i++)
                        {
                            string ObjectKey = rd.GetName(x);
                            object Value = rd.GetValue(x);
                            result[ObjectKey] = Value;
                                string columnName = rd.GetName(i);
                                object value = rd.GetValue(i);

                                row[columnName] = value;
                        }
                        resultat.Add(result);
                            results.Add(row);
                    }
                }
            }
            connection.CloseConnection();
            // traitement des resultat du recherche 
            if (resultat.Count == 0)
                if (results.Count == 0)
            {
                MessageResult MR = new MessageResult();
                MR.ShowDialog();
                    MessageBox.Show("Données inexistants");

            }
            else
            {
                setDataTableAppoints(resultat);
                    // actualisation de donnée
                    connection.OpenConnection();
                    setlistDataGrid(results);
                    connection.CloseConnection();
                }

            }
        }

        private void comboBoxEver_SelectedIndexChanged_1(object sender, EventArgs e)
        private void ClientPage_Click(object sender, EventArgs e)
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
        private void lbl3_Click(object sender, EventArgs e)
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

        private void lbl4_Click(object sender, EventArgs e)
            {
                comboBoxEver.SelectedText = "";
                MessageResult MR = new MessageResult();
                MR.ShowDialog();

            }
            else

        private void pictureBox3_Click(object sender, EventArgs e)
            {
                setDataTableAppoints(resultat);
            }
            
        }
        private void setShadowBorder(Panel panel, int rayonBordure)

        private void Actualiser_Click(object sender, EventArgs e)
        {
            panel.BorderStyle = BorderStyle.None;

            // Créer un panneau d'ombre
            Panel ombrePanel = new Panel();
            ombrePanel.BackColor = ColorTranslator.FromHtml("#2c2c2c");
            ombrePanel.Location = new Point(panel.Location.X + 2, panel.Location.Y + 2);
            ombrePanel.Size = panel.Size;
            ombrePanel.Padding = new Padding(3);
            ombrePanel.Margin = new Padding(-3);
        }

            // Appliquer le Border Radius à l'ombrePanel
            System.Drawing.Drawing2D.GraphicsPath ombrePath = new System.Drawing.Drawing2D.GraphicsPath();
            ombrePath.AddRectangle(new Rectangle(0, 0, ombrePanel.Width, ombrePanel.Height));
            ombrePath.AddEllipse(rayonBordure, rayonBordure, ombrePanel.Width - (rayonBordure * 2), ombrePanel.Height - (rayonBordure * 2));
            ombrePanel.Region = new System.Drawing.Region(ombrePath);
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            nom.Text = "";
            prenom.Text = "";
            email.Text = "";
            tel.Text = "";
            seach.Text = "";
        }

            // Ajouter le panneau d'ombre derrière le panneau principal
            panel.Parent.Controls.Add(ombrePanel);
            panel.Parent.Controls.SetChildIndex(ombrePanel, panel.Parent.Controls.IndexOf(panel));
        private void seach_TextChanged(object sender, EventArgs e)
        {

            // Réorganiser les contrôles pour que le panneau principal soit au-dessus de l'ombre
            panel.BringToFront();
        }
    }
}


    