using APBD_Cw1_s32965.Models;
using APBD_Cw1_s32965.Enums;
using APBD_Cw1_s32965.Exceptions;

namespace APBD_Cw1_s32965.Services.Rentals;

public class RentalService : IRentalService {
  private readonly List<Rental> rents = [];

  public int RentItem(DateTime returnDate, User user, Equipment item) {
    if (item.EquipmentStatus != EquipmentStatus.Available) {
      throw new ItemUnavailableException(item.Id);
    }

    int userRents = 0;
    foreach(Rental r in rents) {
      if (!r.IsReturned && r.User == user) {
        userRents++;
      }
    }

    if (userRents >= user.GetMaxReservations()) {
      throw new TooManyRentsException(user);
    }

    Rental rental = new Rental(DateTime.Now, returnDate, user, item);
    rents.Add(rental);

    return rental.Id;
  }

  public int RentItem(DateTime rentTime, DateTime returnDate, User user, Equipment item) {
    if (item.EquipmentStatus != EquipmentStatus.Available) {
      throw new ItemUnavailableException(item.Id);
    }

    int userRents = 0;
    foreach(Rental r in rents) {
      if (!r.IsReturned && r.User == user) {
        userRents++;
      }
    }

    if (userRents >= user.GetMaxReservations()) {
      throw new TooManyRentsException(user);
    }

    Rental rental = new Rental(rentTime, returnDate, user, item);
    rents.Add(rental);

    return rental.Id;
  }

  public void ReturnItem(int rentalId) {
    Rental? rental = null;

    foreach(Rental r in rents) {
      if (r.Id == rentalId) {
        rental = r;
      }
    }

    if (rental is null) {
      throw new NoRentWithGivenIdException(rentalId);
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

  public Rental GetRentById(int id) {
    Rental? result = null;

    foreach (Rental r in rents) {
      if (r.Id == id) {
        result = r;
      }
    }

    if (result is null) {
      throw new Exception($"No rent with id {id}");
    }

    return result;
  }
}
