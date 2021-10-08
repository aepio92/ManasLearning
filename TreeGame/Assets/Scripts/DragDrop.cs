using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [HideInInspector] public bool RightSlot;
    [SerializeField] private AudioSource ErrorAudio;
    [SerializeField] private AudioSource SuccessAudio;

    private Vector2 AnchoredPosition;
    private RectTransform DragRectTransform;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        AnchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        DragRectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData EventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData EventData)
    {
        Debug.Log("OnDrag");
        DragRectTransform.anchoredPosition += EventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData EventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;

        if (!RightSlot)
        {
            DragRectTransform.anchoredPosition =  AnchoredPosition;
            ErrorAudio.Play();
        }
        else
        {
            SuccessAudio.Play();
            Destroy(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData EventData)
    {
        Debug.Log("OnPointerDown");
    }
}
