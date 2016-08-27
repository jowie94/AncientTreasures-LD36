using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreaseures
{
    [RequireComponent(typeof(PlatformerCharacterController))]
    public class MainCharacterControl : MonoBehaviour
    {
        private PlatformerCharacterController m_controller;
        private Transform m_weaponBox;
        private bool m_jump;

        private bool Attacking
        {
            get { return m_weaponBox.gameObject.activeSelf; }
            set { m_weaponBox.gameObject.SetActive(value); }
        }

        void Awake()
        {
            m_controller = GetComponent<PlatformerCharacterController>();
            m_weaponBox = transform.Find("WeaponBox");
        }

        // Update is called once per frame
        void Update()
        {
            if (!m_jump)
                m_jump = Input.GetButtonDown("Jump");
        }

        void FixedUpdate()
        {
            float move = Input.GetAxis("Horizontal");
            if (!Attacking)
                m_controller.Move(move, m_jump);
            m_jump = false;
            if (!Attacking && m_controller.IsGrounded && Input.GetButtonDown("Fire1"))
                Attack();
        }

        void Attack()
        {
            Attacking = true;
            StartCoroutine(DisableAttack());
        }

        // TODO: Temporal while waiting for animations
        IEnumerator DisableAttack()
        {
            yield return new WaitForSeconds(0.5f);
            Attacking = false;
            yield return null;
        }

        void EnemyCollision(Damage damage)
        {
            m_controller.Damage(damage);
        }
    }
}
