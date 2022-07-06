namespace CadastroProdutos.Models
{
    public class Category
    {

        private static string nomeArquivo = "category";

        public int Id { get; set; }
        public string Nome { get; set; }

        public static List<Category> ListAll()
        {
            return Base.Ler<Category>(nomeArquivo);
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
                var item = list.FirstOrDefault(a => a.Id == Id);
                var index = list.IndexOf(item);
                list[index] = this;
            }

            Base.Escrever<Category>(nomeArquivo, list);
        }

        public static Category Get(int id)
        {
            var list = ListAll();
            var category = list.Where(x => x.Id == id).FirstOrDefault();
            if (category != null)
            {
                return category;
            }
            return new Category();
        }

        public static void Delete(int id)
        {
            var list = ListAll();
            var category = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(category);

            Base.Escrever<Category>(nomeArquivo, list);
        }
    }
}
