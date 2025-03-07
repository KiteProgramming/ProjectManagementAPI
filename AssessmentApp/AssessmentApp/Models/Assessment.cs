using System;

namespace AssessmentApp.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public void SetDateCreatedToUtc()
        {
            if (DateCreated.Kind == DateTimeKind.Unspecified)
            {
                DateCreated = DateTime.SpecifyKind(DateCreated, DateTimeKind.Utc);
            }
            else
            {
                DateCreated = DateCreated.ToUniversalTime();
            }
        }
    }
}