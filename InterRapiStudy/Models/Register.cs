namespace InterRapiStudy.Models;

public class Register
{
    public int RegId { get; set; }

    public string Uid { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int StudentId { get; set; }

    public virtual ICollection<RegisterDetail> RegisterDetails { get; set; } = new List<RegisterDetail>();

    public virtual Student Student { get; set; } = null!;
}