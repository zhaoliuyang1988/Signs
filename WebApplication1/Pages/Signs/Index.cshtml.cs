using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Signs
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public const int SignCount = 3;

        public IList<Sign> Sign { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sign != null)
            {
                var list = await _context.Sign.ToListAsync();

                if (list.Count >= SignCount)
                {
                    var index = GenerateNumber.Get(1, list.Count, SignCount);
                    Sign = new List<Sign>();
                    foreach (var item in index)
                    {
                        Sign.Add(list[item - 1]);
                    }
                }
                else
                {

                    Sign = new List<Sign>();
                }
            }
        }
    }
}


public class GenerateNumber
{
    public static List<int> Get(int min, int max, int count)
    {
        List<int> list = new List<int>();
        Random rnd = new Random();
        int n = rnd.Next(min, max);
        list.Add(n);
        while (list.Count < count)
        {
            n = rnd.Next(min, max);
            if (list.All(x => x != n))
            {
                list.Add(n);
            }
        }
        return list;
    }

}