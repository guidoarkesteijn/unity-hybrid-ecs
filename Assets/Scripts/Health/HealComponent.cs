using System;
using Unity.Entities;

[Serializable]
public struct HealComponent : IComponentData
{
    public int Value;
}
