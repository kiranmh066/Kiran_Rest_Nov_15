using Microsoft.EntityFrameworkCore;
using RestaurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantDAL.Repost
{
    public class AssignWorkRepost:IAssignWorkRepost
    {
        RestaurantDbContext _dbContext;//default private

        public AssignWorkRepost(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddAssignWork(AssignWork assignWork)
        {
            _dbContext.tbl_AssignWork.Add(assignWork);
            _dbContext.SaveChanges();
        }

        public void DeleteAssignWork(int assignWorkId)
        {
            var assignWork = _dbContext.tbl_AssignWork.Find(assignWorkId);
            _dbContext.tbl_AssignWork.Remove(assignWork);
            _dbContext.SaveChanges();
        }

        public AssignWork GetAssignWorkById(int assignWorkId)
        {
            return _dbContext.tbl_AssignWork.Find(assignWorkId);
        }

        public IEnumerable<AssignWork> GetAssignWorks()
        {
            return _dbContext.tbl_AssignWork.Include(obj => obj.Employee).Include(obj=>obj.Order).ToList();
        }

        public IEnumerable<AssignWork> GetAssignWorksBySpeciality(string speciality)
        {
            throw new NotImplementedException();
        }

        public void UpdateAssignWork(AssignWork assignWork)
        {
            _dbContext.Entry(assignWork).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
