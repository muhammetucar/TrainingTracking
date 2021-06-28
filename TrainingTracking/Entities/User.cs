using System.Text.Json.Serialization;

namespace TrainingTracking.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
