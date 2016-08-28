using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class HitTrigger : MonoBehaviour
    {
        public string EventName = "";

        // Use this for initialization
        void Start()
        {
            if (string.IsNullOrEmpty(EventName))
            {
                Debug.LogError("Trigger name is not specified, disabling trigger " + name);
                enabled = false;
            }
        }

        void WeaponDamage(Damage ignored)
        {
            GameManager.Instance.EventSystem.Trigger(EventName);
        }

        void FeetDamage(Damage ignored) {}
    }
}
