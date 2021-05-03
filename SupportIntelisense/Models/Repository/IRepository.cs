using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportIntelisense.Models.Repository
{
    public interface IRepository
    {
        string GeneratePRONumber();
        string GenerateTKNumber();
    }
}
