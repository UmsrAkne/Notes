using System.Collections.ObjectModel;

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

        /// <summary>
        /// 入力された文字から Scrap オブジェクトを生成して、 Scraps に追加します。
        /// </summary>
        /// <param name="str">ファイルパスであれば、そのファイルの種類に応じたものが、それ以外ならば単純なテキストの Scrap が追加されます。</param>
        public void Add(string str)
        {
            // Todo : まだ完全に実装していない。
            Scraps.Add(new Scrap() { Title = str, });
        }
    }
}