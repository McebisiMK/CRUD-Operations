using Lulalend.IRepositories;
using Lulalend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lulalend.Repositories
{
    public class LecturersRepository : ILecturersRepository
    {
        private readonly IGenericRepository<Lecturers> _genericRepository;

        public LecturersRepository(IGenericRepository<Lecturers> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Lecturers>> GetAll()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public async Task<Lecturers> GetBy(int id)
        {
            return await _genericRepository.GetBy(lecturer => lecturer.Id == id).SingleAsync();
        }

        public async Task Add(Lecturers lecturer)
        {
            _genericRepository.Add(lecturer);
            await _genericRepository.Save();
        }

        public async Task Update(int id)
        {
            _genericRepository.Update(id);
            await _genericRepository.Save();
        }

        public async Task Delete(int id)
        {
            _genericRepository.Delete(id);
            await _genericRepository.Save();
        }
    }
}