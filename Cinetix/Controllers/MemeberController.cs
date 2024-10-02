using Cinetix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinetix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            // Include Group data when fetching Members
            return Ok(await _context.Members.Include(m => m.Group).ToListAsync());
        }

        // GET: api/member/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members.Include(m => m.Group)
                                               .FirstOrDefaultAsync(m => m.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // POST: api/member
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<Member>> CreateMember(MemberDto memberDto)
        {
            var groupExists = await _context.Groups.AnyAsync(g => g.Id == memberDto.GroupId);
            if (!groupExists)
            {
                return BadRequest("Invalid GroupId");
            }

            var member = new Member
            {
                Id = memberDto.Id,
                Name = memberDto.Name,
                Role = memberDto.Role,
                GroupId = memberDto.GroupId
            };

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMember), new { id = member.Id }, member);
        }


        // PUT: api/member/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, MemberDto memberDto)
        {
            // Check if the member exists
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            // Check if the provided GroupId is valid
            var groupExists = await _context.Groups.AnyAsync(g => g.Id == memberDto.GroupId);
            if (!groupExists)
            {
                return BadRequest("Invalid GroupId");
            }

            // Update member properties
            member.Name = memberDto.Name;
            member.Role = memberDto.Role;
            member.GroupId = memberDto.GroupId;

            // Mark the member entity as modified
            _context.Entry(member).State = EntityState.Modified;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/member/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
