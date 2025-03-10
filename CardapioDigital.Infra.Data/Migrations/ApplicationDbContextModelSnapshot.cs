﻿// <auto-generated />
using System;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CardapioDigital.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CardapioDigital.Domain.Entities.AtendimentoPedidoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int>("QtdPessoasDivisao")
                        .HasColumnType("int")
                        .HasColumnName("qtd_pessoas_divisao");

                    b.Property<int>("RestauranteMesaAtendimentoId")
                        .HasColumnType("int")
                        .HasColumnName("restaurante_mesa_atendimento_id");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("int")
                        .HasColumnName("status_pedido");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ItemId");

                    b.HasIndex("RestauranteMesaAtendimentoId");

                    b.ToTable("ATENDIMENTO_PEDIDO_CLIENTE");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.AtendimentoPedidoClienteCompartilhado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtendimentoPedidoClienteId")
                        .HasColumnType("int")
                        .HasColumnName("atendimento_pedido_cliente_id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.HasKey("Id");

                    b.HasIndex("AtendimentoPedidoClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ATENDIMENTO_PEDIDO_CLIENTE_COMPARTILHADO");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("contato")
                        .IsFixedLength();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .HasColumnName("cpf")
                        .IsFixedLength();

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<int>("StatusAdimplencia")
                        .HasColumnType("int")
                        .HasColumnName("status_adimplencia");

                    b.HasKey("Id");

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<int>("Excluido")
                        .HasColumnType("int")
                        .HasColumnName("excluido");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("password_salt");

                    b.HasKey("Id");

                    b.ToTable("RESTAURANTE");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteItemCardapio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("descricao");

                    b.Property<int>("Disponivel")
                        .HasColumnType("int")
                        .HasColumnName("disponivel");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("money")
                        .HasColumnName("preco");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int")
                        .HasColumnName("restaurante_id");

                    b.Property<int>("ServeQtdPessoas")
                        .HasColumnType("int")
                        .HasColumnName("serve_qtd_pessoas");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("RESTAURANTE_ITEM_CARDAPIO");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroMesa")
                        .HasColumnType("int")
                        .HasColumnName("numero_mesa");

                    b.Property<int>("RestauranteId")
                        .HasColumnType("int")
                        .HasColumnName("restaurante_id");

                    b.Property<int>("StatusMesa")
                        .HasColumnType("int")
                        .HasColumnName("status_mesa");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("RESTAURANTE_MESA");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesaAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataHoraFim")
                        .HasColumnType("datetime")
                        .HasColumnName("data_hora_fim");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("data_hora_inicio");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("int")
                        .HasColumnName("qtd_pessoas");

                    b.Property<int>("RestauranteMesaId")
                        .HasColumnType("int")
                        .HasColumnName("restaurante_mesa_id");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("int")
                        .HasColumnName("status_atendimento");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("money")
                        .HasColumnName("valor_total");

                    b.Property<decimal?>("ValorTotalPago")
                        .HasColumnType("money")
                        .HasColumnName("valor_total_pago");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteMesaId");

                    b.ToTable("RESTAURANTE_MESA_ATENDIMENTO");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesaAtendimentoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataHoraAbertura")
                        .HasColumnType("datetime")
                        .HasColumnName("data_hora_abertura");

                    b.Property<DateTime?>("DataHoraFechamento")
                        .HasColumnType("datetime")
                        .HasColumnName("data_hora_fechamento");

                    b.Property<int>("RestauranteMesaAtendimentoId")
                        .HasColumnType("int")
                        .HasColumnName("restaurante_mesa_atendimento_id");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int")
                        .HasColumnName("status_pagamento");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("money")
                        .HasColumnName("valor_total");

                    b.Property<decimal?>("ValorTotalPago")
                        .HasColumnType("money")
                        .HasColumnName("valor_total_pago");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("RestauranteMesaAtendimentoId");

                    b.ToTable("RESTAURANTE_MESA_ATENDIMENTO_CLIENTE");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("texto");

                    b.HasKey("Id");

                    b.ToTable("TAG");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.TagItemCardapio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("TagId");

                    b.ToTable("TAG_ITEM_CARDAPIO");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.AtendimentoPedidoCliente", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.Cliente", "Cliente")
                        .WithMany("AtendimentoPedidoClientes")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_CLIENTE");

                    b.HasOne("CardapioDigital.Domain.Entities.RestauranteItemCardapio", "Item")
                        .WithMany("AtendimentoPedidoClientes")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO");

                    b.HasOne("CardapioDigital.Domain.Entities.RestauranteMesaAtendimento", "RestauranteMesaAtendimento")
                        .WithMany("AtendimentoPedidoClientes")
                        .HasForeignKey("RestauranteMesaAtendimentoId")
                        .IsRequired()
                        .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO1");

                    b.Navigation("Cliente");

                    b.Navigation("Item");

                    b.Navigation("RestauranteMesaAtendimento");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.AtendimentoPedidoClienteCompartilhado", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.AtendimentoPedidoCliente", "AtendimentoPedidoCliente")
                        .WithMany("AtendimentoPedidoClienteCompartilhados")
                        .HasForeignKey("AtendimentoPedidoClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_COMPARTILHADO_ATENDIMENTO_PEDIDO_CLIENTE1");

                    b.HasOne("CardapioDigital.Domain.Entities.Cliente", "Cliente")
                        .WithMany("AtendimentoPedidoClienteCompartilhados")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_COMPARTILHADO_ATENDIMENTO_PEDIDO_CLIENTE");

                    b.Navigation("AtendimentoPedidoCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteItemCardapio", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.Restaurante", "Restaurante")
                        .WithMany("RestauranteItemCardapios")
                        .HasForeignKey("RestauranteId")
                        .IsRequired()
                        .HasConstraintName("FK_RESTAURANTE_ITEM_CARDAPIO_RESTAURANTE_ITEM_CARDAPIO");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesa", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.Restaurante", "Restaurante")
                        .WithMany("RestauranteMesas")
                        .HasForeignKey("RestauranteId")
                        .IsRequired()
                        .HasConstraintName("FK_RESTAURANTE_MESA_RESTAURANTE");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesaAtendimento", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.RestauranteMesa", "RestauranteMesa")
                        .WithMany("RestauranteMesaAtendimentos")
                        .HasForeignKey("RestauranteMesaId")
                        .IsRequired()
                        .HasConstraintName("FK_RESTAURANTE_MESA_ATENDIMENTO_RESTAURANTE_MESA");

                    b.Navigation("RestauranteMesa");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesaAtendimentoCliente", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.Cliente", "Cliente")
                        .WithMany("RestauranteMesaAtendimentoClientes")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_RESTAURANTE_MESA_ATENDIMENTO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO");

                    b.HasOne("CardapioDigital.Domain.Entities.RestauranteMesaAtendimento", "RestauranteMesaAtendimento")
                        .WithMany("RestauranteMesaAtendimentoClientes")
                        .HasForeignKey("RestauranteMesaAtendimentoId")
                        .IsRequired()
                        .HasConstraintName("FK_RESTAURANTE_MESA_ATENDIMENTO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO1");

                    b.Navigation("Cliente");

                    b.Navigation("RestauranteMesaAtendimento");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.TagItemCardapio", b =>
                {
                    b.HasOne("CardapioDigital.Domain.Entities.RestauranteItemCardapio", "Item")
                        .WithMany("TagItemCardapios")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardapioDigital.Domain.Entities.Tag", "Tag")
                        .WithMany("TagItemCardapios")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.AtendimentoPedidoCliente", b =>
                {
                    b.Navigation("AtendimentoPedidoClienteCompartilhados");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("AtendimentoPedidoClienteCompartilhados");

                    b.Navigation("AtendimentoPedidoClientes");

                    b.Navigation("RestauranteMesaAtendimentoClientes");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.Restaurante", b =>
                {
                    b.Navigation("RestauranteItemCardapios");

                    b.Navigation("RestauranteMesas");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteItemCardapio", b =>
                {
                    b.Navigation("AtendimentoPedidoClientes");

                    b.Navigation("TagItemCardapios");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesa", b =>
                {
                    b.Navigation("RestauranteMesaAtendimentos");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.RestauranteMesaAtendimento", b =>
                {
                    b.Navigation("AtendimentoPedidoClientes");

                    b.Navigation("RestauranteMesaAtendimentoClientes");
                });

            modelBuilder.Entity("CardapioDigital.Domain.Entities.Tag", b =>
                {
                    b.Navigation("TagItemCardapios");
                });
#pragma warning restore 612, 618
        }
    }
}
