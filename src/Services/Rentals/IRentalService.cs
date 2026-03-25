using APBD_Cw1_s32965.Models;

namespace APBD_Cw1_s32965.Services.Rentals;

public interface IRentalService {
  public void RentItem(DateTime returnDate, User user, Equipment item); 
  public void ReturnItem(int rentalId);
  public List<Rental> GetAllActiveRents();
  public List<Rental> GetUsersActiveRents(User user); 
  public List<Rental> GetAllOverdueRents(); 
}
