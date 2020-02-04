using Microsoft.EntityFrameworkCore;
using QuantumITApp.Core.Entities;
using QuantumITApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumITApp.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly QuantumITDataContext _context;

        public SubjectRepository(QuantumITDataContext context)
        {
            _context = context;
        }

        public async Task<Subject> AddAsync(Subject newSubject)
        {
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();
            return newSubject;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Subject subject)
        {
            if (!await SubjectExists(subject.Id))
                return false;
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await SubjectExists(id))
                return false;

            // first, delete from SubjectStudent table
            var toRemoveSubjectStudents = _context.SubjectStudent.Where(x => x.SubjectId == id);
            foreach (var subjectstudent in toRemoveSubjectStudents)
            {
                _context.SubjectStudent.Remove(subjectstudent);
            }

            var toRemove = _context.Subjects.Find(id);
            _context.Subjects.Remove(toRemove);

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> SubjectExists(int id)
        {
            return await _context.Subjects.AnyAsync(c => c.Id == id);
        }



    }
}
