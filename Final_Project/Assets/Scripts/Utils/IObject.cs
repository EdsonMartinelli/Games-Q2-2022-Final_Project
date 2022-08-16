using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IObject : IInteractable
{
    public void InteractionEnter();

    public void InteractionExit();

}
