using UnityEngine;

public class ScriptSizeChange : MonoBehaviour
{
    public GameObject characterPanel;

    public void ChangeHeight(float x) {
        Vector3 scale = characterPanel.transform.localScale;
        characterPanel.transform.localScale = new Vector3(scale.x, x, scale.z);
    }

    public void ChangeWidth(float x) {
        Vector3 scale = characterPanel.transform.localScale;
        characterPanel.transform.localScale = new Vector3(x, scale.y, scale.z);
    }
}
