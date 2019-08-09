using BeAn.Models;
using Microsoft.EntityFrameworkCore;

namespace BeAn.Data
{
    public class TestDataPopulator
    {

        public static void PopulateTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Program>().HasData(
                new { Id = -1, Name = "School", Description = "Dealing with school situations", ProgramComplete = 0, MasteryCriteriaCompareType = 1, MasteryCriteriaCompareTo = 80.0, MasteryCriteriaConsecutiveSessions = 1, Reusable = true, StudentId = -1 },
                new { Id = -2, Name = "Home", Description = "Dealing with home situations", ProgramComplete = 1, MasteryCriteriaCompareType = 1, MasteryCriteriaCompareTo = 80.0, MasteryCriteriaConsecutiveSessions = 2, Reusable = true, StudentId = -1 },
                new { Id = -3, Name = "Outing", Description = "Being away from home", ProgramComplete = 0, MasteryCriteriaCompareType = 1, MasteryCriteriaCompareTo = 80.0, MasteryCriteriaConsecutiveSessions = 3, Reusable = true, StudentId = -1 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = -1, StudentId = "id1", StudentInitials = "Apple A.", Remark = "This student is very smart" },
                new Student() { Id = -2, StudentId = "id2", StudentInitials = "Banana B.", Remark = "Temporary student until I go on vacation" },
                new Student() { Id = -3, StudentId = "id3", StudentInitials = "Carrot C.", Remark = "Only schedule on Saturdays" }
            );

            modelBuilder.Entity<Target>().HasData(
                new
                {
                    Id = -1,
                    Name = "Washing hands",
                    Type = "trial",
                    MinTrial = 2,
                    MaxTrial = 4,
                    ProgramId = -1
                },
                new
                {
                    Id = -2,
                    Name = "Making friends",
                    Type = "trial",
                    MinTrial = 1,
                    MaxTrial = 5,
                    ProgramId = -1
                },
                new
                {
                    Id = -3,
                    Name = "Attending class",
                    Type = "trial",
                    MinTrial = 2,
                    MaxTrial = 4,
                    ProgramId = -1
                },
                new
                {
                    Id = -4,
                    Name = "Eating dinner",
                    Type = "trial",
                    MinTrial = 3,
                    MaxTrial = 10,
                    ProgramId = -2
                },
                new
                {
                    Id = -5,
                    Name = "Washing dishes",
                    Type = "trial",
                    MinTrial = 2,
                    MaxTrial = 4,
                    ProgramId = -2
                },
                new
                {
                    Id = -6,
                    Name = "Going to bed",
                    Type = "trial",
                    MinTrial = 1,
                    MaxTrial = 5,
                    ProgramId = -2
                },
                new
                {
                    Id = -7,
                    Name = "Riding the bus",
                    Type = "trial",
                    MinTrial = 3,
                    MaxTrial = 10,
                    ProgramId = -3
                },
                new
                {
                    Id = -8,
                    Name = "Buying groceries",
                    Type = "trial",
                    MinTrial = 2,
                    MaxTrial = 4,
                    ProgramId = -3
                },
                new
                {
                    Id = -9,
                    Name = "Finding an address",
                    Type = "trial",
                    MinTrial = 1,
                    MaxTrial = 6,
                    ProgramId = -3
                }
            );

            modelBuilder.Entity<Prompt>().HasData(
                new { Id = -1, Level = 1, Description = "Full physical guidance", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -1 },
                new { Id = -2, Level = 2, Description = "Demonstration of me washing hands", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -1 },
                new { Id = -3, Level = 3, Description = "No assistance required", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -1 },
                new { Id = -4, Level = 1, Description = "Requires introduction and prompting", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 1, TargetId = -2 },
                new { Id = -5, Level = 2, Description = "Needs a reminder", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -2 },
                new { Id = -6, Level = 3, Description = "Will initiate interaction on their own", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -2 },
                new { Id = -7, Level = 1, Description = "Won't go to class unless physically guided", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 1, TargetId = -3 },
                new { Id = -8, Level = 2, Description = "Must remind to attend class", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 1, TargetId = -3 },
                new { Id = -9, Level = 3, Description = "Usually remembers to attend class", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -3 },
                new { Id = -10, Level = 1, Description = "Needs physical guidance with cutlery", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -4 },
                new { Id = -11, Level = 2, Description = "Makes small mistakes and spills food", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -4 },
                new { Id = -12, Level = 3, Description = "Flawless eater", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -4 },
                new { Id = -13, Level = 1, Description = "Needs physical guidance", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -5 },
                new { Id = -14, Level = 2, Description = "Misses a few spots", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -5 },
                new { Id = -15, Level = 1, Description = "Complains and must be dragged to bed", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -6 },
                new { Id = -16, Level = 2, Description = "Goes to bed on their own", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 2, TargetId = -6 },
                new { Id = -17, Level = 1, Description = "Doesn't know how to get on the bus", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 1, TargetId = -7 },
                new { Id = -18, Level = 2, Description = "Can ride the bus with guidance", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 2, TargetId = -7 },
                new { Id = -19, Level = 1, Description = "Doesn't know what to buy", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 3, TargetId = -8 },
                new { Id = -20, Level = 2, Description = "Is able to follow shopping list and checkout", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 1, TargetId = -8 },
                new { Id = -21, Level = 1, Description = "Needs assistance", PromptLevelComplete = 1, ConsecutiveSuccessfulSession = 3, TargetId = -9 },
                new { Id = -22, Level = 2, Description = "Can use Google Maps to find an address", PromptLevelComplete = 0, ConsecutiveSuccessfulSession = 0, TargetId = -9 }
            );

            modelBuilder.Entity<Session>().HasData(
                new { Id = -1, Description = "session1", StudentId = -3 }
            );

            modelBuilder.Entity<SessionData>().HasData(
                new { Id = -1, Data = 1, SessionId = -1, ProgramId = -2, TargetId = -2 }
            );
        }
    }
}
