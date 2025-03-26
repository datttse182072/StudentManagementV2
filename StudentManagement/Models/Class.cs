using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<StudySlot> StudySlots { get; set; } = new List<StudySlot>();
}
