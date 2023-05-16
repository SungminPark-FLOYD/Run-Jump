using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameController gameController;

    private void Update()
    {
        if (gameController.IsGamePlay == false) return;
        Invoke("Hide",3f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
