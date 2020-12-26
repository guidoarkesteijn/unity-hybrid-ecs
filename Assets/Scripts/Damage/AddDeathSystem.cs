using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(DamageSystem))]
public class AddDeathSystem : JobComponentSystem
{
    EndSimulationEntityCommandBufferSystem endSimulationEcbSystem;
    AddDamageSystem addDamageSystem;

    protected override void OnCreate()
    {
        base.OnCreate();

        endSimulationEcbSystem = World
            .GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        addDamageSystem = World.GetOrCreateSystem<AddDamageSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var ecb = endSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();

        inputDeps = Entities
            .ForEach((Entity entity, int entityInQueryIndex, ref HealthComponent health, ref DamageComponent damageComponent) =>
            {
                ecb.RemoveComponent<DamageComponent>(entityInQueryIndex, entity);

                if (health.CurrentHealth == 0)
                {
                    ecb.AddComponent(entityInQueryIndex, entity, new DeathComponent());
                }
            }).Schedule(inputDeps);

        inputDeps.Complete();

        return inputDeps;
    }
}
