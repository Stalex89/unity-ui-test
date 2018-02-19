using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PanelDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector2 beginMousePos, beginPanelPos;




    public void OnBeginDrag(PointerEventData eventData)
    {
        beginMousePos = eventData.position;
        beginPanelPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = (eventData.position - beginMousePos) + beginPanelPos;
    }
    
}
