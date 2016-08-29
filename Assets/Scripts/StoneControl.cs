using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    public class StoneControl : MonoBehaviour
    {
        public string EventListening;

        private Rigidbody2D m_stone;
        private Transform m_rope;

        void Start()
        {
            GameManager.Instance.EventSystem.Subscribe(EventListening, EventReceived);
            m_stone = GetComponentInChildren<Rigidbody2D>();
            m_rope = transform.Find("Rope");
        }

        void EventReceived()
        {
            GameManager.Instance.EventSystem.Unsubscribe(EventListening, EventReceived);
            m_stone.isKinematic = false;
            m_rope.gameObject.SetActive(false);
        }
    }
}
