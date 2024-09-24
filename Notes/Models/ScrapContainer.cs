using System.Collections.ObjectModel;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;

namespace Notes.Models
{
    public class ScrapContainer : BindableBase
    {
        private IScrapService scrapService;

        public ScrapContainer()
        {
            CursorManager = new CursorManager
            {
                Items = Scraps,
            };
        }

        public ObservableCollection<Scrap> Scraps { get; set; } = new ();

        public CursorManager CursorManager { get; set; }

        public IScrapService ScrapService
        {
            get => scrapService;
            set
            {
                Scraps.AddRange(value.GetScraps());
                scrapService = value;
            }
        }

        public DelegateCommand AddScrapCommand => new DelegateCommand(() =>
        {
            Add("テストスクラップ");
        });

        /// <summary>
        /// 入力された文字から Scrap オブジェクトを生成して、 Scraps に追加します。
        /// </summary>
        /// <param name="str">ファイルパスであれば、そのファイルの種類に応じたものが、それ以外ならば単純なテキストの Scrap が追加されます。</param>
        public void Add(string str)
        {
            // Todo : まだ完全に実装していない。
            var scr = new Scrap() { Title = str, Id = ScrapService.GetMaxId() + 1, };
            Scraps.Add(scr);

            var f = new FileInfoWrapper(new FileSystem(), new FileInfo($"{ScrapService.CurrentDirectory}\\{scr.Id:D4}.json"));
            ScrapService.AddScrap(scr, f);
        }

        public void Add(Scrap scrap)
        {
            // Todo : まだ完全に実装していない。
            scrap.Id = ScrapService.GetMaxId() + 1;
            Scraps.Add(scrap);
            var f = new FileInfoWrapper(new FileSystem(), new FileInfo($"{ScrapService.CurrentDirectory}\\{scrap.Id:D4}.json"));
            ScrapService.AddScrap(scrap, f);
        }
    }
}