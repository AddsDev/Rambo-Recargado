using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;


    public void HiddenMenu()
    {
        menu.SetActive(false);
    }
}
