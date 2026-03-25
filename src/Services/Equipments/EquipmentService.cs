using APBD_Cw1_s32965.Models;
using APBD_Cw1_s32965.Enums;
using APBD_Cw1_s32965.Exceptions;

namespace APBD_Cw1_s32965.Services.Equipments;

public class EquipmentService : IEquipmentService {
  private readonly List<Equipment> items = [];

  public void AddItem(Equipment equipment) {
    if (items.Contains(equipment)) {
      throw new ItemAlreadyInCatalogueException(equipment.Id);
    }

    items.Add(equipment);
  }

  public List<Equipment> GetEquipment() {
    return items;
  }

  public void ListAllEquipment() {
    foreach(Equipment e in items) {
      Console.WriteLine($"ID: {e.Id}  Name: {e.Name}  Status: {e.EquipmentStatus}");  
    }
  }

  public List<Equipment> GetAvailableEquipment() {
    List<Equipment> results = [];

    foreach(Equipment e in items) {
      if (e.EquipmentStatus != EquipmentStatus.Unavailable) {
        results.Add(e);
      }
    }

    return results;
  }
}
