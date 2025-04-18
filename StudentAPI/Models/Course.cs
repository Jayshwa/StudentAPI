using System;

namespace StudentAPI.Models{

    public class Course{

        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public ICollection<Student>? Students { get; set; }

    }


}