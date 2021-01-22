using UnityEngine;

namespace EscapePenguin
{
    /// <summary>
    /// ゲーム全体で使用されるリソースを管理します。
    /// </summary>
    public class GameController : MonoBehaviour
    {
        #region シングルトンインスタンス

        [RuntimeInitializeOnLoadMethod]
        private static void CreateInstance()
        {
            // Resourcesからプレハブを読み込む
            var prefab = Resources.Load<GameObject>("GameController");
            Instantiate(prefab);
        }

        /// <summary>
        /// このクラスのインスタンスを取得します。
        /// </summary>
        public static GameController Instance
        {
            get { return instance; }
        }
        private static GameController instance = null;

        /// <summary>
        /// Start()の実行より先行して処理したい内容を記述します。
        /// </summary>
        private void Awake()
        {
            // 初回作成時
            if (instance == null)
            {
                instance = this;
                // シーンをまたいで削除されないように設定
                DontDestroyOnLoad(gameObject);
                // セーブデータを読み込む
                Load();
            }
            // 2個目以降の作成時
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        /// <summary>
        /// ベストエスケープを取得または設定します。
        /// </summary>
        public int BestEscape
        {
            get { return bestEscape; }
            set
            {
                bestEscape = value;
                Save();
            }
        }

        /// <summary>
        /// ベストエスケープの基準値を指定します。
        /// </summary>
        [SerializeField]
        private int bestEscape = 30;

        /// <summary>
        /// GameControllerが破棄される場合に呼び出されます。
        /// </summary>
        private void OnDestroy()
        {
            Save();
        }

        // セーブデータ用の識別子
        static readonly string bestEscapeKey = "BestEscapeKey";

        /// <summary>
        /// ゲームデータを読込みます。
        /// </summary>
        private void Load()
        {
            BestEscape = PlayerPrefs.GetInt(bestEscapeKey, BestEscape);
        }

        /// <summary>
        /// ゲームデータを保存します。
        /// </summary>
        public void Save()
        {
            PlayerPrefs.SetInt(bestEscapeKey, BestEscape);
            PlayerPrefs.Save();
        }
    }
}
