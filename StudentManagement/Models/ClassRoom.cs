using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class ClassRoom
{
    public int ClassRoomId { get; set; }

    public string RoomName { get; set; } = null!;

    public int? Capacity { get; set; }

    public virtual ICollection<StudySlot> StudySlots { get; set; } = new List<StudySlot>();
}
