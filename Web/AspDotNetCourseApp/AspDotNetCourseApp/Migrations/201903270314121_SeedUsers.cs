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

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'116b8e29-2e96-4719-9ce4-fb065af439ad', N'guest.sarah@gmail.com', 0, N'AADJ23fRUwuYutvUKYzSL7lq55XaKhvUyseKoHYzxCoaQ6aCHEn7E8WrmjV9rIdEWg==', N'9d15b0a0-905c-41a8-9177-1560301d41ef', NULL, 0, 0, NULL, 1, 0, N'guest.sarah@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fe146c5d-b2fb-4f3b-95cc-04ed856e5932', N'admin.sarah@gmail.com', 0, N'AJfTjgt3+aiCyX6oMVT1ESZv/+hiy5MSKDfzSYt9E29mtTTnou3JOcx6z4XHgU6QlQ==', N'8abd4768-a14f-45df-a77c-7265479159d1', NULL, 0, 0, NULL, 1, 0, N'admin.sarah@gmail.com')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe146c5d-b2fb-4f3b-95cc-04ed856e5932', N'4d7472d7-d025-4746-92a2-eaedcf73efc6')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
