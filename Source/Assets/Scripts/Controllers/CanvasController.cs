using Boo.Lang;
using System.Collections;
using UnityEngine;
using System;

public class CanvasController : MonoBehaviour
{
    public float speedTranslationObjFromSlot = 3;

    [SerializeField]
    private GameObject Textinteractionkey;
    [SerializeField]
    private GameObject inventary;
    private SlotType[] inventarySlots;


    // Use this for initialization
    void Start()
    {
        inventarySlots = inventary.GetComponentsInChildren<SlotType>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInventary()
    {
        iTween.ScaleTo(inventary, new Vector3(1, 1, 1), 1);
    }

    public void HideInventary()
    {
        iTween.ScaleTo(inventary, new Vector3(0, 0, 0), 1);
    }

    public void EnableTextInterationKey()
    {
        Textinteractionkey.SetActive(true);
    }

    public void DisableTextInterationKey()
    {
        Textinteractionkey.SetActive(false);
    }

    public void GetObject(GameObject obj)
    {
        ShowInventary();
        iTween.MoveTo(obj, VerifyEnptySlot(), 2);
    }

    private Vector3 VerifyEnptySlot()
    {
        foreach (SlotType slot in inventarySlots)
        {
            if (slot.IsEmpty)
            {
                return slot.transform.position;
            }
        }
        return Vector3.zero;
    }
}
