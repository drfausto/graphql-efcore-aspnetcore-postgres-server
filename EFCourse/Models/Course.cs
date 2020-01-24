namespace EFCourse.Models {
	public partial class Course {
		public Course() { }

		public int CourseID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int DepartmentId { get; set; }
		public Department Department	{ get; set; }
	}
}
