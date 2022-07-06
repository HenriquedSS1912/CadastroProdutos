using Newtonsoft.Json;

namespace CadastroProdutos.Models
{
    public class Base
    {
        public static List<T> Ler<T>(string name)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", $"{name}.json");
            var json = System.IO.File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public static void Escrever<T>(string name, List<T> dado)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", $"{name}.json");

            var json = JsonConvert.SerializeObject(dado);
            System.IO.File.WriteAllText(path, json);
        } 


    }
}
