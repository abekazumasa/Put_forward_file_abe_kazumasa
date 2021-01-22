using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EscapePenguin.Result
{
    /// <summary>
    /// 『Result画面』の制御を表します
    /// </summary>
    public class SceneController : MonoBehaviour
    {
        #region property
        /// <summary>
        /// クリアーした脱出人数を取得または設定します。
        /// </summary>
        public static int ClearEscape
        {
            get { return clearEscape; }
            set { clearEscape = value; }
        }
        private static int clearEscape = 6;
        #endregion

        #region SerializeField
        /// <summary>
        /// 「もう一度」と「たいとるへ」を指定します
        /// </summary>
        /// <remarks>
        /// buttons[0]   RetryButton
        /// buttons[1]   TitleButton
        /// </remarks>
        [SerializeField]
        private Transform[] buttons = default;
        //ボタンの大きさを指定します
        [SerializeField]
        private Vector3 bouttonScale = new Vector3(1.2f, 1.2f, 1.0f);
        //ボタン移動の速度を指定します
        [SerializeField]
        private float cursorSpeed = 0.0f;
        //脱出人数成功
        [SerializeField]
        private GameObject EscapeRoot = default;
        [SerializeField]
        private GameObject bestEscapeRoot = default;
        [SerializeField]
        private GameObject NewRecode = default;
        #endregion
        //ボタン選択用
        private float selectedIndex = 0;

        // 開始時に呼ばれます
        private void Start()
        {
            // ベストタイムを更新
            if (clearEscape > GameController.Instance.BestEscape)
            {
                NewRecode.SetActive(true);
                GameController.Instance.BestEscape = clearEscape;
            }

            EscapeRoot.GetComponentInChildren<Text>().text =
                 ClearEscape.ToString("脱出人数") + clearEscape;

            bestEscapeRoot.GetComponentInChildren<Text>().text =
                 GameController.Instance.BestEscape.ToString("BEST:") + GameController.Instance.BestEscape;
        }

        // 毎フレーム呼ばれます
        private void Update()
        {
            OnStart();
        }

        #region OnStart method
        /// <summary>
        /// このメソットが呼び出されたときボタンを制御
        /// </summary>
        private void OnStart()
        {
            //ボタンの選択
            float horizontalKey = Input.GetAxisRaw("Horizontal");
            if (horizontalKey < 0)
            {
                selectedIndex += -cursorSpeed * Time.deltaTime;
            }
            else if (horizontalKey > 0)
            {
                selectedIndex += cursorSpeed * Time.deltaTime;
            }
            else
            {
                selectedIndex = Mathf.FloorToInt(selectedIndex);
            }
            //最大値を超えないようにします
            selectedIndex = Mathf.Clamp(selectedIndex, 0.0f, buttons.Length - 1);
            //Enter/joy stick sutton1が押されたら
            if (Input.GetButtonDown("Submit"))
            {
                //selectedIndexの小数を切り捨てます
                var index = Mathf.FloorToInt(selectedIndex);
                switch (index)
                {
                    case 0:
                        //ステージに移動
                        SceneManager.LoadSceneAsync("Stage");
                        break;
                    case 1:
                        //タイトルに移動
                        SceneManager.LoadSceneAsync("Title");
                        break;
                }
            }
            for (int index = 0; index < buttons.Length; index++)
            {
                if (index == (int)selectedIndex)
                {
                    buttons[index].localScale = bouttonScale;
                }
                else
                {
                    buttons[index].localScale = Vector3.one;
                }
            }
        }
        #endregion
    }
}
