using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTSAPI.DBContexts;
using VTSAPI.Models;

namespace VTSAPI.Repository
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicle();
        Vehicle GetVehicleByID(int vId);
        void InsertVehicle(Vehicle vehicle);
        void DeleteVehicle(int vId);
        void UpdateVehicle(Vehicle vehicle);
        void Save();
    }
    public class VehicleRepository: IVehicleRepository
    {
        private readonly UserContext _dbContext;
        public VehicleRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Vehicle> GetVehicle()
        {
            return _dbContext.Vehicle.ToList();
        }
        public Vehicle GetVehicleByID(int Id)
        {
            return _dbContext.Vehicle.Find(Id);
        }
        public void InsertVehicle(Vehicle vehicle)
        {
            _dbContext.Add(vehicle);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            _dbContext.Entry(vehicle).State = EntityState.Modified;
            Save();
        }
        public void DeleteVehicle(int vId)
        {
            var vehicle = _dbContext.Vehicle.Find(vId);
            _dbContext.Vehicle.Remove(vehicle);
            Save();
        }
    }
}
