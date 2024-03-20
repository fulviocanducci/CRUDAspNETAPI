using System.ComponentModel.DataAnnotations;

namespace Services.Records.Peoples;

public record PeopleCreate([Required][MaxLength(100)] string Name, bool Active);
