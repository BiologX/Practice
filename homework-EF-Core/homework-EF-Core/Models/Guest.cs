namespace HotelBookingSystem.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Навигационные свойства
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}