using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct HealthComponent : IComponentData
{
    public float Percentage => (float)CurrentHealth / MaxHealth;

    public bool IsDead => CurrentHealth == 0;

    public int CurrentHealth;
    public int MaxHealth;

    public HealthComponent(int startHealth, int maxHealth)
    {
        CurrentHealth = startHealth;
        MaxHealth = maxHealth;
    }

    public void Damage(int value)
    {
        CurrentHealth = math.max(CurrentHealth - value, 0);
    }

    public void Heal(int value)
    {
        CurrentHealth = math.min(CurrentHealth + value, MaxHealth);
    }
}
