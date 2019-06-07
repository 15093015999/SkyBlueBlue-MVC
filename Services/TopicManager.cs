using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkyBlueBlue.Date;
using SkyBlueBlue.Models;
using AutoMapper;
using System;
using System.Text.RegularExpressions;
// using AutoMapperTest.Entities;

namespace SkyBlueBlue.Services
{
    public class TopicManager
    {
        private readonly ApplicationDbContext dbcontext;

        public TopicManager(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<bool> AddTopicAsync(TopicModel model)
        {
            try
            {
                await dbcontext.Topics.AddAsync(model);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            
        }

        public async Task<List<TopicModel>> FindTopicAllAsync()
        {
            List<TopicModel> models = await dbcontext.Topics.ToListAsync();
            return models;
        }

        public TopicModel FindTopicById(int id)
        {
            return dbcontext.Topics.FirstOrDefault(x=>x.id==id);
        }
        public string FindTitleById(int id)
        {
            var theTopics = dbcontext.Topics.FirstOrDefault(x=>x.id==id);
            if (theTopics!=null){
                return theTopics.title;
            }
            return null;
        }

        public List<TopicModel> FindTopicName(string queryString)
        {
            var queryList =dbcontext.Topics.Where( 
                x => Regex.IsMatch( x.title ,".*"+queryString+".*" )).ToList();
            return queryList;
        }

        public bool DeleteTopic(TopicModel model)
        {
            try
            {
                dbcontext.Topics.Remove(model);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        // public async Task<List<TopicViewModel>> FindTopicIds(int[] ids)
        // {
            
        // }


    }
}