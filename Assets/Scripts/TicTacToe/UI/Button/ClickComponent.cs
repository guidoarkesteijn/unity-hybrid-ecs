using System;
using Unity.Entities;

[Serializable]
public struct ClickComponent : IComponentData
{
    public Entity Button;
}
