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
        Result Add(DirectoryModel model);
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

        public Result Add(DirectoryModel model)
        {
            // Way 1: may cause problems for Turkish characters such as İ, i, I and ı
            //if (_db.Roles.Any(r => r.Name.ToUpper() == model.Name.ToUpper().Trim()))
            //    return new ErrorResult("Role with the same name already exists!");
            // Way 2: one of the correct ways for checking string data without any problems for Turkish characters,
            // works correct for English culture,
            // since Entity Framework is built on ADO.NET, we can run SQL commands directly as below in the database
            var nameSqlParameter = new SqlParameter("Username", model.UserName.Trim()); // using a parameter prevents SQL Injection
                                                                                        // we provide SQL parameters to the SQL query as the second and rest parameters for the FromSqlRaw method
                                                                                        // according to their usage order in the SQL query
            var query = _db.Directors.FromSqlRaw("select * from Directors where UPPER(Name) = UPPER(@Username)", nameSqlParameter);
            if (query.Any()) // if there are any results for the query above
                return new ErrorResult("Director with the same name already exists!");

            var entity = new Director()
            {
                Name = model.UserName.Trim(),
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                IsRetired = model.IsRetired,
            };
            _db.Directors.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Director added successfully.");
        }




    }
}