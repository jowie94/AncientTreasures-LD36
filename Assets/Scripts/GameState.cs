using UnityEngine;

namespace MandarineStudio.AncientTreaseures
{
    class GameState : ScriptableObject
    {
        [SerializeField] private float m_life = 0f;
        [SerializeField] private float m_score = 0f;

        public float Life
        {
            get { return m_life; }
            set { m_life = value; }
        }

        public float Score
        {
            get { return m_score; }
            set { m_score = value; }
        }
    }
}
