using System.Collections.Generic;

namespace Registrar.Models
{
  public class Course
  {
    public Course()
    {
      this.JoinEntities = new HashSet<Enrollment>();
    }

    public int CourseId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public string Department { get; set; }
    public virtual ICollection<Enrollment> JoinEntities { get; set; }
  }
}