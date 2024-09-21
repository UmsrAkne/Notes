namespace Notes.Models
{
    public enum ScrapKind
    {
        /// <summary>
        /// スクラップの内容がファイルパス以外のテキストであることを表します。
        /// </summary>
        Text,

        /// <summary>
        /// スクラップの内容がファイルパスであることを表します。
        /// </summary>
        FilePath,

        /// <summary>
        /// スクラップの内容が音声ファイルであることを表します。
        /// </summary>
        Sound,

        /// <summary>
        /// スクラップの内容が画像ファイルであることを表します。
        /// </summary>
        Image,

        /// <summary>
        /// スクラップの内容が実行ファイルであることを表します。
        /// </summary>
        Executable,
    }
}