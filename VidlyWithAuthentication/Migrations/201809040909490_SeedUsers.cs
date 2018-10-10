namespace VidlyWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'502fd46c-43ac-4927-a1db-e25e897ded32', N'guest@vidly.com', 0, N'ACg6kZ49pHMnLBxQdB1yTvIyqi3shIDDsv8cT1nF7lawWDapDfDuPpuOF5lrolCWJg==', N'9d8272ba-7da9-48f3-b75c-0cf0dde4ffe4', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9bc6828e-5aab-4c32-acb3-55c62e656ea0', N'admin@vidly.com', 0, N'AGEAeYDXpqShT4oF2dsqCI94RokmjwyRlgg4sHDIen8n8uMc0ebakgpaniFUp0ZJiQ==', N'54fb720a-e9f7-4bfa-9957-5b67f58fe9ed', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'755ae983-7e3d-4f2f-b9e5-2f2e2cd9f341', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9bc6828e-5aab-4c32-acb3-55c62e656ea0', N'755ae983-7e3d-4f2f-b9e5-2f2e2cd9f341')

");
        }
        
        public override void Down()
        {
        }
    }
}
