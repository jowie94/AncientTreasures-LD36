using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LiveController : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.Instance.LiveCollected();
                Destroy(gameObject);
            }
        }
    }
}
