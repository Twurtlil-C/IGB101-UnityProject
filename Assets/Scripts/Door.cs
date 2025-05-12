using UnityEngine;

public class Door : MonoBehaviour
{
    public float openProximity = 2.0f;

    Animation anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WithinOpenProximity() && Input.GetKeyDown("f"))
        {
            anim.Play();
        }
    }

    bool WithinOpenProximity()
    {
        return Vector3.Distance(GameManager.Instance.player.transform.position, this.gameObject.transform.position) <= openProximity;
    }
}
