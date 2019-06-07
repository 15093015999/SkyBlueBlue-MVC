using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkyBlueBlue.Models;
using SkyBlueBlue.Services;

namespace SkyBlueBlue.Controllers
{
    [Authorize(Roles = "Teacher,Administrators")]
    public class PaperController : Controller
    {
        private readonly PaperManager paperManager;
        private readonly TopicManager topicManager;

        public PaperController(PaperManager paperManager, TopicManager topicManager)
        {
            this.paperManager = paperManager;
            this.topicManager = topicManager;
        }
        public async Task<IActionResult> Index()
        {
            List<PaperModel> papers = await paperManager.FindPaperAllAsync();
            return View(papers);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<TopicModel> topics = await topicManager.FindTopicAllAsync();
            ViewBag.Topics = topics;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaperModel paper)
        {
            //添加创建人
            paper.teacherUserName=HttpContext.User.Identity.Name;
            var topicIdList = JsonConvert.DeserializeObject<List<TopicId>>(paper.body);
            int sum =0;
            //计算总分
            foreach (var item in topicIdList)
            {
                sum += topicManager.FindTopicById(item.id).scores;
            }
            paper.subtotal=sum;
            await paperManager.AddPaperAsync(paper);
            List<PaperModel> papers = await paperManager.FindPaperAllAsync();
            return View("Index", papers);
        }
        public IActionResult Detail(int id)
        {

            var paper = paperManager.FindPaperById(id);
            var topicIdList = JsonConvert.DeserializeObject<List<TopicId>>(paper.body);
            var topicIdTitleList = new List<TopicIdTitle>();
            foreach (var item in topicIdList)
            {
                var theTopic = topicManager.FindTitleById(item.id);
                if(theTopic==null)
                {
                    paperManager.CheckBodyById(id);
                    return RedirectToAction("Detail",id);
                }
                topicIdTitleList.Add(
                    new TopicIdTitle{
                        id=item.id,
                        title= theTopic
                    }
                ); 
                
            }
            ViewBag.Paper=paper;
            ViewBag.TopicIdList =topicIdTitleList;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var paper = paperManager.FindPaperById(id);
            paperManager.DeletePaper(paper);
            return RedirectToAction(nameof(Index));
        }
        // public async Task<JsonResult> TopicData()
        // {
        //     List<TopicModel> topics =  await topicManager.FindTopicAll();
        //     return Json(topics);
        // }

    }
    public class TopicId
    {
        public int id { get; set; }
    }
    public class TopicIdTitle
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}