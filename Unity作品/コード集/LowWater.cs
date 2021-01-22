using UnityEngine;

namespace EscapePenguin
{
    /// <summary>
    /// planeの生成の制御を表します
    /// </summary>
    public class LowWater : MonoBehaviour
    {
        #region SerializeField
        //横の頂点の数を指定します
        [SerializeField]
        private int widthSegments = 1;
        //縦の頂点の数を指定します
        [SerializeField]
        private int lengthSegments = 1;
        //Planeの横幅を指定します
        [SerializeField]
        private float fieldWidth = 1.0f;
        //Planeの横幅を指定します
        [SerializeField]
        private float fieldLength = 1.0f;
        #endregion

        //起動時に呼び出されます
        private void Awake()
        {
            CreatePlane();
        }

        #region CreatePlane method
        /// <summary>
        /// Planeの生成の設定です
        /// </summary>
        private void CreatePlane()
        {
            Mesh mesh = new Mesh();

            int widthCount = widthSegments + 1;
            int lengthCount = lengthSegments + 1;
            //頂点の最大数
            int vertice = lengthCount * widthCount;
            //頂点を置く場所
            Vector3[] vertices = new Vector3[vertice];
            //それぞれの最大最小を指定します
            widthSegments = Mathf.Clamp(widthSegments, 1, 254);
            lengthSegments = Mathf.Clamp(lengthSegments, 1, 254);

            //三角形の最大数
            int triangle = widthSegments * lengthSegments * 6;

            //Mashのもとのベースのテクスチャー座標
            Vector2[] uvs = new Vector2[vertice];
            //三角形の数
            int[] triangles = new int[triangle];
            //三角形の場所
            Vector4[] tangents = new Vector4[vertice];
            //正接
            Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
            //頂点の始点
            Vector2 anchorOffset = Vector2.zero;
            //頂点のX方向の間隔を指定
            float uvFactorX = 1.0f / widthSegments;
            //頂点のZ方向の間隔を指定
            float uvFactorZ = 1.0f / lengthSegments;
            //planeのX方向の大きさを指定
            float scaleX = fieldWidth / widthSegments;
            //planeのZ方向の大きさを指定
            float scaleZ = fieldLength / lengthSegments;

            //頂点を一定間隔でおきます
            int index = 0;
            for (float z = 0.0f; z < widthCount; z++)
            {
                for (float x = 0.0f; x < lengthCount; x++)
                {
                    vertices[index] = new Vector3(x * scaleX - fieldWidth / 2f - anchorOffset.x, 0, z * scaleZ - fieldLength / 2f - anchorOffset.y);
                    tangents[index] = tangent;
                    uvs[index++] = new Vector2(x * uvFactorX, z * uvFactorZ);
                }
            }

            //描写します
            index = 0;
            for (int z = 0; z < lengthSegments; z++)
            {
                for (int x = 0; x < widthSegments; x++)
                {
                    triangles[index] = (z * lengthCount) + x;
                    triangles[index + 1] = ((z + 1) * lengthCount) + x;
                    triangles[index + 2] = (z * lengthCount) + x + 1;

                    triangles[index + 3] = ((z + 1) * lengthCount) + x;
                    triangles[index + 4] = ((z + 1) * lengthCount) + x + 1;
                    triangles[index + 5] = (z * lengthCount) + x + 1;
                    index += 6;
                }
            }
            //更新します
            mesh.vertices = vertices;
            mesh.uv = uvs;
            mesh.triangles = triangles;
            mesh.tangents = tangents;
            mesh.RecalculateNormals();

            //meshにコンポーネントします
            GetComponent<MeshFilter>().sharedMesh = mesh;
        }
        #endregion
    }
}