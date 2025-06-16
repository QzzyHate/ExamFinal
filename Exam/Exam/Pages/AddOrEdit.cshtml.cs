using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.Pages
{
    [IgnoreAntiforgeryToken]
    public class AddOrEditModel : PageModel
    {
        private readonly ExamContext _context;

        public AddOrEditModel(ExamContext context)
        {
            _context = context;
            Console.WriteLine("bd");
        }

        [BindProperty]
        public PartnerOrder Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Order = new PartnerOrder();
            }
            else
            {
                Order = await _context.PartnerOrders
                    .Include(o => o.Partner)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (Order == null)
                    return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ���������, ���������� ��� ��������������
            if (Order.Id == 0)
            {
                // �������� ������ ������� � ������
                _context.Partners.Add(Order.Partner); // ������� �������
                await _context.SaveChangesAsync(); // ��������, ����� �������� Partner.Id

                Order.PartnerId = Order.Partner.Id; // ������� � �������
                _context.PartnerOrders.Add(Order);
            }
            else
            {
                // ���������� �������������
                var existingOrder = await _context.PartnerOrders
                    .Include(o => o.Partner)
                    .FirstOrDefaultAsync(o => o.Id == Order.Id);

                if (existingOrder == null)
                {
                    return NotFound();
                }

                // ���������� ����� ������
                existingOrder.TotalCost = Order.TotalCost;

                // ���������� ������ �������
                existingOrder.Partner.PartnerType = Order.Partner.PartnerType;
                existingOrder.Partner.PartnerName = Order.Partner.PartnerName;
                existingOrder.Partner.Director = Order.Partner.Director;
                existingOrder.Partner.Address = Order.Partner.Address;
                existingOrder.Partner.Phone = Order.Partner.Phone;
                existingOrder.Partner.Email = Order.Partner.Email;
                existingOrder.Partner.Rating = Order.Partner.Rating;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Requests");
        }

    }
}