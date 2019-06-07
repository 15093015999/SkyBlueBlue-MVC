using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SkyBlueBlue.Controllers;
using SkyBlueBlue.Date;
using SkyBlueBlue.Models;

namespace SkyBlueBlue.Services
{
    public class PaperManager
    {
        private readonly ApplicationDbContext dbcontext;

        public PaperManager(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<List<PaperModel>> FindPaperAllAsync()
        {
            List<PaperModel> models = await dbcontext.Papers.ToListAsync();
            return models;
        }

        public PaperModel FindPaperById(int id)
        {
            return dbcontext.Papers.FirstOrDefault(x=>x.id==id);
        }

        public async Task<bool> AddPaperAsync(PaperModel model)
        {
            try
            {
                await dbcontext.Papers.AddAsync(model);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeletePaper(PaperModel model)
        {
            try
            {
                dbcontext.Papers.Remove(model);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool ChangeBodyById(int id,string body)
        {
            try
            {
                dbcontext.Papers.FirstOrDefault(x=>x.id==id).body=body;
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void CheckBodyById(int id)
        {
            var oldTopicIdList = JsonConvert.DeserializeObject<List<TopicId>>(dbcontext.Papers.FirstOrDefault(x=>x.id==id).body);
            var newTopicIdList = new List<TopicId>();
            int sum =0;
            foreach(var item in oldTopicIdList)
            {
                var theTopic =dbcontext.Topics.FirstOrDefault(x=>x.id==item.id);
                if(theTopic!=null)
                {
                    sum+=theTopic.scores;
                    newTopicIdList.Add(new TopicId{id = theTopic.id });
                }
            }
            dbcontext.Papers.FirstOrDefault(x=>x.id==id).subtotal=sum;
            dbcontext.Papers.FirstOrDefault(x=>x.id==id).body=JsonConvert.SerializeObject(newTopicIdList);
            dbcontext.SaveChanges();
        }
        
    }
}