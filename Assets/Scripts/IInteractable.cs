using UnityEngine;

public interface IInteractable
{
    void Interact();
    Vector3 Destination { get; }
}