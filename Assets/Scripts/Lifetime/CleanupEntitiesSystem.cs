using Unity.Entities;

[UpdateAfter(typeof(LifetimeSystem))]
public class CleanupEntitiesSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem ecb;

    protected override void OnCreate()
    {
        base.OnCreate();

        ecb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var concurrent = ecb.CreateCommandBuffer().AsParallelWriter();

        Entities.ForEach((Entity entity, int entityInQueryIndex, ref LifetimeComponent lifetime) =>
        {
            if (lifetime.TimeRemaining == 0f)
            {
                concurrent.DestroyEntity(entityInQueryIndex, entity);
            }
        }).Schedule();

        ecb.AddJobHandleForProducer(Dependency);
    }
}
