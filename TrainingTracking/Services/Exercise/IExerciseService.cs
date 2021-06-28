using System.Collections.Generic;

namespace TrainingTracking.Services.Exercise
{
    public interface IExerciseService
    {
        List<Entities.Exercise> GetAll();
        List<Entities.Exercise> GetAllByUserId(int userId);
        Entities.Exercise GetById(int id);
        Entities.Exercise Create(Entities.Exercise exercise);
        Entities.Exercise Update(Entities.Exercise exercise);
    }
}