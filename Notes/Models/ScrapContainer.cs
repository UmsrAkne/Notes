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
        private ObservableCollection<Scrap> scraps = new ();

        public ScrapContainer()
        {
            CursorManager = new CursorManager
            {
                Items = Scraps,
            };
        }

        public ObservableCollection<Scrap> Scraps
        {
            get => scraps;
            private set => SetProperty(ref scraps, value);
        }

        public CursorManager CursorManager { get; set; }

        public IScrapService ScrapService
        {
            get => scrapService;
            set
            {
                Scraps = new ObservableCollection<Scrap>(Scraps.Concat(value.GetScraps()));
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
            var scr = new Scrap() { Title = str, };
            Scraps.Add(scr);

            var id = ScrapService.GetMaxId() + 1;

            var f = new FileInfoWrapper(new FileSystem(), new FileInfo($"{ScrapService.CurrentDirectory}\\{id:D4}-{scr.Title}.json"));
            ScrapService.AddScrap(scr, f);
        }
    }
}