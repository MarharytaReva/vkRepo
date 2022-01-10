using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
       
        public string Password { get; set; }
        public string Login { get; set; }



        [InverseProperty("User")]
        public List<UserAudio> UserAudios { get; set; }
        [InverseProperty("User")]
        public List<UserPhoto> UserPhotos { get; set; }
        [InverseProperty("User")]
        public List<UserVideo> UserVideos { get; set; }
        [InverseProperty("User")]
        public List<UserDocument> UserDocuments { get; set; }


        [InverseProperty("User")]
        public List<Post> Posts { get; set; }


       
        public List<Friendship> FriendsFirst { get; set; }
       
        public List<Friendship> FriendsSecond { get; set; }


        public List<Invitation> InvitationsFromMe { get; set; }
        public List<Invitation> InvitationsToMe { get; set; }

        public List<CanceledInvitation> CanceledInvitationsFromMe { get; set; }
        public List<CanceledInvitation> CanceledInvitationsToMe { get; set; }

        [ForeignKey("UserInfo")]
        public int? UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }


        [ForeignKey("Ava")]
        public int? AvaId { get; set; }
        public UserPhoto Ava { get; set; }
       
        [InverseProperty("User")]
        public List<CommentedEntity> CommentedEntities { get; set; }

        [InverseProperty("User")]
        public List<LikedEntity> LikedEntities { get; set; }

        [InverseProperty("User")]
        public List<Comment> Comments { get; set; }


        [InverseProperty("User")]
        public List<Membership> Memberships { get; set; }

        [InverseProperty("Subscriber")]
        public List<Subscribition> Subscribitions { get; set; }

        [InverseProperty("Creator")]
        public List<Community> CreatedCommunities { get; set; }






        [InverseProperty("ToUser")]
        public List<Answer> AnswersToUser { get; set; }

        [InverseProperty("FromUser")]
        public List<Answer> AnswersFromUser { get; set; }
       
    }
}
