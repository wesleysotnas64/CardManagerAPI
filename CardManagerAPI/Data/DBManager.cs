using CardManagerAPI.Models;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CardManagerAPI.Data
{
    public class DBManager
    {
        private string pathFile;
        private List<Card>? data;

        public DBManager()
        {
            pathFile = "C:Caminho\\CardManagerAPI\\CardManagerAPI\\Data\\data.json";
            data = new List<Card>();
            LoadData();
        }

        public void AddCard(Card card)
        {
            data.Add(card);

            SaveData();
        }

        public void SaveData()
        {
            try
            {
                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(pathFile, json);
            }
            catch
            {
            }
        }

        public void LoadData()
        {
            try
            {
                string json = File.ReadAllText(pathFile);
                data = JsonSerializer.Deserialize<List<Card>>(json);
            }
            catch
            {
            }
        }

        public Card GetCard(int id)
        {
            Card card = new Card();

            foreach(Card c in data)
            {
                if (c.Id == id)
                {
                    card = c;
                    break;
                }
            }

            return card;
        }

        public List<Card> GetAllCards()
        {
            return data;
        }
    }
}
