using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [Header("Camera shake")]
    public AnimationCurve curve;
    public IEnumerator Shake(float duration)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = originalPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = originalPosition;
    } 
}
