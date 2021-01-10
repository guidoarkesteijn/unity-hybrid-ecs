using Unity.Entities;
using UnityEngine.UI;

public class UpdateInteractableSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithoutBurst()
            .ForEach((Entity entity, Button button) =>
            {
                bool hasInteractable = EntityManager.HasComponent<InteractableComponent>(entity);
                button.interactable = hasInteractable;
            }).Run();
    }
}
