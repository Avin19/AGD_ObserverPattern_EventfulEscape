using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDrop : MonoBehaviour
{
    [SerializeField] private Transform Skulls;

    private void OnEnable()
    {
        SkullDropEventTrigger.OnSkullDrop += OnSkullDrop;
    }

    private void OnDisable()
    {
        SkullDropEventTrigger.OnSkullDrop -= OnSkullDrop;
    }

    private void OnSkullDrop()
    {
        Skulls.gameObject.SetActive(true);
    }

}
