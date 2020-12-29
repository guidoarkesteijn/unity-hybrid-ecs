using System;
using Unity.Entities;

[Serializable]
public struct DamageComponent : IComponentData
{
    public Entity Source;
    public Entity Victim;
    public int Value;
}
