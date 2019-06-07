using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkyBlueBlue.Date;
using SkyBlueBlue.Models;

namespace SkyBlueBlue.Services
{
    public class SuccessManager
    {
        private readonly ApplicationDbContext dbcontext;

        public SuccessManager(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<bool> CreateSuccessAsync(SuccessModel model)
        {
            try
            {
                await dbcontext.Success.AddAsync(model);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<SuccessModel>> FindSuccessByUserNameAsync(string userName)
        {
            return await Task<List<SuccessModel>>.Run(
                ()=>dbcontext.Success.Where(s=>s.userName.Equals(userName)).ToList());
        }
    }
}