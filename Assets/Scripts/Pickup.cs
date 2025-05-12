using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup SFX")]
    public AudioClip clip;
    public float volume = 1.0f;
    public float minPitch = 0.99f;
    public float maxPitch = 1.01f;

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
            GameManager.Instance.PlayAudioClip(clip, volume, Random.Range(minPitch, maxPitch));
            Destroy(this.gameObject);
        }
    }
}
