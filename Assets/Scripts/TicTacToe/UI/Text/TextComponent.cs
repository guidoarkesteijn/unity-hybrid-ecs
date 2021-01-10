using System;
using Unity.Entities;

[Serializable]
public struct TextComponent : IComponentData
{
    public BlobString Text;
}
