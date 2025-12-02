namespace HotelBookingSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        // Навигационные свойства
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}