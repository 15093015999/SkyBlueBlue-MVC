using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyBlueBlue.Models;
using SkyBlueBlue.Services;

namespace SkyBlueBlue.Controllers
{
    [Authorize(Roles = "Teacher,Administrators")]
    public class TopicController:Controller
    {
        private readonly TopicManager topicManager;

        public TopicController(TopicManager topicManager){
            this.topicManager = topicManager;
        }
        public async Task<IActionResult> Index()
        {
            List<TopicModel> topics =  await topicManager.FindTopicAllAsync();
            return View(topics);
        }
        [HttpGet]
        public IActionResult SelectCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SelectCreate(string Select)
        {
            switch (Select)
            {
                case "Choice": return View("CreateChoice");
                case "Fill":return View("CreateFill");
                case "Judge":return View("CreateJudge");
                default:return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopicModel topic)
        {
            if(ModelState.IsValid){
                var newModel=await topicManager.AddTopicAsync(topic);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var topic = topicManager.FindTopicById(id);
            return View(topic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var topic = topicManager.FindTopicById(id);
            topicManager.DeleteTopic(topic);
            return  RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string queryString)
        {
            var queryTopic = topicManager.FindTopicName(queryString);
            return View("Index",queryTopic);
        }

    }
}