using System.Collections.Generic;
using UnityEngine;


public class AutoEnable_Runtime : MonoBehaviour
{
    public List<GameObject> objectsToEnable = null;

    private void Awake()
    {
        foreach (var gameObject in objectsToEnable)
        {
            gameObject.SetActive(true);
        }
    }

}
