using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactMenu : MonoBehaviour
{
    public RectTransform target;

    void Update()
    {
        //target.SetActive(Input.GetKey(KeyCode.Tab));

        if(Input.GetKey(KeyCode.Tab))
        {
            target.anchoredPosition = Vector3.Lerp(target.anchoredPosition, new Vector3(427, 0, 0), 0.07f);
        }
        else
        {
            target.anchoredPosition = Vector3.Lerp(target.anchoredPosition, new Vector3(-650, 0, 0), 0.07f);
        }
    }
}