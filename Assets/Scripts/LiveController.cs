using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LiveController : MonoBehaviour
    {
        private AudioSource m_heart;
        private SpriteRenderer m_renderer;

        void Awake()
        {
            m_heart = GetComponent<AudioSource>();
            m_renderer = GetComponent<SpriteRenderer>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && enabled)
            {
                enabled = false;
                m_heart.Play();
                m_renderer.enabled = false;
                GameManager.Instance.LiveCollected();
                Destroy(gameObject, m_heart.clip.length);
            }
        }
    }
}
