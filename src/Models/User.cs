namespace APBD_Cw1_s32965.Models;

public abstract class User(string firstName, string surname) {
  private static int id = 0;

  public int Id { get; } = id++;
  public string FirstName { get; set; } = firstName;
  public string Surname { get; set; } = surname;

  public abstract int GetMaxReservations();
}
