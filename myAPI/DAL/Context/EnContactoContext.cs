using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class EnContactoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Subscribition> Subscribitions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<CanceledInvitation> CanceledInvitations { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<LikedEntity> LikedEntities { get; set; }
        public DbSet<CommentedEntity> CommentedEntities { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentMedia> CommentMedias { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserAudio> UserAudios { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<UserVideo> UserVideos { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<Visibility> Visibilities { get; set; }

        //public DbSet<Ava> Avas { get; set; }
        public EnContactoContext(DbContextOptions options) : base (options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CanceledInvitation>().HasKey(k => new { k.FromUserId, k.ToUserId });
            builder.Entity<CanceledInvitation>()
               .HasOne(inv => inv.FromUser)
               .WithMany(user => user.CanceledInvitationsFromMe)
               .HasForeignKey(inv => inv.FromUserId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<CanceledInvitation>()
              .HasOne(inv => inv.ToUser)
              .WithMany(user => user.CanceledInvitationsToMe)
              .HasForeignKey(inv => inv.ToUserId);



            builder.Entity<Invitation>().HasKey(k => new { k.FromUserId, k.ToUserId });
            builder.Entity<Invitation>()
              .HasOne(inv => inv.FromUser)
              .WithMany(user => user.InvitationsFromMe)
              .HasForeignKey(inv => inv.FromUserId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Invitation>()
             .HasOne(inv => inv.ToUser)
             .WithMany(user => user.InvitationsToMe)
             .HasForeignKey(inv => inv.ToUserId);
             


            builder.Entity<Friendship>().HasKey(k => new { k.FirstUserId, k.SecondUserId });
            builder.Entity<Friendship>()
            .HasOne(f => f.FirstUser)
            .WithMany(user => user.FriendsSecond)
            .HasForeignKey(f => f.FirstUserId);
            builder.Entity<Friendship>()
            .HasOne(f => f.SecondUser)
            .WithMany(user => user.FriendsFirst)
            .HasForeignKey(f => f.SecondUserId)
            .OnDelete(DeleteBehavior.Restrict);




            builder.Entity<Membership>().HasKey(k => new { k.UserId, k.CommunityId });
            builder.Entity<Membership>()
                .HasOne(m => m.User)
                .WithMany(u => u.Memberships)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subscribition>().HasKey(k => new { k.SubscriberId, k.CommunityId });
            builder.Entity<Subscribition>()
                .HasOne(s => s.Subscriber)
                .WithMany(u => u.Subscribitions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LikedEntity>().HasKey(k => new { k.UserId, k.EntityId });

            builder.Entity<CommentedEntity>().HasKey(k => new { k.CommentId, k.EntityId });
            builder.Entity<CommentedEntity>()
                .HasOne(e => e.User)
                .WithMany(u => u.CommentedEntities)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<User>()
            //.HasOne(u => u.UserInfo).WithOne(p => p.User)
            //.HasForeignKey<UserInfo>(up => up.UserInfoId);

            //builder.Entity<User>()
            //.HasOne(u => u.UserAva).WithOne(p => p.AvaUser)
            //.HasForeignKey<UserPhoto>(up => up.AvaUserId);

           // builder.Entity<Ava>()
           //.HasOne(f => f.User)
           //.WithOne(user => user.Ava)
           //.OnDelete(DeleteBehavior.Restrict);

           // builder.Entity<Ava>()
           // .HasOne(f => f.UserPhoto)
           // .WithOne()
           // .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<Answer>()
            .HasOne(p => p.FromUser)
            .WithMany(t => t.AnswersFromUser)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserAudio>()
                .HasOne(a => a.Visibility)
                .WithMany(v => v.UserAudios)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserDocument>()
                .HasOne(d => d.Visibility)
                .WithMany(v => v.UserDocuments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserPhoto>()
                .HasOne(p => p.Visibility)
                .WithMany(v => v.UserPhotos)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserVideo>()
                .HasOne(vid => vid.Visibility)
                .WithMany(v => v.UserVideos)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<User>().ToTable("Users");
            // builder.Entity<UserInfo>().ToTable("Users");
            //builder.Entity<User>()
            //    .HasOne<UserPhoto>(u => u.UserAva)
            //    .WithOne(p => p.AvaUser)
            //    .HasForeignKey<UserPhoto>(p => p.AvaUserId)
            //    .HasForeignKey<User>(u => u.AvaId);

            //builder.Entity<Community>()
            //    .HasOne(c => c.Ava)
            //    .WithOne(p => p.AvaCommunity)
            //    .HasForeignKey<UserPhoto>(p => p.AvaCommunityId)
            //    .HasForeignKey<Community>(c => c.AvaId);

            base.OnModelCreating(builder);
            //builder.Entity<User>().HasMany(x => x.Friends);

            //Gender female = new Gender()
            //{
            //    GenderId = 1,
            //    GenderName = "mujer"
            //};
            //Gender male = new Gender()
            //{
            //    GenderId = 2,
            //    GenderName = "hombre"
            //};
            //Gender hermaphrodite = new Gender()
            //{
            //    GenderId = 3,
            //    GenderName = "hermafrodita"
            //};
            //builder.Entity<Gender>().HasData(female, male, hermaphrodite);
            //User user = new User()
            //{
            //    UserId = 1,
            //    Name = "Margarita",
            //    Status = "Estoy soltera",
            //    CityCurrent = "Kiev",
            //    CountryCurrent = "Ukraine",
            //    Birthday = new DateTime(2003, 6, 9),
            //    GenderId = 1,
            //     Additional = "Yo quisiera transladar a España pero mi familia no esta lista",
            //    City = "Dnipropetrovsc",
            //    Country = "Ukraine",
            //    Email = "reva.marhatyta@gmail.com",
            //    StudyPlace = "universidad de avion",
            //    WorkPlace = "trabajo en la tienda antes las clases",
            //    Phone = "067-324-74-02"
            //};
            // builder.Entity<User>().HasData(user);

        }
    }
}
