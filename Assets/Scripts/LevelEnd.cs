using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    public class LevelEnd : MonoBehaviour
    {
        public string NextLevel;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
                GameManager.Instance.LoadLevel(NextLevel);
        }
    }
}
