using UnityEngine;
namespace EscapePenguin.Stage
{
    public class FlockPenguin : MonoBehaviour
    {
        #region public property
        public Transform Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        [SerializeField]
        private Transform parent = null;
        #endregion

        //移動時の最大速度
        [SerializeField]
        private float moveSpeed = 8f;

        #region private variable
        //追う物をの設定
        private GameObject tracker = default;
        //ついていくものの設定
        private GameObject follower = default;
        //シーンコントローラーを選択s
        private SceneController sceneController = default;
        //追跡中かの判定用
        private bool isChase = false;
        //ついているかの判定用
        private bool isFollow = false;
        //コンポーネントの参照用変数
        private new Rigidbody rigidbody = default;
        #endregion

        // 開始時に呼ばれます
        private void Start()
        {
            //事前にコンポーネントします
            rigidbody = GetComponent<Rigidbody>();
            sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        }

        //一定時間ごとに呼ばれます
        private void FixedUpdate()
        {
            //アクティブなら
            if (sceneController.IsActive)
            {
                if (isChase)
                {
                    ChaseMode();
                }

                if (isFollow)
                {
                    FollowMode();
                }
                else
                {
                    rigidbody.velocity = transform.forward * moveSpeed;
                    if (parent.childCount > 4)
                    {
                        rigidbody.velocity += Separation();
                        rigidbody.velocity += Alingment();
                        rigidbody.velocity += Cohesion();
                        transform.rotation = Quaternion.LookRotation(rigidbody.velocity, Vector3.up);
                    }
                }
            }
            else
            {
                rigidbody.velocity = Vector3.zero;
            }
        }

        #region ChaseMode method
        /// <summary>
        /// 逃げるように動く制御
        /// </summary>
        private void ChaseMode()
        {
            var vector = (transform.position - tracker.transform.position);
            transform.rotation = Quaternion.LookRotation(vector, Vector3.up);
            rigidbody.velocity = vector * moveSpeed;
        }
        #endregion

        #region FollowMode method
        /// <summary>
        /// ついていくように制御します
        /// </summary>
        private void FollowMode()
        {
            var velocity = Vector3.zero;
            transform.LookAt(follower.transform);
            if ((follower.transform.position - rigidbody.position).magnitude > 1.0f)
            {
                velocity += follower.transform.position - rigidbody.position;
            }
            rigidbody.velocity = velocity;
        }
        #endregion

        #region Cohesion method
        //群れの中心に行くように動かす
        private Vector3 Cohesion()
        {
            // 群れの認知中心を計算
            var perceivedCenter = Vector3.zero;
            foreach (Transform boid in parent)
            {
                // 自分は除外
                if (boid != transform)
                {
                    perceivedCenter += boid.GetComponent<Rigidbody>().position;
                }
            }
            perceivedCenter /= parent.childCount - 1;
            return (perceivedCenter - rigidbody.position) / 100;
        }
        #endregion

        #region Separation method
        // 近づきすぎて衝突しないように動かす
        private Vector3 Separation()
        {
            var velocity = Vector3.zero;
            foreach (Transform boid in Parent)
            {
                //自分は除外
                if (boid != transform)
                {
                    var boidRigidbody = boid.GetComponent<Rigidbody>();
                    // 閾値より近づいてるボイドがそんざいする場合
                    if ((boidRigidbody.position - rigidbody.position).magnitude < 5.0f)
                    {
                        velocity -= boidRigidbody.position - rigidbody.position;
                    }
                }
            }
            return velocity;
        }
        #endregion

        #region Alingment method
        //群れの進む方向に合わせて移動します
        private Vector3 Alingment()
        {
            //群れの認知速度（平均速度で代用）を計算
            Vector3 perceivedVelocity = Vector3.zero;
            foreach (Transform boid in Parent)
            {
                //自分は除外
                if (boid != transform)
                {
                    perceivedVelocity += boid.GetComponent<Rigidbody>().velocity;
                }
            }
            perceivedVelocity /= Parent.childCount - 1;
            return (perceivedVelocity - rigidbody.velocity) / 8;
        }
        #endregion

        /// <summary>
        /// コライダーに入ったら呼び出します
        /// </summary>
        /// <param name="other">コライダーに入ってきたtag</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                tracker = other.transform.gameObject;
                isChase = true;
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                follower = other.transform.gameObject;
                isFollow = true;
            }
        }

        /// <summary>
        /// コライダーに入ったら呼び出します
        /// </summary>
        /// <param name="other">コライダーに入ってきたtag</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                isChase = false;
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                isFollow = false;
            }
        }
    }
}