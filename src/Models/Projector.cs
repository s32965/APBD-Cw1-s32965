namespace APBD_Cw1_s32965.Models;

public class Projector(string name, int productionYear, string manufacturer, string resolution, List<string> inputMethods) : Equipment(name, productionYear, manufacturer) {
  public string Resolution { get; set; } = resolution;
  public List<string> InputMethods { get; set; } = inputMethods;
}
