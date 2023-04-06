using Blog2.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog2.Data.Mappings 
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            // Chave Primaria
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // PRIMARY KEY IDENTITY (1,1)

             // Propriedades
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate") // DATETIME NOT NULL DEFAULT (GETDATE())
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");
            
            // Indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();

            // Relacionamentos
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>(
                "PostTag",
                post => post.HasOne<Tag>()
                 .WithMany()
                 .HasForeignKey("PostId")
                 .HasConstraintName("FK_PostTag_PostId")
                 .OnDelete(DeleteBehavior.Cascade),
                tag => tag.HasOne<Post>()
                  .WithMany()
                  .HasForeignKey("TagId")
                  .HasConstraintName("FK_PostTag_TagId")
                  .OnDelete(DeleteBehavior.Cascade));

        }
    }
}