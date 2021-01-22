using UnityEngine;
namespace EscapePenguin.Stage
{
    /// <summary>
    /// 『Goal』を制御を表します
    /// </summary>
    public class GoalController : MonoBehaviour
    {
        //脱出する場所を指定します
        [SerializeField]
        private Transform Escapes = default;
        //Escapeした時のSEを指定します
        [SerializeField]
        private AudioClip audioClip = default;

        //SceneController参照用です
        private SceneController sceneController = default;
        //AudioSource参照用です
        private AudioSource audioSource = default;

        private void Start()
        {
            sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
            audioSource = sceneController.transform.GetComponent<AudioSource>();
        }
        /// <summary>
        ///コライダーが入ったら呼ばれます 
        /// </summary>
        /// <param name="other">boidsのコライダーです</param>
        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Boids"))
            {
                audioSource.PlayOneShot(audioClip);
                other.transform.parent = Escapes.gameObject.transform;
            }
        }

    }
}
