using System.Collections;
using UnityEngine;

public class RandomiseAnimationOffset : MonoBehaviour
{
    public Animation[] animations;
    public float minOffset = 0.1f;
    public float maxOffset = 0.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayAnimationStart());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayAnimationStart()
    {
        for (int i = 0; i < animations.Length; i++)
        {
            float randomOffset = Random.Range(minOffset, maxOffset);

            animations[i].Play();

            yield return new WaitForSeconds(randomOffset);
        }
        

        
    }
}
