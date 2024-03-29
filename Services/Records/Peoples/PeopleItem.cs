namespace Services.Records.Peoples;

public record PeopleItem
{
   public PeopleItem() { }

   public PeopleItem(Models.People result) : this(result.Id, result.Name, result.Active) { }

   public PeopleItem(int id, string name, bool active)
   {
      Id = id;
      Name = name;
      Active = active;
   }

   public int Id { get; set; }
   public string Name { get; set; }
   public bool Active { get; set; }

   public static PeopleItem Create(Models.People result) => new PeopleItem(result);
   public static PeopleItem Create(int id, string name, bool active) => new PeopleItem(id, name, active);
}
