using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreaseures
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = Instantiate(new GameManager());
                return m_instance;
            }
        }

        public EventSystem EventSystem
        {
            get { return m_eventSystem; }
        }

        public float Score
        {
            get { return m_score; }
        }

        private static GameManager m_instance;
        private EventSystem m_eventSystem = new EventSystem();

        [SerializeField] private float m_score = 0f;

        public void TakeGem()
        {
            m_score += 1f;
        }

        public void SaveGame()
        {
            
        }
    }
}