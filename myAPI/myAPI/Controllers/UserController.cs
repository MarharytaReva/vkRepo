using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;
using DTO;
using DAL.Repos;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserManager userManager;
        private FriendshipManager friendshipManager;
        private UserPhotoManager photoMaganer;
        private UserVideoManager videoManager;
        private UserDocumentManager documentManager;
        private UserAudioManager audioManager;
        private SubscribitionManager subscribitionManager;

        public UserController(UserManager userManager, 
                              FriendshipManager fm,
                              UserPhotoManager phm,
                              UserVideoManager vm,
                              UserDocumentManager dm,
                              UserAudioManager am,
                              SubscribitionManager sm)
        {
            this.userManager = userManager;
            friendshipManager = fm;
            photoMaganer = phm;
            videoManager = vm;
            documentManager = dm;
            audioManager = am;
            subscribitionManager = sm;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await userManager.GetItemAsync(id);
            if (user is null)
                return NotFound();
            return user;
        }
        [HttpGet("/frindCount/{id:int}")]
        public async Task<ActionResult<int>> FrindCount(int id)
        {
            int count = friendshipManager.Count(new Func<DAL.Context.Friendship, bool>(x => x.FirstUserId == id));
            return count;
        }
        [HttpGet("/photoCount/{id:int}")]
        public async Task<ActionResult<int>> PhotoCount(int id)
        {
            int count = photoMaganer.Count(new Func<DAL.Context.UserPhoto, bool>(x => x.UserId == id));
            return count;
        }
        [HttpGet("/videoCount/{id:int}")]
        public async Task<ActionResult<int>> VideoCount(int id)
        {
            int count = videoManager.Count(new Func<DAL.Context.UserVideo, bool>(x => x.UserId == id));
            return count;
        }
        [HttpGet("/documentCount/{id:int}")]
        public async Task<ActionResult<int>> DocumentCount(int id)
        {
            int count = documentManager.Count(new Func<DAL.Context.UserDocument, bool>(x => x.UserId == id));
            return count;
        }
        [HttpGet("/audioCount/{id:int}")]
        public async Task<ActionResult<int>> AudioCount(int id)
        {
            int count = audioManager.Count(new Func<DAL.Context.UserAudio, bool>(x => x.UserId == id));
            return count;
        }
        [HttpGet("/subscribitionCount/{id:int}")]
        public async Task<ActionResult<int>> SubscribitionCount(int id)
        {
            int count = subscribitionManager.Count(new Func<DAL.Context.Subscribition, bool>(x => x.SubscriberId == id));
            return count;
        }
    }
}
