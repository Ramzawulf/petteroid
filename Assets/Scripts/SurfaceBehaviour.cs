using UnityEngine;

public class SurfaceBehaviour : MonoBehaviour, IClickable
{

    Vector3 lastPosition = Vector3.zero;
    Vector3 newPosition = Vector3.zero;

    public void OnClick(Vector3 hit)
    {
        GameObject go = GameObject.Instantiate(PrefabManager.Instance.ClickParticle);
        go.transform.position = hit;
        PetBehaviour.Instance.MoveTo(hit);
    }

    void OnMouseDrag()
    {
        if (lastPosition == Vector3.zero)
            lastPosition = Input.mousePosition;
        if (Input.mousePosition != lastPosition)
        {
            newPosition = Input.mousePosition;
            Vector3 delta = (newPosition - lastPosition).normalized;
            lastPosition = newPosition;
            CameraBehaviour.Instance.Rotate(delta);
        }
    }
}
