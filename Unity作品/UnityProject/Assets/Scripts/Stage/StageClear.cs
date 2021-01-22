using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// ゲームクリア演出を制御を表します
    /// </summary>
    public class StageClear : MonoBehaviour
    {
        //開始時に呼ばれます
        private void Start()
        {
            StartCoroutine(StartClear());
        }

        /// <summary>
        /// クリアー演出を制御します
        /// </summary>
        private IEnumerator StartClear()
        {
            //2秒待ってからリザルトに移動
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Result");
        }
    }

}