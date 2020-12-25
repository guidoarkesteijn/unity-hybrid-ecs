using System;
using Unity.Entities;

[Serializable]
public struct DamageComponent : IComponentData
{
    public int Value;
}
