using Unity.Entities;

public class PickupSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((in PickupComponent pickup) =>
        {
            
        }).Schedule();
    }
}
