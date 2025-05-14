using UnityEngine;
using UnityEngine.UI;

public class GUIEvent : MonoBehaviour
{
    public GameObject doorInstruction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoorText(bool isActive)
    {
        doorInstruction.SetActive(isActive);
    }
}
