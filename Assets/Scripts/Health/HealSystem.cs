using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class HealSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem ecb;

    protected override void OnCreate()
    {
        base.OnCreate();

        ecb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var healthComponentData = ecb.GetComponentDataFromEntity<HealthComponent>(true);

        Entities.ForEach((in HealComponent heal) => {
            var health = healthComponentData[heal.Victim];
            health.CurrentHealth = math.min(health.CurrentHealth + heal.Value, health.MaxHealth);
        }).Schedule();

        ecb.AddJobHandleForProducer(Dependency);
    }
}
