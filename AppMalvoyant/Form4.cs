using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Net.NetworkInformation;

namespace AppMalvoyant
{
    public partial class Form4 : Form
    {
        private SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

        private CultureInfo frenchCulture = new CultureInfo("fr-FR");
        private CultureInfo arabicCulture = new CultureInfo("ar-SA");
        private CultureInfo englishCulture = new CultureInfo("en-US");
        private bool CheckInternetConnection()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }
        
        public Form4()
        {
            InitializeComponent();
            if (CheckInternetConnection())
            {
                RefreshDataAr RefreshDatAr = new RefreshDataAr();
                RefreshDataFr RefreshDatfr = new RefreshDataFr();
                RefreshDataEn RefreshDaten = new RefreshDataEn();

                RefreshDatAr.RefreshDatar();
                RefreshDatfr.RefreshDatr();
                RefreshDaten.RefreshDatrEn();

            }
            
        }

        
        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            
            if (e.Result.Text == "français")
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                form1.Text = "français";


            }
            else if (e.Result.Text == "arabe")
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
                form2.Text = "arabe";
                this.Hide();
               
            }
            else if (e.Result.Text == "english" )
            {
                this.Hide();
                Form3 form3 = new Form3();
                form3.Text = "english";
                form3.ShowDialog();
                
            }
            
           
        }
        

        

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognizer.RecognizeAsyncCancel();
            recognizer.Dispose();
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Veuillez choisir votre langue entre français, arabe et einglish.");
            
            Choices choix = new Choices(new string[] { "français", "arabe", "english" });
            GrammarBuilder gb = new GrammarBuilder(choix);
            Grammar grammaire = new Grammar(gb);

            recognizer.LoadGrammar(grammaire);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(RecognitionEngine_SpeechRecognized);

            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
