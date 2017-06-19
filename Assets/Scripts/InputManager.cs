using UnityEngine;

public class InputManager : MonoBehaviour {

    private float lastMouseDown;
    public float ClickThreshold = 0.15f;
    
    void Start () {
        lastMouseDown = Time.time;
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
            lastMouseDown = Time.time;
        if (Input.GetMouseButtonUp(0) && (Time.time - lastMouseDown) < ClickThreshold)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                var obj = hit.transform.gameObject.GetComponent<IClickable>();
                if (obj != null)
                {
                    obj.OnClick(hit.point);
                }
            }
        }
    }
}
