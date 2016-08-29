using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Lifetime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MandarineStudio.AncientTreasures
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
            private set { m_gameState.Life = value; }
        }

        public bool AllowMovement
        {
            get { return m_allowMovement; }
        }

        public bool SpawnPlayer = true;

        private static GameManager m_instance;
        private EventSystem m_eventSystem = new EventSystem();
        private Text m_scoreText;
        private Text m_lifeText;
        private GameState m_lastCheckpointState;
        private Spawn m_lastCheckpoint;
        private GameState m_gameState;
        private PlatformerCharacterController m_playerCharacter;
        private bool m_allowMovement = true;

        void Awake()
        {
            if (m_instance == null)
                m_instance = this;
            m_gameState = ScriptableObject.CreateInstance<GameState>();
            ReloadComponents();
        }

        public void ChestOpened(float amount)
        {
            m_gameState.Score += amount;
        }

        public void SpecialChestOpened()
        {
            m_allowMovement = false;
            m_playerCharacter.Animator.Play("Win", true);
            m_playerCharacter.Animator.onStop.AddListener(Won);
        }

        void Won()
        {
            m_playerCharacter.Animator.onStop.RemoveListener(Won);
            LoadLevel("Won");
            m_allowMovement = true;
        }

        public void GemCollected()
        {
            m_gameState.Score += 1f;
        }

        public void LiveCollected()
        {
            m_playerCharacter.Life += 1;
        }

        public void KillPlayer()
        {
            m_playerCharacter.TriggerDeath();
        }

        void LateUpdate()
        {
            // Update screen text
            if (m_scoreText != null)
                m_scoreText.text = Score.ToString();
            if (m_lifeText != null)
                m_lifeText.text = Life.ToString();
        }

        void OnLevelWasLoaded()
        {
            m_eventSystem.Reset();
            ReloadComponents();
            m_allowMovement = true;
        }

        private void ReloadComponents()
        {
            GameObject obj = GameObject.Find("ScoreText");
            if (obj != null)
                m_scoreText = obj.GetComponent<Text>();
            obj = GameObject.Find("LifeText");
            if (obj != null)
                m_lifeText = obj.GetComponent<Text>();
            obj = GameObject.Find("Spawn");
            if (obj)
            {
                m_lastCheckpoint = obj.GetComponent<Spawn>();
                m_gameState.Entities = GameObject.Find("Entities");
                TakeSnapshot();
            }
        }

        public void PlayerSpawned(PlatformerCharacterController player)
        {
            m_playerCharacter = player;
            SubscribePlayerEvents();
        }

        public void Checkpoint(Spawn spawn)
        {
            TakeSnapshot();
            m_lastCheckpoint = spawn;
        }

        public void ReloadCheckpoint()
        {
            Destroy(m_gameState.Entities);
            m_gameState = Instantiate(m_lastCheckpointState);
            m_gameState.name = "GameState";
            m_gameState.Entities = Instantiate(m_lastCheckpointState.Entities);
            m_gameState.Entities.SetActive(true);
            m_gameState.Entities.name = "Entities";
            m_playerCharacter = m_lastCheckpoint.SpawnPlayer();
            SubscribePlayerEvents();
            m_allowMovement = true;
        }

        void SubscribePlayerEvents()
        {
            m_playerCharacter.OnLife.AddListener(life => Life = life);
            m_playerCharacter.OnDied.AddListener(ReloadCheckpoint);
            m_playerCharacter.OnDying.AddListener(PlayerDying);
        }

        void PlayerDying()
        {
            m_allowMovement = false;
        }

        void TakeSnapshot()
        {
            m_lastCheckpointState = Instantiate(m_gameState);
            m_lastCheckpointState.name = "GameStateCheckpoint";
            m_lastCheckpointState.Entities = Instantiate(m_gameState.Entities);
            m_lastCheckpointState.Entities.name = "EntitiesSave";
            m_lastCheckpointState.Entities.SetActive(false);
        }

        public void LoadLevel(string level)
        {
            SceneManager.LoadScene("Scenes/" + level);
        }

        public void SaveGame()
        {

        }

        public void LoadGame()
        {
            
        }
    }
}