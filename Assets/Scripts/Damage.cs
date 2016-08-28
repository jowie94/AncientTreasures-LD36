using UnityEngine;
using System.Collections;

namespace MandarineStudio.AncientTreasures
{
    public class Damage
    {
        public float Amount;
        public Vector2 Direction;

        public Damage(float amount, Vector2 direction)
        {
            Amount = amount;
            Direction = direction;
        }
    }
}
