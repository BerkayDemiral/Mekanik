using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //objeye event ekleme
    public bool useEvents;

    //Bakýnca yazý gözüksün
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }

    public void BaseIntrecat()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {

    }

    
}
