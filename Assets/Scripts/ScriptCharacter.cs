using TMPro;
using UnityEngine;

public class ScriptCharacter : MonoBehaviour
{
    public GameObject characterDropdown;
    public GameObject maleCharacter;
    public GameObject femaleCharacter;
    public GameObject characterDescription;

    private string maleDescription =
        "I am a curious and energetic adventurer. " +
        "I enjoy exploring new places, going on hikes, and " +
        "trying things I have never done before.\n\n" +
        "In my free time, I ride my bike, listen to music, " +
        "and spend time with friends. I am happy to help others and " +
        "try to find practical solutions in difficult situations.";

    private string femaleDescription =
        "I am a creative and enterprising adventurer. " +
        "I enjoy taking photos, exploring new places, and " +
        "noticing unusual details in everyday life.\n\n" +
        "In my free time, I draw, go for walks, and listen to music. " +
        "I enjoy trying out new ideas and encourage my friends " +
        "not to give up when something does not work on the first try.";

    private void Start()
    {
        ShowCharacter();
    }

    public void ShowCharacter() {
        int x = characterDropdown.GetComponent<TMP_Dropdown>().value;

        //Parāda tēlu
        maleCharacter.SetActive(x == 0);
        femaleCharacter.SetActive(x == 1);

        //Parāda tēla aprakstu
        if (x == 0) {
            characterDescription.GetComponent<TMP_Text>().text =
                maleDescription;
        }else {
            characterDescription.GetComponent<TMP_Text>().text =
                femaleDescription;
        }
    }
}
