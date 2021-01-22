using UnityEngine;

namespace EscapePenguin
{
    /// <summary>
    /// 波の生成を制御を表します
    /// </summary>
    public class CreateWave : MonoBehaviour
    {
        #region SerializeField
        //波の発生地点を指定します
        [SerializeField]
        private Vector3 wavePostion = new Vector3(0.0f, 0.0f, 0.0f);
        //波長の長さを指定します
        [SerializeField]
        private float waveLength = 0.75f;
        //波の高さを指定します
        [SerializeField]
        private float waveHeight = 0.5f;
        //波の頻度を指定します
        [SerializeField]
        private float waveFrequeny = 0.5f;
        #endregion

        #region variable
        //参照用です
        private Vector3[] vectors = null;
        private Mesh mesh = null;
        private MeshFilter filter = null;
        #endregion

        //起動時に呼び出されます
        private void Awake()
        {
            filter = GetComponent<MeshFilter>();
        }

        // 開始時に呼ばれます
        private void Start()
        {
            CreateMesh(filter);

        }

        // 毎フレーム呼ばれます
        private void Update()
        {
            Waves();
        }

        #region CreateMesh method
        /// <summary>
        /// Meshを生成します
        /// </summary>
        /// <param name="meshFilter">生成場所</param>
        /// <returns></returns>
        private MeshFilter CreateMesh(MeshFilter meshFilter)
        {
            mesh = meshFilter.sharedMesh;

            Vector3[] originalVertices = mesh.vertices;

            int[] triangles = mesh.triangles;

            Vector3[] vertices = new Vector3[triangles.Length];

            for (int i = 0; i < triangles.Length; i++)
            {
                vertices[i] = originalVertices[triangles[i]];
                triangles[i] = i;
            }
            //更新します
            mesh.vertices = vertices;
            mesh.SetTriangles(triangles, 0);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            vectors = mesh.vertices;

            return meshFilter;
        }
        #endregion

        #region Waves method
        /// <summary>
        /// 波を制御します
        /// </summary>
        private void Waves()
        {
            for (int index = 0; index < vectors.Length; index++)
            {
                //頂点の座標を指定します
                Vector3 apex = vectors[index];

                apex.y = 0.0f;
                //頂点と波の発生地点の差を調べます
                float distance = Vector3.Distance(apex, wavePostion);
                distance = (distance % waveLength) / waveLength;

                apex.y = waveHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * waveFrequeny + (Mathf.PI * 2.0f * distance));
                vectors[index] = apex;
            }
            //更新します
            mesh.vertices = vectors;
            mesh.RecalculateNormals();
            mesh.MarkDynamic();
            filter.mesh = mesh;
        }
        #endregion

    }
}