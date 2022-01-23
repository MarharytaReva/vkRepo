using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private UserPhotoManager photoManager;
        private UserVideoManager videoManager;
        private UserDocumentManager documentManager;
        private UserAudioManager audioManager;
        private LikedEntityManager likedEntityManager;

        public PostController(UserPhotoManager phm,
                              UserVideoManager vm,
                              UserDocumentManager dm,
                              UserAudioManager am,
                              LikedEntityManager lem)
        {
            photoManager = phm;
            videoManager = vm;
            documentManager = dm;
            audioManager = am;
            likedEntityManager = lem;
        }
        [HttpGet("CountInfo/{id:int}")]
        public IActionResult CountInfo(int id)
        {
            int photoc = photoManager.Count(new Func<DAL.Context.UserPhoto, bool>(x => x.PostId == id));
            int videoc = videoManager.Count(new Func<DAL.Context.UserVideo, bool>(x => x.PostId == id));
            int documentc = documentManager.Count(new Func<DAL.Context.UserDocument, bool>(x => x.PostId == id));
            int audioc = audioManager.Count(new Func<DAL.Context.UserAudio, bool>(x => x.PostId == id));
            int likesc = likedEntityManager.Count(new Func<DAL.Context.LikedEntity, bool>(x => x.EntityId == id));
            return Json(new { photoCount = photoc,
                              videoCount = videoc,
                              documentCount = documentc,
                              audioCount = audioc,
                              likeCount = likesc});
        }
    }
}
