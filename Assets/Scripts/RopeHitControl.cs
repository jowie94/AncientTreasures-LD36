using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(HitTrigger))]
    public class RopeHitControl : MonoBehaviour
    {

        // Use this for initialization
        void Start ()
        {
            GameManager.Instance.EventSystem.Subscribe(GetComponent<HitTrigger>().EventName, () => gameObject.SetActive(false));
        }
    }
}
