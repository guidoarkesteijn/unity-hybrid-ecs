using Unity.Entities;

public class UpdateTimerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref TimeComponent value) =>
        {
            value.Time += 1 * deltaTime;
        }).Schedule();
    }
}
