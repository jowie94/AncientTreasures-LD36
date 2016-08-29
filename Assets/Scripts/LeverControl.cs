using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(UseOnPlayerTrigger), typeof(SpriteAnimator))]
    public class LeverControl : MonoBehaviour
    {
        public string EventName;

        private SpriteAnimator m_animator;

        void Awake ()
        {
            m_animator = GetComponent<SpriteAnimator>();
        }

        void ActivateLever()
        {
            m_animator.Play("Move", true);
            m_animator.onStop.AddListener(Action);
        }

        void Action()
        {
            GameManager.Instance.EventSystem.Trigger(EventName);
            m_animator.onStop.RemoveListener(Action);
            m_animator.Play("On", true);
        }
    }
}
