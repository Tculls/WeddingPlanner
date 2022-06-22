#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
public class Association
{
    [Key]

    public int AssociationId {get; set; }

    public int WeddingId {get; set; }

    public int UserId {get; set; }

    public Wedding? Wedding {get; set; }

    public User? Attendee {get; set; }
}