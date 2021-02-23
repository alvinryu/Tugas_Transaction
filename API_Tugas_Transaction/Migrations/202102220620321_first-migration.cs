namespace API_Tugas_Transaction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Account",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_M_Employee", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_M_Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Account", "Id", "dbo.Tbl_M_Employee");
            DropIndex("dbo.Tbl_Account", new[] { "Id" });
            DropTable("dbo.Tbl_M_Employee");
            DropTable("dbo.Tbl_Account");
        }
    }
}
