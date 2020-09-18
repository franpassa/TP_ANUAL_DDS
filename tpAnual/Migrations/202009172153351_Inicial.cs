namespace TPANUAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ciudad",
                c => new
                    {
                        ID_Ciudad = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(unicode: false),
                        ID_Provincia = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Ciudad)
                .ForeignKey("dbo.provincia", t => t.ID_Provincia)
                .Index(t => t.ID_Provincia);
            
            CreateTable(
                "dbo.direccion",
                c => new
                    {
                        ID_Direccion = c.Int(nullable: false, identity: true),
                        Calle = c.String(unicode: false),
                        Depto = c.String(unicode: false),
                        Piso = c.Int(nullable: false),
                        Ciudad_ID_Ciudad = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Direccion)
                .ForeignKey("dbo.ciudad", t => t.Ciudad_ID_Ciudad)
                .Index(t => t.Ciudad_ID_Ciudad);
            
            CreateTable(
                "dbo.documentocomercial",
                c => new
                    {
                        ID_DocumentoComercial = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TipoDocumento = c.String(unicode: false),
                        OperacionDeEgreso_ID_OperacionDeEgreso = c.Int(),
                        Presupuesto_ID_Presupuesto = c.Int(),
                    })
                .PrimaryKey(t => t.ID_DocumentoComercial)
                .ForeignKey("dbo.operaciondeegreso", t => t.OperacionDeEgreso_ID_OperacionDeEgreso)
                .ForeignKey("dbo.presupuesto", t => t.Presupuesto_ID_Presupuesto)
                .Index(t => t.OperacionDeEgreso_ID_OperacionDeEgreso)
                .Index(t => t.Presupuesto_ID_Presupuesto);
            
            CreateTable(
                "dbo.organizacion",
                c => new
                    {
                        ID_Organizacion = c.Int(nullable: false, identity: true),
                        NombreFicticio = c.String(unicode: false),
                        PromedioVentasAnuales = c.Single(nullable: false),
                        ActComisionistaoAgenciaDeViaje = c.Boolean(nullable: false),
                        CantidadDePersonal = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.operaciondeegreso",
                c => new
                    {
                        ID_OperacionDeEgreso = c.Int(nullable: false, identity: true),
                        ID_Organizacion = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        ValorTotal = c.Single(nullable: false),
                        IngresoAsociado_ID_Ingreso = c.Int(),
                        MedioDePago_ID_MedioDePago = c.Int(),
                    })
                .PrimaryKey(t => t.ID_OperacionDeEgreso)
                .ForeignKey("dbo.operaciondeingreso", t => t.IngresoAsociado_ID_Ingreso)
                .ForeignKey("dbo.mediodepago", t => t.MedioDePago_ID_MedioDePago)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion, cascadeDelete: true)
                .Index(t => t.ID_Organizacion)
                .Index(t => t.IngresoAsociado_ID_Ingreso)
                .Index(t => t.MedioDePago_ID_MedioDePago);
            
            CreateTable(
                "dbo.operaciondeingreso",
                c => new
                    {
                        ID_Ingreso = c.Int(nullable: false, identity: true),
                        ID_Organizacion = c.Int(nullable: false),
                        Descripcion = c.String(unicode: false),
                        Monto = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Ingreso)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion, cascadeDelete: true)
                .Index(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.mediodepago",
                c => new
                    {
                        ID_MedioDePago = c.Int(nullable: false, identity: true),
                        ID_Pais = c.String(maxLength: 128, storeType: "nvarchar"),
                        Numero = c.String(unicode: false),
                        TipoPago = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_MedioDePago)
                .ForeignKey("dbo.pais", t => t.ID_Pais)
                .Index(t => t.ID_Pais);
            
            CreateTable(
                "dbo.pais",
                c => new
                    {
                        ID_Pais = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(unicode: false),
                        ID_Moneda = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Pais)
                .ForeignKey("dbo.moneda", t => t.ID_Moneda)
                .Index(t => t.ID_Moneda);
            
            CreateTable(
                "dbo.moneda",
                c => new
                    {
                        ID_Moneda = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descripcion = c.String(unicode: false),
                        Simbolo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_Moneda);
            
            CreateTable(
                "dbo.provincia",
                c => new
                    {
                        ID_Provincia = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(unicode: false),
                        ID_Pais = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Provincia)
                .ForeignKey("dbo.pais", t => t.ID_Pais)
                .Index(t => t.ID_Pais);
            
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        ID_Usuario = c.Int(nullable: false, identity: true),
                        Contraseña = c.String(unicode: false),
                        NombreUsuario = c.String(unicode: false),
                        TipoUsuario = c.String(unicode: false),
                        ID_Organizacion = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Usuario)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion)
                .Index(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        ID_Item = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        ValorTotal = c.Single(nullable: false),
                        Descripcion = c.String(unicode: false),
                        Compra_ID_TipoEgreso = c.Int(),
                        Presupuesto_ID_Presupuesto = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Item)
                .ForeignKey("dbo.compra", t => t.Compra_ID_TipoEgreso)
                .ForeignKey("dbo.presupuesto", t => t.Presupuesto_ID_Presupuesto)
                .Index(t => t.Compra_ID_TipoEgreso)
                .Index(t => t.Presupuesto_ID_Presupuesto);
            
            CreateTable(
                "dbo.presupuesto",
                c => new
                    {
                        ID_Presupuesto = c.Int(nullable: false, identity: true),
                        Detalle = c.String(unicode: false),
                        ValorTotal = c.Single(nullable: false),
                        Compra_ID_TipoEgreso = c.Int(),
                        EntidadJuridicaProveedora_ID_Proveedor = c.Int(),
                        PersonaProveedora_ID_Proveedor = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Presupuesto)
                .ForeignKey("dbo.compra", t => t.Compra_ID_TipoEgreso)
                .ForeignKey("dbo.entidadjuridicaproveedora", t => t.EntidadJuridicaProveedora_ID_Proveedor)
                .ForeignKey("dbo.personaproveedora", t => t.PersonaProveedora_ID_Proveedor)
                .Index(t => t.Compra_ID_TipoEgreso)
                .Index(t => t.EntidadJuridicaProveedora_ID_Proveedor)
                .Index(t => t.PersonaProveedora_ID_Proveedor);
            
            CreateTable(
                "dbo.entidadjuridicaproveedora",
                c => new
                    {
                        ID_Proveedor = c.Int(nullable: false),
                        CodigoInscripcion = c.String(unicode: false),
                        CUIT = c.String(unicode: false),
                        RazonSocial = c.String(unicode: false),
                        ID_Direccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Proveedor)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion, cascadeDelete: true)
                .Index(t => t.ID_Direccion);
            
            CreateTable(
                "dbo.personaproveedora",
                c => new
                    {
                        ID_Proveedor = c.Int(nullable: false),
                        DNI = c.String(unicode: false),
                        Nombre = c.String(unicode: false),
                        ID_Direccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Proveedor)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion, cascadeDelete: true)
                .Index(t => t.ID_Direccion);
            
            CreateTable(
                "dbo.usuariosxcompra",
                c => new
                    {
                        ID_Compra = c.Int(nullable: false),
                        ID_Usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID_Compra, t.ID_Usuario })
                .ForeignKey("dbo.compra", t => t.ID_Compra, cascadeDelete: true)
                .ForeignKey("dbo.usuario", t => t.ID_Usuario, cascadeDelete: true)
                .Index(t => t.ID_Compra)
                .Index(t => t.ID_Usuario);
            
            CreateTable(
                "dbo.compra",
                c => new
                    {
                        ID_TipoEgreso = c.Int(nullable: false),
                        EntidadJuridicaProveedora_ID_Proveedor = c.Int(),
                        PersonaProveedora_ID_Proveedor = c.Int(),
                        CantidadDePresupuestosRequeridos = c.Int(nullable: false),
                        ID_OperacionDeEgreso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_TipoEgreso)
                .ForeignKey("dbo.entidadjuridicaproveedora", t => t.EntidadJuridicaProveedora_ID_Proveedor)
                .ForeignKey("dbo.personaproveedora", t => t.PersonaProveedora_ID_Proveedor)
                .ForeignKey("dbo.operaciondeegreso", t => t.ID_OperacionDeEgreso, cascadeDelete: true)
                .Index(t => t.EntidadJuridicaProveedora_ID_Proveedor)
                .Index(t => t.PersonaProveedora_ID_Proveedor)
                .Index(t => t.ID_OperacionDeEgreso);
            
            CreateTable(
                "dbo.entidadbase",
                c => new
                    {
                        ID_Entidad = c.Int(nullable: false),
                        JuridicaAsociada_ID_Entidad = c.Int(),
                        ID_Direccion = c.Int(),
                        ID_Organizacion = c.Int(nullable: false),
                        Descripcion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_Entidad)
                .ForeignKey("dbo.entidadjuridica", t => t.JuridicaAsociada_ID_Entidad)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion, cascadeDelete: true)
                .Index(t => t.JuridicaAsociada_ID_Entidad)
                .Index(t => t.ID_Direccion)
                .Index(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.entidadjuridica",
                c => new
                    {
                        ID_Entidad = c.Int(nullable: false),
                        ID_Direccion = c.Int(),
                        ID_Organizacion = c.Int(nullable: false),
                        CodigoInscripcion = c.String(unicode: false),
                        CUIT = c.String(unicode: false),
                        RazonSocial = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_Entidad)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion, cascadeDelete: true)
                .Index(t => t.ID_Direccion)
                .Index(t => t.ID_Organizacion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.entidadjuridica", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.entidadjuridica", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.entidadbase", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.entidadbase", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.entidadbase", "JuridicaAsociada_ID_Entidad", "dbo.entidadjuridica");
            DropForeignKey("dbo.compra", "ID_OperacionDeEgreso", "dbo.operaciondeegreso");
            DropForeignKey("dbo.compra", "PersonaProveedora_ID_Proveedor", "dbo.personaproveedora");
            DropForeignKey("dbo.compra", "EntidadJuridicaProveedora_ID_Proveedor", "dbo.entidadjuridicaproveedora");
            DropForeignKey("dbo.presupuesto", "PersonaProveedora_ID_Proveedor", "dbo.personaproveedora");
            DropForeignKey("dbo.personaproveedora", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.presupuesto", "EntidadJuridicaProveedora_ID_Proveedor", "dbo.entidadjuridicaproveedora");
            DropForeignKey("dbo.entidadjuridicaproveedora", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.usuario", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.operaciondeingreso", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.operaciondeegreso", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.usuariosxcompra", "ID_Usuario", "dbo.usuario");
            DropForeignKey("dbo.usuariosxcompra", "ID_Compra", "dbo.compra");
            DropForeignKey("dbo.item", "Presupuesto_ID_Presupuesto", "dbo.presupuesto");
            DropForeignKey("dbo.documentocomercial", "Presupuesto_ID_Presupuesto", "dbo.presupuesto");
            DropForeignKey("dbo.presupuesto", "Compra_ID_TipoEgreso", "dbo.compra");
            DropForeignKey("dbo.item", "Compra_ID_TipoEgreso", "dbo.compra");
            DropForeignKey("dbo.operaciondeegreso", "MedioDePago_ID_MedioDePago", "dbo.mediodepago");
            DropForeignKey("dbo.mediodepago", "ID_Pais", "dbo.pais");
            DropForeignKey("dbo.provincia", "ID_Pais", "dbo.pais");
            DropForeignKey("dbo.ciudad", "ID_Provincia", "dbo.provincia");
            DropForeignKey("dbo.pais", "ID_Moneda", "dbo.moneda");
            DropForeignKey("dbo.operaciondeegreso", "IngresoAsociado_ID_Ingreso", "dbo.operaciondeingreso");
            DropForeignKey("dbo.documentocomercial", "OperacionDeEgreso_ID_OperacionDeEgreso", "dbo.operaciondeegreso");
            DropForeignKey("dbo.direccion", "Ciudad_ID_Ciudad", "dbo.ciudad");
            DropIndex("dbo.entidadjuridica", new[] { "ID_Organizacion" });
            DropIndex("dbo.entidadjuridica", new[] { "ID_Direccion" });
            DropIndex("dbo.entidadbase", new[] { "ID_Organizacion" });
            DropIndex("dbo.entidadbase", new[] { "ID_Direccion" });
            DropIndex("dbo.entidadbase", new[] { "JuridicaAsociada_ID_Entidad" });
            DropIndex("dbo.compra", new[] { "ID_OperacionDeEgreso" });
            DropIndex("dbo.compra", new[] { "PersonaProveedora_ID_Proveedor" });
            DropIndex("dbo.compra", new[] { "EntidadJuridicaProveedora_ID_Proveedor" });
            DropIndex("dbo.usuariosxcompra", new[] { "ID_Usuario" });
            DropIndex("dbo.usuariosxcompra", new[] { "ID_Compra" });
            DropIndex("dbo.personaproveedora", new[] { "ID_Direccion" });
            DropIndex("dbo.entidadjuridicaproveedora", new[] { "ID_Direccion" });
            DropIndex("dbo.presupuesto", new[] { "PersonaProveedora_ID_Proveedor" });
            DropIndex("dbo.presupuesto", new[] { "EntidadJuridicaProveedora_ID_Proveedor" });
            DropIndex("dbo.presupuesto", new[] { "Compra_ID_TipoEgreso" });
            DropIndex("dbo.item", new[] { "Presupuesto_ID_Presupuesto" });
            DropIndex("dbo.item", new[] { "Compra_ID_TipoEgreso" });
            DropIndex("dbo.usuario", new[] { "ID_Organizacion" });
            DropIndex("dbo.provincia", new[] { "ID_Pais" });
            DropIndex("dbo.pais", new[] { "ID_Moneda" });
            DropIndex("dbo.mediodepago", new[] { "ID_Pais" });
            DropIndex("dbo.operaciondeingreso", new[] { "ID_Organizacion" });
            DropIndex("dbo.operaciondeegreso", new[] { "MedioDePago_ID_MedioDePago" });
            DropIndex("dbo.operaciondeegreso", new[] { "IngresoAsociado_ID_Ingreso" });
            DropIndex("dbo.operaciondeegreso", new[] { "ID_Organizacion" });
            DropIndex("dbo.documentocomercial", new[] { "Presupuesto_ID_Presupuesto" });
            DropIndex("dbo.documentocomercial", new[] { "OperacionDeEgreso_ID_OperacionDeEgreso" });
            DropIndex("dbo.direccion", new[] { "Ciudad_ID_Ciudad" });
            DropIndex("dbo.ciudad", new[] { "ID_Provincia" });
            DropTable("dbo.entidadjuridica");
            DropTable("dbo.entidadbase");
            DropTable("dbo.compra");
            DropTable("dbo.usuariosxcompra");
            DropTable("dbo.personaproveedora");
            DropTable("dbo.entidadjuridicaproveedora");
            DropTable("dbo.presupuesto");
            DropTable("dbo.item");
            DropTable("dbo.usuario");
            DropTable("dbo.provincia");
            DropTable("dbo.moneda");
            DropTable("dbo.pais");
            DropTable("dbo.mediodepago");
            DropTable("dbo.operaciondeingreso");
            DropTable("dbo.operaciondeegreso");
            DropTable("dbo.organizacion");
            DropTable("dbo.documentocomercial");
            DropTable("dbo.direccion");
            DropTable("dbo.ciudad");
        }
    }
}
