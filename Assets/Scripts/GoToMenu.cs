using UnityEngine;
using UnityEngine.UI;

namespace MandarineStudio.AncientTreasures
{
    public class GoToMenu : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Menu);
        }


        void Menu()
        {
            GameManager.Instance.GoToMenu();
        }
    }
}
