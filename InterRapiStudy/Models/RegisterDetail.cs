namespace InterRapiStudy.Models;

public class RegisterDetail
{
    public int RegDetId { get; set; }

    public int RegiterId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int ProgSubjId { get; set; }

    public virtual ProgramSubject ProgSubj { get; set; } = null!;

    public virtual Register Regiter { get; set; } = null!;
}