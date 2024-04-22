using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;

    public void RotateForward()
    {
        Debug.Log("rotate forward");
        index++;
        float angle = 180;
        StartCoroutine(Rotate(angle, true));

    }
    public void RotateBack()
    {
        Debug.Log("rotate baackward");
        float angle = 0;
        StartCoroutine(Rotate(angle, false));
    }
    public void test()
    {
        Debug.Log("button presed");
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);

            if(angle1< 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                break;
            }
            yield return null;
        }
    }
}