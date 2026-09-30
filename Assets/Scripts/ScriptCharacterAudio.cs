using UnityEngine;

public class ScriptCharacterAudio : MonoBehaviour
{
    public AudioSource soundEffects;
    public GameObject femaleCharacter;
    public GameObject maleCharacter;

    public AudioClip[] femaleAudioClips;
    public AudioClip[] maleAudioClips;
    
    // Laiks starp skaņām sekundēs
    public float interval = 120f;
    private float timer;

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= interval) {
            PlayRandomAudio();
            timer = 0f;
        }
    }

    public void PlayRandomAudio() {
        AudioClip[] clips;

        //Izvēlas skaņas atbilstoši aktīvajam tēlam
        if (femaleCharacter.activeInHierarchy) {
            clips = femaleAudioClips;
        }
        else if (maleCharacter.activeInHierarchy) {
            clips = maleAudioClips;
        }
        else {
            return;
        }

        //Ja skaņu nav
        if (clips.Length == 0) {
            return;
        }

        //Nejauši izvēlas vienu skaņu
        int x = Random.Range(0, clips.Length);
        soundEffects.PlayOneShot(clips[x]);
    }
}