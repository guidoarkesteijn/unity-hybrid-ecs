using System;
using Unity.Entities;

[Serializable]
public struct HealComponent : IComponentData
{
    public Entity Source;
    public Entity Victim;
    public int Value;
}
