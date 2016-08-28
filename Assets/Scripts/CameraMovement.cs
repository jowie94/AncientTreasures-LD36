using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreaseures
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform Target
        {
            get { return m_target; }
            set
            {
                m_target = value;
                ForcePosition(value.position);
            }
        }

        public float Speed = 1.0f;

        private Transform m_target;
        private bool m_stopped;
        private Vector3 m_lastPosition;
        private float m_zDistance;

        void Awake()
        {
            m_stopped = true;
            m_zDistance = transform.position.z;
            //m_lastPosition = Target.position;
            //m_lastPosition.z = m_zDistance;
            //transform.position = m_lastPosition;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            float smooth = 1.0f - Mathf.Pow(0.5f, Time.deltaTime*Speed);
            Vector3 result = Vector3.Lerp(transform.position, Target.position, smooth);
            result.z = m_zDistance;
            transform.position = result;
        }

        public void ForcePosition(Vector3 position)
        {
            position.z = m_zDistance;
            transform.position = position;
        }
    }
}
