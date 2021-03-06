// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using devTalksWPF.Classes;

namespace devTalksWPF.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechnoTopic", b =>
                {
                    b.Property<int>("TechnosId")
                        .HasColumnType("int");

                    b.Property<int>("Topics_idId")
                        .HasColumnType("int");

                    b.HasKey("TechnosId", "Topics_idId");

                    b.HasIndex("Topics_idId");

                    b.ToTable("TechnoTopic");
                });

            modelBuilder.Entity("devTalksWPF.Classes.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_topic")
                        .HasColumnType("int");

                    b.Property<int>("Id_user")
                        .HasColumnType("int");

                    b.Property<int>("StateMessage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_topic");

                    b.HasIndex("Id_user");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("devTalksWPF.Classes.Techno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Technos");
                });

            modelBuilder.Entity("devTalksWPF.Classes.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateTopic")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("devTalksWPF.Classes.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLogged")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TechnoTopic", b =>
                {
                    b.HasOne("devTalksWPF.Classes.Techno", null)
                        .WithMany()
                        .HasForeignKey("TechnosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devTalksWPF.Classes.Topic", null)
                        .WithMany()
                        .HasForeignKey("Topics_idId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("devTalksWPF.Classes.Message", b =>
                {
                    b.HasOne("devTalksWPF.Classes.Topic", "topic")
                        .WithMany("Responses")
                        .HasForeignKey("Id_topic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devTalksWPF.Classes.User", "user")
                        .WithMany()
                        .HasForeignKey("Id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("topic");

                    b.Navigation("user");
                });

            modelBuilder.Entity("devTalksWPF.Classes.Topic", b =>
                {
                    b.HasOne("devTalksWPF.Classes.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("devTalksWPF.Classes.Topic", b =>
                {
                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
