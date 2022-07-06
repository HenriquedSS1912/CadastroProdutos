namespace CadastroProdutos.Models
{
    public class Product
    {
        private static string nomeArquivo = "arquivo";

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public int CategoryId { get; set; }
        public List<string> Cores { get; set; }
        public Category Categoria { get; set; }
        public static List<Product> ListAll()
        {
            return Base.Ler<Product>(nomeArquivo);
        }

        public void Save()
        {
            var list = ListAll();

            if (Id == 0)
            {
                Id = (list.Any() ? list.Max(a => a.Id) : 0) + 1;
                list.Add(this);
            }
            else
            {
                var item = list.FirstOrDefault(f => f.Id == Id);
                var index = list.IndexOf(item);
                list[index] = this;
            }

            Base.Escrever<Product>(nomeArquivo, list);
        }

        public static Product Get(int id)
        {
            var list = ListAll();
            var product = list.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                return product;
            }

            return new Product();
        }

        public static void Delete(int id)
        {
            var list = Product.ListAll();
            var product = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(product);

            Base.Escrever<Product>(nomeArquivo, list);
        }
    }
}
