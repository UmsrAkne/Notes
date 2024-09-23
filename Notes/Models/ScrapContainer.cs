using System.Collections.ObjectModel;
using System.IO;
using System.IO.Abstractions;
using Prism.Commands;

namespace Notes.Models
{
    public class ScrapContainer
    {
        public ScrapContainer()
        {
            CursorManager = new CursorManager
            {
                Items = Scraps,
            };
        }

        public ObservableCollection<Scrap> Scraps { get; private set; } = new ();

        public CursorManager CursorManager { get; set; }

        public IScrapService ScrapService { get; set; }

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

            var f = new FileInfoWrapper(new FileSystem(), new FileInfo($"{ScrapService.CurrentDirectory}\\0000-{scr.Title}.json"));
            ScrapService.AddScrap(scr, f);
        }
    }
}