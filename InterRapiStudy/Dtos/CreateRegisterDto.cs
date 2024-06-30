namespace InterRapiStudy.Dtos;

public class CreateRegisterDto
{
    public string StudentEmail { get; set; }
    
    public List<CreateRegisterDetailDto> RegisterDetail { get; set; }
}