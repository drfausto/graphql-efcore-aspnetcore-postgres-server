using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCourse.Data;
using EFCourse .Models;
using Microsoft.EntityFrameworkCore;

namespace EFCourse.Store {
  public class DataStore : IDataStore {
    private readonly CourseContext _applicationDbContext;
    public DataStore(CourseContext applicationDbContext) {
      _applicationDbContext = applicationDbContext;
    }
    public async Task<IEnumerable<University>> GetUniversitiesAsync() {
      return await _applicationDbContext.University.AsNoTracking().ToListAsync();
    }      
    public async Task<University> GetUniversityByIdAsync(int univId) {
      return await _applicationDbContext.University.FindAsync(univId);
    }      
    public async Task<University> CreateUniversityAsync(University univ) {
      var addedUniv = await _applicationDbContext.University.AddAsync(univ);
      await _applicationDbContext.SaveChangesAsync();
      return addedUniv.Entity;
    }
    public async Task<IEnumerable<Department>> GetDepartmentsAsync() {
      return await _applicationDbContext.Department.AsNoTracking().ToListAsync();
    }
    public async Task<Department> GetDepartmentByIdAsync(int dptoId) {
      return await _applicationDbContext.Department.FindAsync(dptoId);
    } 
    public async Task<IEnumerable<Department>> GetDepartmentByUniversityIdAsync(int univId) {
      return await _applicationDbContext.Department
        .Where(o => o.UniversityId == univId)
        .ToListAsync();
    }
    public async Task<ILookup<int, Department>> GetDepartmentByUniversityIdAsync(
      IEnumerable<int> univIds) {
        var dptos = await _applicationDbContext.Department
          .Where(i => univIds.Contains(i.UniversityId))
          .ToListAsync();
        return dptos.ToLookup(i => i.UniversityId);
    }  
    public async Task<Department> CreateDepartmentAsync(Department dpto) {         
      var addedDpto = await _applicationDbContext.Department.AddAsync(dpto);
      await _applicationDbContext.SaveChangesAsync();
      return addedDpto.Entity;
    }      
    public async Task<IEnumerable<Course>> GetCoursesAsync() {
      return await _applicationDbContext.Course.AsNoTracking().ToListAsync();
    } 
    public async Task<Course> GetCourseByIdAsync(int courId) {
      return await _applicationDbContext.Course.FindAsync(courId);
    }
    public async Task<IEnumerable<Course>> GetCourseByDepartmentIdAsync(int dptoId) {
      return await _applicationDbContext
      .Course.Where(o => o.DepartmentId == dptoId).ToListAsync();
    }
    public async Task<ILookup<int, Course>> GetCourseByDepartmentIdAsync(
      IEnumerable<int> dptoIds) {
        var courses = await _applicationDbContext.Course
          .Where(i => dptoIds.Contains(i.DepartmentId))
          .ToListAsync();
        return courses.ToLookup(i => i.DepartmentId);
    }    
    public async Task<Course> CreateCourseAsync(Course course) {
      var addedCourse = await _applicationDbContext.Course.AddAsync(course);
      await _applicationDbContext.SaveChangesAsync();
      return addedCourse.Entity;
    }
  }
}
