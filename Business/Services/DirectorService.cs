using System.Data;
using System.Linq;
using Business.Models;
using Business.Results;
using Business.Results.Bases;
using DataAccess.Contexts;
using Data_Access.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IDirectoryService
    {
        IQueryable<DirectoryModel> Query();
        //Result Add(DirectoryModel model);
        //Result Update(DirectoryModel model);
        //Result Delete(int id);
    }

    public class DirectorService : IDirectoryService
    {
        private readonly Db _db;

        public DirectorService(Db db)
        {
            _db = db;
        }

        public IQueryable<DirectoryModel> Query()
        {
            return _db.Directors.Include(r => r.Movies).Select(r => new DirectoryModel()
            {
                // model - entity property assignments
                Id = r.Id,
                UserName = r.Name,
                Surname = r.Surname,
                BirthDate = r.BirthDate,
                IsRetired = r.IsRetired,
                IsRetiredOutput = r.IsRetired ? "yes" : "no",
                MovieCountOutput = r.Movies.Count,
                Movies = r.Movies

                // modified model - entity property assignments for displaying in views
                // display the user count for each role
            });
        }
    }
}