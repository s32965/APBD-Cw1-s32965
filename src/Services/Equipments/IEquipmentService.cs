using APBD_Cw1_s32965.Models;

namespace APBD_Cw1_s32965.Services.Equipments;

public interface IEquipmentService {
  public void AddItem(Equipment equipment);
  public List<Equipment> GetEquipment();
  public void ListAllEquipment();
  public List<Equipment> GetAvailableEquipment(); 
}
