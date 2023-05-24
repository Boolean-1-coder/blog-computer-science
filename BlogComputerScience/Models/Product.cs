namespace BlogComputerScience.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Category { get; set; } da aggiungere relazioni 1 a N.
        public string ImgUrl { get; set; }
        public int Ranking { get; set; }

        public Product() { }

        public Product (string name, string description, string imgurl, int ranking) { 
         this.Name = name;
         this.Description = description;
         this.ImgUrl = imgurl;
         this.Ranking = ranking;
        }

    }

}
