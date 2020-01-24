using System.Collections.Generic;

namespace EFCourse.Models {
	public partial class Department {
		public Department() {
			Course = new HashSet<Course>();
		}
		public int DepartmentId { get; set; }
		public string Name { get; set; }
		public int UniversityId { get; set; }
		public University University { get; set; }
		public ICollection<Course> Course { get; set; }
	}
}
