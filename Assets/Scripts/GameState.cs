using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    class GameState : ScriptableObject
    {
        [SerializeField] private float m_life = 10f;
        [SerializeField] private float m_score = 0f;
        [SerializeField] private GameObject m_entities;

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

        public GameObject Entities
        {
            get { return m_entities; }
            set { m_entities = value; }
        }
    }
}
