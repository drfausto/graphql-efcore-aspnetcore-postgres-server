using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCourse.Models;

namespace EFCourse.Store {
	public interface IDataStore {
		Task<IEnumerable<University>> GetUniversitiesAsync();		
		Task<University> GetUniversityByIdAsync(int univId);		
    Task<University> CreateUniversityAsync(University univ);
    
		Task<IEnumerable<Department>> GetDepartmentsAsync();
		Task<Department> GetDepartmentByIdAsync(int dptoId);
		Task<IEnumerable<Department>> GetDepartmentByUniversityIdAsync(int dptoId);
		Task<ILookup<int, Department>> GetDepartmentByUniversityIdAsync(
			IEnumerable<int> univIds);
    Task<Department> CreateDepartmentAsync(Department dpto);

		Task<IEnumerable<Course>> GetCoursesAsync();
		Task<Course> GetCourseByIdAsync(int courId);    
		Task<IEnumerable<Course>> GetCoursesByDepartmentIdAsync(int dptoId);		
		Task<Course> CreateCourseAsync(Course course);
	}
}