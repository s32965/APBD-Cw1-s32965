using APBD_Cw1_s32965.Models;
using APBD_Cw1_s32965.Services.Rentals;
using APBD_Cw1_s32965.Services.Equipments;
using APBD_Cw1_s32965.Enums;

User s1 = new Student("Student", "Test1");
User e1 = new Employee("Employee", "Test2");

Equipment l1 = new Laptop("I use arch btw", 2020, "System69", 20.00, "GNU/Linux", "Intel i5");
Equipment c1 = new Camera("Camera1", 2020, "Canon", 10.00, "DSLR", 5);
Equipment p1 = new Projector("Projector1", 1995, "Brother", 5.99, "1920x1080", ["HDMI", "VGA"]);

IEquipmentService equipmentService = new EquipmentService();

equipmentService.AddItem(l1);
equipmentService.AddItem(c1);
equipmentService.AddItem(p1);

equipmentService.SetUnavailable(c1.Id);

IRentalService rentalService = new RentalService();

// Rent available l1

int l1RentalId = 0;
Console.WriteLine("\nDemo: Rent item l1");
try {
  l1RentalId = rentalService.RentItem(DateTime.Now.AddDays(7), s1, l1); 
} catch (Exception e) {
  Console.WriteLine(e.Message);
}

// Rent unavailable c1
Console.WriteLine("\nDemo: Rent item c1");
try {
  rentalService.RentItem(DateTime.Now.AddDays(7), s1, c1);
} catch (Exception e) {
  Console.WriteLine(e.Message);
}

// Return item on time
Console.WriteLine("\nDemo: Return item l1 on time");
try {
  rentalService.ReturnItem(l1RentalId);
} catch (Exception e) {
  Console.WriteLine(e.Message);
}

// Return overdue item
Console.WriteLine("\nDemo: Return overdue item");
try {
 int rId = rentalService.RentItem(new DateTime(2000, 1, 1), DateTime.Now.AddDays(-6), e1, p1);
 Console.WriteLine($"Predicted cost based on time: {rentalService.GetRentById(rId).PredictedCost}");
 rentalService.ReturnItem(rId);
 Console.WriteLine($"Overdue costs: {rentalService.GetRentById(rId).ActualCost - rentalService.GetRentById(rId).PredictedCost}");
} catch (Exception e) {
  Console.WriteLine(e.Message);
}

// Print report
Console.WriteLine("");
Console.WriteLine("");
Util.Raport(equipmentService, rentalService);
