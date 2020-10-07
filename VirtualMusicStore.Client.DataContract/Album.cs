namespace VirtualMusicStore.Client.DataContract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Album
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string AlbumName { get; set; }

        [DataMember]
        public string Artist { get; set; }

        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public LabelType LabelType { get; set; }

        [DataMember]
        public int Stock { get; set; }
    }

    public enum LabelType
    {
        Vinyl,
        CD

    }
}
