using UnityEngine;

public class Door : MonoBehaviour
{
    public float openProximity = 2.0f;
    public AudioClip openSFX;

    public GUIEvent GUIEvent;

    Animation anim;

    private bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        GUIEvent.ToggleDoorText(false);

        if (WithinOpenProximity())
        {
            if (!isOpen) GUIEvent.ToggleDoorText(true);

            if (Input.GetKeyDown("f"))
            {
                anim.Play();
                isOpen = true;
            }
        }
    }

    bool WithinOpenProximity()
    {
        return Vector3.Distance(GameManager.Instance.player.transform.position, this.gameObject.transform.position) <= openProximity;
    }
}
