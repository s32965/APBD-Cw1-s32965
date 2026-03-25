namespace APBD_Cw1_s32965.Exceptions;

public class ItemAlreadyInCatalogueException(int id) : Exception($"Item with id {id} is already in catalogue.");
