using System.Collections.Generic;

namespace Notes.Models
{
    public interface IScrapService
    {
        public IEnumerable<Scrap> GetScraps();
    }
}