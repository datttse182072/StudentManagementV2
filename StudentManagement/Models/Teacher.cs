using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Specialty { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<StudySlot> StudySlots { get; set; } = new List<StudySlot>();
}
