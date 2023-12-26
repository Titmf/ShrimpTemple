using UnityEngine;
using UnityEngine.EventSystems;

public class ShrimpController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _shrimp;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShrimpRotate();
    }
    
    private void ShrimpRotate()
    {
        _shrimp.transform.Rotate(0, 0, 90); 
    }
}