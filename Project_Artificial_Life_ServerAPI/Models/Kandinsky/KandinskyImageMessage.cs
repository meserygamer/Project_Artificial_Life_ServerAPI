namespace Project_Artificial_Life_ServerAPI.Models.Kandinsky
{
    public class KandinskyImageMessage
    {
        public string uuid { get; set; }
        public string status { get; set; }
        public ICollection<string> images { get; set; }
        public string errorDescription { get; set; }
        public bool censored { get; set; }
    }
}
