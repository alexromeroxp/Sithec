using Microsoft.EntityFrameworkCore;
using Sithec.Models;


namespace Sithec.Services
{
    public class HumanService : IHumanService
    {
        private readonly SithecDBContext _context;

        public HumanService(SithecDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Human>> GetHumans()
        {
            if (_context.Human == null)
            {
                return null;
            }

            return await _context.Human.ToListAsync();
        }

        public IEnumerable<Human> GetMockHumans()
        {
            var humans = new List<Human>
            {
                new Human
                {
                    Id = 3,
                    Nombre = "Gerardo",
                    Edad = 20,
                    Altura = 190,
                    Peso = 180,
                    Sexo = "Masculino"
                },
                new Human
                {
                    Id = 3,
                    Nombre = "Alex",
                    Edad = 18,
                    Altura = 170,
                    Peso = 150,
                    Sexo = "Masculino"
                }
            };

            return humans;
        }

        public async Task<Human> GetHuman(int id)
        {
            if (_context.Human == null)
            {
                return null;
            }

            return await _context.Human.FindAsync(id);
        }

        public async Task<bool> UpdateHuman(int id, Human human)
        {
            if (id != human.Id)
            {
                return false;
            }

            _context.Entry(human).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<Human> CreateHuman(Human human)
        {
            if (_context.Human == null)
            {
                return null;
            }

            _context.Human.Add(human);
            await _context.SaveChangesAsync();

            return human;
        }

        public async Task<bool> DeleteHuman(int id)
        {
            if (_context.Human == null)
            {
                return false;
            }

            var human = await _context.Human.FindAsync(id);

            if (human == null)
            {
                return false;
            }

            _context.Human.Remove(human);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool HumanExists(int id)
        {
            return (_context.Human?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
