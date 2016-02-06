namespace ApartmentApps.API.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buildings", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Units", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Tenants", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Buildings", new[] { "PropertyId" });
            DropIndex("dbo.Units", new[] { "BuildingId" });
            DropIndex("dbo.Tenants", new[] { "UserId" });
            CreateTable(
                "dbo.PropertyAddons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        PropertyIntegrationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyAddonTypes", t => t.PropertyIntegrationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.PropertyIntegrationTypeId);
            
            CreateTable(
                "dbo.PropertyAddonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Tenants", "PropertyId", c => c.Int(nullable: false));
            AddColumn("dbo.Tenants", "ThirdPartyId", c => c.String());
            AddColumn("dbo.Tenants", "FirstName", c => c.String());
            AddColumn("dbo.Tenants", "LastName", c => c.String());
            AddColumn("dbo.Tenants", "UnitNumber", c => c.String());
            AddColumn("dbo.Tenants", "BuildingName", c => c.String());
            AddColumn("dbo.Tenants", "Address", c => c.String());
            AddColumn("dbo.Tenants", "City", c => c.String());
            AddColumn("dbo.Tenants", "State", c => c.String());
            AddColumn("dbo.Tenants", "PostalCode", c => c.String());
            AddColumn("dbo.Tenants", "Email", c => c.String());
            AddColumn("dbo.Tenants", "Gender", c => c.String());
            AddColumn("dbo.Tenants", "MiddleName", c => c.String());
            AlterColumn("dbo.Tenants", "UserId", c => c.String());
            CreateIndex("dbo.Tenants", "PropertyId");
            CreateIndex("dbo.AspNetUsers", "TenantId");
            AddForeignKey("dbo.Tenants", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "TenantId", "dbo.Tenants", "Id", cascadeDelete: true);
            DropTable("dbo.Buildings");
            DropTable("dbo.Units");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUsers", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.Tenants", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.PropertyAddons", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.PropertyAddons", "PropertyIntegrationTypeId", "dbo.PropertyAddonTypes");
            DropIndex("dbo.AspNetUsers", new[] { "TenantId" });
            DropIndex("dbo.Tenants", new[] { "PropertyId" });
            DropIndex("dbo.PropertyAddons", new[] { "PropertyIntegrationTypeId" });
            DropIndex("dbo.PropertyAddons", new[] { "PropertyId" });
            AlterColumn("dbo.Tenants", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Tenants", "MiddleName");
            DropColumn("dbo.Tenants", "Gender");
            DropColumn("dbo.Tenants", "Email");
            DropColumn("dbo.Tenants", "PostalCode");
            DropColumn("dbo.Tenants", "State");
            DropColumn("dbo.Tenants", "City");
            DropColumn("dbo.Tenants", "Address");
            DropColumn("dbo.Tenants", "BuildingName");
            DropColumn("dbo.Tenants", "UnitNumber");
            DropColumn("dbo.Tenants", "LastName");
            DropColumn("dbo.Tenants", "FirstName");
            DropColumn("dbo.Tenants", "ThirdPartyId");
            DropColumn("dbo.Tenants", "PropertyId");
            DropColumn("dbo.AspNetUsers", "TenantId");
            DropTable("dbo.PropertyAddonTypes");
            DropTable("dbo.PropertyAddons");
            CreateIndex("dbo.Tenants", "UserId");
            CreateIndex("dbo.Units", "BuildingId");
            CreateIndex("dbo.Buildings", "PropertyId");
            AddForeignKey("dbo.Tenants", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Units", "BuildingId", "dbo.Buildings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Buildings", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
    }
}
