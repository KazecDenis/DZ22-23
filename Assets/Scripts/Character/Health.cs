
public class Health
{
    public int Max {get;}
    public int Current {get; private set;}
    public bool IsDead => Current <= 0;
    private float _woundedThreshold = 0.3f;
    public bool IsWounded => Current < Max * _woundedThreshold;

    public Health (int maxHealth)
    {
        Max = maxHealth;
        Current = maxHealth;
    }
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
