using TMPro;
using UnityEngine;

public class ScriptCharacter : MonoBehaviour
{
    public GameObject characterDropdown;
    public GameObject maleCharacter;
    public GameObject femaleCharacter;

    private void Start()
    {
        ShowCharacter();
    }

    public void ShowCharacter()
    {
        int x = characterDropdown.GetComponent<TMP_Dropdown>().value;

        maleCharacter.SetActive(x == 0);
        femaleCharacter.SetActive(x == 1);
    }
}
