using System;
using Prism.Mvvm;

namespace Notes.Models
{
    public class Scrap : BindableBase
    {
        private int indentCount;
        private string title;
        private string description;
        private bool isMarked;
        private ScrapKind kind;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public ScrapKind Kind { get => kind; set => SetProperty(ref kind, value); }

        /// <summary>
        /// このスクラップをいくつインデントするかを表します。
        /// 値は (0-3) の範囲のみ有効です。それ以外の値を入力すると、内部で近い方の境界値に合わせた後入力されます。
        /// </summary>
        public int IndentCount
        {
            get => indentCount;
            set
            {
                var v = Math.Min(3, Math.Max(0, value));
                SetProperty(ref indentCount, v);
            }
        }

        public bool IsMarked { get => isMarked; set => SetProperty(ref isMarked, value); }
    }
}