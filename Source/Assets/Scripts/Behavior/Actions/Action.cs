using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Action
{
    public string ActionName;
    public float startDelay;
    [SerializeField]
    public Constants.Actions action;
    public GameObject gameobject;
    public string animationProperty;

    [SerializeField]
    public EventTrigger.TriggerEvent methods;
    
}
