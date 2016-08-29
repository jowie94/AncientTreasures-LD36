using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(PlatformerCharacterController))]
    public class MainCharacterControl : MonoBehaviour
    {
        private PlatformerCharacterController m_controller;
        private Transform m_weaponBox;
        private Transform m_feetBox;
        private bool m_jump;
        private bool m_blinking = false;
        private Renderer m_renderer;

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
            m_renderer = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!m_jump)
                m_jump = Input.GetButtonDown("Jump");
        }

        void FixedUpdate()
        {
            if (m_controller.IsAlive)
            {
                float move = Input.GetAxis("Horizontal");
                if (!Attacking)
                    m_controller.Move(move, m_jump);
                m_feetBox.gameObject.SetActive(!m_controller.IsGrounded);
                m_jump = false;
                if (!Attacking && m_controller.IsGrounded && Input.GetButtonDown("Fire1"))
                    Attack();
            }
        }

        void Attack()
        {
            Attacking = true;
            m_controller.Stop();
            m_controller.Animator.Play("Attack", true);
            m_controller.Animator.onStop.AddListener(FinishAttack);
        }

        void FinishAttack()
        {
            Attacking = false;
            m_controller.SetIdle();
            m_controller.Animator.onFinish.RemoveListener(FinishAttack);
        }

        IEnumerator DamageBlink()
        {
            m_blinking = true;
            for (int n = 0; n < 5; n++)
            {
                m_renderer.enabled = true;
                yield return new WaitForSeconds(0.1f);
                m_renderer.enabled = false;
                yield return new WaitForSeconds(0.1f);
            }
            m_renderer.enabled = true;
            m_blinking = false;
        }

        void EnemyCollision(Damage damage)
        {
            if (!m_blinking)
            {
                m_controller.Damage(damage);
                if (m_controller.IsAlive)
                    StartCoroutine(DamageBlink());
            }
        }
    }
}
