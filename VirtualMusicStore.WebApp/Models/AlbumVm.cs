namespace VirtualMusicStore.WebApp.Models
{
    public class AlbumVm
    {

        public int Id { get; set; }

        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public string Label { get; set; }

        public LabelTypeVm LabelType { get; set; }

        public int Stock { get; set; }
    }

    public enum LabelTypeVm
    {
        Vinyl,
        CD

    }
}