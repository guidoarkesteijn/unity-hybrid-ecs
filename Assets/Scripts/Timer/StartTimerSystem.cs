using Unity.Entities;
using UnityEngine;

public class StartTimerSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem cbs;

    protected override void OnCreate()
    {
        base.OnCreate();

        cbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        bool isKeyDown = Input.GetKeyDown(KeyCode.S);

        var buffer = cbs.CreateCommandBuffer().AsParallelWriter();

        Entities.ForEach((Entity entity, int entityInQueryIndex, in TimerComponent timer) =>
        {
            if (isKeyDown)
            {
                buffer.AddComponent(entityInQueryIndex, entity, new TimeComponent());
            }
        }).Schedule();

        cbs.AddJobHandleForProducer(Dependency);
    }
}
