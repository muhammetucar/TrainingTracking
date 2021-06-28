using System;

namespace TrainingTracking.Entities
{
    public class UserExercise
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public Exercise Exercise { get; set; }
    }
}