using System;
using System.Collections.Generic;
using System.IO.Abstractions;

namespace Notes.Models
{
    public class DummyScrapService : IScrapService
    {
        public IDirectoryInfo CurrentDirectory { get; set; }

        public IEnumerable<Scrap> GetScraps()
        {
            var l = new List<Scrap>();
            for (var i = 0; i < 30; i++)
            {
                l.Add(new Scrap
                {
                    IndentCount = 0,
                    Title = $"testTitle{i + 1}",
                    Description = $"testDescription{i + 1}",
                    IsMarked = false,
                    Kind = ScrapKind.Text,
                    GroupName = string.Empty,
                    CreationDateTime = DateTime.Now,
                });
            }

            return l;
        }

        public void AddScrap(Scrap scrap, IFileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }
    }
}