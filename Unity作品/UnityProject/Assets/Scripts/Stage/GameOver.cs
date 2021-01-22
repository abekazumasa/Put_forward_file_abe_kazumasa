using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// ゲームオーバー演出を制御を表します
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        #region SerializeField

        /// <summary>
        /// 「もういちど」と「たいとるへ」を指定します
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
        //ボタン移動速度を指定します
        [SerializeField]
        private float cursorSpeed = 0.0f;
        #endregion

        //ボタン選択用
        private float selectedIndex = 0.0f;

        //開始時に呼ばれます
        private void Start()
        {
            StartCoroutine(StartGameOver());
        }

        #region StartGameOver coroutine
        //ゲームオーバーボタン制御コルーチンです
        private IEnumerator StartGameOver()
        {
            yield return new WaitForSeconds(1.0f);

            while (true)
            {
                float horizontalKey = Input.GetAxisRaw("Horizontal");
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

                selectedIndex = Mathf.Clamp(selectedIndex, 0.0f, buttons.Length - 1);
                if (Input.GetButtonDown("Submit"))
                {
                    //selectedIndexの小数を切り捨てます
                    var index = Mathf.FloorToInt(selectedIndex);

                    switch (index)
                    {
                        case 0:
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                            break;
                        case 1:
                            SceneManager.LoadScene("Title");
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
                yield return null;
            }
        }
        #endregion
    }
}
