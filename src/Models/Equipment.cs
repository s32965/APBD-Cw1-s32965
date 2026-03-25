using APBD_Cw1_s32965.Enums;

namespace APBD_Cw1_s32965.Models;

public abstract class Equipment(string name) {
  private static int id = 0;

  public int Id { get; } = id++;
  public string Name { get; set; } = name;
  public EquipmentStatus equipmentStatus { get; set; } = EquipmentStatus.Available; 
}
