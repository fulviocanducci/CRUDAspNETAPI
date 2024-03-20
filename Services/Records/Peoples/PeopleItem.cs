namespace Services.Records.Peoples;

public record PeopleItem
{
   public PeopleItem() { }

   public PeopleItem(int id, string name, bool active)
   {
      Id = id;
      Name = name;
      Active = active;
   }

   public int Id { get; set; }
   public string Name { get; set; }
   public bool Active { get; set; }
}
