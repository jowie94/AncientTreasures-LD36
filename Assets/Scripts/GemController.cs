using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(BoxCollider2D), typeof(AudioSource))]
    public class GemController : MonoBehaviour
    {
        private AudioSource m_rupee;
        private SpriteRenderer m_renderer;

        void Awake()
        {
            m_rupee = GetComponent<AudioSource>();
            m_renderer = GetComponent<SpriteRenderer>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && enabled)
            {
                enabled = false;
                m_rupee.Play();
                m_renderer.enabled = false;
                GameManager.Instance.GemCollected();
                Destroy(gameObject, m_rupee.clip.length);
            }
        }
    }
}
