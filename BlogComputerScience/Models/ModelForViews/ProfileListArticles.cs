namespace BlogComputerScience.Models.ModelForViews
{
    public class ProfileListArticles
    {
        public UserProfile Profile { get; set; }

        public string SearchString { get; set; }

        public List<Article> ResultArticles { get; set; }

        public ProfileListArticles(UserProfile profile, string searchString, List<Article> resultArticles)
        {
            Profile = profile;
            SearchString = searchString;
            ResultArticles = resultArticles;
        }
    }
}
