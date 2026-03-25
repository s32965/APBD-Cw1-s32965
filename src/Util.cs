using APBD_Cw1_s32965.Models;
using APBD_Cw1_s32965.Services.Equipments;
using APBD_Cw1_s32965.Services.Rentals;

namespace APBD_Cw1_s32965;

public static class Util 
{
    public static void Raport(EquipmentService equipmentService, RentalService rentalService) 
    {
        Console.WriteLine("SYSTEM REPORT:\n");

        var allEquipment = equipmentService.GetEquipment();
        var availableEquipment = equipmentService.GetAvailableEquipment();
        int unavailableCount = allEquipment.Count - availableEquipment.Count;

        Console.WriteLine($"Total equipment in catalogue: {allEquipment.Count}");
        Console.WriteLine($"Currently available: {availableEquipment.Count}");
        Console.WriteLine($"Currently unavailable: {unavailableCount}\n");

        var activeRents = rentalService.GetAllActiveRents();
        var overdueRents = rentalService.GetAllOverdueRents();

        Console.WriteLine($"Total active rentals: {activeRents.Count}");
        Console.WriteLine($"Overdue rentals: {overdueRents.Count}");
        
        if (overdueRents.Count > 0) 
        {
            foreach (Rental rent in overdueRents) 
            {
                int daysOverdue = (DateTime.Now - rent.AgreedReturnDate).Days;
                Console.WriteLine($"Rent ID: {rent.Id}\nUser: {rent.User.FirstName} {rent.User.Surname}\nItem: {rent.Item.Name}\nDays Overdue: {daysOverdue}");
            }
        }
    }
}
