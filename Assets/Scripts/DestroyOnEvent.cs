using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    public class DestroyOnEvent : MonoBehaviour
    {
        public string EventName;

        // Use this for initialization
        void Start () {
            if (string.IsNullOrEmpty(EventName))
            {
                Debug.LogError("Trigger name is not specified, disabling trigger " + name);
                enabled = false;
            }
            GameManager.Instance.EventSystem.Subscribe(EventName, () => Destroy(gameObject));
        }
    }
}
