using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VillaManagement.Application.Common.Interfaces;
using VillaManagement.Domain.Entities;
using VillaManagement.Infrastructure.Data;

namespace VillaManagement.Infrastructure.Repository
{
    public class VillaRepository :Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;

        }  
        public void Save()
        {
           _db.SaveChanges();
        }

        public void Update(Villa entity)
        {
           _db.Villas.Update(entity);
        }
    }
}
