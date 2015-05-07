using System;

public class Group
{
    // Properties
    public int GroupNumber { get; set; }
    public string DepartmentName { get; set; }

    // Constructor
    public Group(int groupNumber, string departmentName)
    {
        this.GroupNumber = groupNumber;
        this.DepartmentName = departmentName;
    }
}