using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkyBlueBlue.Models;
using SkyBlueBlue.Services;

namespace SkyBlueBlue.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly PaperManager paperManager;
        private readonly TopicManager topicManager;
        private readonly SuccessManager successManager;
        private readonly IMapper mapper;

        public HomeController(
            PaperManager paperManager,
            TopicManager topicManager,
            SuccessManager successManager,
            IMapper mapper)
        {
            this.paperManager = paperManager;
            this.topicManager = topicManager;
            this.successManager = successManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            // ViewBag.Avatar=avatar;
            
            return View();
        }
        // [Authorize(Roles = "Student,Teacher,Administrators")]
        public async Task<IActionResult> Test()
        {
            List<PaperModel> papers = await paperManager.FindPaperAllAsync();
            return View(papers);
        }
        // [Authorize(Roles = "Student,Teacher,Administrators")]
        public IActionResult Begin(int id)
        {
            var thePaper = paperManager.FindPaperById(id);
            ViewBag.ThePaper = thePaper;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student,Teacher,Administrators")]
        public async Task<IActionResult> End(SubmitModel submitModel)
        {
            var result = JsonConvert.DeserializeObject<List<ValueModel>>(submitModel.result);

            var thePaper = paperManager.FindPaperById(submitModel.paperId);
            
            var topicIdList = JsonConvert.DeserializeObject<List<TopicId>>(thePaper.body);
            
            if(result.Count == topicIdList.Count)
            {
                int sum = 0;
                for(int i=0;i<result.Count;i++)
                {
                    var theTopic = topicManager.FindTopicById(topicIdList[i].id);
                    if(theTopic.answe.Equals(result[i].value))
                    {
                        sum+=theTopic.scores;
                    }
                }
                var flag=await successManager.CreateSuccessAsync(new SuccessModel{
                    userName=User.Identity.Name,
                    paper=thePaper.title,
                    scores=sum,
                    subtotal=thePaper.subtotal
                });
                if(flag){
                    ViewBag.Subtotal =thePaper.subtotal;
                    return View(sum);
                }
                
            }
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public JsonResult TopicData(int id)
        {
            var thePaper = paperManager.FindPaperById(id);
            var topicIdList = JsonConvert.DeserializeObject<List<TopicId>>(thePaper.body);
            var topicList = new List<TestModel>();
            foreach (var item in topicIdList)
            {
                var theTopic = topicManager.FindTopicById(item.id);
                if(theTopic==null)
                {
                    paperManager.CheckBodyById(id);
                    return TopicData(id);
                }
                topicList.Add(mapper.Map<TestModel>(theTopic)); 
                
                
            }
            return Json(topicList);
        }

        public async Task<JsonResult> SuccessData()
        {
            var successList = await successManager.FindSuccessByUserNameAsync(User.Identity.Name);
            return Json(successList);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }



}
