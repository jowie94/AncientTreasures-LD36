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
        private GameState m_lastCheckpointState;
        private Spawn m_lastCheckpoint;
        private GameState m_gameState;
        private PlatformerCharacterController m_playerCharacter;

        void Awake()
        {
            m_gameState = ScriptableObject.CreateInstance<GameState>();
            ReloadComponents();
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
            ReloadComponents();
        }

        private void ReloadComponents()
        {
            GameObject obj = GameObject.Find("ScoreText");
            if (obj != null)
                m_scoreText = obj.GetComponent<Text>();
            obj = GameObject.Find("LifeText");
            if (obj != null)
                m_lifeText = obj.GetComponent<Text>();
            obj = GameObject.Find("Player");
            if (obj != null)
            {
                m_playerCharacter = obj.GetComponent<PlatformerCharacterController>();
                if (m_playerCharacter)
                {
                    m_playerCharacter.OnLife.AddListener(life => Life = life);
                    m_playerCharacter.OnDied.AddListener(() => {}); // TODO
                }
            }

        }

        public void Checkpoint(Spawn spawn)
        {
            m_lastCheckpointState = Instantiate(m_gameState);
            m_lastCheckpoint = spawn;
        }

        public void ReloadCheckpoint()
        {
            m_gameState = m_lastCheckpointState;
            m_lastCheckpoint.SpawnPlayer();
        }

        public void SaveGame()
        {

        }

        public void LoadGame()
        {
            
        }
    }
}