using System.ComponentModel.DataAnnotations;

namespace Services.Records.Peoples;

public record PeopleEdit([Required] int Id, [Required][MaxLength(100)] string Name, bool Active) : PeopleCreate(Name, Active);

