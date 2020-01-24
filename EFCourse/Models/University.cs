using System.Collections.Generic;

namespace EFCourse.Models {
	public partial class University {
		public University() {
			Department = new HashSet<Department>();
		}
		public int UniversityId { get; set; }
		public string Name { get; set; }
		public string City { get; set; }		
		public string State { get; set; }
		public string Country { get; set; }
		public ICollection<Department> Department { get; set; }
	}
}
