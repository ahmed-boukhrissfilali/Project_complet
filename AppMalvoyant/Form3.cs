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
    public partial class Form3 : Form
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
        string EngQuery = "SELECT Time, Title FROM Newsen ORDER BY Id ASC OFFSET (SELECT COUNT(*) FROM Newsen) - 16 ROWS FETCH NEXT 16 ROWS ONLY"; string 
            arQuery = "SELECT Time, Title FROM Newsen ORDER BY Id ASC OFFSET (SELECT COUNT(*) FROM Newsen) - 16 ROWS FETCH NEXT 16 ROWS ONLY";

        string EngDernierQuery = "SELECT Title FROM Newsen WHERE Id = (SELECT MAX(Id) FROM Newsen)";
        string ENg = "SELECT Time, Title FROM Newsen";

        private CultureInfo englishCulture = new CultureInfo("en-US");
        private bool CheckInternetConnection()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }
        public Form3()
        {
            ExecuteInternetDependentLogic();
        }
        private void ExecuteInternetDependentLogic()
        {
            if (CheckInternetConnection())
            {
                InitializeComponent();
                // NavigateToHref();
                LoadWebsite("https://en.hespress.com/");
                this.WindowState = FormWindowState.Maximized;
                EngPanel1.Visible = false;
                EngPanel2.Visible = false;
                EngPrecedent.Visible = false;
                EngPlay.Visible = false;
                EngDernier.Visible = false;
                EngDetails.Visible = false;
                EngSuivant.Visible = false;
                EngStop.Visible = false;
                Dgrv_EngNews.Visible = false;
                richTextBoxEng.Visible = false;
                stop1.Visible = false;




            }
            else
            {
                InitializeComponent();
                stop.Visible = false;
                InitializeSpeechRecognition();
                _synthesizer = new SpeechSynthesizer();
                // Ajouter l'événement Click pour le bouton "détails"
                this.EngDetails.Click += new System.EventHandler(this.EngDetails_Click);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(ENg, connection);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        Dgrv_EngNews.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                switch (e.Result.Text)
                {
                    case "pause":
                       stop1.PerformClick();
                        break;
                    case "first":
                        currentItemIndex = 0;
                        break;
                    case "next":
                        currentItemIndex = Math.Min(currentItemIndex + 1, items.Count - 1);
                        break;
                    case "previous":
                        currentItemIndex = Math.Max(currentItemIndex - 1, 0);
                        break;
                    case "last":
                        currentItemIndex = items.Count - 1;
                        break;
                    case "resume":
                        synthesizer.Resume();
                        break;
                    case "turn up":
                        synthesizer.Volume = Math.Min(synthesizer.Volume + 10, 100);
                        break;
                    case "Lower the volume":
                        synthesizer.Volume = Math.Max(synthesizer.Volume - 10, 0);
                        break;
                    case "detailed":
                        Details();
                        break;
                    case "Exit":
                        Application.Exit();
                        break;
                    case "Home":
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
                if (e.Result.Text == "résume")
                {
                    _synthesizer.Pause();
                }

                // Exécuter la commande correspondante
                switch (command)
                {
                    case "first":
                        EngPremier.PerformClick();
                        break;
                    case "next":
                        EngSuivant.PerformClick();
                        break;
                    case "previous":
                        EngPrecedent.PerformClick();
                        break;
                    case "last":
                        EngDernier.PerformClick();
                        break;
                    case "details":
                        EngDetails.PerformClick();
                        break;
                    case "home  ":
                        EngPanel2.Visible = false;
                        EngPanel1.Visible = true;
                        break;
                    case "stop":
                        EngStop.PerformClick();
                        break;
                    case "play":
                        EngPlay.PerformClick();
                        break;
                }
                // Récupérer la chaîne de texte de la reconnaissance vocale
                // string recognizedText = e.Result.Text;
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
                    "pause", "first", "next", "previous", "last", "resume", "turn up",
                    "Lower the volume", "detailed", "exit", "home"
                }));
                Grammar grammar = new Grammar(grammarBuilder);
                var pausetGrammar = new GrammarBuilder();
                pausetGrammar.Append(new Choices(new string[] { "pause", "paused", "stop", "stopped" }));
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
                    const string fix = "https://en.hespress.com/";
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
        private void InitializeSpeechRecognition()
        {
            // Créer le moteur de reconnaissance vocale
            _recognizer = new SpeechRecognitionEngine();

            // Ajouter la grammaire de commandes vocales
            var commands = new Choices(new[] { "first", "next", "previous", "last", "details", "stop", "play", "home", });
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
        private void Form3_Load(object sender, EventArgs e)
        {
            if (CheckInternetConnection())
            {
                LoadData();
                recors();
                ReadCurrentItem();
               stop1.Width = 0;
                stop1.Height = 0;
                stop1.Location = new Point(-100, -100);
                stop1.Text = "";
            }
        }
        private void LoadData()
        {
            _httpClient = new HttpClient();

            // Envoyer une requête GET à la page d'accueil
            const string url = "https://en.hespress.com/";
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
            var message = $" hour : {time} ,Title : {title}";
            synthesizer.Speak(message);
        }
        private async void recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            await Task.Delay(30000); // Délai de 30 secondes
            synthesizer.SpeakAsync("Voice command not recognized");
        }
        private void EngPremier_Click(object sender, EventArgs e)
        {
            try
            {
                // créer une nouvelle connexion à la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(ENg, connection);
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
        private void EngSuivant_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentID < Dgrv_EngNews.Rows.Count - 1)
                {
                    currentID++;
                    string textToSpeak = Dgrv_EngNews.Rows[currentID].Cells[1].Value.ToString();
                    _synthesizer.SpeakAsync(textToSpeak);
                }
                else
                {
                    MessageBox.Show("You've reached the latest news.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EngPrecedent_Click(object sender, EventArgs e)
        {
            int maxID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT MAX(Id) FROM Newsen", connection);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out maxID))
                    {
                        if (currentID > 0)
                        {
                            currentID--;
                            string textToSpeak = Dgrv_EngNews.Rows[currentID].Cells[1].Value.ToString();
                            _synthesizer.SpeakAsync(textToSpeak);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You're in the first news.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EngDernier_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow lastrow = Dgrv_EngNews.Rows[Dgrv_EngNews.Rows.Count - 2];
                currentID = lastrow.Index;
                string textToRead = lastrow.Cells[1].Value.ToString(); // Récupérer le texte à lire
                synthesizer.SpeakAsync(textToRead); // Lire le texte à haute voix
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EngDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentID > 0)
                {
                    EngPanel2.Visible = true;
                    EngPanel1.Visible = false;
                    string dtls = Dgrv_EngNews.Rows[currentID].Cells[2].Value.ToString();
                    richTextBoxEng.Text = dtls;
                    _synthesizer.SpeakAsync(dtls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EngStop_Click(object sender, EventArgs e)
        {
            _synthesizer.Pause();

        }
        private void EngPlay_Click(object sender, EventArgs e)
        {
            _synthesizer.Resume();

        }
        

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognizer.RecognizeAsyncCancel();
            recognizer.Dispose();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            synthesizer.Pause();
        }
    }
}
