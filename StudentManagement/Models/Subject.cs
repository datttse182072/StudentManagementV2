using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectCode { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<StudySlot> StudySlots { get; set; } = new List<StudySlot>();
}
