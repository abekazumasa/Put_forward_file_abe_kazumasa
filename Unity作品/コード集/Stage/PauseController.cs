using UnityEngine;
using UnityEngine.SceneManagement;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// 『ポーズ画面』のスクリプト制御を表します
    /// </summary>
    public class PauseController : MonoBehaviour
    {
        #region SerializeField
        /// <summary>
        /// 「げーむにもどる」「もういちど」「たいとるへ」を指定します
        /// </summary>
        /// <remarks>
        /// buttons[0]   RemoveButton
        /// buttons[1]   RetryButton
        /// buttons[2]   TitleButton
        /// </remarks>
        [SerializeField]
        private Transform[] buttons = default;
        //ボタンの大きさを指定します
        [SerializeField]
        private Vector3 bouttonScale = new Vector3(1.2f, 1.2f, 1.0f);
        //ボタン移動の速度を指定します
        [SerializeField]
        private float cursorSpeed = 0.0f;
        // ゲームに戻るときのSE  を指定します。
        [SerializeField]
        private AudioClip audioClips = default;
        #endregion

        #region private variable
        //ボタン選択用
        private float selectedIndex = 0;
        //SceneController参照用です
        private SceneController sceneController = default;
        //AudioSourceの参照用です
        private AudioSource audioSource = default;
        #endregion

        //開始時に呼び出されます
        private void Start()
        {
            sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
            audioSource = sceneController.transform.GetComponent<AudioSource>();
        }

        //毎フレーム呼ばれます
        private void Update()
        {
            StartPuse();
        }

        #region StartPuse method
        /// <summary>
        /// このメソットが呼び出されたときボタンを制御します
        /// </summary>
        private void StartPuse()
        {

            //ボタンの選択
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
            //最大値を超えないようにします
            selectedIndex = Mathf.Clamp(selectedIndex, 0.0f, buttons.Length - 1);

            if (Input.GetButtonDown("Submit"))
            {
                //小数を切り捨てます
                var index = Mathf.FloorToInt(selectedIndex);

                switch (index)
                {
                    case 0:
                        audioSource.Play();
                        audioSource.PlayOneShot(audioClips);
                        //IsActiveをtureにこのオブジェクトを削除します
                        sceneController.IsActive = true;
                        Destroy(gameObject);
                        break;
                    case 1:
                        //ステージを再読み込みします
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        break;
                    case 2:
                        //タイトルにもどります
                        SceneManager.LoadScene("Title");
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
    }
}
