using Unity.Entities;
using Unity.Jobs;

public class HealSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref HealthComponent health, in HealComponent heal) => {
            health.Heal(heal.Value);
        }).Schedule();
    }
}
