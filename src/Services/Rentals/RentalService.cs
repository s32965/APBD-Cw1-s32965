using APBD_Cw1_s32965.Models;
using APBD_Cw1_s32965.Enums;

namespace APBD_Cw1_s32965.Services.Rentals;

public class RentalService : IRentalService {
  private readonly List<Rental> rents = [];

  public void RentItem(DateTime returnDate, User user, Equipment item) {
    if (item.EquipmentStatus != EquipmentStatus.Available) {
      Console.WriteLine("Item " + item.Id + " is unavailable.");
      return;
    }

    int userRents = 0;
    foreach(Rental r in rents) {
      if (!r.IsReturned && r.User == user) {
        userRents++;
      }
    }

    if (userRents >= user.GetMaxReservations()) {
      Console.WriteLine("User has too many rented items.");
      return;
    }

    Rental rental = new Rental(DateTime.Now, returnDate, user, item);
    rents.Add(rental);
  }

  public void ReturnItem(int rentalId) {
    Rental? rental = null;

    foreach(Rental r in rents) {
      if (r.Id == rentalId) {
        rental = r;
      }
    }

    if (rental is null) {
      Console.WriteLine("There is no rent with id: " + rentalId);
      return;
    }

    rental.Return();
  }

  public List<Rental> GetAllActiveRents() {
    List<Rental> results = [];
    
    foreach(Rental r in rents) {
      if (!r.IsReturned) {
        results.Add(r);
      }
    }

    return results;
  }
 
  public List<Rental> GetUsersActiveRents(User user) {
    List<Rental> results = [];
    
    foreach(Rental r in rents) {
      if (!r.IsReturned && r.User == user) {
        results.Add(r);
      }
    }

    return results;
  }

  public List<Rental> GetAllOverdueRents() {
    List<Rental> results = [];
    
    DateTime today = DateTime.Now;
    foreach(Rental r in rents) {
      if (!r.IsReturned && (today > r.AgreedReturnDate)) {
        results.Add(r);
      }
    }

    return results;
  }
}
