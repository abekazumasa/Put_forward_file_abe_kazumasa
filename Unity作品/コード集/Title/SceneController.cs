using UnityEngine;
using UnityEngine.SceneManagement;

namespace EscapePenguin.Title
{
    /// <summary>
    /// 『タイトル画面』内の進行制御を表します。
    /// </summary>
    public class SceneController : MonoBehaviour
    {
        #region SerializeField
        /// <summary>
        /// 「はじめる」と「おわる」を指定します
        /// </summary>
        /// <remarks>
        /// buttons[0]   StartButton
        /// buttons[1]   EndButton
        /// </remarks>
        [SerializeField]
        private Transform[] buttons = default;
        //ボタンの大きさを指定します
        [SerializeField]
        private Vector3 bouttonScale = new Vector3(1.2f, 1.2f, 1.0f);
        //ボタン移動の速度を指定します
        [SerializeField]
        private float cursorSpeed = 0.0f;
        #endregion

        //ボタン選択用です
        private float selectedIndex = 0.0f;

        //フレーム毎に呼ばれます
        private void Update()
        {
            OnStart();
        }

        #region OnStart method
        /// <summary>
        /// このメソットが呼び出されたときボタンを制御します
        /// </summary>
        private void OnStart()
        {
            //ボタンの選択
            var horizontalKey = Input.GetAxisRaw("Horizontal");
            if (horizontalKey < 0.0f)
            {
                selectedIndex += -cursorSpeed * Time.deltaTime;
            }
            else if (horizontalKey > 0.0f)
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
                        //ゲームを終了
                        Quit();
                        break;
                }
            }

            //選択時ボタンを大きくします
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

        #region Quit method
        /// <summary>
        /// ゲームを終了時呼び出されます
        /// </summary>
        private void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
        }
        #endregion
    }
}