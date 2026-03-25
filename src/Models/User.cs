using APBD_Cw1_s32965.Enums;

namespace APBD_Cw1_s32965.Models;

public abstract class User {
  private static int id = 0;

  public int Id { get; }
  public string FirstName { get; set; }
  public string Surname { get; set; }
  public UserType Type { get; set; }
  public int MaxRents { get; } = 0;

  public User(string firstName, string surname, UserType type) {
    Id = id++;
    FirstName = firstName;
    Surname = surname;
    Type = type;
    
    if (type == UserType.Student) {
      MaxRents = 2;
    } else if (type == UserType.Employee) {
      MaxRents = 5;
    }
  }
}
