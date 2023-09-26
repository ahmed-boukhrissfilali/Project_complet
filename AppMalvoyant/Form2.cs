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
    public partial class Form2 : Form
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

        string arQuery =
            "SELECT ArTime, ArTitle FROM ArNews ORDER BY Arid ASC OFFSET (SELECT COUNT(*) FROM ArNews) - 16 ROWS FETCH NEXT 16 ROWS ONLY";

        string ArDernierQuery = "SELECT ArTitle FROM ArNews WHERE Arid = (SELECT MAX(Arid) FROM ArNews)";
        string ar = "SELECT ArTime, ArTitle FROM ArNews";

        private SpeechRecognitionEngine recognitionEngine;
        private CultureInfo arabicCulture = new CultureInfo("ar-SA");

        private bool CheckInternetConnection()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public Form2()
        {
            ExecuteInternetDependentLogic();
        }

        private void recors()
        {
            // Créer le moteur de reconnaissance vocale
            recognizer = new SpeechRecognitionEngine();

            // Ajouter les choix de commandes vocales
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(new Choices(new string[]
            {
                "إيقاف مؤقت", "الأول", "التالي", "السابق", "الأخير", "إيقاف مؤقت", "استئناف", "زيادة الصوت",
                "تخفيض الصوت", "التفاصيل", "الخروج", "الصفحة الرئيسية"
            }));
            Grammar grammar = new Grammar(grammarBuilder);
            var pausetGrammar = new GrammarBuilder();
            pausetGrammar.Append(new Choices(new string[] { "إيقاف مؤقت", "متوقف", "إيقاف", "متوقف" }));
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
                const string fix = "https://hespress.com/";
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

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (CheckInternetConnection())
            {
                this.WindowState = FormWindowState.Maximized;
                switch (e.Result.Text)
                {
                    case "يوقف":
                        stop.PerformClick();
                        break;
                    case "أولاً":
                        currentItemIndex = 0;
                        break;
                    case "التالي":
                        currentItemIndex = Math.Min(currentItemIndex + 1, items.Count - 1);
                        break;
                    case "سابق":
                        currentItemIndex = Math.Max(currentItemIndex - 1, 0);
                        break;
                    case "آخر":
                        currentItemIndex = items.Count - 1;
                        break;
                    case "الاستئناف":
                        synthesizer.Resume();
                        break;
                    case "ارفع الصوت":
                        synthesizer.Volume = Math.Min(synthesizer.Volume + 10, 100);
                        break;
                    case "خفض الصوت":
                        synthesizer.Volume = Math.Max(synthesizer.Volume - 10, 0);
                        break;
                    case "مفصلة":
                        Details();
                        break;
                    case "يترك":
                       
                        Application.Exit();
                        break;
                    case "ترحيب":
                        browser.Back();
                        this.Text = "هسبرس";
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
                    synthesizer.Pause();
                }

                if (e.Result.Text == "résume")
                {
                    synthesizer.Pause();
                }

                // Exécuter la commande correspondante
                switch (command)
                {
                    case "الأول":
                        ArPremier.PerformClick();
                        break;
                    case "التالي":
                        ArSuivant.PerformClick();
                        break;
                    case "السابق":
                        ArPrecedent.PerformClick();
                        break;
                    case "الأخير":
                        ArDernier.PerformClick();
                        break;
                    case "التفاصيل":
                        Ardetails.PerformClick();
                        break;
                    case "الصفحة الرئيسية ":
                        EngPanel2.Visible = false;
                        ArPanel1.Visible = true;
                        break;
                    case "توقف":
                        ArStop.PerformClick();
                        break;
                    case "أكمل":
                        ArPlay.PerformClick();
                        break;
                }
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

        private void ExecuteInternetDependentLogic()
        {
            if (CheckInternetConnection())
            {
                this.WindowState = FormWindowState.Maximized;

                InitializeComponent();
                // NavigateToHref();
                LoadWebsite("https://hespress.com/");
                ArPanel1.Visible = false;
                EngPanel2.Visible = false;
                ArPremier.Visible = false;
                ArPrecedent.Visible = false;
                ArDernier.Visible = false;
                ArSuivant.Visible = false;
                Dgrv_ArNews.Visible = false;
                richTextBoxEng.Visible = false;
                ArStop.Visible = false;
                stop1.Visible = false;



            }
            else
            {
                this.WindowState = FormWindowState.Minimized;

                InitializeComponent();
                InitializeSpeechRecognition();
                synthesizer = new SpeechSynthesizer();
                stop1.Visible = false;
                // Ajouter l'événement Click pour le bouton "détails"
                this.Ardetails.Click += new System.EventHandler(this.Ardetails_Click);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(ar, connection);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        Dgrv_ArNews.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
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

        private void Form2_Load(object sender, EventArgs e)
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
            else
            {
                stop1.Visible = false;
            }

        }

        private void LoadData()
        {
            _httpClient = new HttpClient();

            // Envoyer une requête GET à la page d'accueil
            const string url = "https://hespress.com/";
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
            var message = $" ساعة : {time} ,عنوان : {title}";
            synthesizer.Speak(message);
        }

        private void InitializeSpeechRecognition()
        {
            // Créer le moteur de reconnaissance vocale
            recognizer = new SpeechRecognitionEngine();

            // Ajouter la grammaire de commandes vocales
            var commands = new Choices(new[]
                { "الأول", "التالي", "السابق", "الأخير", "التفاصيل", "توقف", "أكمل", "الصفحة الرئيسية ", });
            var grammarBuilder = new GrammarBuilder(commands);
            var grammar = new Grammar(grammarBuilder);
            recognizer.LoadGrammar(grammar);

            // Configurer les événements de reconnaissance 
            recognizer.SpeechRecognized += recognizer_SpeechRecognized;
            recognizer.SpeechRecognitionRejected += recognizer_SpeechRecognitionRejected;

            // Démarrer la reconnaissance vocale
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private async void recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            await Task.Delay(30000); // Délai de 30 secondes
            synthesizer.SpeakAsync("لم يتم التعرف على الأمر الصوتي");
        }



        private void ArPremier_Click(object sender, EventArgs e)
        {
            
                // créer une nouvelle connexion à la base de données
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(ar, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    string textToSpeakk = reader.GetString(1); // Récupérer la première colonne de la première ligne
                    reader.Close();
                    connection.Close();
                    synthesizer.SpeakAsync(textToSpeakk); // Synthétiser la voix
                }
            
        }

        private void ArSuivant_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentID < Dgrv_ArNews.Rows.Count - 1)
                {
                    currentID++;
                    string textToSpeak = Dgrv_ArNews.Rows[currentID].Cells[1].Value.ToString();
                    synthesizer.SpeakAsync(textToSpeak);
                }
                else
                {
                  //  MessageBox.Show("لقد وصلت إلى آخر الأخبار.");
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void ArPrecedent_Click(object sender, EventArgs e)
        {
            int maxID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT MAX(AridD) FROM ArNews", connection);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out maxID))
                    {
                        if (currentID > 0)
                        {
                            currentID--;
                            string textToSpeak = Dgrv_ArNews.Rows[currentID].Cells[1].Value.ToString();
                            synthesizer.SpeakAsync(textToSpeak);
                        }
                    }
                    else
                    {
                       // MessageBox.Show("أنت في الأخبار الأولى.");
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void ArDernier_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow lastrow = Dgrv_ArNews.Rows[Dgrv_ArNews.Rows.Count - 2];
                currentID = lastrow.Index;
                string textToRead = lastrow.Cells[1].Value.ToString(); // Récupérer le texte à lire
                synthesizer.SpeakAsync(textToRead); // Lire le texte à haute voix
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void Ardetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentID != null && currentID < Dgrv_ArNews.Rows.Count)
                {
                    EngPanel2.Visible = false;
                    ArPanel1.Visible = true;
                    string dtls = Dgrv_ArNews.Rows[currentID].Cells[2].Value.ToString();
                    richTextBoxEng.Text = dtls;
                    synthesizer.SpeakAsync(dtls);
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        private void ArStop_Click(object sender, EventArgs e)
        {
            synthesizer.Pause();
        }

        private void ArPlay_Click(object sender, EventArgs e)
        {
            synthesizer.Resume();

        }

       

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognizer.RecognizeAsyncCancel();
            recognizer.Dispose();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            _synthesizer.Pause();
        }
    }
}


