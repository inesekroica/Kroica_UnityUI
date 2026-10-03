using TMPro;
using UnityEngine;

public class ScriptCharacter : MonoBehaviour
{
    public GameObject characterDropdown;
    public GameObject maleCharacter;
    public GameObject femaleCharacter;
    public GameObject characterDescription;

    private string maleDescription =
            "Esmu zinātkārs un enerģisks piedzīvojumu meklētājs. " +
            "Man patīk izpētīt jaunas vietas, doties pārgājienos un " +
            "izmēģināt lietas, ko iepriekš neesmu darījis.\n\n" +
            "Brīvajā laikā braucu ar velosipēdu, klausos mūziku " +
            "un tiekos ar draugiem. Es labprāt palīdzu citiem un " +
            "sarežģītās situācijās cenšos atrast praktisku risinājumu.";

    private string femaleDescription =
            "Esmu radoša un uzņēmīga piedzīvojumu meklētāja. " +
            "Man patīk fotografēt, iepazīt jaunas vietas un " +
            "pamanīt neparastas detaļas ikdienā.\n\n" +
            "Brīvajā laikā zīmēju, dodos pastaigās un klausos mūziku. " +
            "Es labprāt izmēģinu jaunas idejas un iedrošinu draugus " +
            "nepadoties, ja kaut kas neizdodas ar pirmo reizi.";

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
