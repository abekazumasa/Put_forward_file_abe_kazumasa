using UnityEngine;
using UnityEngine.UI;

namespace EscapePenguin.Stage
{
    /// <summary>
    /// 『ステージ画面』内の進行制御を表します。
    /// </summary>
    public class SceneController : MonoBehaviour
    {
        #region public property
        /// <summary>
        /// 全体の挙動の制御します
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        bool isActive = false;
        #endregion

        #region SerializeField
        //スタート開始演出のPrefabを指定します
        [SerializeField]
        private GameObject startPrefab = default;
        //ゲームオーバー演出のPrefabを指定します
        [SerializeField]
        private GameObject gameOverPrefab = default;
        //ゲームクリア演出のPrefabを指定します
        [SerializeField]
        private GameObject stageClearPrefab = default;
        //ポーズのPrefabを指定します
        [SerializeField]
        private GameObject pausePrefab = default;
        //ゲーム中UI表示Canvasを指定します
        [SerializeField]
        private Transform canvasRoot = default;
        //Boid発生オブジェクトを指定します
        [SerializeField]
        private BoidSpawner boidSpawner = default;
        [SerializeField]
        private int NumberAchieved = 0;
        //タイマーの分を設定します
        [SerializeField]
        private float minute = 3f;
        //タイマーの秒を設定します
        [SerializeField]
        private float second = 0f;
        //Pauseを押された時のSEを指定します
        [SerializeField]
        private AudioClip audioClip = default;
        #endregion

        #region　private variable
        //全体のタイマーです
        private float totalTime = 0f;
        //古い時間です
        private float oldSecond = 0f;
        //boids全体の数です
        private int totalCount = 0;
        //AudioSource参照用です
        private AudioSource audioSource = default;
        #endregion

        //開始時によばれます
        private void Start()
        {
            totalTime = minute * 60 + second;
            Instantiate(startPrefab, canvasRoot);
            boidSpawner = boidSpawner.GetComponent<BoidSpawner>();
            audioSource = GetComponent<AudioSource>();
        }

        //毎フレーム呼ばれます
        private void Update()
        {
            ActiveCount();
            EscapeCount();
            totalCount = boidSpawner.FollowCount + boidSpawner.ActiveCount;

            if (isActive)
            {
                
                TimerControll();
                PauseControll();

                if (totalCount <= 0 || second < 0)
                {
                    if (boidSpawner.EscapeCount > NumberAchieved)
                    {
                        Result.SceneController.ClearEscape = boidSpawner.EscapeCount;
                        Instantiate(stageClearPrefab, canvasRoot);
                    }
                    else
                    {
                        IsActive = false;
                        Instantiate(gameOverPrefab, canvasRoot);
                    }
                }

                DebugControll();
            }
        }

        #region EscapeCount method
        /// <summary>
        /// 残りの脱出数です
        /// </summary>
        private void EscapeCount()
        {
            //Escapeの中のテキストを探します
            var escapeRoot = canvasRoot.Find("Escape/Text");
            //Textをコンポーネントします
            var text = escapeRoot.GetComponent<Text>();

            text.text = "残り" + (NumberAchieved - boidSpawner.EscapeCount);
            //達成数を超えたら表示を変えます
            if ((NumberAchieved - boidSpawner.EscapeCount) <= 0)
            {
                text.text = "脱出人数" + boidSpawner.EscapeCount;
            }
        }
        #endregion

        #region ActiveCount method
        /// <summary>
        /// 残りの生存数です
        /// </summary>
        private void ActiveCount()
        {
            //BoidsActiveの中のテキストを探します
            var activeRoot = canvasRoot.Find("BoidsActive/Text");
            //Textをコンポーネントします
            var text = activeRoot.GetComponent<Text>();
            text.text = "x" + totalCount;
        }
        #endregion

        #region TimerControll method
        /// <summary>
        /// タイマーの制御です
        /// </summary>
        private void TimerControll()
        {
            totalTime = minute * 60 + second;
            totalTime -= Time.deltaTime;
            minute = (int)totalTime / 60;
            second = totalTime - minute * 60;
            //Timeの中のTextを探します
            var timerRoot = canvasRoot.Find("Time/Text");
            //Textをコンポーネントします
            var text = timerRoot.gameObject.GetComponent<Text>();
            if ((int)second != (int)oldSecond)
            {
                text.text = minute.ToString("00") + ":" + second.ToString("00");
            }
            oldSecond = second;
        }
        #endregion

        #region PauseControll method
        /// <summary>
        ///Pause用のボタン制御です
        /// </summary>
        private void PauseControll()
        {
            if (Input.GetButtonDown("Pause"))
            {
                audioSource.Stop();
                audioSource.PlayOneShot(audioClip);
                Instantiate(pausePrefab, canvasRoot);
                isActive = false;
            }
        }
        #endregion

        #region DebugControll method
        /// <summary>
        ///  デバック用ボタン制御です
        /// </summary>
        private void DebugControll()
        {
#if UNITY_EDITOR

            if (Input.GetKeyUp(KeyCode.O))
            {
                IsActive = false;
                Instantiate(gameOverPrefab, canvasRoot);
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                Result.SceneController.ClearEscape = boidSpawner.EscapeCount;
                Instantiate(stageClearPrefab, canvasRoot);
            }
#endif
        }
        #endregion
    }
}


