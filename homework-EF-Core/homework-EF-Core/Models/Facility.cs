namespace HotelBookingSystem.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Внешний ключ
        public int HotelId { get; set; }

        // Навигационное свойство
        public Hotel Hotel { get; set; } = null!;
    }
}