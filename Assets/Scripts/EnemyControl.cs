﻿using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(PlatformerCharacterController), typeof(AudioSource))]
    public abstract class EnemyControl : MonoBehaviour
    {
        public float Direction = 1f;

        protected PlatformerCharacterController Controller
        {
            get { return m_controller; }
        }

        protected AudioSource AudioHurt;

        [SerializeField] private LayerMask m_WhatIsWall;
        [SerializeField] private float m_damage;

        const float k_GroundedRadius = .2f;
        private PlatformerCharacterController m_controller;
        private Transform m_sideCollision;

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player" && m_controller.IsAlive)
            {
                float sym = transform.localScale.x/Mathf.Abs(transform.localScale.x);
                Vector2 vector = new Vector2(transform.right.x * sym, transform.right.y);
                Flip();
                col.gameObject.BroadcastMessage("EnemyCollision", new Damage(m_damage, vector));
            }
        }

        void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player" && m_controller.IsAlive)
            {
                float sym = transform.localScale.x / Mathf.Abs(transform.localScale.x);
                Vector2 vector = new Vector2(transform.right.x * sym, transform.right.y);
                col.gameObject.BroadcastMessage("EnemyCollision", new Damage(m_damage, vector));
            }
        }

        protected abstract void FeetDamage(Damage damage);

        protected abstract void WeaponDamage(Damage damage);
        
        // Use this for initialization
        void Awake()
        {
            m_controller = GetComponent<PlatformerCharacterController>();
            m_sideCollision = transform.Find("SideCollisionDetector");
            AudioHurt = GetComponent<AudioSource>();
        }
        
        void FixedUpdate()
        {
            if (m_controller.IsAlive && GameManager.Instance.AllowMovement)
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
                    Flip();
                m_controller.Move(0.1f*Direction, false);
            }
            else if (!GameManager.Instance.AllowMovement)
                m_controller.Stop();
        }

        protected void Flip()
        {
            Direction *= -1;
        }
    }
}