using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Pages
{
    public class RequestsModel : PageModel
    {
        private readonly ExamContext _context;

        public RequestsModel(ExamContext context)
        {
            _context = context;
        }

        public List<PartnerOrder> Orders { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _context.PartnerOrders
                .Include(r => r.Partner)
                .Include(r => r.OrderProducts)
                    .ThenInclude(rp => rp.Product)
                .ToListAsync();
        }
    }
}