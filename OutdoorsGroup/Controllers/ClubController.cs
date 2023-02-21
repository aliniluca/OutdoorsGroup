using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OutdoorsGroup.Data;
using OutdoorsGroup.Interfaces;
using OutdoorsGroup.Models;

namespace OutdoorsGroup.Controllers
{
    public class ClubController : Controller
    {
       
        private readonly IClubRepository _clubRepository;

        public ClubController(ApplicationDbContext _context, IClubRepository clubRepository)
        {
           
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs= await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
    }
} 
