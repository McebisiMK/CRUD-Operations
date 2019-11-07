using System.Collections.Generic;
using System.Threading.Tasks;
using Lulalend.IRepositories;
using Lulalend.IServices;
using Lulalend.Models;

namespace Lulalend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository=studentsRepository;
        }

        public async Task<IEnumerable<Students>> GetAll()
        {
            return await _studentsRepository.GetAll();
        }

        public async Task<Students> GetBy(int id)
        {
            return await _studentsRepository.GetBy(id);
        }

        public async Task Add(Students student)
        {
            await _studentsRepository.Add(student);
        }

        public async Task Update(int id)
        {
            await _studentsRepository.Update(id);
        }

        public async Task Delete(int id)
        {
            await _studentsRepository.Delete(id);
        }
    }
}