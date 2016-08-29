using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(UseOnPlayerTrigger))]
    public class ChestControl : MonoBehaviour
    {
        public float NumberOfGems = 0f;

        void OpenChest()
        {
            // TODO: Open animation
            GameManager.Instance.ChestOpened(NumberOfGems);
        }
    }
}
