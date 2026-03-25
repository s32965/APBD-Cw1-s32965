using APBD_Cw1_s32965.Models;

namespace APBD_Cw1_s32965.Exceptions;

public class TooManyRentsException(User user) : Exception($"User with id {user.Id} has too many rented items.");
