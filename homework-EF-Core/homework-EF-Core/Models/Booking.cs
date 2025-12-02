namespace HotelBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        // Внешние ключи
        public int RoomId { get; set; }
        public int GuestId { get; set; }

        // Навигационные свойства
        public Room Room { get; set; } = null!;
        public Guest Guest { get; set; } = null!;
    }
}