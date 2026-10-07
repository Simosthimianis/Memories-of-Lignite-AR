using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class MapPanZoomController : MonoBehaviour
{
    public AbstractMap map;
    public float zoomSpeed = 0.25f;
    public float panSpeed = 0.002f;
    public float minZoom = 1f;
    public float maxZoom = 20f;

    private Vector3 lastPanPosition;
    private bool isPanning = false;

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseZoom();
        HandleMousePan();
#else
        HandleTouchZoom();
        HandleTouchPan();
#endif
    }

    void HandleMouseZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            float newZoom = Mathf.Clamp(map.Zoom + scroll * zoomSpeed * 10f, minZoom, maxZoom);
            map.UpdateMap(map.CenterLatitudeLongitude, newZoom);
        }
    }

    void HandleMousePan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
            isPanning = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPanning = false;
        }

        if (isPanning)
        {
            Vector3 delta = Input.mousePosition - lastPanPosition;
            lastPanPosition = Input.mousePosition;

            PanMap(delta);
        }
    }

    void HandleTouchZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            Vector2 prevT0 = t0.position - t0.deltaPosition;
            Vector2 prevT1 = t1.position - t1.deltaPosition;

            float prevDist = Vector2.Distance(prevT0, prevT1);
            float currDist = Vector2.Distance(t0.position, t1.position);
            float delta = currDist - prevDist;

            if (Mathf.Abs(delta) > 1.0f)
            {
                float newZoom = Mathf.Clamp(map.Zoom + delta * zoomSpeed * 0.01f, minZoom, maxZoom);
                map.UpdateMap(map.CenterLatitudeLongitude, newZoom);
            }
        }
    }

    void HandleTouchPan()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                PanMap(touch.deltaPosition);
            }
        }
    }

    void PanMap(Vector2 delta)
    {
        var latLongDelta = new Vector2d(-delta.y * panSpeed, -delta.x * panSpeed);
        var newCenter = map.CenterLatitudeLongitude + latLongDelta;
        map.UpdateMap(newCenter, map.Zoom);
    }
}
