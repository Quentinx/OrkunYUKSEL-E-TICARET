namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                        EMail = c.String(),
                        OlusturulmaTarihi = c.DateTime(nullable: false),
                        KullaniciTip = c.Int(nullable: false),
                        Aktiflik = c.Boolean(nullable: false),
                        GuidId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sepets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OltaId = c.Int(nullable: false),
                        KullaniciId = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciId, cascadeDelete: true)
                .ForeignKey("dbo.Oltas", t => t.OltaId, cascadeDelete: true)
                .Index(t => t.OltaId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Oltas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Misina = c.String(),
                        İlanNo = c.Int(nullable: false),
                        Baslik = c.String(),
                        Fiyat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OltaOzelliks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OltaId = c.Int(nullable: false),
                        YapimYili = c.Int(),
                        OltaTipi = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oltas", t => t.OltaId, cascadeDelete: true)
                .Index(t => t.OltaId);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(),
                        AdiSoyadi = c.String(),
                        Email = c.String(),
                        Olta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciId)
                .ForeignKey("dbo.Oltas", t => t.Olta_Id)
                .Index(t => t.KullaniciId)
                .Index(t => t.Olta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "Olta_Id", "dbo.Oltas");
            DropForeignKey("dbo.Yorums", "KullaniciId", "dbo.Kullanicis");
            DropForeignKey("dbo.Sepets", "OltaId", "dbo.Oltas");
            DropForeignKey("dbo.OltaOzelliks", "OltaId", "dbo.Oltas");
            DropForeignKey("dbo.Sepets", "KullaniciId", "dbo.Kullanicis");
            DropIndex("dbo.Yorums", new[] { "Olta_Id" });
            DropIndex("dbo.Yorums", new[] { "KullaniciId" });
            DropIndex("dbo.OltaOzelliks", new[] { "OltaId" });
            DropIndex("dbo.Sepets", new[] { "KullaniciId" });
            DropIndex("dbo.Sepets", new[] { "OltaId" });
            DropTable("dbo.Yorums");
            DropTable("dbo.OltaOzelliks");
            DropTable("dbo.Oltas");
            DropTable("dbo.Sepets");
            DropTable("dbo.Kullanicis");
        }
    }
}
