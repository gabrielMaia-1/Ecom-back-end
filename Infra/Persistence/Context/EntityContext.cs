using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Common.Entities;

#nullable disable

namespace Infra.Persistence.Context
{
    public partial class EntityContext : DbContext
    {
        public EntityContext()
        {
        }

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Equipe> Equipe { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoProduto> PedidoProduto { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VFatoPedidos> VPedidos { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade", "cad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cad.sq_cidade'::regclass)");

                entity.Property(e => e.EstadoId).HasColumnName("estado_id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_estado");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco", "cad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cad.sq_endereco'::regclass)");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.Property(e => e.CidadeId).HasColumnName("cidade_id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.CidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cidade");
            });

            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.ToTable("equipe", "staff");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('staff.sq_equipe'::regclass)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                entity.Property(e => e.VeiculoId).HasColumnName("veiculo_id");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.Equipe)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veiculo");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado", "cad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cad.sq_estado'::regclass)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("uf");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedido", "ped");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('ped.sq_pedido'::regclass)");

                entity.Property(e => e.DataEntrega).HasColumnName("data_entrega");

                entity.Property(e => e.DataInclusao)
                    .HasColumnName("data_inclusao")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_endereco");
            });

            modelBuilder.Entity<PedidoProduto>(entity =>
            {
                entity.HasKey(e => new { e.IdPedido, e.IdProduto })
                    .HasName("pedido_produto_pkey");

                entity.ToTable("pedido_produto", "ped");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto", "cad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cad.sq_produto'::regclass)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario", "cad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cad.usuario'::regclass)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("username");
            });

            modelBuilder.Entity<VFatoPedidos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_fato_pedidos", "ped");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasColumnType("character varying")
                    .HasColumnName("cidade");

                entity.Property(e => e.CidadeId).HasColumnName("cidade_id");

                entity.Property(e => e.DataEntrega).HasColumnName("data_entrega");

                entity.Property(e => e.DataInclusao).HasColumnName("data_inclusao");

                entity.Property(e => e.DescricaoProduto)
                    .HasColumnType("character varying")
                    .HasColumnName("descricao_produto");

                entity.Property(e => e.Endereco)
                    .HasColumnType("character varying")
                    .HasColumnName("endereco");

                entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

                entity.Property(e => e.Estado)
                    .HasColumnType("character varying")
                    .HasColumnName("estado");

                entity.Property(e => e.EstadoId).HasColumnName("estado_id");

                entity.Property(e => e.PedidoId).HasColumnName("pedido_id");

                entity.Property(e => e.Produto)
                    .HasColumnType("character varying")
                    .HasColumnName("produto");

                entity.Property(e => e.ProdutoId).HasColumnName("produto_id");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("uf");

                entity.Property(e => e.ValorProduto).HasColumnName("valor_produto");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("veiculo", "cad");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('cad.sq_veiculo'::regclass)");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("placa");
            });

            modelBuilder.HasSequence("sq_cidade", "cad");

            modelBuilder.HasSequence("sq_endereco", "cad");

            modelBuilder.HasSequence("sq_equipe", "staff");

            modelBuilder.HasSequence("sq_estado", "cad");

            modelBuilder.HasSequence("sq_pedido", "ped");

            modelBuilder.HasSequence("sq_produto", "cad");

            modelBuilder.HasSequence("sq_veiculo", "cad");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
