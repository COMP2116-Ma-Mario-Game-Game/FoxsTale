using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*************  ✨ Windsurf Command ⭐  *************/
    /// <summary>
    /// Plays the sound effect specified by the index.
    /// </summary>
    /// <param name="soundToPlay">The index of the sound effect to play from the soundEffects array.</param>

    /*******  7ec40229-3683-4261-8c3a-246798f4ae2f  *******/

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].Play();

    }
}
