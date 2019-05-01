namespace AspDotNetCourseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4d7472d7-d025-4746-92a2-eaedcf73efc6', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'99dc0361-691e-4f3e-8ebb-9b1be5b23dc9', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7887e02-a6b5-4157-8fcc-d42c279039f0', N'admin@example.com', 0, N'ACI4nuUvfUPA3AgnFsbeLbsaIWbmYicXJQP0tH4tc/DaqTmZLG//3BEdNn4oODOhKg==', N'0e7d146b-5f4c-419e-a3da-978c657292c6', NULL, 0, 0, NULL, 1, 0, N'admin@example.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fc9800c3-4fa4-4c5f-9e94-239d933ea1f5', N'user@example.com', 0, N'AHZaPymEgDEYsMmBKIc6fzjKia9Z8YREZHje5n3EUUt9fq/4963gBI5tQM+1+ES30w==', N'71837623-a71a-4bca-b2d8-d9c91410d6cc', NULL, 0, 0, NULL, 1, 0, N'user@example.com')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7887e02-a6b5-4157-8fcc-d42c279039f0', N'4d7472d7-d025-4746-92a2-eaedcf73efc6')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
