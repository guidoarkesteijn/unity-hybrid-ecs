using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(DamageSystem))]
public class AddDamageSystem : JobComponentSystem
{   
    BeginSimulationEntityCommandBufferSystem beginSimulationEcbSystem;

    protected override void OnCreate()
    {
        base.OnCreate();

        beginSimulationEcbSystem = World
            .GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var spaceDown = Input.GetKeyDown(KeyCode.Space);
        var ecb = beginSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();

        var jobHandle = Entities
            .ForEach((Entity entity, int entityInQueryIndex, ref HealthComponent health) =>
            {
                if (spaceDown)
                {
                    ecb.AddComponent(entityInQueryIndex, entity, new DamageComponent { Value = 5 });
                }
            }).Schedule(inputDeps);

        jobHandle.Complete();
        return default;
    }
}
