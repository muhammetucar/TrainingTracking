using System.Text.Json.Serialization;

namespace TrainingTracking.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}