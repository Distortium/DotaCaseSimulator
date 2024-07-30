using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class Hero : MonoBehaviour, IPointerClickHandler
{
    public event Action<int> OnClicked;
    private int _id;
    public Sprite HeroIcon { get; private set; }

    public void Init(int id, Sprite sprite = null)
    {
        _id = id;
        HeroIcon = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke(_id);
    }
}