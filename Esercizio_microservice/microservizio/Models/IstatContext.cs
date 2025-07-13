using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace microservizio.Models;

public partial class IstatContext : DbContext
{
    public IstatContext()
    {
    }

    public IstatContext(DbContextOptions<IstatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CodRegProv> CodRegProvs { get; set; }

    public virtual DbSet<Comune> Comunes { get; set; }

    public virtual DbSet<Comuni30012015> Comuni30012015s { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Regione> Regiones { get; set; }

    public virtual DbSet<RipartizioneGeografica> RipartizioneGeograficas { get; set; }

    public virtual DbSet<ZonaAltimetrica> ZonaAltimetricas { get; set; }

    public virtual DbSet<ZonaMontana> ZonaMontanas { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Istat;User ID=sa; Password=Its-2025;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CodRegProv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COD_REG_PROV");

            entity.Property(e => e.CodiceNuts1)
                .HasMaxLength(255)
                .HasColumnName("Codice NUTS1");
            entity.Property(e => e.CodiceNuts22006A)
                .HasMaxLength(255)
                .HasColumnName("Codice NUTS2 2006(a)");
            entity.Property(e => e.CodiceNuts32006)
                .HasMaxLength(255)
                .HasColumnName("Codice NUTS3 2006");
            entity.Property(e => e.CodiceProvincia)
                .HasMaxLength(255)
                .HasColumnName("Codice provincia");
            entity.Property(e => e.CodiceRegione)
                .HasMaxLength(255)
                .HasColumnName("Codice regione");
            entity.Property(e => e.CodiceRipartizione).HasColumnName("Codice ripartizione");
            entity.Property(e => e.DenominazioneProvincia)
                .HasMaxLength(255)
                .HasColumnName("Denominazione provincia");
            entity.Property(e => e.DenominazioneRegione)
                .HasMaxLength(255)
                .HasColumnName("Denominazione regione");
            entity.Property(e => e.DenominazioneRegioneMaisucolo)
                .HasMaxLength(255)
                .HasColumnName("Denominazione regione_(Maisucolo)");
            entity.Property(e => e.F13).HasMaxLength(255);
            entity.Property(e => e.F14).HasMaxLength(255);
            entity.Property(e => e.F15).HasMaxLength(255);
            entity.Property(e => e.RipartizioneGeografica)
                .HasMaxLength(255)
                .HasColumnName("Ripartizione geografica");
            entity.Property(e => e.RipartizioneGeograficaMaiuscolo)
                .HasMaxLength(255)
                .HasColumnName("Ripartizione geografica_(Maiuscolo)");
            entity.Property(e => e.SiglaAutomobilistica)
                .HasMaxLength(255)
                .HasColumnName("Sigla automobilistica");
        });

        modelBuilder.Entity<Comune>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comune__3214EC07918D1B4C");

            entity.ToTable("Comune");

            entity.Property(e => e.CodiceCatastale)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdZonaMontana)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Comunes)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comune_Provincia");

            entity.HasOne(d => d.IdZonaAltimetricaNavigation).WithMany(p => p.Comunes)
                .HasForeignKey(d => d.IdZonaAltimetrica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comune_ZonaAltimetrica");

            entity.HasOne(d => d.IdZonaMontanaNavigation).WithMany(p => p.Comunes)
                .HasForeignKey(d => d.IdZonaMontana)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comune_ZonaMontana");
        });

        modelBuilder.Entity<Comuni30012015>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COMUNI30012015");

            entity.Property(e => e.AltitudineDelCentroMetri).HasColumnName("Altitudine del centro (metri)");
            entity.Property(e => e.CodiceCatastale)
                .HasMaxLength(255)
                .HasColumnName("Codice Catastale ");
            entity.Property(e => e.CodiceCittàMetropolitana)
                .HasMaxLength(255)
                .HasColumnName("Codice Città Metropolitana");
            entity.Property(e => e.CodiceIstatDelComuneA103ProvinceFormatoNumerico).HasColumnName("Codice Istat del Comune a 103 province_(formato numerico)");
            entity.Property(e => e.CodiceIstatDelComuneA107ProvinceFormatoNumerico).HasColumnName("Codice Istat del Comune a 107 province_(formato numerico)");
            entity.Property(e => e.CodiceIstatDelComuneFormatoAlfanumerico).HasColumnName("Codice Istat del Comune _(formato alfanumerico)");
            entity.Property(e => e.CodiceIstatDelComuneFormatoNumerico).HasColumnName("Codice Istat del Comune _(formato numerico)");
            entity.Property(e => e.CodiceNuts22010)
                .HasMaxLength(255)
                .HasColumnName("Codice NUTS2 2010");
            entity.Property(e => e.CodiceNuts32010)
                .HasMaxLength(255)
                .HasColumnName("Codice NUTS3 2010");
            entity.Property(e => e.CodiceProvincia)
                .HasMaxLength(255)
                .HasColumnName("Codice Provincia");
            entity.Property(e => e.CodiceRegione)
                .HasMaxLength(255)
                .HasColumnName("Codice Regione");
            entity.Property(e => e.ComuneCapoluogoDiProvincia).HasColumnName("Comune capoluogo di provincia");
            entity.Property(e => e.ComuneLitoraneo).HasColumnName("Comune litoraneo");
            entity.Property(e => e.ComuneMontano)
                .HasMaxLength(255)
                .HasColumnName("Comune Montano");
            entity.Property(e => e.NumeroProgressivoComune)
                .HasMaxLength(255)
                .HasColumnName("Numero progressivo Comune");
            entity.Property(e => e.PopolazioneLegale200121102001).HasColumnName("Popolazione legale 2001 (21/10/2001)");
            entity.Property(e => e.PopolazioneLegale201109102011).HasColumnName("Popolazione legale 2011 (09/10/2011)");
            entity.Property(e => e.RipartizioneGeografica)
                .HasMaxLength(255)
                .HasColumnName("Ripartizione geografica");
            entity.Property(e => e.SoloDenominazioneInItaliano)
                .HasMaxLength(255)
                .HasColumnName("Solo denominazione in italiano");
            entity.Property(e => e.SoloDenominazioneInTedesco).HasColumnName("Solo denominazione in tedesco");
            entity.Property(e => e.SuperficieTerritorialeKmqAl09102011).HasColumnName("Superficie territoriale (kmq) al 09/10/2011");
            entity.Property(e => e.ZonaAltimetrica)
                .HasMaxLength(255)
                .HasColumnName("Zona altimetrica");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3214EC0762EBB50F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdRegioneNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdRegione)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_Regione");
        });

        modelBuilder.Entity<Regione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Regione__3214EC0790E9E202");

            entity.ToTable("Regione");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRipartizioneNavigation).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.IdRipartizione)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Regione_RipartizioneGeografica");
        });

        modelBuilder.Entity<RipartizioneGeografica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ripartiz__3214EC07FEC22120");

            entity.ToTable("RipartizioneGeografica");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZonaAltimetrica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZonaAlti__3214EC07358F1DA3");

            entity.ToTable("ZonaAltimetrica");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZonaMontana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZonaMont__3214EC07A6028124");

            entity.ToTable("ZonaMontana");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
