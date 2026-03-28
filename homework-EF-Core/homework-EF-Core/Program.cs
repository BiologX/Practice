using HotelBookingSystem.Data;
using HotelBookingSystem.Models;

class Program
{
    static void Main()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("=== Демонстрация работы с БД ===\n");

        // СОЗДАНИЕ отеля
        Console.WriteLine("1. СОЗДАНИЕ ОТЕЛЯ:");
        var hotel = new Hotel
        {
            Name = "Grand Hotel",
            City = "Москва"
        };

        context.Hotels.Add(hotel);
        context.SaveChanges();
        Console.WriteLine($"Создан отель: {hotel.Name}, ID: {hotel.Id}");
        WaitForEnter();

        // ЧТЕНИЕ отеля
        Console.WriteLine("2. ЧТЕНИЕ ОТЕЛЕЙ:");
        var hotels = context.Hotels.ToList();
        foreach (var h in hotels)
        {
            Console.WriteLine($"Отель: {h.Name}, Город: {h.City}");
        }
        WaitForEnter();

        // ОБНОВЛЕНИЕ отеля
        Console.WriteLine("3. ОБНОВЛЕНИЕ ОТЕЛЯ:");
        var hotelToUpdate = context.Hotels.Find(hotel.Id);
        if (hotelToUpdate != null)
        {
            hotelToUpdate.City = "Санкт-Петербург";
            context.SaveChanges();
            Console.WriteLine($"Отель обновлен: {hotelToUpdate.Name}, Город: {hotelToUpdate.City}");
        }
        WaitForEnter();

        // УДАЛЕНИЕ отеля
        Console.WriteLine("4. УДАЛЕНИЕ ОТЕЛЯ:");
        var hotelToDelete = context.Hotels.Find(hotel.Id);
        if (hotelToDelete != null)
        {
            context.Hotels.Remove(hotelToDelete);
            context.SaveChanges();
            Console.WriteLine($"Отель удален: {hotelToDelete.Name}");
        }

        Console.WriteLine("\n=== Готово ===");
        WaitForEnter();
    }

    static void WaitForEnter()
    {
        Console.WriteLine("\n[Нажмите Enter для продолжения...]");
        Console.ReadLine();
        Console.Clear();
    }
}