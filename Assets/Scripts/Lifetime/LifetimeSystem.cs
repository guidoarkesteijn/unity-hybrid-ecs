using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class LifetimeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref LifetimeComponent lifetime) =>
        {
            lifetime.TimeRemaining = math.max(lifetime.TimeRemaining - 1f * deltaTime, 0f);
        }).Schedule();

        
    }
}
