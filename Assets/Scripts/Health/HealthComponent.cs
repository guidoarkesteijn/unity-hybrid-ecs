using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct HealthComponent : IComponentData
{
    public float Percentage => (float)CurrentHealth / MaxHealth;

    public int CurrentHealth;
    public int MaxHealth;
}
