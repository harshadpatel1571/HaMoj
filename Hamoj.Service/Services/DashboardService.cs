

using Hamoj.DB.Context;
using Hamoj.Service.Interface;

namespace Hamoj.Service.Services;

public class DashboardService : IDashboardService
{
    private readonly HamojDBContext _context;

    public DashboardService(HamojDBContext context) 
    {
        // Set Object Value 
        _context = context;
    }
     
}
