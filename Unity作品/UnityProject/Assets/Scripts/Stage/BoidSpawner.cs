using UnityEngine;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// Boidの発生を制御を表します
    /// </summary>
    public class BoidSpawner : MonoBehaviour
    {
        #region SerializeField
        // 生成するボイドのプレハブを指定します。
        [SerializeField]
        private GameObject boidPrefab = null;
        // 生成するボイドの数を指定します。
        [SerializeField]
        private int count = 99;
        // ボイドを生成する立方体の最小値を指定します
        [SerializeField]
        private Vector3 minSpawnRange = new Vector3(-100, 1.1f, -100);
        //ボイドを生成する立方体の最大値を指定します。
        [SerializeField]
        private Vector3 maxSpawnRange = new Vector3(100, 1.1f, 100);
        // 生存ペンギンのルート
        [SerializeField]
        private Transform activeRoot = default;
        // 脱出ペンギンのルート
        [SerializeField]
        private Transform escapeRoot = default;
        //追従ペンギンのルート
        [SerializeField]
        private Transform followRoot = default;
        #endregion

        #region public property
        /// <summary>
        /// 生存者数を取得します。
        /// </summary>
        public int ActiveCount { get { return activeRoot.childCount; } }
        /// <summary>
        /// 追尾中のBoidsの数を取得します
        /// </summary>
        public int FollowCount { get { return followRoot.childCount; } }
        /// <summary>
        /// 脱出者数を取得します。
        /// </summary>
        public int EscapeCount { get { return escapeRoot.childCount; } }
        #endregion

        //開始時に呼ばれます
        private void Start()
        {
            Spawn(count);
        }

        #region Spawn method
        /// <summary>
        /// boidを発生させます
        /// </summary>
        /// <param name="count">boidの発生数</param>
        private void Spawn(int count)
        {
            Vector3 position = Vector3.zero;
            for (int index = 0; index < count; index++)
            {
                var boid = Instantiate(boidPrefab, transform);
                position.x = Random.Range(minSpawnRange.x, maxSpawnRange.x);
                position.y = Random.Range(minSpawnRange.y, maxSpawnRange.y);
                position.z = Random.Range(minSpawnRange.z, maxSpawnRange.z);
                boid.transform.position = position;
                boid.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360.0f), 0);
                boid.GetComponent<FlockPenguin>().Parent = transform;
            }
        }
        #endregion
    }
}