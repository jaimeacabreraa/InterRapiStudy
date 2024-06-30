namespace InterRapiStudy.Dtos;

public class FindRegisterDto
{
    public string? Uid { get; set; }
    public string? StudentEmail { get; set; }

    public IEnumerable<FindRegisterDetailDto>? RegisterDetail { get; set; }
}