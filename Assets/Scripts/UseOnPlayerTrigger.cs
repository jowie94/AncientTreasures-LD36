using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class UseOnPlayerTrigger : MonoBehaviour
    {
        public string FunctionToCall = "";
        public bool OneShot = true;

        private bool m_playerIn;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
                m_playerIn = true;
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.tag == "Player")
                m_playerIn = false;
        }

        // Use this for initialization
        void Start()
        {
            m_playerIn = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_playerIn && Input.GetButtonDown("Use"))
            {
                BroadcastMessage(FunctionToCall);
                if (OneShot)
                    enabled = false;
            }
        }
    }
}
