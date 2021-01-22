using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// 『スタート演出』の制御を表します
    /// </summary>
    public class StratStage : MonoBehaviour
    {
        #region SerializeField
        //カウントに必要な画像を指定します
        [SerializeField]
        private Image countImage = default;
        //カウントに必要なスプライトを指定します
        [SerializeField]
        private Sprite[] countSprites = default;
        //待ち時間を指定します
        [SerializeField]
        private float waitTime = 0.0f;
        #endregion

        //SceneControllerを参照用です
        private SceneController sceneController = default;

        //開始時に呼ばれます
        private void Start()
        {
            sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
            StartCoroutine(StartCountDown());
        }

        /// <summary>
        /// カウントダウン演出を制御します
        /// </summary>
        private IEnumerator StartCountDown()
        {
            //文字の最大の大きさ
            var maxScale = new Vector3(2, 2, 1);
            //文字の最小の大きさ
            var minScale = new Vector3(1, 1, 1);
            //更新速度
            var speed = 0.1f;

            for (int index = countSprites.Length - 1; index >= 0; index--)
            {
                //各数値のリセット
                countImage.transform.localScale = minScale;
                var size = 0f;
                countImage.sprite = countSprites[index];
                while (size <= 1.0f)
                {
                    countImage.transform.localScale = Vector3.Lerp(transform.localScale, maxScale, size);
                    size += speed;
                    yield return null;
                }
                yield return new WaitForSeconds(waitTime);
            }
            sceneController.IsActive = true;
            Destroy(gameObject);
        }
    }
}
