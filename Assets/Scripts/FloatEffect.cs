using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    public class FloatEffect : MonoBehaviour
    {
        public float FloatingSpeed = 10f;

        private float m_angle = 0;
        private float m_yPosition;
        private float m_maxUpAndDown = 0.1f;


        void Start()
        {
            m_yPosition = transform.localPosition.y;
        }

        void Update () {
            m_angle += FloatingSpeed * Time.deltaTime;
            if (m_angle > 360) m_angle -= 360;
            Vector3 pos = transform.localPosition;
            pos.y = m_yPosition + m_maxUpAndDown * Mathf.Sin(m_angle * Mathf.Deg2Rad);
            transform.localPosition = pos;
        }
    }
}
