namespace Project_Artificial_Life_ServerAPI.Models.Kandinsky
{
    [Serializable]
    public class KandinskyGeneratedImage
    {
        public string type { get; set; }
        public int numImages { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public KandinskyGenerateMessageGenerateParams generateParams { get; set; }
    }
}
