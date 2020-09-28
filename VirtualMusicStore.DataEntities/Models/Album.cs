namespace VirtualMusicStore.DataEntities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public LabelType LabelType { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
