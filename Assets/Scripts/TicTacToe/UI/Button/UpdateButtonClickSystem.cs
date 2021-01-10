using Unity.Entities;

public class UpdateButtonClickSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref ClickComponent click) =>
               {
                   //Process click by Updating Text of button. 
               }).Schedule();
    }
}
