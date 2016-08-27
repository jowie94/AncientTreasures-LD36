using UnityEngine;

namespace MandarineStudio.AncientTreaseures
{
    public class WeaponCollision : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                float sym = transform.localScale.x / Mathf.Abs(transform.localScale.x);
                Vector2 vector = new Vector2(col.transform.right.x * sym, col.transform.right.y);
                col.gameObject.BroadcastMessage("WeaponDamage", new Damage(1.0f, vector));
            }
        }
    }
}