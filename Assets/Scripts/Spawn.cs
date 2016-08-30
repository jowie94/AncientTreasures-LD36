using UnityEngine;
using System.Collections;
using MandarineStudio.AncientTreasures;

namespace MandarineStudio.AncientTreasures
{
    public class Spawn : MonoBehaviour
    {
        public bool IsCheckpoint = false;

        private bool m_used = false;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (IsCheckpoint && !m_used)
            {
                GameManager.Instance.Checkpoint(this);
                m_used = true;
            }
        }

        public PlatformerCharacterController SpawnPlayer()
        {
            m_used = true;
            GameObject player = (GameObject) Instantiate(Resources.Load("Prefabs/Player"));
            player.name = "Player";
            player.transform.position = transform.position;
            PlatformerCharacterController pcc = player.GetComponent<PlatformerCharacterController>();
            pcc.Life = GameManager.Instance.Life;
            CameraMovement camera = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
            camera.Target = player.transform;
            return pcc;
        }

        void Start()
        {
            m_used = !IsCheckpoint;
            if (GameManager.Instance.SpawnPlayer && !IsCheckpoint)
                GameManager.Instance.PlayerSpawned(SpawnPlayer());
        }
    }
}
