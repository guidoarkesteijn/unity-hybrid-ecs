using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour, IConvertGameObjectToEntity
{
    private EntityManager entityManager;
    private Entity entity;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        this.entity = entity;
        this.entityManager = dstManager;
    }

    protected void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Entity clickEntity = entityManager.CreateEntity();
        entityManager.AddComponent<ClickComponent>(clickEntity);
        entityManager.SetComponentData(clickEntity, new ClickComponent { Button = entity });

        entityManager.RemoveComponent<InteractableComponent>(entity);
    }
}
