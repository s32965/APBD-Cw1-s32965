namespace APBD_Cw1_s32965.Models;

public class Camera(string name, int productionYear, string manufacturer, string type, int maxZoom) : Equipment(name, productionYear, manufacturer) {
  public string Type { get; set; } = type;
  public int MaxZoom { get; set; } = maxZoom;
}
