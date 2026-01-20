using FitnessClubManagement.Models;
using System;

public class Member : Person
{
    public DateTime DateOfBirth { get; set; }
    public double Height { get; set; } 
    public double Weight { get; set; } 
    public Membership Membership { get; set; }  
    public string PhoneNumber { get; set; }     
    public bool IsActive { get; set; }

    public int CalculateAge()
    {
        return DateTime.Now.Year - DateOfBirth.Year;
    }

    public double CalculateBMI()
    {
        double heightInMeters = Height / 100;
        return Weight / (heightInMeters * heightInMeters);
    }
}
