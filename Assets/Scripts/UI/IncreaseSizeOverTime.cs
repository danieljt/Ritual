/*
Daniel James Tarplett
StupidGirlGames
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
/// Increase an images size over time. This script is used in the introduction scene
///</summary>
public class IncreaseSizeOverTime : MonoBehaviour
{
    public GameObject objectToResize;
    public Vector3 startScale;
    public Vector3 endScale;
    public float time;

    private void Start()
    {
        StartCoroutine(ScaleGameObjectOverTime(startScale, endScale, time));
    }

    private IEnumerator ScaleGameObjectOverTime(Vector3 start, Vector3 end, float time)
    {
        if(objectToResize)
        {
            objectToResize.transform.localScale = start;
            float currentTime = 0;

            do
            {
                objectToResize.transform.localScale = Vector3.Lerp(startScale, endScale, currentTime/time);
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            while(currentTime <= time);
            yield break;
        }
    }
  
}
