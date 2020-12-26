using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

[UpdateAfter(typeof(DamageSystem))]
public class DeathSystem : JobComponentSystem
{
    EndSimulationEntityCommandBufferSystem endSimulationEcbSystem;

    protected override void OnCreate()
    {
        base.OnCreate();

        endSimulationEcbSystem = World
            .GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var ecb = endSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();

        var jobHandle = Entities.ForEach((Entity entity, int entityInQueryIndex, ref HealthComponent health) =>
        {
            health.CurrentHealth = math.max(health.CurrentHealth - 1, 0);

            if (health.CurrentHealth == 0)
            {
                ecb.AddComponent(entityInQueryIndex, entity, new DeathComponent());
            }

        }).Schedule(inputDeps);

        endSimulationEcbSystem.AddJobHandleForProducer(jobHandle);
        return default;
    }
}
