using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
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

        const float Step = 1f;

        private float m_currentStep = Step;
        private Transform m_target;
        private bool m_stopped;
        private Vector3 m_lastPosition;
        private Vector3 m_lastCameraPosition;
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
            if (m_lastPosition == Target.position && m_lastCameraPosition == transform.position)
            {
                m_currentStep = Step;
            }
            else
            {
                m_lastCameraPosition = transform.position;
                Vector3 result = Vector3.Lerp(transform.position, Target.position, 1 - m_currentStep);
                m_currentStep -= Time.deltaTime*0.1f;
                result.z = m_zDistance;
                transform.position = result;
                m_lastPosition = Target.position;
            }
        }

        public void ForcePosition(Vector3 position)
        {
            m_lastPosition = position;
            position.z = m_zDistance;
            transform.position = position;
            m_lastCameraPosition = transform.position;
        }
    }
}
