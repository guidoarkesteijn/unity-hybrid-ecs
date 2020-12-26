using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

public class HealSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref HealthComponent health, in HealComponent heal) => {
            health.CurrentHealth = math.min(health.CurrentHealth + heal.Value, health.MaxHealth);
        }).Schedule();
    }
}
