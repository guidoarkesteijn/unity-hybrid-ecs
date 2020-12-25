using Unity.Entities;
using Unity.Jobs;

public class DamageSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref HealthComponent health, in DamageComponent damage) => {
            health.Damage(damage.Value);
        }).Schedule();
    }
}
