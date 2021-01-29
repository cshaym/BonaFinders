namespace BonaFinders.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EthicalOrganization",
                c => new
                    {
                        EthicalOrganizationId = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        EthicalOrganizationName = c.String(nullable: false),
                        CrueltyFree = c.Boolean(nullable: false),
                        Sustainable = c.Boolean(nullable: false),
                        Diverse = c.Boolean(nullable: false),
                        ECountry = c.String(),
                        EImprove = c.String(),
                    })
                .PrimaryKey(t => t.EthicalOrganizationId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.EthicalReview",
                c => new
                    {
                        EthicalReviewId = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        EthicalOrganizationId = c.Int(nullable: false),
                        EthicalReviewTitle = c.String(nullable: false),
                        EthicalReviewText = c.String(),
                    })
                .PrimaryKey(t => t.EthicalReviewId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.EthicalOrganization", t => t.EthicalOrganizationId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EthicalOrganizationId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tip",
                c => new
                    {
                        TipId = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.TipId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UnethicalOrganization",
                c => new
                    {
                        UnethicalOrganizationId = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        UnethicalOrganizationName = c.String(nullable: false),
                        FastFashion = c.Boolean(nullable: false),
                        Exploitation = c.Boolean(nullable: false),
                        Sweatshop = c.Boolean(nullable: false),
                        Copyright = c.Boolean(nullable: false),
                        UCountry = c.String(),
                        UImprove = c.String(),
                    })
                .PrimaryKey(t => t.UnethicalOrganizationId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UnethicalReview",
                c => new
                    {
                        UnethicalReviewId = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        UnethicalOrganizationId = c.Int(nullable: false),
                        UnethicalReviewTitle = c.String(nullable: false),
                        UnethicalReviewText = c.String(),
                    })
                .PrimaryKey(t => t.UnethicalReviewId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.UnethicalOrganization", t => t.UnethicalOrganizationId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.UnethicalOrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnethicalReview", "UnethicalOrganizationId", "dbo.UnethicalOrganization");
            DropForeignKey("dbo.UnethicalReview", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.UnethicalOrganization", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Tip", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.EthicalReview", "EthicalOrganizationId", "dbo.EthicalOrganization");
            DropForeignKey("dbo.EthicalReview", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.EthicalOrganization", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.UnethicalReview", new[] { "UnethicalOrganizationId" });
            DropIndex("dbo.UnethicalReview", new[] { "UserId" });
            DropIndex("dbo.UnethicalOrganization", new[] { "UserId" });
            DropIndex("dbo.Tip", new[] { "UserId" });
            DropIndex("dbo.EthicalReview", new[] { "EthicalOrganizationId" });
            DropIndex("dbo.EthicalReview", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.EthicalOrganization", new[] { "UserId" });
            DropTable("dbo.UnethicalReview");
            DropTable("dbo.UnethicalOrganization");
            DropTable("dbo.Tip");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.EthicalReview");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.EthicalOrganization");
        }
    }
}
