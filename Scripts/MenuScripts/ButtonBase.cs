using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBase : UI_MenuNav, ISelectHandler
{
    protected UI_MenuNav menuNav;

    protected new virtual void Start()
    {
        menuNav = GameObject.Find("Menu Manager").GetComponent<UI_MenuNav>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    public virtual void OnSelect(BaseEventData eventData) 
    {
        Debug.Log($"{gameObject.name} Selected");        
    }
}
