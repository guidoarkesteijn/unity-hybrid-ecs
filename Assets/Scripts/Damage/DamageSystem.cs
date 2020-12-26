using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class DamageSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref HealthComponent health, in DamageComponent damage) => {
            health.CurrentHealth = math.min(health.CurrentHealth - damage.Value, 0);
        }).Schedule();
    }
}
