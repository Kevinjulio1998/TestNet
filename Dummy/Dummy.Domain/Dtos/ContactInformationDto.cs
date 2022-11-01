namespace Dummy.Domain.Dtos
{
    public class ContactInformationDto
    {
        public int IdPeople { get; set; }
        public int IdTypeContact { get; set; }
        public string Contact { get; set; }
    }
    public class ContactInformationDtoView
    {
        public string Type { get; set; }
        public string Contact { get; set; }
    }
}
