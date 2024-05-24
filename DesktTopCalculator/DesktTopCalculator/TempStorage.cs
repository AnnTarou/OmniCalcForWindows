namespace DesktTopCalculator
{
    // 保存系クラス
    internal class TempStorage
    {
        // Display.Textを保存するスタック
        public Stack<string> storageStack = new Stack<string>();

        // カーソル位置を保存するスタック        
        public Stack<int> storageStackIndex = new Stack<int>();

        // スタックの初期化
        public void PushInitialValue()
        {
            // スタックに空文字とカーソル位置0をPush
            storageStack.Push("");
            storageStackIndex.Push(0);
        }

        // Display.Textとカーソル位置をスタックへ保存する
        public void TempStack(string text, int cursorposition)
        {
            // Display.Textが何もなければ空文字列をスタックへ保存
            if (text == null)
            {
                storageStack.Push("");
            }
            else
            {
                storageStack.Push(text);
            }

            // カーソル位置を保存
            storageStackIndex.Push(cursorposition);
        }

        // スタックを空にする
        public void ClearStack()
        {
            storageStack.Clear();

            storageStackIndex.Clear();
        }

        // スタックからDisplay.Textを取り出す
        public string PopDisplayText()
        {
            // 一番上のテキストを取り出す
            storageStack.Pop();

            // 二番目のテキストを返す
            return storageStack.Pop();
        }

        // スタックからカーソル位置を取り出す
        public int PopCursoulPosition()
        {
            // 一番上のカーソル位置を取り出す
            storageStackIndex.Pop();

            // 二番目のカーソル位置を返す
            return storageStackIndex.Pop();
        }

        // KeepBoxの文字列の取得
        public string SelectResult(ListBox buttonkeep)
        {
            string? selectedItem = buttonkeep.SelectedItem?.ToString() ?? null;

            // ＝のインデックスを検索
            int indexOfEquals = selectedItem?.IndexOf("=") ?? 0;

            // ＝以降の文字列を取得
            string resultString = selectedItem?.Substring(indexOfEquals + 1) ?? "";

            return resultString;
        }
    }
}
