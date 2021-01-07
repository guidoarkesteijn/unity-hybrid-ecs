using System;
using Unity.Entities;

[GenerateAuthoringComponent]
[Serializable]
public struct LifetimeComponent : IComponentData
{
    public float TimeRemaining;
}
