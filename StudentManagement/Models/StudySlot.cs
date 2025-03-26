using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class StudySlot
{
    public int StudySlotId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public int ClassRoomId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ClassRoom ClassRoom { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
