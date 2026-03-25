using APBD_Cw1_s32965.Enums;

namespace APBD_Cw1_s32965.Models;

public class Rental(DateTime rentDate, DateTime agreedReturnDate, User user, Equipment item) {
  private static int id = 0;

  public int Id { get; set; } = id++;
  public DateTime RentDate { get; set; } = rentDate >= agreedReturnDate ? throw new ArgumentException("Rent date is after agreed return date") : rentDate;
  public DateTime AgreedReturnDate { get; set; } = agreedReturnDate;
  public DateTime? ActualReturnDate { get; set; } = null;
  public User User { get; set; } = user;
  public Equipment Item { get; set; } = item;
  public bool IsReturned { get; private set; } = false;
  public bool? WasReturnedOnTime { get; private set; } = null;
  public double PredictedCost { get; } = (agreedReturnDate - rentDate).Days * item.CostPerDay;
  public double? ActualCost { get; set; } = null;

  public static double OverdueMultiplier { get; } = 2;

  public void Return() {
    DateTime now = DateTime.Now;
    
    if (now <= AgreedReturnDate) {
      this.ActualCost = (now - this.RentDate).Days * item.CostPerDay;
      this.WasReturnedOnTime = true;
    } else {
      this.ActualCost = this.PredictedCost + ((now - this.AgreedReturnDate).Days * item.CostPerDay) * OverdueMultiplier;
      this.WasReturnedOnTime = false;
    }
    
    this.IsReturned = true;
    this.ActualReturnDate = now;
  }

  public double CalculateOverdue() {
    return ((DateTime.Now - this.AgreedReturnDate).Days * this.Item.CostPerDay) * OverdueMultiplier;
  }

}
