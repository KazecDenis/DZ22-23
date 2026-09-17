
public class Health
{
    private float _woundedThreshold = 0.3f;
    public Health (int maxHealth)
    {
        Max = maxHealth;
        Current = maxHealth;
    }
    public int Max {get;}
    public int Current {get; private set;}
    public bool IsDead => Current <= 0;
    public bool IsWounded => Current < Max * _woundedThreshold;

    public void TakeDamage(int damage)
    {
        if (IsDead)
            return;

        if (damage <= 0)
            return;

        Current -= damage;

        if (Current < 0)
            Current = 0;
    }
}
