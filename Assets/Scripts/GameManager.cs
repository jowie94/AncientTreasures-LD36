using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Lifetime;
using UnityEngine.UI;

namespace MandarineStudio.AncientTreaseures
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    GameObject go = new GameObject();
                    m_instance = go.AddComponent<GameManager>();
                    go.name = "Game Manager";
                    DontDestroyOnLoad(go);   
                }
                return m_instance;
            }
        }

        public EventSystem EventSystem
        {
            get { return m_eventSystem; }
        }

        public float Score
        {
            get { return m_gameState.Score; }
        }

        public float Life
        {
            get { return m_gameState.Life; }
            set { m_gameState.Life = value; }
        }

        private static GameManager m_instance;
        private EventSystem m_eventSystem = new EventSystem();
        private Text m_scoreText;
        private Text m_lifeText;
        private GameState m_gameState;

        void Awake()
        {
            m_gameState = ScriptableObject.CreateInstance<GameState>();
            GameObject obj = GameObject.Find("ScoreText");
            if (obj != null)
                m_scoreText = obj.GetComponent<Text>();
            obj = GameObject.Find("LifeText");
            if (obj != null)
                m_lifeText = obj.GetComponent<Text>();
        }

        public void GemCollected()
        {
            m_gameState.Score += 1f;
        }

        void LateUpdate()
        {
            // Update screen text
            if (m_scoreText != null)
                m_scoreText.text = "Score: " + Score;
            if (m_lifeText != null)
                m_lifeText.text = "Life: " + Life;
        }

        void OnLevelWasLoaded()
        {
            m_eventSystem.Reset();
            GameObject obj = GameObject.Find("ScoreText");
            if (obj != null)
                m_scoreText = obj.GetComponent<Text>();
            obj = GameObject.Find("LifeText");
            if (obj != null)
                m_lifeText = obj.GetComponent<Text>();
        }

        public void SaveGame()
        {

        }

        public void LoadGame()
        {
            
        }
    }
}