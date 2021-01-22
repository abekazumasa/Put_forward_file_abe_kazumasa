using System.Collections.Generic;
//using TMPro;
using UnityEngine;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// 『Enemy』の制御を表します
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        //boidsを獲得するためのList
        readonly List<FlockPenguin> boids = new List<FlockPenguin>();

        #region SerializeField
        //倒したboidsの親の指定します
        [SerializeField]
        private Transform nonActiveRoot = default;
        //移動速度を指定します
        [SerializeField]
        private float moveSpeed = 2.0f;
        //カスタム重力を指定します
        [SerializeField]
        private Vector3 localGravity = default;
        //ターゲットまでの距離を指定します
        [SerializeField]
        private float tragetDistans = 0.0f;
        //巡回する場所を指定します
        [SerializeField]
        private Transform[] patrolPos = default;
        //ポイントまでの距離を指定します
        [SerializeField]
        private float patrolRange = 0.0f;
        #endregion

        #region private variable
        //カスタムで使うRigidbodyです
        private new Rigidbody rigidbody = default;
        //追う相手を指定します
        private FlockPenguin target = default;
        //パトロールする場所を指定します
        private Transform patrolTarget = default;
        //SceneControllerを呼びます
        private SceneController sceneController = default;
        //相手の距離を取得します
        private float distance = 0.0f;
        private float range = 0.0f;
        //ターゲットを固定します
        private int randomTraking = 0;
        private int patrolNumber = 0;
        //相手が決まってるかの判定用です
        private bool isRandomStop = false;
        private bool isPatrol = false;
        #endregion

        // 開始時に呼ばれます
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
            rigidbody.useGravity = false;
        }

        //毎フレーム呼ばれます
        private void Update()
        {
            if (sceneController.IsActive && boids.Count > 0)
            {
                randomTraking = Random.Range(0, boids.Count);
                if (!isRandomStop)
                {
                    target = boids[randomTraking];
                    isRandomStop = true;
                }
                else
                {
                    DoTraking();
                }
            }
            else
            {
                patrolNumber = Random.Range(0, patrolPos.Length - 1);
                if (!isPatrol)
                {
                    patrolTarget = patrolPos[patrolNumber];
                    isPatrol = true;
                }
                else
                {
                    PatrolRoot();
                }
            }

        }

        // 一定時間ごとに呼ばれます
        private void FixedUpdate()
        {
            SetLocalGravity();
        }

        #region DoTraking method
        /// <summary>
        /// Enemyの移動制御です
        /// </summary>
        private void DoTraking()
        {
            //ターゲットの座標を指定
            var targetPos = target.transform.position;
            distance = Vector3.Distance(transform.position, targetPos);
            transform.LookAt(targetPos);
            transform.position += transform.forward * moveSpeed;
            if (distance < tragetDistans)
            {
                target.transform.parent = nonActiveRoot.transform;
                target.gameObject.SetActive(false);
                boids.Clear();
                isRandomStop = false;
            }
        }
        #endregion
        #region PatrolRoot method
        /// <summary>
        ///追ってないときの行動パターンです 
        /// </summary>
        private void PatrolRoot()
        {   //パトロールの座標を指定
            var Patrol = patrolTarget.position;
            range = Vector3.Distance(transform.position, Patrol);
            transform.LookAt(Patrol);
            transform.position += transform.forward * moveSpeed;
            if (range < patrolRange || boids.Count > 0)
            {
                isPatrol = false;
            }
        }
        #endregion

        #region SetLocalGravity method
        /// <summary>
        /// カスタム重力の制御です
        /// </summary>
        private void SetLocalGravity()
        {
            rigidbody.AddForce(localGravity, ForceMode.Acceleration);
        }
        #endregion

        /// <summary>
        /// コライダーに入ったら呼ばれます
        /// </summary>
        /// <param name="other">Boidのコライダー</param>
        private void OnTriggerEnter(Collider other)
        {
            //boidsがコライダーに入ったらlistに追加
            if (other.gameObject.CompareTag("Boids") && other.gameObject.activeSelf)
            {
                boids.Add(other.gameObject.GetComponent<FlockPenguin>());
            }
        }

        /// <summary>
        /// コライダーから出たら呼ばれます
        /// </summary>
        /// <param name="other">Boidのコライダー</param>
        private void OnTriggerExit(Collider other)
        {
            //boidsがコライダーから出たらlistから外す
            if (other.gameObject.CompareTag("Boids"))
            {
                boids.Remove(other.gameObject.GetComponent<FlockPenguin>());
            }
        }
    }
}