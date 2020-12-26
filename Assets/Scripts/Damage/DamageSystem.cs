using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(AddDamageSystem))]
[UpdateBefore(typeof(AddDeathSystem))]
public class DamageSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref HealthComponent health, in DamageComponent damage) => {
            health.CurrentHealth = math.max(health.CurrentHealth - damage.Value, 0);
        }).Schedule();
    }
}
