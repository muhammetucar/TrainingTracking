using System.Text.Json.Serialization;

namespace TrainingTracking.Models
{
    public class UpdateExerciseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}