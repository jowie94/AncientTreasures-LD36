namespace MandarineStudio.AncientTreasures
{
    class ScorpionControl : EnemyControl
    {
        protected override void WeaponDamage(Damage damage)
        {
            Flip();
            AudioHurt.Play();
            Controller.Damage(damage);
        }

        protected override void FeetDamage(Damage damage)
        {
            Flip();
            AudioHurt.Play();
            Controller.Damage(damage);
        }
    }
}
