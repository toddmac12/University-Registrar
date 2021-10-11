using System.Collections.Generic;

namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
      this.JoinEntities = new HashSet<Enrollment>();
    }

    public int StudentId { get; set; }
    public string Name { get; set; }
    public date EnrollmentDate { get; set; }

    public virtual ICollection<Enrollment> JoinEntities { get; }
  }
}