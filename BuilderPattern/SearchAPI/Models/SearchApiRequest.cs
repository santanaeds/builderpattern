namespace SearchAPI.Models
{
    public class SearchApiRequest
    {
        public string search { get; set; }
        public bool count { get; set; }
        public string filter { get; set; }
        public int top { get; set; }
        public int skip { get; set; }
    }
}
