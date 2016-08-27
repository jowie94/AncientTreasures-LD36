using UnityEngine;

namespace MandarineStudio.AncientTreaseures
{
    public class WeaponCollision : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                float sym = transform.parent.localScale.x / Mathf.Abs(transform.parent.localScale.x);
                Vector2 vector = new Vector2(transform.right.x * sym, transform.right.y);
                col.gameObject.BroadcastMessage("WeaponDamage", new Damage(1.0f, vector));
            }
        }
    }
}