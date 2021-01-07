using Unity.Entities;
using UnityEngine;

public class InterruptTimeSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem cbs;

    protected override void OnCreate()
    {
        base.OnCreate();

        cbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        bool isKeyDown = Input.GetKeyDown(KeyCode.I);

        var buffer = cbs.CreateCommandBuffer().AsParallelWriter();

        Entities.ForEach((Entity entity, int entityInQueryIndex, ref TimeComponent time) =>
        {
            if (isKeyDown)
            {
                buffer.RemoveComponent<TimeComponent>(entityInQueryIndex, entity);
            }
        }).Schedule();

        cbs.AddJobHandleForProducer(Dependency);
    }
}
