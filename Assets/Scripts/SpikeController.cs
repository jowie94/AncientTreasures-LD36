using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpikeController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
                GameManager.Instance.KillPlayer();
        }
        // Use this for initialization
        void Awake() {
    
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    }
}
