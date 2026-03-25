namespace APBD_Cw1_s32965.Exceptions;

public class NoRentWithGivenIdException(int id) : Exception($"There is no rental with id {id}.");
