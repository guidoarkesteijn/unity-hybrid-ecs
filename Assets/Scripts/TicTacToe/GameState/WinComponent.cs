using System;
using Unity.Entities;

[Serializable]
public struct WinComponent : IComponentData
{
    public Entity Winner;
}
