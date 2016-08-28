using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreaseures
{
    [RequireComponent(typeof(PlatformerCharacterController))]
    public class MainCharacterControl : MonoBehaviour
    {
        private PlatformerCharacterController m_controller;
        private Transform m_weaponBox;
        private Transform m_feetBox;
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
            m_feetBox = transform.Find("FeetBox");
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
            m_feetBox.gameObject.SetActive(!m_controller.IsGrounded);
            m_jump = false;
            if (!Attacking && m_controller.IsGrounded && Input.GetButtonDown("Fire1"))
                Attack();
        }

        void Attack()
        {
            Attacking = true;
            m_controller.Animator.Play("Attack", true);
            m_controller.Animator.onFinish.AddListener(() =>
            {
                Attacking = false;
                m_controller.SetIdle();
                //m_controller.Animator.onFinish.RemoveListener();
            });
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
