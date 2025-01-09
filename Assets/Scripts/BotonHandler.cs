using UnityEngine;
using UnityEngine.EventSystems;

public class BotonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public DispararBala dispararBala;

    public void OnPointerDown(PointerEventData eventData)
    {
        dispararBala.ComenzarDisparo();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dispararBala.FinalizarDisparo();
    }
}
