using System.Collections.Generic;
using System.Threading.Tasks;
using Lulalend.IRepositories;
using Lulalend.IServices;
using Lulalend.Models;

namespace Lulalend.Services
{
    public class LecturersService : ILecturersService
    {
        private ILecturersRepository _lecturersRepository;

        public LecturersService(ILecturersRepository lecturersRepository)
        {
            _lecturersRepository = lecturersRepository;
        }

        public async Task<IEnumerable<Lecturers>> GetAll()
        {
            return await _lecturersRepository.GetAll();
        }

        public async Task<Lecturers> GetBy(int id)
        {
            return await _lecturersRepository.GetBy(id);
        }

        public async Task Add(Lecturers lecturer)
        {
            await _lecturersRepository.Add(lecturer);
        }

        public async Task Delete(int id)
        {
            await _lecturersRepository.Delete(id);
        }

        public async Task Update(int id)
        {
            await _lecturersRepository.Update(id);
        }
    }
}