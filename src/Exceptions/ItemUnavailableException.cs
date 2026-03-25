namespace APBD_Cw1_s32965.Exceptions;

public class ItemUnavailableException(int id) : Exception($"Item with id {id} is currently unavailable for rent.");
