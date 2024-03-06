namespace Project_Artificial_Life_ServerAPI.Models.Kandinsky
{
    [Serializable]
    public class KandinskySendRequestOnGeneratingParams
    {
        public KandinskyGeneratedImage messageParam { get; set; }

        public int modelID { get; set; } 
    }
}
