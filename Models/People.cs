
namespace Models;
public class People
{
   public People() { }

   public People(string name, bool active)
   {
      Id = 0;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Active = active;
   }

   public People(int id, string name, bool active)
   {
      Id = id;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Active = active;
   }

   public int Id { get; set; }
   public string Name { get; set; }
   public bool Active { get; set; }

   public static People Create(string name, bool active) => new People(name, active);
   public static People Create(int id, string name, bool active) => new People(id, name, active);
}