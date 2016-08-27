using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1.0f;

    private bool m_stopped;
    private Vector3 m_lastPosition;
    private float m_zDistance;

    void Start()
    {
        m_stopped = true;
        m_zDistance = transform.position.z;
        m_lastPosition = Target.position;
        m_lastPosition.z = m_zDistance;
        transform.position = m_lastPosition;
    }
    
    // Update is called once per frame
    void LateUpdate ()
    {
        if (Target.position.Equals(m_lastPosition))
        {
            m_stopped = true;
        }
        else
        {
            float smooth = 1.0f - Mathf.Pow(0.5f, Time.deltaTime * Speed);
            Vector3 result = Vector3.Lerp(transform.position, Target.position, smooth);
            result.z = m_zDistance;
            transform.position = result;
        }
    }
}
