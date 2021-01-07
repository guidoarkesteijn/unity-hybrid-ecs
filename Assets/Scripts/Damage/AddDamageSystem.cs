using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class AddDamageSystem : SystemBase
{
    BeginSimulationEntityCommandBufferSystem cbs;

    protected override void OnCreate()
    {
        base.OnCreate();

        cbs = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var buttonDown = Input.GetKeyDown(KeyCode.Space);
        var ecb = cbs.CreateCommandBuffer().AsParallelWriter();

        Entities.ForEach((Entity entity, int entityInQueryIndex, ref HealthComponent health) =>
        {
            if (buttonDown)
            {
                ecb.AddComponent(entityInQueryIndex, entity, new DamageComponent { Value = 5 });
            }
        }).Schedule();

        cbs.AddJobHandleForProducer(Dependency);
    }
}
