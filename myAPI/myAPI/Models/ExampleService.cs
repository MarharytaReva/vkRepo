using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myAPI.Models
{
    public static class ExampleService
    {
        public static void FillDb(EnContactoContext context)
        {
            if(!context.Users.Any())
            {
                Visibility visibility = new Visibility()
                { 
                     Name = "some visibility"
                };

                List<UserPhoto> photos = new List<UserPhoto>()
                { 
                    new UserPhoto()
                    {
                          Directory = "Photos",
                          FileName = "file name 1",
                          Visibility = visibility,
                          Extension = "jpg",
                          LineNumber = 1
                    },
                    new UserPhoto()
                    {
                          Directory = "Photos",
                          FileName = "file name 2",
                          Visibility = visibility,
                          Extension = "jpg",
                          LineNumber = 1
                    },
                    new UserPhoto()
                    {
                          Directory = "Photos",
                          FileName = "file name 3",
                          Visibility = visibility,
                          Extension = "jpg",
                          LineNumber = 1
                    },
                    new UserPhoto()
                    {
                          Directory = "Photos",
                          FileName = "file name 4",
                          Visibility = visibility,
                          Extension = "jpg",
                          LineNumber = 1
                    },
                    new UserPhoto()
                    {
                          Directory = "Photos",
                          FileName = "file name 5",
                          Visibility = visibility,
                          Extension = "jpg",
                          LineNumber = 1
                    }
                };
                Gender female = new Gender()
                {
                    GenderName = "mujer"
                };
                Gender male = new Gender()
                {
                    GenderName = "hombre"
                };
                Gender hermaphrodite = new Gender()
                {
                    GenderName = "hermafrodita"
                };
                List<UserInfo> infos = new List<UserInfo>()
                { 
                    new UserInfo()
                    {
                         Additional = "bla",
                         Birthday = DateTime.Now,
                         Status = "some statys",
                          City = "bla",
                          Gender = female,
                             
                    },
                    new UserInfo()
                    {
                         Additional = "bla",
                         Birthday = DateTime.Now,
                          Status = "some statys",
                          City = "bla",
                          Gender = male,

                    },
                    new UserInfo()
                    {
                         Additional = "bla",
                         Birthday = DateTime.Now,
                          Status = "some statys",
                          City = "bla",
                          Gender = female,

                    },
                    new UserInfo()
                    {
                         Additional = "bla",
                         Birthday = DateTime.Now,
                          Status = "some statys",
                          City = "bla",
                          Gender = male,

                    },
                    new UserInfo()
                    {
                         Additional = "bla",
                         Birthday = DateTime.Now,
                          Status = "some statys",
                          City = "bla",
                          Gender = female,

                    }
                };

             
                List<User> users = new List<User>()
                {
                    new User()
                    {
                         Name = "name 1",
                         Password = "passord 1",
                         Login = "login 1",
                         
                         UserInfo = infos[0]
                    },
                    new User()
                    {
                         Name = "name 2",
                         Password = "passord 2",
                         Login = "login 2",
                         
                         UserInfo = infos[1]
                    },
                    new User()
                    {
                         Name = "name 3",
                         Password = "passord 3",
                         Login = "login 3",
                        
                         UserInfo = infos[2]
                    },
                    new User()
                    {
                         Name = "name 4",
                         Password = "passord 4",
                         Login = "login 4",
                        
                         UserInfo = infos[3]
                    },
                    new User()
                    {
                         Name = "name 5",
                         Password = "passord 5",
                         Login = "login 5",
                        
                         UserInfo = infos[4]
                    }
                };

                

                context.Genders.AddRange(male, female, hermaphrodite);
                context.Visibilities.Add(visibility);

                context.SaveChanges();


                context.UserInfos.AddRange(infos);

                context.SaveChanges();

                

             


                context.Users.AddRange(users);
                users[0].UserInfo = infos[0];
                users[1].UserInfo = infos[1];
                users[2].UserInfo = infos[2];
                users[3].UserInfo = infos[3];
                users[4].UserInfo = infos[4];

                context.SaveChanges();

                photos[0].User = users[0];
                photos[1].User = users[1];
                photos[2].User = users[2];
                photos[3].User = users[3];
                photos[4].User = users[4];

                context.UserPhotos.AddRange(photos);
                context.SaveChanges();

                users[0].Ava = photos[0];
                users[1].Ava = photos[1];
                users[2].Ava = photos[2];
                users[3].Ava = photos[3];
                users[4].Ava = photos[4];

                context.SaveChanges();


                List<Post> avaPosts = new List<Post>()
                {
                    new Post()
                {
                     Title = "new ava",
                     Text = "Mira",
                     User = users[0],
                     Visibility = visibility
                },
                    new Post()
                {
                     Title = "new ava",
                     Text = "Mira",
                     User = users[1],
                     Visibility = visibility
                },
                    new Post()
                {
                     Title = "new ava",
                     Text = "Mira",
                     User = users[2],
                     Visibility = visibility
                },
                    new Post()
                {
                     Title = "new ava",
                     Text = "Mira",
                     User = users[3],
                     Visibility = visibility
                },
                    new Post()
                {
                     Title = "new ava",
                     Text = "Mira",
                     User = users[4],
                     Visibility = visibility
                }

                };

                context.Posts.AddRange(avaPosts);
                context.SaveChanges();

                photos[0].Post = avaPosts[0];
                photos[1].Post = avaPosts[1];
                photos[2].Post = avaPosts[2];
                photos[3].Post = avaPosts[3];
                photos[4].Post = avaPosts[4];

                context.SaveChanges();


                Friendship friendship = new Friendship()
                {
                    FirstUser = users[0],
                    SecondUser = users[1]
                };
                Friendship friendship1 = new Friendship()
                {
                    FirstUser = users[1],
                    SecondUser = users[0]
                };
                context.Friendships.AddRange(friendship, friendship1);

                context.SaveChanges();


                CanceledInvitation canceledInvitation = new CanceledInvitation()
                {
                    FromUser = users[0],
                    ToUser = users[2]
                };
                CanceledInvitation canceledInvitation1 = new CanceledInvitation()
                {
                    FromUser = users[0],
                    ToUser = users[3]
                };
                context.CanceledInvitations.AddRange(canceledInvitation, canceledInvitation1);
                context.SaveChanges();

                Invitation invitation = new Invitation()
                {
                    FromUser = users[0],
                    ToUser = users[4]
                };
                context.Invitations.Add(invitation);
                context.SaveChanges();

                //UserPhoto communityAvaPhoto = new UserPhoto()
                //{
                //    Directory = "Photos",
                //    FileName = "com file name 1",
                //    Visibility = visibility
                //};

                //Post communityAvaPost = new Post()
                //{
                //    Title = "new community ava",
                //    Text = "",
                //    User = users[0],
                //    Visibility = visibility
                //};
                //communityAvaPhoto.Post = communityAvaPost;

                //Community community = new Community()
                //{
                //    Name = "some community",
                //    Description = "kukukukukuku",
                //    Ava = communityAvaPhoto,
                //    Creator = users[0]
                //};
                //communityAvaPost.Community = community;
                //context.UserPhotos.Add(communityAvaPhoto);
                //context.Posts.Add(communityAvaPost);


                //Subscribition subscribition = new Subscribition()
                //{
                //    Community = community,
                //    Subscriber = users[3]
                //};
                //Subscribition subscribition1 = new Subscribition()
                //{
                //    Community = community,
                //    Subscriber = users[2]
                //};
                //Membership membership = new Membership()
                //{
                //    Community = community,
                //    User = users[1]
                //};
                //context.Communities.Add(community);
                //context.Subscribitions.AddRange(subscribition, subscribition1);
                //context.Memberships.Add(membership);





                //Post usersPost = new Post()
                //{
                //     Title = "some title of user",
                //     Text = "ku text",
                //     User = users[0],
                //     Visibility = visibility
                //};
                //Post comPost = new Post()
                //{
                //    Title = "some title of com",
                //    Text = "com text",
                //    User = users[0],
                //    Visibility = visibility,
                //    Community = community
                //};

                //UserPhoto photoU = new UserPhoto()
                //{
                //    Directory = "Photos",
                //    FileName = "photo name 1",
                //    Visibility = visibility,
                //    LineNumber = 1,
                //    Post = usersPost,
                //    User = users[0]
                //};
                //UserVideo videoU = new UserVideo()
                //{
                //    Directory = "Videos",
                //    FileName = "video name 1",
                //    Visibility = visibility,
                //    LineNumber = 2,
                //    Post = usersPost,
                //    User = users[0]
                //};
                //UserDocument docU = new UserDocument()
                //{
                //    Directory = "Documents",
                //    FileName = "doc name 1",
                //    Visibility = visibility,
                //    Post = usersPost,
                //    User = users[0]
                //};

                //UserPhoto photoC = new UserPhoto()
                //{
                //    Directory = "Photos",
                //    FileName = "photo name 2",
                //    Visibility = visibility,
                //    LineNumber = 1,
                //    Post = comPost,
                //    User = users[0]
                //};
                //UserVideo videoC = new UserVideo()
                //{
                //    Directory = "Videos",
                //    FileName = "video name 2",
                //    Visibility = visibility,
                //    LineNumber = 2,
                //    Post = comPost,
                //    User = users[0]
                //};
                //UserDocument docC = new UserDocument()
                //{
                //    Directory = "Documents",
                //    FileName = "doc name 2",
                //    Visibility = visibility,
                //    Post = comPost,
                //    User = users[0]

                //};
                //context.Posts.AddRange(comPost, usersPost);
                //context.UserPhotos.AddRange(photoC, photoU);
                //context.UserVideos.AddRange(videoC, videoU);
                //context.UserDocuments.AddRange(docC, docU);


                //List<LikedEntity> likedEntities = new List<LikedEntity>()
                //{
                //    new LikedEntity()
                //    {
                //         Entity = usersPost,
                //         User = users[1]
                //    },
                //    new LikedEntity()
                //    {
                //         Entity = usersPost,
                //         User = users[2]
                //    },
                //    new LikedEntity()
                //    {
                //         Entity = usersPost,
                //         User = users[3]
                //    },
                //    new LikedEntity()
                //    {
                //         Entity = comPost,
                //         User = users[1]
                //    },
                //    new LikedEntity()
                //    {
                //         Entity = comPost,
                //         User = users[2]
                //    },
                //    new LikedEntity()
                //    {
                //         Entity = comPost,
                //         User = users[3]
                //    },
                //    new LikedEntity()
                //    {
                //         Entity = comPost,
                //         User = users[4]
                //    }

                //};
                //context.LikedEntities.AddRange(likedEntities);

                //List<Comment> comments = new List<Comment>()
                //{
                //    new Comment()
                //    {
                //         Text = "text comment 1",
                //         User = users[1],
                //    },
                //     new Comment()
                //    {
                //         Text = "text comment 2",
                //         User = users[1],
                //    },
                //      new Comment()
                //    {
                //         Text = "text comment 3",
                //         User = users[1],
                //    },

                //};
                //context.Comments.AddRange(comments);

                //List<Answer> answers = new List<Answer>()
                //{
                //    new Answer()
                //    {
                //         Text = "aswer text 1",
                //         Comment = comments[0],
                //         FromUser = users[2]
                //    },
                //    new Answer()
                //    {
                //         Text = "aswer text 1",
                //         Comment = comments[0],
                //         FromUser = users[3],
                //         ToUser = users[2]
                //    },
                //    new Answer()
                //    {
                //         Text = "aswer text 1",
                //         Comment = comments[0],
                //         FromUser = users[3]
                //    },
                //};
                //context.Answers.AddRange(answers);
                //List<LikedEntity> commentLiks = new List<LikedEntity>()
                //{
                //    new LikedEntity()
                //    {
                //        Entity = comments[0],
                //        User = users[2]
                //    },
                //    new LikedEntity()
                //    {
                //        Entity = answers[1],
                //        User = users[1]
                //    }
                //};
                //context.LikedEntities.AddRange(commentLiks);
                //List<CommentedEntity> commentedEntities = new List<CommentedEntity>()
                //{
                //    new CommentedEntity()
                //    {
                //        Comment = comments[0],
                //        Entity = comPost,
                //        User = users[1]
                //    },
                //    new CommentedEntity()
                //    {
                //        Comment = comments[1],
                //        Entity = usersPost,
                //        User = users[1]
                //    },
                //    new CommentedEntity()
                //    {
                //        Comment = comments[0],
                //        Entity = photoC,
                //        User = users[1]
                //    },
                //};
                //context.CommentedEntities.AddRange(commentedEntities);
                //context.SaveChanges();
            }
        }
    }
}
