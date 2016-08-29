using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(UseOnPlayerTrigger))]
    public class ChestControl : MonoBehaviour
    {
        private AudioSource m_chest;
        public float NumberOfGems = 0f;

        private SpriteAnimator m_animator;
        void Awake()
        {
            m_animator = GetComponent<SpriteAnimator>();
            m_chest = GetComponent<AudioSource>();
        }

        void OpenChest()
        {
            m_chest.Play();
            m_animator.onStop.AddListener(Give);
            m_animator.Play("Open", true);
        }

        void Give()
        {
            m_animator.onStop.RemoveListener(Give);
            m_animator.Play("Opened");
            GameManager.Instance.ChestOpened(NumberOfGems);
        }
    }
}
