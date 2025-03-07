using AssessmentApp.Data;
using AssessmentApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentApp.Services
{
    public class AssessmentService
    {
        private readonly ApplicationDbContext _context;

        public AssessmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Assessment> GetAll()
        {
            return _context.Assessments.ToList();
        }

        public Assessment GetById(int id)
        {
            return _context.Assessments.Find(id);
        }

        public void Add(Assessment assessment)
        {
            assessment.SetDateCreatedToUtc();
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
        }

        public void Update(Assessment assessment)
        {
            assessment.SetDateCreatedToUtc();
            _context.Assessments.Update(assessment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var assessment = _context.Assessments.Find(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
                _context.SaveChanges();
            }
        }
    }
}