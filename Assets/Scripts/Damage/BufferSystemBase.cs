using Unity.Entities;
using UnityEngine;

public abstract class BufferSystemBase : SystemBase
{
    protected BeginSimulationEntityCommandBufferSystem beginSimulationECBS;
    protected EndSimulationEntityCommandBufferSystem endSimulationECBS;

    protected override void OnCreate()
    {
        base.OnCreate();

        beginSimulationECBS = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
        endSimulationECBS = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected abstract override void OnUpdate();
}
