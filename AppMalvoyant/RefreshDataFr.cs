using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using HtmlAgilityPack;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Data.SqlClient;


namespace AppMalvoyant
{
    public class RefreshDataFr
    {
        public void RefreshDatr()
        {
             var httpClient = new HttpClient();

            // Envoyer une requête GET à la page d'accueil
            const string fix = "https://fr.hespress.com/";
            var response = httpClient.GetAsync(fix).Result;

            // Utiliser HtmlAgilityPack pour analyser le contenu HTML
            var document = new HtmlDocument();
            document.LoadHtml(response.Content.ReadAsStringAsync().Result);
            
            var section = document.DocumentNode.SelectSingleNode("//div[@class='h24-b']//ul");

            // Extraire tous les éléments li dans la section
            var listItems = section.SelectNodes(".//li");

            

            var connection = new SqlConnection(@"Data Source=.;Initial Catalog=hespress;Integrated Security=True");

            // Ouverture de la connexion
            connection.Open();
            int count = 0;
            // Parcourir les éléments et enregistrer chaque élément directement dans la base de données
            foreach (var item in listItems)
            {
                var a = item.Descendants("a").FirstOrDefault();
                var href = a?.GetAttributeValue("href", "");
                var time = item.Descendants("span").FirstOrDefault(x => x.GetAttributeValue("class", "") == "time-label")?.InnerText;
                var title = item.Descendants("h3").FirstOrDefault()?.InnerText;

                // Envoyer une requête GET à l'URL
                var articleResponse = httpClient.GetAsync(href).Result;

                // Vérifier que la réponse est réussie
                if (articleResponse.IsSuccessStatusCode)
                {
                    // Extraire le contenu HTML de la réponse
                    var articleDocument = new HtmlDocument();
                    articleDocument.LoadHtml(articleResponse.Content.ReadAsStringAsync().Result);

                    // Extraire le contenu de la classe article-content
                    var articleContent = articleDocument.DocumentNode.SelectSingleNode("//div[@class='article-content']");

                    // Extraire l'URL de l'image
                    var imageSrc = articleDocument.DocumentNode.SelectSingleNode("//figure/div/div/img")?.GetAttributeValue("src", "");

                    // Si le contenu existe, enregistrer les données dans la base de données
                    if (articleContent != null)
                    {
                        var content = articleContent.InnerText;

                        SqlCommand command =
                            new SqlCommand(
                                "INSERT INTO News (Time, Title, Content, Image) VALUES (@time, @title, @content, @imageUrl)",
                                connection);
                        command.Parameters.AddWithValue("@time", time);
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@content", content);
                        command.Parameters.AddWithValue("@imageUrl", imageSrc);

                        command.ExecuteNonQuery();
                    }

                    count++;
                }

            }
          //  MessageBox.Show($"Nombre de lignes insérées : {count}");

        
        }
    }
}