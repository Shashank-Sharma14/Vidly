namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30578131-d8b0-43fa-81f7-086ca2d53d18', N'guest@gmail.com', 0, N'ABMlm+Yu8AgUs4RxlaQCZufJbKk3gbBtJT2lEVuXDDQNquwTwWZmdV7k7MwYANKK3w==', N'86d83b28-b9f8-4942-aa0d-b84f25e35022', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9a4e1599-ded8-4014-80fa-af17808a3526', N'Shashanksharma@vidly.com', 0, N'AAcVU4T0fxWylkm4k9ZNqZ1gP6M/bcNrWpskxfBt7raVVeL2Y9jRiN9kQFFgN5Xs5Q==', N'2188debc-e4bc-4285-8e1a-f8660ad33e38', NULL, 0, 0, NULL, 1, 0, N'Shashanksharma@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bbbb3de2-3f51-40cd-82e9-910a9585522f', N'sharma14697@gmail.com', 0, N'AD/qzx0G7V9yd2d7hPneGY/9CCyyicjdJIaxzBTRaj9DRg5p5mG5jY5OsE4FUBGhfg==', N'bef84f14-e7b9-4db3-b0f0-0085e4a8c05e', NULL, 0, 0, NULL, 1, 0, N'sharma14697@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c6ec05ef-d603-4548-b223-1a729fc53d32', N'guest@vidly.com', 0, N'AFNRgHzYw39BI0zoOSJrzvVCrUWjwrsk6O22vt221fcLRCtaoE4Q6OxVnhClJ/yWlg==', N'60d726ac-b17e-4c2a-a2c0-318cb0cd0fe5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5db4dc26-5156-4152-9fca-6c16a1a48f5f', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9a4e1599-ded8-4014-80fa-af17808a3526', N'5db4dc26-5156-4152-9fca-6c16a1a48f5f')

");
        }
        
        public override void Down()
        {
        }
    }
}
