using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFloater : MonoBehaviour
{
    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GoUp");
    }

    IEnumerator GoUp()
    {
        for(int i = 0; i < 15; i++)
        {
            float t = (float)i / (float)15;
            transform.localPosition = Vector3.Lerp(topPosition, bottomPosition, t);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
        StopAllCoroutines();
        StartCoroutine("GoDown");
    }

    IEnumerator GoDown()
    {
        for (int i = 0; i < 15; i++)
        {
            float t = (float)i / (float)15;
            transform.localPosition = Vector3.Lerp( bottomPosition, topPosition, t);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
        StopAllCoroutines();
        StartCoroutine("GoUp");
    }
}
