using UnityEngine;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// 『プレイヤー』の制御を表します
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region SerializeField
        //移動速度を指定します
        [SerializeField]
        private float moveSpeed = 5.0f;
        //旋回速度を指定します
        [SerializeField]
        private float rotateSpeed = 1.0f;
        //カスタムの重力を指定します
        [SerializeField]
        private Vector3 localGravity = default;
        //フォロー先を指定します
        [SerializeField]
        private Transform followerRoot = default;
        //生存先を指定します
        [SerializeField]
        private Transform ActiveRoot = default;
        #endregion

        #region private variable
        //カスタムで使うRigidbodyです
        private new Rigidbody rigidbody = default;
        //SceneControllerのプロパティの参照用です
        private SceneController sceneController = default;
        #endregion

        //開始時に呼ばれます
        private void Start()
        {
            //事前にコンポーネントします
            rigidbody = GetComponent<Rigidbody>();
            sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
            //重力をなくします
            rigidbody.useGravity = false;
        }

        //毎フレーム呼ばれます
        private void Update()
        {
            if (sceneController.IsActive)
            {
                MoveController();
            }
        }

        //一定時間ごとに呼ばれます
        private void FixedUpdate()
        {
            SetLocalGravity();
        }

        #region MoveController method
        /// <summary>
        /// プレイヤーの移動を制御します
        /// </summary>
        private void MoveController()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            rigidbody.velocity = transform.forward * moveSpeed * vertical;
            transform.Rotate(0.0f, rotateSpeed * horizontal, 0.0f);
        }
        #endregion

        #region SetLocalGravity method
        /// <summary>
        /// カスタム重力の制御をします
        /// </summary>
        private void SetLocalGravity()
        {
            rigidbody.AddForce(localGravity, ForceMode.Acceleration);
        }
        #endregion

        /// <summary>
        /// コライダーに入ったら呼ばれます
        /// </summary>
        /// <param name="other">侵入したコライダー</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Boids"))
            {
                other.gameObject.transform.parent = followerRoot.gameObject.transform;
            }
        }

        /// <summary>
        /// コライダーから出たら呼ばれます
        /// </summary>
        /// <param name="other">出て行ったコライダー</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Boids"))
            {
                other.gameObject.transform.parent = ActiveRoot.gameObject.transform;
            }
        }
    }
}