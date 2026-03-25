using APBD_Cw1_s32965.Models;

namespace APBD_Cw1_s32965.Services.Rentals;

public interface IRentalService {
  public int RentItem(DateTime returnDate, User user, Equipment item);
  public int RentItem(DateTime rentTime, DateTime returnDate, User user, Equipment item);
  public void ReturnItem(int rentalId);
  public List<Rental> GetAllActiveRents();
  public List<Rental> GetUsersActiveRents(User user); 
  public List<Rental> GetAllOverdueRents();
  public Rental GetRentById(int id);
}
