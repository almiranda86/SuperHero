using SuperHero.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Domain.Behavior.Service
{
    public interface IBaseHeroService
    {
        Task CreateBaseHero(IEnumerable<BaseHero> baseHeroCollection);
    }
}
