namespace APBD_Cw1_s32965.Models;

public class Laptop(string name, int productionYear, string manufacturer, string operatingSystem, string cpu) : Equipment(name, productionYear, manufacturer) {
  public string OperatingSystem { get; set; } = operatingSystem;
  public string CPU { get; set; } = cpu;
}
