namespace APBD_Cw1_s32965.Models;

public class Student(string firstName, string surname) : User(firstName, surname) {
  public override int GetMaxReservations() => 2; 
}
