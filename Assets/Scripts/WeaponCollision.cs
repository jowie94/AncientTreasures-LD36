using UnityEngine;

namespace MandarineStudio.AncientTreasures
{
    public class WeaponCollision : MonoBehaviour
    {
        public string DamageType = "WeaponDamage";

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                float sym = transform.parent.localScale.x / Mathf.Abs(transform.parent.localScale.x);
                Vector2 vector = new Vector2(transform.right.x * sym, transform.right.y);
                col.gameObject.BroadcastMessage(DamageType, new Damage(1.0f, vector));
            }
        }
    }
}
