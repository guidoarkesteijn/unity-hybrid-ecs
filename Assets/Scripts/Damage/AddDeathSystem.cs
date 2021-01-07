using Unity.Entities;
using Unity.Jobs;

public class AddDeathSystem : SystemBase
{
    EndSimulationEntityCommandBufferSystem ecb;

    protected override void OnCreate()
    {
        base.OnCreate();

        ecb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var buffer = ecb.CreateCommandBuffer().AsParallelWriter();

        Entities
            .ForEach((Entity entity, int entityInQueryIndex, ref HealthComponent health, ref DamageComponent damageComponent) =>
            {
                buffer.RemoveComponent<DamageComponent>(entityInQueryIndex, entity);

                if (health.CurrentHealth == 0)
                {
                    buffer.AddComponent(entityInQueryIndex, entity, new DeathComponent());
                }
            }).Schedule();

        ecb.AddJobHandleForProducer(Dependency);

        return;
    }
}
