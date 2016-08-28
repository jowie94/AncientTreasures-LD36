using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    public class DeathTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlatformerCharacterController>().Die(true);
            }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
