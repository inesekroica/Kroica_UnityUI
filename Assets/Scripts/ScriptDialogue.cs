using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ScriptDialogue : MonoBehaviour
{
    public GameObject inputName;
    public GameObject inputDate;
    public GameObject outputText;

    public void GetInformation()
    {
        string name = inputName.GetComponent<TMP_InputField>().text.Trim();
        string dateString = inputDate.GetComponent<TMP_InputField>().text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            outputText.GetComponent<TMP_Text>().text = "Enter character name.";
            return;
        }

        if (!DateTime.TryParseExact(dateString,"dd.MM.yyyy",CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime birthDate))
        {
            outputText.GetComponent<TMP_Text>().text = "Enter a valid birth date in format DD.MM.YYYY.";
            return;
        }

        DateTime todayDate = DateTime.Today;

        if (birthDate > todayDate)
        {
            outputText.GetComponent<TMP_Text>().text = "Birth date cannot be in the future.";
            return;
        }

        int age = todayDate.Year - birthDate.Year;

        if (birthDate.AddYears(age) > todayDate)
        {
            age--;
        }

        outputText.GetComponent<TMP_Text>().text = $"Hi! My name is {name} and I am {age} years old.";
    }
}
