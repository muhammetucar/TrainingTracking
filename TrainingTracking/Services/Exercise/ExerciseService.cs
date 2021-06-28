using System.Collections.Generic;
using System.Linq;
using TrainingTracking.Entities;

namespace TrainingTracking.Services.Exercise
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _dbContext;

        public ExerciseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Entities.Exercise> GetAll()
        {
            return _dbContext.Exercises.ToList();
        }

        public List<Entities.Exercise> GetAllByUserId(int userId)
        {
            return _dbContext.Exercises.Where(x => x.UserId == userId).ToList();
        }

        public Entities.Exercise GetById(int id)
        {
            return _dbContext.Exercises.FirstOrDefault(x => x.Id == id);
        }

        public Entities.Exercise Create(Entities.Exercise exercise)
        {
            _dbContext.Exercises.Add(exercise);
            _dbContext.SaveChanges();
            return exercise;
        }

        public Entities.Exercise Update(Entities.Exercise exercise)
        {
            _dbContext.Exercises.Update(exercise);
            _dbContext.SaveChanges();
            return exercise;
        }
    }
}