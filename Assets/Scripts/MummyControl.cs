using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    public class MummyControl : EnemyControl
    {
        private Rigidbody2D m_rigidbody;

        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }

        protected override void FeetDamage(Damage damage) {}

        protected override void WeaponDamage(Damage damage)
        {
            Controller.Animator.onStop.AddListener(Restore);
            Controller.Animator.Play("Die", true);
            m_rigidbody.isKinematic = true;
            enabled = false;
            Controller.Life = 0;
        }

        void Restore()
        {
            Controller.Animator.onStop.RemoveListener(Restore);
            Controller.Life = 1;
            enabled = true;
            m_rigidbody.isKinematic = false;
        }
    }
}
