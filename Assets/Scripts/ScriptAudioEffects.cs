using UnityEngine;

public class ScriptAudioEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void PlayAudioClip(int x) {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.PlayOneShot(audioClips[x]);
    }
}
