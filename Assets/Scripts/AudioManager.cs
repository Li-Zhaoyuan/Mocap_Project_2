using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    [Range(0f,0.5f)]
    public float randVol = 0.1f;

    [Range(0f, 0.5f)]
    public float randPitch = 0.1f;


    private AudioSource source;
    public void SetSource(AudioSource _source)
    {
        source = _source;
        _source.clip = clip;
    }
    public void Play()
    {
        if (source.isPlaying)
            return;

        source.volume = volume * (1 + Random.Range(-randVol/2f,randVol/2f));
        source.pitch = pitch * (1 + Random.Range(-randPitch / 2f, randPitch / 2f));   
        source.Play();
    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        if (instance != null)
            Debug.LogError("Too many fuckking audio managers");
        else
            instance = this;

        //Debug.Log("fuuuuuuuuug");
    }
    void Start()
    {
       // Debug.Log("fucking starting");
        for(int i = 0; i< sounds.Length; i++)
        {
            Debug.Log(sounds.Length);
            GameObject sound = new GameObject("sound" + i + "_" + sounds[i].name);
            sounds[i].SetSource(sound.AddComponent<AudioSource>());
        }

       // playsound("walk");
    }
    public void playsound(string _name)
    {
       // Debug.Log("playing sound");
        for(int i = 0; i< sounds.Length; i++)
        {
            
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("audiomanger:Wrong fuckin sound name//not found in list>" + _name);

    }
}
