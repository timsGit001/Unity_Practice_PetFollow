using UnityEngine;
namespace KID
{
    public class Pet : MonoBehaviour
    {
        [Header("移動速度"), Range(0, 1000)]
        public float speed = 1.5f;
        [Header("跟隨的點")]
        public Transform followPoint;
    private Player m_player; // Player腳本
        private Vector3 m_nextPos;
        private Rigidbody m_Rigidbody;
        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_player = FindObjectOfType<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            Turn(m_nextPos);
        }
        void LateUpdate()
        {
            Follow(followPoint);
            //Turn(m_nextPos);
        }

        private void Turn(Vector3 target)
        {
            transform.LookAt(target); // , Vector3.right
        }

        private void Follow(Transform target)
        {
            Turn(m_player.transform.position);
            m_nextPos = Vector3.Lerp(transform.position, target.position, 0.5f * speed * Time.deltaTime);
            transform.position = m_nextPos;
            //m_Rigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }
}
