namespace Tutorial2Session4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Creds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.JellyDonuts",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        Grade = c.Int(),
                        Course_CourseID = c.Int(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        ResidenceHall = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Student_ID" });
            DropIndex("dbo.Enrollments", new[] { "Course_CourseID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
