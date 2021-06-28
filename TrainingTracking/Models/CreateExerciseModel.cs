using System.Text.Json.Serialization;

namespace TrainingTracking.Models
{
    public class CreateExerciseModel
    {
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}