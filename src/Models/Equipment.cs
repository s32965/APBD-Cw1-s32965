using APBD_Cw1_s32965.Enums;

namespace APBD_Cw1_s32965.Models;

public abstract class Equipment(string name, int productionYear, string manufacturer) {
  private static int id = 0;

  public int Id { get; } = id++;
  public string Name { get; set; } = name;
  public int Year { get; set; } = productionYear;
  public string Manufacturer { get; set; } = manufacturer;
  public EquipmentStatus EquipmentStatus { get; set; } = EquipmentStatus.Available; 
}
