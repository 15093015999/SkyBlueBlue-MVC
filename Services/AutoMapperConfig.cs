using System;
using AutoMapper;
using Newtonsoft.Json;
using SkyBlueBlue.Models;

namespace SkyBlueBlue.Services
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TopicModel, TestModel>();
            // CreateMap<TopicModel, ChoiceTopicModel>()
            //     .ForMember(d => d.content, u => u.MapFrom(s => JsonConvert.DeserializeObject<ChoiceContent>(s.content).content))
            //     .ForMember(d => d.optionA, u => u.MapFrom(s => JsonConvert.DeserializeObject<ChoiceContent>(s.content).optionA))
            //     .ForMember(d => d.optionB, u => u.MapFrom(s => JsonConvert.DeserializeObject<ChoiceContent>(s.content).optionB))
            //     .ForMember(d => d.optionC, u => u.MapFrom(s => JsonConvert.DeserializeObject<ChoiceContent>(s.content).optionC))
            //     .ForMember(d => d.optionD, u => u.MapFrom(s => JsonConvert.DeserializeObject<ChoiceContent>(s.content).optionD));

            // CreateMap<ChoiceTopicModel, TopicModel>()
            //     .ForMember(d => d.content, u => u.MapFrom(s => JsonConvert.SerializeObject(new {content=s.content,optionA=s.optionA,optionB=s.optionB,optionC=s.optionC,optionD=s.optionD})));
            // CreateMap<TopicModel, FillTopicModel>();
            // CreateMap<FillTopicModel, TopicModel>();
            // CreateMap<TopicModel, JudgeTopicModel>();
            // CreateMap<JudgeTopicModel, TopicModel>();
        }
        public class ChoiceContent
        {
            public string content { get; set; }
            public string optionA{get;set;}
            public string optionB{get;set;}
            public string optionC{get;set;}
            public string optionD{get;set;}
        }
    }
}