using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public virtual Account Account { get; set; } = null!;
}
