namespace CustomerAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Age = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql(@"  SET IDENTITY_INSERT [dbo].[Clients] ON
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (1, N'Tom', N'Cook', 44, N'2001-12-01 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (2, N'Mary', N'Taxi Driver', 22, N'2002-12-02 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (3, N'Jane', N'Nurse', 28, N'2003-12-03 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (4, N'Lex', N'Doctor', 51, N'2004-10-12 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (5, N'Paul', N'Salesman', 23, N'2005-11-02 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (6, N'Frank', N'Butler', 32, N'2002-08-19 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (7, N'Joe', N'Programmer', 30, N'2004-12-18 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (8, N'John', N'Clerk', 25, N'2005-12-15 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (9, N'Mark', N'Student', 14, N'2006-11-25 00:00:00')
                    INSERT INTO [dbo].[Clients] ([Id], [Name], [Description], [Age], [Date]) VALUES (10, N'Paula', N'Student', 12, N'2003-11-30 00:00:00')
                    SET IDENTITY_INSERT [dbo].[Clients] OFF");

        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
