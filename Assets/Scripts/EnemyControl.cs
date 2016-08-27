using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreaseures
{
    [RequireComponent(typeof(PlatformerCharacterController))]
    public class EnemyControl : MonoBehaviour
    {
        [SerializeField] private LayerMask m_WhatIsWall;
        [SerializeField] private float m_damage;

        const float k_GroundedRadius = .2f;
        private PlatformerCharacterController m_controller;
        private Transform m_sideCollision;
        public float m_direction = 1f;

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player" && m_controller.IsAlive)
            {
                float sym = transform.localScale.x/Mathf.Abs(transform.localScale.x);
                Vector2 vector = new Vector2(col.transform.right.x * sym, col.transform.right.y);
                m_direction *= -1;
                col.gameObject.BroadcastMessage("EnemyCollision", new Damage(m_damage, vector));
            }
        }

        void WeaponDamage(Damage damage)
        {
            m_controller.Damage(damage);
        }

        // Use this for initialization
        void Awake()
        {
            m_controller = GetComponent<PlatformerCharacterController>();
            m_sideCollision = transform.Find("SideCollisionDetector");
        }
        
        void FixedUpdate()
        {
            if (m_controller.IsAlive)
            {
                bool hasCollided = false;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(m_sideCollision.position, k_GroundedRadius,
                    m_WhatIsWall);
                foreach (Collider2D col in colliders)
                {
                    if (col.gameObject != gameObject)
                        hasCollided = true;
                }

                if (hasCollided)
                    m_direction *= -1;
                m_controller.Move(0.1f*m_direction, false);
            }
        }
    }

}