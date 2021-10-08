using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private int AppleCount=0;
    [SerializeField] private GameObject[] Apples;

    public UI_Handler Ui_Manager;
    public void OnDrop(PointerEventData EventData)
    {
        Debug.Log("OnDrop");

        if(EventData.pointerDrag!=null)
        {
            if(EventData.pointerDrag.tag==gameObject.tag)
            {
                EventData.pointerDrag.GetComponent<DragDrop>().RightSlot = true;
                Apples[AppleCount].SetActive(true);
                AppleCount++;
                Ui_Manager.AppleCount++;
                if(Ui_Manager.AppleCount>=14)
                {
                    Ui_Manager.OpenGameOverMenu();
                }
            }
        }
    }

}
