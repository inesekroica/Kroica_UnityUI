using UnityEngine;
using UnityEngine.EventSystems;

public class ScriptDragDrop : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject wornClothes;
    private RectTransform clothing;
    private RectTransform panel;
    private Vector2 offset;

    private RectTransform originalPanel;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private int originalOrder;

    private void Start() {
        clothing = GetComponent<RectTransform>();
        panel = wornClothes.GetComponent<RectTransform>();

        //Saglabā sākotnējo pozīciju
        originalPanel = clothing.parent.GetComponent<RectTransform>();
        originalPosition = clothing.localPosition;
        originalScale = clothing.localScale;
        originalOrder = clothing.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        //Pārceļ apģērbu uz tēla paneli
        clothing.SetParent(panel, true);
        //Parāda apģērbu virs tēla
        clothing.SetAsLastSibling();

        Vector2 mousePosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            panel,
            eventData.position,
            eventData.pressEventCamera,
            out mousePosition);

        //Saglabā vietu, kur apģērbs tika satverts
        offset = (Vector2)clothing.localPosition - mousePosition;
    }

    public void OnDrag(PointerEventData eventData){
        Vector2 mousePosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            panel,
            eventData.position,
            eventData.pressEventCamera,
            out mousePosition);

        //Pārvieto apģērbu
        Vector2 position = mousePosition + offset;

        clothing.localPosition = new Vector3(
            position.x,
            position.y,
            clothing.localPosition.z);
    }

    public void OnEndDrag(PointerEventData eventData) {
        //Ja sākotnējais panelis ir paslēpts, apģērbu neatgriež
        if (!originalPanel.gameObject.activeInHierarchy) {
            return;
        }

        //Pārbauda vai pele atlaista virs sākotnējā paneļa
        bool overOriginalPanel =
            RectTransformUtility.RectangleContainsScreenPoint(
                originalPanel,
                eventData.position,
                eventData.pressEventCamera);

        if (overOriginalPanel) {
            //Atjauno sākotnējo pozīciju un mērogu
            clothing.SetParent(originalPanel, false);
            clothing.localPosition = originalPosition;
            clothing.localScale = originalScale;
            clothing.SetSiblingIndex(originalOrder);
        }
    }
}