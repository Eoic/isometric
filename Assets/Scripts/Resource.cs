﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Resource : MonoBehaviour, IPointerClickHandler
{
    public enum ResourceType { STONE, IRON, WOOD }
    [SerializeField] private ResourceType type = ResourceType.STONE;
    [SerializeField] private int supply = 5;

    public ResourceType Type { get => type; }
    public int Supply { get => supply; }
    public bool IsDepleted { get => (supply <= 0); }

    public int ConsumeResource(int amount)
    {
        if (supply - amount < 0)
        {
            int consumed = supply;
            supply = 0;
            return consumed;
        }

        supply -= amount;
        return amount;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.PlayMouseClick();
        // TODO: Open resource info on click
    }
}
