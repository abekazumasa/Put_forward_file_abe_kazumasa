using UnityEngine;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// カメラの制御を表します
    /// </summary>
    public class ChaseCamera : MonoBehaviour
    {
        //対象を指定します
        [SerializeField]
        private Transform target = null;

        // 毎フレーム呼ばれます
        private void Update()
        {
            //対象に移動します
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}
