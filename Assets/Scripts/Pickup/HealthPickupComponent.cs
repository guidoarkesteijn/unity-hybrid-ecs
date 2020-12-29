using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct HealthPickupComponent : IComponentData
{
    public int Value;
}
