using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonSairMenu : ButtonBase
{

    protected override void Start()
    {
        base.Start();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        audioSource.clip = menuNav.menuAudioClip[10];
        audioSource.Play();
    }
}
