﻿using UnityEngine;
using System.Collections;
// ReSharper disable CheckNamespace

namespace MandarineStudio.AncientTreaseures
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteAnimator))]
    public class PlatformerCharacterController : MonoBehaviour
    {
        public bool IsGrounded
        {
            get { return m_grounded; }
        }

        public float Life
        {
            get { return m_life; }
            set { m_life = value; }
        }

        public bool IsAlive
        {
            get { return m_life > 0; }
        }

        [SerializeField] private float m_JumpForce = 100f;
        [SerializeField] private float m_MaxSpeed = 10f;
        [SerializeField] private LayerMask m_WhatIsGround;
        [SerializeField] private float m_life;

        private Transform m_groundCheck;
        const float k_GroundedRadius = .2f;
        private Rigidbody2D m_rigidbody2D;
        private SpriteAnimator m_animator;
        private bool m_facingRight = true;
        private bool m_grounded = true;
        
        void Awake()
        {
            m_groundCheck = transform.Find("GroundCheck");
            m_rigidbody2D = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<SpriteAnimator>();
        }

        void FixedUpdate()
        {
            m_grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundCheck.position, k_GroundedRadius, m_WhatIsGround);
            foreach (Collider2D col in colliders)
            {
                if (col.gameObject != gameObject)
                    m_grounded = true;
            }
        }

        public void Move(float move, bool jump)
        {
            // TODO: Set movement animation
            m_rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_rigidbody2D.velocity.y);

            if (move > 0 && !m_facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_facingRight)
            {
                // ... flip the player.
                Flip();
            }

            if (m_grounded && jump)
            {
                m_grounded = false;
                // TODO: Set jump animation
                m_rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_facingRight = !m_facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public void Damage(Damage damage)
        {
            m_life -= damage.Amount;
            if (!IsAlive)
                TriggerDeath();
            else
                m_rigidbody2D.AddForce(damage.Direction*3000f);
        }

        private void TriggerDeath()
        {
            // TODO: Launch animation and subscribe to its end
            m_rigidbody2D.isKinematic = true;
            GetComponent<Collider2D>().isTrigger = true;
            Die();
        }

        private void Die()
        {
            Destroy(gameObject, 1.0f);
        }
    }
}