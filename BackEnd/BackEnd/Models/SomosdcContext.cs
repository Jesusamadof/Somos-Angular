using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models;

public partial class SomosdcContext : DbContext
{
    public SomosdcContext()
    {
    }

    public SomosdcContext(DbContextOptions<SomosdcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBitacora> TblBitacoras { get; set; }

    public virtual DbSet<TblCaso> TblCasos { get; set; }

    public virtual DbSet<TblCondicionMigratorium> TblCondicionMigratoria { get; set; }

    public virtual DbSet<TblDepartamento> TblDepartamentos { get; set; }

    public virtual DbSet<TblDependiente> TblDependientes { get; set; }

    public virtual DbSet<TblDetDepenVictima> TblDetDepenVictimas { get; set; }

    public virtual DbSet<TblDetOrganVictima> TblDetOrganVictimas { get; set; }

    public virtual DbSet<TblDetallesSobreRelacion> TblDetallesSobreRelacions { get; set; }

    public virtual DbSet<TblEnlaceRecopDato> TblEnlaceRecopDatos { get; set; }

    public virtual DbSet<TblEtnium> TblEtnia { get; set; }

    public virtual DbSet<TblExpresionGenero> TblExpresionGeneros { get; set; }

    public virtual DbSet<TblFuenteDato> TblFuenteDatos { get; set; }

    public virtual DbSet<TblGeneradorHecho> TblGeneradorHechoes { get; set; }

    public virtual DbSet<TblGeneroVictima> TblGeneroVictimas { get; set; }

    public virtual DbSet<TblHecho> TblHechoes { get; set; }

    public virtual DbSet<TblLugarDomicilio> TblLugarDomicilios { get; set; }

    public virtual DbSet<TblLugarNacimiento> TblLugarNacimientos { get; set; }

    public virtual DbSet<TblModalidad> TblModalidads { get; set; }

    public virtual DbSet<TblMunicipio> TblMunicipios { get; set; }

    public virtual DbSet<TblNivelEducacion> TblNivelEducacions { get; set; }

    public virtual DbSet<TblObjeto> TblObjetos { get; set; }

    public virtual DbSet<TblOrganizacion> TblOrganizacions { get; set; }

    public virtual DbSet<TblOrientacionSexual> TblOrientacionSexuals { get; set; }

    public virtual DbSet<TblPermiso> TblPermisos { get; set; }

    public virtual DbSet<TblPersona> TblPersonas { get; set; }

    public virtual DbSet<TblPreguntaUsuario> TblPreguntaUsuarios { get; set; }

    public virtual DbSet<TblPreguntum> TblPregunta { get; set; }

    public virtual DbSet<TblReporteActual> TblReporteActuals { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblTipoRelacion> TblTipoRelacions { get; set; }

    public virtual DbSet<TblTipoReporte> TblTipoReportes { get; set; }

    public virtual DbSet<TblTipoVictima> TblTipoVictimas { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    public virtual DbSet<TblVictima> TblVictimas { get; set; }

    public virtual DbSet<VCaso> VCasos { get; set; }

    public virtual DbSet<VDetDependiente> VDetDependientes { get; set; }

    public virtual DbSet<VDetOrganizacione> VDetOrganizaciones { get; set; }

    public virtual DbSet<VPermiso> VPermisos { get; set; }

    public virtual DbSet<VPersona> VPersonas { get; set; }

    public virtual DbSet<VPreguntasUsuario> VPreguntasUsuarios { get; set; }

    public virtual DbSet<VUsuario> VUsuarios { get; set; }

    public virtual DbSet<VUsuarioLogin> VUsuarioLogins { get; set; }

    public virtual DbSet<VUsuarioRol> VUsuarioRols { get; set; }

    public virtual DbSet<VVictima> VVictimas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=somosdc;user=root;password=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TblBitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PRIMARY");

            entity.ToTable("tbl_bitacora");

            entity.HasIndex(e => e.IdUsuario, "fk_usuario_bitacora");

            entity.Property(e => e.IdBitacora).HasColumnName("id_bitacora");
            entity.Property(e => e.Evento)
                .HasMaxLength(100)
                .HasColumnName("evento");
            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Valor)
                .HasMaxLength(500)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblBitacoras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_usuario_bitacora");
        });

        modelBuilder.Entity<TblCaso>(entity =>
        {
            entity.HasKey(e => e.IdCaso).HasName("PRIMARY");

            entity.ToTable("tbl_caso");

            entity.HasIndex(e => e.IdOrientacion, "fk_caso_orientacion");

            entity.Property(e => e.IdCaso).HasColumnName("id_caso");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .HasColumnName("alias");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .HasColumnName("hora");
            entity.Property(e => e.IdOrientacion).HasColumnName("id_orientacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Lugar)
                .HasMaxLength(100)
                .HasColumnName("lugar");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .HasColumnName("nombre_genero");
            entity.Property(e => e.OtroNombre)
                .HasMaxLength(100)
                .HasColumnName("otro_nombre");

            entity.HasOne(d => d.IdOrientacionNavigation).WithMany(p => p.TblCasos)
                .HasForeignKey(d => d.IdOrientacion)
                .HasConstraintName("fk_caso_orientacion");
        });

        modelBuilder.Entity<TblCondicionMigratorium>(entity =>
        {
            entity.HasKey(e => e.IdCondicionMigratoria).HasName("PRIMARY");

            entity.ToTable("tbl_condicion_migratoria");

            entity.Property(e => e.IdCondicionMigratoria).HasColumnName("id_condicion_migratoria");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.NombreCondicion)
                .HasMaxLength(40)
                .HasColumnName("nombre_condicion");
        });

        modelBuilder.Entity<TblDepartamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PRIMARY");

            entity.ToTable("tbl_departamento");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.CodigoDepartamento)
                .HasMaxLength(2)
                .HasColumnName("codigo_departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(20)
                .HasColumnName("nombre_departamento");
        });

        modelBuilder.Entity<TblDependiente>(entity =>
        {
            entity.HasKey(e => e.IdDependiente).HasName("PRIMARY");

            entity.ToTable("tbl_dependiente");

            entity.Property(e => e.IdDependiente).HasColumnName("id_dependiente");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.TipoDependiente)
                .HasMaxLength(40)
                .HasColumnName("tipo_dependiente");
        });

        modelBuilder.Entity<TblDetDepenVictima>(entity =>
        {
            entity.HasKey(e => e.IdDetDepVictima).HasName("PRIMARY");

            entity.ToTable("tbl_det_depen_victima");

            entity.HasIndex(e => e.IdDependiente, "fk_det_depd_victima");

            entity.HasIndex(e => e.IdVictima, "fk_det_victima");

            entity.Property(e => e.IdDetDepVictima).HasColumnName("id_det_dep_victima");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdDependiente).HasColumnName("id_dependiente");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.IdVictima).HasColumnName("id_victima");

            entity.HasOne(d => d.IdDependienteNavigation).WithMany(p => p.TblDetDepenVictimas)
                .HasForeignKey(d => d.IdDependiente)
                .HasConstraintName("fk_det_depd_victima");

            entity.HasOne(d => d.IdVictimaNavigation).WithMany(p => p.TblDetDepenVictimas)
                .HasForeignKey(d => d.IdVictima)
                .HasConstraintName("fk_det_victima");
        });

        modelBuilder.Entity<TblDetOrganVictima>(entity =>
        {
            entity.HasKey(e => e.IdDetOrganVictima).HasName("PRIMARY");

            entity.ToTable("tbl_det_organ_victima");

            entity.HasIndex(e => e.IdVictima, "fk_det_org_victima");

            entity.HasIndex(e => e.IdOrganizacion, "fk_det_organiz");

            entity.Property(e => e.IdDetOrganVictima).HasColumnName("id_det_organ_victima");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.IdVictima).HasColumnName("id_victima");

            entity.HasOne(d => d.IdOrganizacionNavigation).WithMany(p => p.TblDetOrganVictimas)
                .HasForeignKey(d => d.IdOrganizacion)
                .HasConstraintName("fk_det_organiz");

            entity.HasOne(d => d.IdVictimaNavigation).WithMany(p => p.TblDetOrganVictimas)
                .HasForeignKey(d => d.IdVictima)
                .HasConstraintName("fk_det_org_victima");
        });

        modelBuilder.Entity<TblDetallesSobreRelacion>(entity =>
        {
            entity.HasKey(e => e.IdDetallesSobreRelacion).HasName("PRIMARY");

            entity.ToTable("tbl_detalles_sobre_relacion");

            entity.Property(e => e.IdDetallesSobreRelacion).HasColumnName("id_detalles_sobre_relacion");
            entity.Property(e => e.DescripcionDetallesRelacion)
                .HasMaxLength(100)
                .HasColumnName("descripcion_detalles_relacion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
        });

        modelBuilder.Entity<TblEnlaceRecopDato>(entity =>
        {
            entity.HasKey(e => e.IdEnlaceRecopDato).HasName("PRIMARY");

            entity.ToTable("tbl_enlace_recop_dato");

            entity.HasIndex(e => e.IdGeneradorHecho, "fk_tbl_generador_h_enlace_rep_dt");

            entity.Property(e => e.IdEnlaceRecopDato).HasColumnName("id_enlace_recop_dato");
            entity.Property(e => e.Archivo).HasColumnName("archivo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdGeneradorHecho).HasColumnName("id_generador_hecho");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .HasColumnName("tipo_archivo");

            entity.HasOne(d => d.IdGeneradorHechoNavigation).WithMany(p => p.TblEnlaceRecopDatos)
                .HasForeignKey(d => d.IdGeneradorHecho)
                .HasConstraintName("fk_tbl_generador_h_enlace_rep_dt");
        });

        modelBuilder.Entity<TblEtnium>(entity =>
        {
            entity.HasKey(e => e.IdEtnia).HasName("PRIMARY");

            entity.ToTable("tbl_etnia");

            entity.Property(e => e.IdEtnia).HasColumnName("id_etnia");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.NombreEtnia)
                .HasMaxLength(40)
                .HasColumnName("nombre_etnia");
        });

        modelBuilder.Entity<TblExpresionGenero>(entity =>
        {
            entity.HasKey(e => e.IdExpresionGenero).HasName("PRIMARY");

            entity.ToTable("tbl_expresion_genero");

            entity.Property(e => e.IdExpresionGenero).HasColumnName("id_expresion_genero");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.NombreExpresion)
                .HasMaxLength(40)
                .HasColumnName("nombre_expresion");
        });

        modelBuilder.Entity<TblFuenteDato>(entity =>
        {
            entity.HasKey(e => e.IdFuenteDato).HasName("PRIMARY");

            entity.ToTable("tbl_fuente_dato");

            entity.Property(e => e.IdFuenteDato).HasColumnName("id_fuente_dato");
            entity.Property(e => e.DescripcionFuente)
                .HasMaxLength(100)
                .HasColumnName("descripcion_fuente");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
        });

        modelBuilder.Entity<TblGeneradorHecho>(entity =>
        {
            entity.HasKey(e => e.IdGeneradorHecho).HasName("PRIMARY");

            entity.ToTable("tbl_generador_hecho");

            entity.HasIndex(e => e.IdFuenteDato, "fk_tbl_gen_h_fue_dt");

            entity.Property(e => e.IdGeneradorHecho).HasColumnName("id_generador_hecho");
            entity.Property(e => e.CargoDentroOrganizacion)
                .HasMaxLength(100)
                .HasColumnName("cargo_dentro_organizacion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaLlenadoDato).HasColumnName("fecha_llenado_dato");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdFuenteDato).HasColumnName("id_fuente_dato");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.IntitucionRecoDato)
                .HasMaxLength(100)
                .HasColumnName("intitucion_reco_dato");
            entity.Property(e => e.NombLlenadorDato)
                .HasMaxLength(50)
                .HasColumnName("nomb_llenador_dato");
            entity.Property(e => e.NombSupervisor)
                .HasMaxLength(500)
                .HasColumnName("nomb_supervisor");

            entity.HasOne(d => d.IdFuenteDatoNavigation).WithMany(p => p.TblGeneradorHechoes)
                .HasForeignKey(d => d.IdFuenteDato)
                .HasConstraintName("fk_tbl_gen_h_fue_dt");
        });

        modelBuilder.Entity<TblGeneroVictima>(entity =>
        {
            entity.HasKey(e => e.IdGeneroVictima).HasName("PRIMARY");

            entity.ToTable("tbl_genero_victima");

            entity.Property(e => e.IdGeneroVictima).HasColumnName("id_genero_victima");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.TipoGeneroVictima)
                .HasMaxLength(100)
                .HasColumnName("tipo_genero_victima");
        });

        modelBuilder.Entity<TblHecho>(entity =>
        {
            entity.HasKey(e => e.IdHecho).HasName("PRIMARY");

            entity.ToTable("tbl_hecho");

            entity.HasIndex(e => e.IdCaso, "fk_caso_hecho");

            entity.HasIndex(e => e.IdDetallesSobreRelacion, "fk_det_sob_relacion");

            entity.HasIndex(e => e.IdGeneradorHecho, "fk_generador_hecho");

            entity.HasIndex(e => e.IdGeneroVictima, "fk_genero_victima_hecho");

            entity.HasIndex(e => e.IdModalidad, "fk_modalidad_hecho");

            entity.HasIndex(e => e.IdTipoRelacion, "fk_tipo_relacion_hecho");

            entity.HasIndex(e => e.IdTipoVictima, "fk_tipo_victima_hecho");

            entity.Property(e => e.IdHecho).HasColumnName("id_hecho");
            entity.Property(e => e.AgresionSexual).HasColumnName("agresion_sexual");
            entity.Property(e => e.DenunciaPrevia).HasColumnName("denuncia_previa");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaHecho).HasColumnName("fecha_hecho");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.HoraHecho)
                .HasColumnType("time")
                .HasColumnName("hora_hecho");
            entity.Property(e => e.IdCaso).HasColumnName("id_caso");
            entity.Property(e => e.IdDetallesSobreRelacion).HasColumnName("id_detalles_sobre_relacion");
            entity.Property(e => e.IdGeneradorHecho).HasColumnName("id_generador_hecho");
            entity.Property(e => e.IdGeneroVictima).HasColumnName("id_genero_victima");
            entity.Property(e => e.IdModalidad).HasColumnName("id_modalidad");
            entity.Property(e => e.IdTipoRelacion).HasColumnName("id_tipo_relacion");
            entity.Property(e => e.IdTipoVictima).HasColumnName("id_tipo_victima");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.LugarHecho)
                .HasMaxLength(100)
                .HasColumnName("lugar_hecho");
            entity.Property(e => e.ProcesoJudicial).HasColumnName("proceso_judicial");

            entity.HasOne(d => d.IdCasoNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdCaso)
                .HasConstraintName("fk_caso_hecho");

            entity.HasOne(d => d.IdDetallesSobreRelacionNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdDetallesSobreRelacion)
                .HasConstraintName("fk_det_sob_relacion");

            entity.HasOne(d => d.IdGeneradorHechoNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdGeneradorHecho)
                .HasConstraintName("fk_generador_hecho");

            entity.HasOne(d => d.IdGeneroVictimaNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdGeneroVictima)
                .HasConstraintName("fk_genero_victima_hecho");

            entity.HasOne(d => d.IdModalidadNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdModalidad)
                .HasConstraintName("fk_modalidad_hecho");

            entity.HasOne(d => d.IdTipoRelacionNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdTipoRelacion)
                .HasConstraintName("fk_tipo_relacion_hecho");

            entity.HasOne(d => d.IdTipoVictimaNavigation).WithMany(p => p.TblHechoes)
                .HasForeignKey(d => d.IdTipoVictima)
                .HasConstraintName("fk_tipo_victima_hecho");
        });

        modelBuilder.Entity<TblLugarDomicilio>(entity =>
        {
            entity.HasKey(e => e.IdLugarDomicilio).HasName("PRIMARY");

            entity.ToTable("tbl_lugar_domicilio");

            entity.HasIndex(e => e.IdDepartamento, "fk_lug_dom_depart");

            entity.HasIndex(e => e.IdMunicipio, "fk_lug_dom_muni");

            entity.HasIndex(e => e.IdPersona, "fk_lug_domi_persona");

            entity.Property(e => e.IdLugarDomicilio).HasColumnName("id_lugar_domicilio");
            entity.Property(e => e.Aldea)
                .HasMaxLength(20)
                .HasColumnName("aldea");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(20)
                .HasColumnName("ciudad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.TblLugarDomicilios)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("fk_lug_dom_depart");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TblLugarDomicilios)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("fk_lug_dom_muni");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.TblLugarDomicilios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("fk_lug_domi_persona");
        });

        modelBuilder.Entity<TblLugarNacimiento>(entity =>
        {
            entity.HasKey(e => e.IdLugarNacimiento).HasName("PRIMARY");

            entity.ToTable("tbl_lugar_nacimiento");

            entity.HasIndex(e => e.IdDepartamento, "fk_lug_nac_depart");

            entity.HasIndex(e => e.IdMunicipio, "fk_lug_nac_muni");

            entity.HasIndex(e => e.IdPersona, "fk_lug_nac_persona");

            entity.Property(e => e.IdLugarNacimiento).HasColumnName("id_lugar_nacimiento");
            entity.Property(e => e.Aldea)
                .HasMaxLength(20)
                .HasColumnName("aldea");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(20)
                .HasColumnName("ciudad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.TblLugarNacimientos)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("fk_lug_nac_depart");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.TblLugarNacimientos)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("fk_lug_nac_muni");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.TblLugarNacimientos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("fk_lug_nac_persona");
        });

        modelBuilder.Entity<TblModalidad>(entity =>
        {
            entity.HasKey(e => e.IdModalidad).HasName("PRIMARY");

            entity.ToTable("tbl_modalidad");

            entity.Property(e => e.IdModalidad).HasColumnName("id_modalidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(100)
                .HasColumnName("modalidad");
        });

        modelBuilder.Entity<TblMunicipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PRIMARY");

            entity.ToTable("tbl_municipio");

            entity.HasIndex(e => e.IdDepartamento, "fk_munic_depart");

            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.CodigoMunicipio)
                .HasMaxLength(5)
                .HasColumnName("codigo_municipio");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(40)
                .HasColumnName("nombre_municipio");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.TblMunicipios)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("fk_munic_depart");
        });

        modelBuilder.Entity<TblNivelEducacion>(entity =>
        {
            entity.HasKey(e => e.IdNivelEduc).HasName("PRIMARY");

            entity.ToTable("tbl_nivel_educacion");

            entity.Property(e => e.IdNivelEduc).HasColumnName("id_nivel_educ");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.NombreNivel)
                .HasMaxLength(50)
                .HasColumnName("nombre_nivel");
        });

        modelBuilder.Entity<TblObjeto>(entity =>
        {
            entity.HasKey(e => e.IdObjeto).HasName("PRIMARY");

            entity.ToTable("tbl_objeto");

            entity.Property(e => e.IdObjeto).HasColumnName("id_objeto");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .HasColumnName("icono");
            entity.Property(e => e.IdObjetoPadre).HasColumnName("id_objeto_padre");
            entity.Property(e => e.NombreObjeto)
                .HasMaxLength(300)
                .HasColumnName("nombre_objeto");
            entity.Property(e => e.Ruta)
                .HasMaxLength(50)
                .HasColumnName("ruta");
        });

        modelBuilder.Entity<TblOrganizacion>(entity =>
        {
            entity.HasKey(e => e.IdOrganizacion).HasName("PRIMARY");

            entity.ToTable("tbl_organizacion");

            entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.NombreOrganizacion)
                .HasMaxLength(40)
                .HasColumnName("nombre_organizacion");
        });

        modelBuilder.Entity<TblOrientacionSexual>(entity =>
        {
            entity.HasKey(e => e.IdOrientacion).HasName("PRIMARY");

            entity.ToTable("tbl_orientacion_sexual");

            entity.Property(e => e.IdOrientacion).HasColumnName("id_orientacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Orientacion)
                .HasMaxLength(30)
                .HasColumnName("orientacion");
        });

        modelBuilder.Entity<TblPermiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PRIMARY");

            entity.ToTable("tbl_permiso");

            entity.HasIndex(e => e.IdObjeto, "fk_objeto_permiso");

            entity.HasIndex(e => e.IdRol, "fk_rol_permiso");

            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.Agregar).HasColumnName("agregar");
            entity.Property(e => e.Editar).HasColumnName("editar");
            entity.Property(e => e.Eliminar).HasColumnName("eliminar");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdObjeto).HasColumnName("id_objeto");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Reporte).HasColumnName("reporte");
            entity.Property(e => e.Ver).HasColumnName("ver");

            entity.HasOne(d => d.IdObjetoNavigation).WithMany(p => p.TblPermisos)
                .HasForeignKey(d => d.IdObjeto)
                .HasConstraintName("fk_objeto_permiso");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblPermisos)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_rol_permiso");
        });

        modelBuilder.Entity<TblPersona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PRIMARY");

            entity.ToTable("tbl_persona");

            entity.HasIndex(e => e.IdNivelEduc, "fk_persona_nivel_educ");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Agravantes)
                .HasMaxLength(300)
                .HasColumnName("agravantes");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoCivil)
                .HasColumnType("enum('Soltero/a','Casado/a','Unión libre o unión de hecho','Separado/a','Divorciado/a','Viudo/a.\\r\\n')")
                .HasColumnName("estado_civil");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdNivelEduc).HasColumnName("id_nivel_educ");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.NombreLegal)
                .HasMaxLength(100)
                .HasColumnName("nombre_legal");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdNivelEducNavigation).WithMany(p => p.TblPersonas)
                .HasForeignKey(d => d.IdNivelEduc)
                .HasConstraintName("fk_persona_nivel_educ");
        });

        modelBuilder.Entity<TblPreguntaUsuario>(entity =>
        {
            entity.HasKey(e => e.IdPreguntaUsuario).HasName("PRIMARY");

            entity.ToTable("tbl_pregunta_usuario");

            entity.HasIndex(e => e.IdPregunta, "fk_tbl_pregunta_prg_usu");

            entity.HasIndex(e => e.IdUsuario, "fk_tbl_usuario_prg_usu");

            entity.Property(e => e.IdPreguntaUsuario).HasColumnName("id_pregunta_usuario");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Respuesta)
                .HasMaxLength(100)
                .HasColumnName("respuesta");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.TblPreguntaUsuarios)
                .HasForeignKey(d => d.IdPregunta)
                .HasConstraintName("fk_tbl_pregunta_prg_usu");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblPreguntaUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_tbl_usuario_prg_usu");
        });

        modelBuilder.Entity<TblPreguntum>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PRIMARY");

            entity.ToTable("tbl_pregunta");

            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.Pregunta)
                .HasMaxLength(50)
                .HasColumnName("pregunta");
        });

        modelBuilder.Entity<TblReporteActual>(entity =>
        {
            entity.HasKey(e => e.IdReporteActual).HasName("PRIMARY");

            entity.ToTable("tbl_reporte_actual");

            entity.Property(e => e.IdReporteActual).HasColumnName("id_reporte_actual");
            entity.Property(e => e.DiligenciaRealizada)
                .HasMaxLength(70)
                .HasColumnName("diligencia_realizada");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.EstadoProceso)
                .HasColumnType("enum('Positivo','Negativo')")
                .HasColumnName("estado_proceso");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.InstitucionConsultada)
                .HasMaxLength(100)
                .HasColumnName("institucion_consultada");
            entity.Property(e => e.Lugar)
                .HasMaxLength(100)
                .HasColumnName("lugar");
            entity.Property(e => e.NombreAutoridadConsultada)
                .HasMaxLength(50)
                .HasColumnName("nombre_autoridad_consultada");
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("tbl_rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(30)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<TblTipoRelacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoRelacion).HasName("PRIMARY");

            entity.ToTable("tbl_tipo_relacion");

            entity.Property(e => e.IdTipoRelacion).HasColumnName("id_tipo_relacion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.TipoRelacion)
                .HasMaxLength(100)
                .HasColumnName("tipo_relacion");
        });

        modelBuilder.Entity<TblTipoReporte>(entity =>
        {
            entity.HasKey(e => e.IdTipoReporte).HasName("PRIMARY");

            entity.ToTable("tbl_tipo_reporte");

            entity.Property(e => e.IdTipoReporte).HasColumnName("id_tipo_reporte");
            entity.Property(e => e.Circular)
                .HasMaxLength(20)
                .HasColumnName("circular");
            entity.Property(e => e.Columnas)
                .HasMaxLength(20)
                .HasColumnName("columnas");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Lineal)
                .HasMaxLength(20)
                .HasColumnName("lineal");
        });

        modelBuilder.Entity<TblTipoVictima>(entity =>
        {
            entity.HasKey(e => e.IdTipoVictima).HasName("PRIMARY");

            entity.ToTable("tbl_tipo_victima");

            entity.Property(e => e.IdTipoVictima).HasColumnName("id_tipo_victima");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.TipoVictima)
                .HasMaxLength(100)
                .HasColumnName("tipo_victima");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("tbl_usuario");

            entity.HasIndex(e => e.IdRol, "fk_rol_usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.CambioContrasena).HasColumnName("cambio_contrasena");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(500)
                .HasColumnName("contrasena");
            entity.Property(e => e.ContrasenaSegura).HasColumnName("contrasena_segura");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_rol_usuario");
        });

        modelBuilder.Entity<TblVictima>(entity =>
        {
            entity.HasKey(e => e.IdVictima).HasName("PRIMARY");

            entity.ToTable("tbl_victima");

            entity.HasIndex(e => e.IdExpresionGenero, "fk_expresion_gen_victima");

            entity.HasIndex(e => e.IdGeneradorHecho, "fk_generador_victima");

            entity.HasIndex(e => e.IdGeneroVictima, "fk_vicitma_genero_vi");

            entity.HasIndex(e => e.IdOrientacion, "fk_vicitma_orient_sexual");

            entity.HasIndex(e => e.IdCondicionMigratoria, "fk_victi_cond_migratoria");

            entity.HasIndex(e => e.IdEtnia, "fk_victi_etnia");

            entity.HasIndex(e => e.IdPersona, "fk_victima_pers");

            entity.Property(e => e.IdVictima).HasColumnName("id_victima");
            entity.Property(e => e.CambioNomLegalVictima)
                .HasMaxLength(50)
                .HasColumnName("cambio_nom_legal_victima");
            entity.Property(e => e.CantHijos).HasColumnName("cant_hijos");
            entity.Property(e => e.CantHijosMay).HasColumnName("cant_hijos_may");
            entity.Property(e => e.CantHijosMen).HasColumnName("cant_hijos_men");
            entity.Property(e => e.CantPersDependiente).HasColumnName("cant_pers_dependiente");
            entity.Property(e => e.DenuciaPrevia).HasColumnName("denucia_previa");
            entity.Property(e => e.DiscapacidadVictima).HasColumnName("discapacidad_victima");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Hijos).HasColumnName("hijos");
            entity.Property(e => e.IdCondicionMigratoria).HasColumnName("id_condicion_migratoria");
            entity.Property(e => e.IdEtnia).HasColumnName("id_etnia");
            entity.Property(e => e.IdExpresionGenero).HasColumnName("id_expresion_genero");
            entity.Property(e => e.IdGeneradorHecho).HasColumnName("id_generador_hecho");
            entity.Property(e => e.IdGeneroVictima).HasColumnName("id_genero_victima");
            entity.Property(e => e.IdOrientacion).HasColumnName("id_orientacion");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.MedidasProteccion)
                .HasMaxLength(300)
                .HasColumnName("medidas_proteccion");
            entity.Property(e => e.NomInstiDenucia)
                .HasMaxLength(300)
                .HasColumnName("nom_insti_denucia");
            entity.Property(e => e.NombreIdentGenero)
                .HasMaxLength(100)
                .HasColumnName("nombre_ident_genero");
            entity.Property(e => e.NombreLegal)
                .HasMaxLength(50)
                .HasColumnName("nombre_legal");
            entity.Property(e => e.NumeroCaso).HasColumnName("numero_caso");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .HasColumnName("ocupacion");
            entity.Property(e => e.OtroNombres)
                .HasMaxLength(50)
                .HasColumnName("otro_nombres");
            entity.Property(e => e.PertenecienteOrganizacion).HasColumnName("perteneciente_organizacion");
            entity.Property(e => e.TipoDenucia)
                .HasMaxLength(300)
                .HasColumnName("tipo_denucia");
            entity.Property(e => e.TipoMedProteccion)
                .HasMaxLength(100)
                .HasColumnName("tipo_med_proteccion");

            entity.HasOne(d => d.IdCondicionMigratoriaNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdCondicionMigratoria)
                .HasConstraintName("fk_victi_cond_migratoria");

            entity.HasOne(d => d.IdEtniaNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdEtnia)
                .HasConstraintName("fk_victi_etnia");

            entity.HasOne(d => d.IdExpresionGeneroNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdExpresionGenero)
                .HasConstraintName("fk_expresion_gen_victima");

            entity.HasOne(d => d.IdGeneradorHechoNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdGeneradorHecho)
                .HasConstraintName("fk_generador_victima");

            entity.HasOne(d => d.IdGeneroVictimaNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdGeneroVictima)
                .HasConstraintName("fk_vicitma_genero_vi");

            entity.HasOne(d => d.IdOrientacionNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdOrientacion)
                .HasConstraintName("fk_vicitma_orient_sexual");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.TblVictimas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("fk_victima_pers");
        });

        modelBuilder.Entity<VCaso>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_casos");

            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .HasColumnName("alias");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .HasColumnName("hora");
            entity.Property(e => e.IdCaso).HasColumnName("id_caso");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdUsuarioModifico).HasColumnName("id_usuario_modifico");
            entity.Property(e => e.Lugar)
                .HasMaxLength(100)
                .HasColumnName("lugar");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .HasColumnName("nombre_genero");
            entity.Property(e => e.Orientacion)
                .HasMaxLength(30)
                .HasColumnName("orientacion");
            entity.Property(e => e.OtroNombre)
                .HasMaxLength(100)
                .HasColumnName("otro_nombre");
        });

        modelBuilder.Entity<VDetDependiente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_det_dependientes");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdDependiente).HasColumnName("id_dependiente");
            entity.Property(e => e.IdDetDepVictima).HasColumnName("id_det_dep_victima");
            entity.Property(e => e.IdVictima).HasColumnName("id_victima");
            entity.Property(e => e.TipoDependiente)
                .HasMaxLength(40)
                .HasColumnName("tipo_dependiente");
        });

        modelBuilder.Entity<VDetOrganizacione>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_det_organizaciones");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdDetOrganVictima).HasColumnName("id_det_organ_victima");
            entity.Property(e => e.IdOrganizacion).HasColumnName("id_organizacion");
            entity.Property(e => e.IdVictima).HasColumnName("id_victima");
            entity.Property(e => e.NombreOrganizacion)
                .HasMaxLength(40)
                .HasColumnName("nombre_organizacion");
        });

        modelBuilder.Entity<VPermiso>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_permisos");

            entity.Property(e => e.Agregar).HasColumnName("agregar");
            entity.Property(e => e.Editar).HasColumnName("editar");
            entity.Property(e => e.Eliminar).HasColumnName("eliminar");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.EstadoEliminacionObjeto).HasColumnName("estado_eliminacion_objeto");
            entity.Property(e => e.EstadoEliminacionPermiso).HasColumnName("estado_eliminacion_permiso");
            entity.Property(e => e.EstadoEliminacionRol).HasColumnName("estado_eliminacion_rol");
            entity.Property(e => e.EstadoObjeto).HasColumnName("estado_objeto");
            entity.Property(e => e.EstadoPermiso).HasColumnName("estado_permiso");
            entity.Property(e => e.EstadoRol).HasColumnName("estado_rol");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .HasColumnName("icono");
            entity.Property(e => e.IconoHijo)
                .HasMaxLength(30)
                .HasColumnName("icono_hijo");
            entity.Property(e => e.IconoPadre)
                .HasMaxLength(30)
                .HasColumnName("icono_padre");
            entity.Property(e => e.IdObjeto).HasColumnName("id_objeto");
            entity.Property(e => e.IdObjetoPadre).HasColumnName("id_objeto_padre");
            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreObjeto)
                .HasMaxLength(300)
                .HasColumnName("nombre_objeto");
            entity.Property(e => e.NombreObjetoPadre)
                .HasMaxLength(300)
                .HasColumnName("nombre_objeto_padre");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(30)
                .HasColumnName("nombre_rol");
            entity.Property(e => e.Reporte).HasColumnName("reporte");
            entity.Property(e => e.Ruta)
                .HasMaxLength(50)
                .HasColumnName("ruta");
            entity.Property(e => e.Ver).HasColumnName("ver");
        });

        modelBuilder.Entity<VPersona>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_personas");

            entity.Property(e => e.Agravantes)
                .HasMaxLength(300)
                .HasColumnName("agravantes");
            entity.Property(e => e.AldeaDom)
                .HasMaxLength(20)
                .HasColumnName("aldea_dom");
            entity.Property(e => e.AldeaNac)
                .HasMaxLength(20)
                .HasColumnName("aldea_nac");
            entity.Property(e => e.CiudadDom)
                .HasMaxLength(20)
                .HasColumnName("ciudad_dom");
            entity.Property(e => e.CiudadNac)
                .HasMaxLength(20)
                .HasColumnName("ciudad_nac");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoCivil)
                .HasColumnType("enum('Soltero/a','Casado/a','Unión libre o unión de hecho','Separado/a','Divorciado/a','Viudo/a.\\r\\n')")
                .HasColumnName("estado_civil");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdDepartamentoDom).HasColumnName("id_departamento_dom");
            entity.Property(e => e.IdDepartamentoNac).HasColumnName("id_departamento_nac");
            entity.Property(e => e.IdLugarDomicilio).HasColumnName("id_lugar_domicilio");
            entity.Property(e => e.IdLugarNacimiento).HasColumnName("id_lugar_nacimiento");
            entity.Property(e => e.IdMunicipioDom).HasColumnName("id_municipio_dom");
            entity.Property(e => e.IdMunicipioNac).HasColumnName("id_municipio_nac");
            entity.Property(e => e.IdNivelEduc).HasColumnName("id_nivel_educ");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.NombreDepartamentoDom)
                .HasMaxLength(20)
                .HasColumnName("nombre_departamento_dom");
            entity.Property(e => e.NombreDepartamentoNac)
                .HasMaxLength(20)
                .HasColumnName("nombre_departamento_nac");
            entity.Property(e => e.NombreLegal)
                .HasMaxLength(100)
                .HasColumnName("nombre_legal");
            entity.Property(e => e.NombreMunicipioDom)
                .HasMaxLength(40)
                .HasColumnName("nombre_municipio_dom");
            entity.Property(e => e.NombreMunicipioNac)
                .HasMaxLength(40)
                .HasColumnName("nombre_municipio_nac");
            entity.Property(e => e.NombreNivel)
                .HasMaxLength(50)
                .HasColumnName("nombre_nivel");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<VPreguntasUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_preguntas_usuario");

            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.IdPreguntaUsuario).HasColumnName("id_pregunta_usuario");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Pregunta)
                .HasMaxLength(50)
                .HasColumnName("pregunta");
            entity.Property(e => e.Respuesta)
                .HasMaxLength(100)
                .HasColumnName("respuesta");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<VUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_usuarios");

            entity.Property(e => e.CambioContrasena).HasColumnName("cambio_contrasena");
            entity.Property(e => e.ContrasenaSegura).HasColumnName("contrasena_segura");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<VUsuarioLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_usuario_login");

            entity.Property(e => e.CambioContrasena).HasColumnName("cambio_contrasena");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(500)
                .HasColumnName("contrasena");
            entity.Property(e => e.ContrasenaSegura).HasColumnName("contrasena_segura");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<VUsuarioRol>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_usuario_rol");

            entity.Property(e => e.CambioContrasena).HasColumnName("cambio_contrasena");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(500)
                .HasColumnName("contrasena");
            entity.Property(e => e.ContrasenaSegura).HasColumnName("contrasena_segura");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.EstadoEliminacionRol).HasColumnName("estado_eliminacion_rol");
            entity.Property(e => e.EstadoRol).HasColumnName("estado_rol");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(30)
                .HasColumnName("nombre_rol");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<VVictima>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_victimas");

            entity.Property(e => e.CambioNomLegalVictima)
                .HasMaxLength(50)
                .HasColumnName("cambio_nom_legal_victima");
            entity.Property(e => e.CantHijos).HasColumnName("cant_hijos");
            entity.Property(e => e.CantHijosMay).HasColumnName("cant_hijos_may");
            entity.Property(e => e.CantHijosMen).HasColumnName("cant_hijos_men");
            entity.Property(e => e.CantPersDependiente).HasColumnName("cant_pers_dependiente");
            entity.Property(e => e.DenuciaPrevia).HasColumnName("denucia_previa");
            entity.Property(e => e.DiscapacidadVictima).HasColumnName("discapacidad_victima");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.EstadoEliminacion).HasColumnName("estado_eliminacion");
            entity.Property(e => e.Hijos).HasColumnName("hijos");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdUsuarioCreo).HasColumnName("id_usuario_creo");
            entity.Property(e => e.IdVictima).HasColumnName("id_victima");
            entity.Property(e => e.MedidasProteccion)
                .HasMaxLength(300)
                .HasColumnName("medidas_proteccion");
            entity.Property(e => e.NomInstiDenucia)
                .HasMaxLength(300)
                .HasColumnName("nom_insti_denucia");
            entity.Property(e => e.NombLlenadorDato)
                .HasMaxLength(50)
                .HasColumnName("nomb_llenador_dato");
            entity.Property(e => e.NombreCondicion)
                .HasMaxLength(40)
                .HasColumnName("nombre_condicion");
            entity.Property(e => e.NombreEtnia)
                .HasMaxLength(40)
                .HasColumnName("nombre_etnia");
            entity.Property(e => e.NombreExpresion)
                .HasMaxLength(40)
                .HasColumnName("nombre_expresion");
            entity.Property(e => e.NombreIdentGenero)
                .HasMaxLength(100)
                .HasColumnName("nombre_ident_genero");
            entity.Property(e => e.NombreLegalPersona)
                .HasMaxLength(100)
                .HasColumnName("nombre_legal_persona");
            entity.Property(e => e.NombreLegalVictima)
                .HasMaxLength(50)
                .HasColumnName("nombre_legal_victima");
            entity.Property(e => e.NumeroCaso).HasColumnName("numero_caso");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .HasColumnName("ocupacion");
            entity.Property(e => e.Orientacion)
                .HasMaxLength(30)
                .HasColumnName("orientacion");
            entity.Property(e => e.OtroNombres)
                .HasMaxLength(50)
                .HasColumnName("otro_nombres");
            entity.Property(e => e.PertenecienteOrganizacion).HasColumnName("perteneciente_organizacion");
            entity.Property(e => e.TipoDenucia)
                .HasMaxLength(300)
                .HasColumnName("tipo_denucia");
            entity.Property(e => e.TipoGeneroVictima)
                .HasMaxLength(100)
                .HasColumnName("tipo_genero_victima");
            entity.Property(e => e.TipoMedProteccion)
                .HasMaxLength(100)
                .HasColumnName("tipo_med_proteccion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
