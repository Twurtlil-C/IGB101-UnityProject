using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup SFX")]
    public AudioClip clip;
    public float volume;
    public float pitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.currentPickups += 1;
            GameManager.Instance.PlayAudioClip(clip, volume, pitch);
            Destroy(this.gameObject);
        }
    }
}
