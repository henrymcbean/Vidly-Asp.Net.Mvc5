namespace Vidly_Asp.Net.Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'83b8e16f-7004-4814-a2a1-9bc89a535e77', N'guest@vidly.com', 0, N'AIvBze8Y+6AyGeyk2cmB4U0l7bpxK2LBshJz2sWm79z22XIOOA7rbFDaB7ygj1vI3w==', N'19597af3-5284-434c-b61a-89d708cfa60e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8c04d066-f0a2-46cd-b17c-7a6c9c6c2f7a', N'admin@vidly.com', 0, N'AFkmPIQgY9styVpFndp24cvwvYZpnwaTscA3b6cSlqd5f5Ch/QNe02FhLsemFLEWgA==', N'ec9adb27-e1d3-4dcc-921f-50917277ca75', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'58daf660-1262-4e31-8bb5-78251c5532c1', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8c04d066-f0a2-46cd-b17c-7a6c9c6c2f7a', N'58daf660-1262-4e31-8bb5-78251c5532c1')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
