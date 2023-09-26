using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using Exception = System.Exception;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace AppMalvoyant
{

    public partial class Form1 : Form
    {
        private HttpClient _httpClient;
        private HtmlDocument _document;
        private HtmlNodeCollection _listItems;
        private SpeechRecognitionEngine recognizer;
        private List<string> items = new List<string>();
        private int currentItemIndex = 0;
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private ChromiumWebBrowser browser;


        private SpeechRecognitionEngine _recognizer;
        private SpeechSynthesizer _synthesizer;
        private int currentID = 0;

        string connectionString = "Data Source=.;Initial Catalog=hespress;Integrated Security=True";

        string query = "SELECT Time, Title FROM News ORDER BY Id ASC OFFSET (SELECT COUNT(*) FROM News) - 12 ROWS FETCH NEXT 16 ROWS ONLY";

        string queryy = "SELECT Title FROM News WHERE ID = (SELECT MAX(ID) FROM News)";

        private bool CheckInternetConnection()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public Form1()
        {
            ExecuteInternetDependentLogic();


        }

        private void ExecuteInternetDependentLogic()
        {
            if (CheckInternetConnection())
            {
                this.WindowState = FormWindowState.Maximized;

                InitializeComponent();
               // NavigateToHref();
               LoadWebsite("https://fr.hespress.com/");
               panel1.Visible = false;
               premier.Visible = false;
               panel2.Visible = false;
               richTextBox1.Visible = false;
               dernier.Visible = false;
               suivant.Visible = false;
               Dgrv_News.Visible = false;
               précédent.Visible = false;
               panel3.Visible = false;
               stop.Visible = false;
               résume.Visible = false;



            }
            else
            {
                InitializeComponent();
                panel3.Visible = false;
                InitializeSpeechRecognition();
                _synthesizer = new SpeechSynthesizer();
                // Ajouter l'événement Click pour le bouton "détails"
                this.détails.Click += new System.EventHandler(this.détails_Click_1);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        Dgrv_News.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void recors()
        {
            // Créer le moteur de reconnaissance vocale
            recognizer = new SpeechRecognitionEngine();

            // Ajouter les choix de commandes vocales
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(new Choices(new string[]
            {
                "pause", "premier", "suivant", "précédent", "dernier", "pause", "reprendre", "augmenter le volume",
                "diminuer le volume", "détaillé", "quitter", "accueil"
            }));
            Grammar grammar = new Grammar(grammarBuilder);
            var pausetGrammar = new GrammarBuilder();
            pausetGrammar.Append(new Choices(new string[] { "pause", "pausé", "stop", "arreté" }));
            recognizer.LoadGrammar(new Grammar(pausetGrammar));

            // Charger la grammaire
            recognizer.LoadGrammar(grammar);

            // Configurer les événements de reconnaissance vocale
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.SpeechRecognitionRejected +=
                new EventHandler<SpeechRecognitionRejectedEventArgs>(recognizer_SpeechRecognitionRejected);

            // Extraire les éléments de la liste
            using (var httpClient = new HttpClient())
            {
                const string fix = "https://fr.hespress.com/";
                var response = httpClient.GetAsync(fix).Result;

                var document = new HtmlDocument();
                document.LoadHtml(response.Content.ReadAsStringAsync().Result);

                var section = document.DocumentNode.SelectSingleNode("//div[@class='h24-b']//ul");

                var listItems = section.SelectNodes(".//li");

                foreach (var listItem in listItems)
                {
                    items.Add(listItem.InnerText.Trim());
                }
            }

            // Démarrer la reconnaissance vocale
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void LoadWebsite(string url)
        {
            browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);
            browser.Load(url);
            if (!Cef.IsInitialized)
            {
                var settings = new CefSettings();
                // Configurez les paramètres de CefSharp selon vos besoins
                Cef.Initialize(settings);
            }
        }
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (CheckInternetConnection())
            {
                this.WindowState = FormWindowState.Maximized;

                switch (e.Result.Text)
                {
                    case "pause":
                        stop.PerformClick();
                        break;
                    case "premier":
                        currentItemIndex = 0;
                        break;
                    case "suivant":
                        currentItemIndex = Math.Min(currentItemIndex + 1, items.Count - 1);
                        break;
                    case "précédent":
                        currentItemIndex = Math.Max(currentItemIndex - 1, 0);
                        break;
                    case "dernier":
                        currentItemIndex = items.Count - 1;
                        break;
                    case "reprendre":
                        synthesizer.Resume();
                        break;
                    case "augmenter le volume":
                        synthesizer.Volume = Math.Min(synthesizer.Volume + 10, 100);
                        break;
                    case "diminuer le volume":
                        synthesizer.Volume = Math.Max(synthesizer.Volume - 10, 0);
                        break;
                    case "détaillé":
                        Details();
                        break;
                    case "quitter":
                        Application.Exit();
                        break;
                    case "accueil":
                        browser.Back();
                        this.Text = "hrsspress";
                        break;
                }

                synthesizer.SpeakAsync(items[currentItemIndex]);
            }
            else
            {
                // Récupérer la commande vocale reconnue
                var command = e.Result.Text;
                if (e.Result.Text == "pause")
                {
                    _synthesizer.Pause();
                }

                if (e.Result.Text == "parle")
                {
                    _synthesizer.Resume();
                }
                if (e.Result.Text == "quitter")
                {
                    Application.Exit();
                }

                // Exécuter la commande correspondante
                switch (command)
                {
                    case "premier":
                        premier.PerformClick();
                        break;
                    case "suivant":
                        suivant.PerformClick();
                        break;
                    case "précédent":
                        précédent.PerformClick();
                        break;
                    case "dernier":
                        dernier.PerformClick();
                        break;
                    case "détails":
                        détails.PerformClick();
                        break;
                    case "acceuil":
                        // Réafficher le panel principal
                        panel1.Visible = true;
                        panel2.Visible = false;

                        break;
                        //case "pause":
                        //    stop.PerformClick();
                        //    break;
                        //case "play":
                        //    résume.PerformClick();
                        //    break;
                }
                // Récupérer la chaîne de texte de la reconnaissance vocale
                // string recognizedText = e.Result.Text;
            }
        }

        private string RemoveSymbols(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c) || c == '%')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private void Details()
        {
            var a = _listItems[currentItemIndex].Descendants("a").FirstOrDefault();
            if (a != null)
            {
                var h3 = a.Descendants("h3").FirstOrDefault()?.InnerText;
                this.Text = h3;
                var href = a.GetAttributeValue("href", "");
                var articleResponse = _httpClient.GetAsync(href).Result;
                var me = a.GetAttributeValue("href", "");
                browser.Load(me.ToLower());
                if (articleResponse.IsSuccessStatusCode)
                {
                    
                    var articleDocument = new HtmlDocument();
                    articleDocument.LoadHtml(articleResponse.Content.ReadAsStringAsync().Result);

                    var articleContent =
                        articleDocument.DocumentNode.SelectSingleNode("//div[@class='article-content']");
                    if (articleContent != null)
                    {
                        var content = RemoveSymbols(articleContent.InnerText);
                        synthesizer.Speak(content);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckInternetConnection())
            {
                LoadData();
                recors();
                ReadCurrentItem();
                stop.Width = 0;
                stop.Height = 0;
                stop.Location = new Point(-100, -100);
                stop.Text = "";
            }
        }

        private void LoadData()
        {
            _httpClient = new HttpClient();

            // Envoyer une requête GET à la page d'accueil
            const string url = "https://fr.hespress.com/";
            var response = _httpClient.GetAsync(url).Result;

            // Utiliser HtmlAgilityPack pour analyser le contenu HTML
            _document = new HtmlDocument();
            _document.LoadHtml(response.Content.ReadAsStringAsync().Result);

            var section = _document.DocumentNode.SelectSingleNode("//div[@class='h24-b']//ul");

            // Extraire tous les éléments li dans la section
            _listItems = section.SelectNodes(".//li");

        }

        private void ReadCurrentItem()
        {
            var item = _listItems[currentItemIndex];
            var a = item.Descendants("a").FirstOrDefault();
            var time = item.Descendants("span").FirstOrDefault(x => x.GetAttributeValue("class", "") == "time-label")
                ?.InnerText;
            var title = RemoveSymbols(item.Descendants("h3").FirstOrDefault()?.InnerText);
            var message = $" heure : {time} ,Titre : {title}";
            synthesizer.Speak(message);
        }


        private async void recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            await Task.Delay(30000); // Délai de 30 secondes
            synthesizer.SpeakAsync("Commande vocale non reconnue");
        }

        private void InitializeSpeechRecognition()
        {
            // Créer le moteur de reconnaissance vocale
            _recognizer = new SpeechRecognitionEngine();

            // Ajouter la grammaire de commandes vocales
            var commands = new Choices(new[]
            {
                "premier", "suivant", "précédent", "dernier", "détails", "pause", "parle", "acceuil", "quitter",
            });
            var grammarBuilder = new GrammarBuilder(commands);
            var grammar = new Grammar(grammarBuilder);
            _recognizer.LoadGrammar(grammar);

            // Configurer les événements de reconnaissance 
            _recognizer.SpeechRecognized += recognizer_SpeechRecognized;
            _recognizer.SpeechRecognitionRejected += recognizer_SpeechRecognitionRejected;

            // Démarrer la reconnaissance vocale


            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }


        private void premier_Click(object sender, EventArgs e)
        {
            try
            {
                // créer une nouvelle connexion à la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    string textToSpeakk = reader.GetString(1); // Récupérer la première colonne de la première ligne
                    reader.Close();
                    connection.Close();
                    _synthesizer.SpeakAsync(textToSpeakk); // Synthétiser la voix
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //   MessageBox.Show("premier");
        }

        private void suivant_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentID < Dgrv_News.Rows.Count - 1)
                {
                    currentID++;
                    string textToSpeak = Dgrv_News.Rows[currentID].Cells[1].Value.ToString();
                    _synthesizer.SpeakAsync(textToSpeak);
                }
                else
                {
                    MessageBox.Show("Vous avez atteint la dernière nouvelle.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void précédent_Click(object sender, EventArgs e)
        {
            int maxID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT MAX(ID) FROM News", connection);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out maxID))
                    {
                        if (currentID > 0)
                        {
                            currentID--;
                            string textToSpeak = Dgrv_News.Rows[currentID].Cells[1].Value.ToString();
                            _synthesizer.SpeakAsync(textToSpeak);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous êtes sur la première nouvelle.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dernier_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow lastrow = Dgrv_News.Rows[Dgrv_News.Rows.Count - 2];
                currentID = lastrow.Index;
                string textToRead = lastrow.Cells[1].Value.ToString(); // Récupérer le texte à lire
                synthesizer.SpeakAsync(textToRead); // Lire le texte à haute voix
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void détails_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (currentID != null && currentID < Dgrv_News.Rows.Count)
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    string dtls = Dgrv_News.Rows[currentID].Cells[2].Value.ToString();
                    richTextBox1.Text = dtls;
                    _synthesizer.SpeakAsync(dtls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            synthesizer.Pause();
        }

        private void résume_Click(object sender, EventArgs e)
        {
            _synthesizer.Resume();

        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognizer.RecognizeAsyncCancel();
            recognizer.Dispose();
        }

        private void stop1_Click(object sender, EventArgs e)
        {
            synthesizer.Pause();
        }
    }
}