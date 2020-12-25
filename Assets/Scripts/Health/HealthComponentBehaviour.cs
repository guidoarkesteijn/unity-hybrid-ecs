using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class HealthComponentBehaviour : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField, Range(0,1000)] private int startHealth = 100;
    [SerializeField, Range(0, 1000)] private int maxHealth = 100;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new HealthComponent(startHealth, maxHealth));
    }
}
