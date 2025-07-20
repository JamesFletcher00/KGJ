using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassBar : MonoBehaviour
{
    public RectTransform compassBarTransform;

    public RectTransform pirateMarkerTransform;
    public RectTransform shopTransform;
    public RectTransform homeTransform;

    public Transform cameraObjectTransform;
    public Transform pirateObjectTransform;
    public Transform shopObjectTransform;
    public Transform homeObjectTransform;

    // Update is called once per frame
    void Update()
    {
        SetMarkerPosition(pirateMarkerTransform, pirateObjectTransform.position);
        SetMarkerPosition(shopTransform, shopObjectTransform.position);
        SetMarkerPosition(homeTransform, homeObjectTransform.position);
    }

    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition)
    {
        Vector3 directionToTarget = worldPosition - cameraObjectTransform.position;
        float angle = Vector2.Angle(new Vector2(directionToTarget.x, directionToTarget.z),
                                    new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compassPositionX = Mathf.Clamp(2 * angle / Camera.main.fieldOfView - 1, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compassBarTransform.rect.width / 2 * compassPositionX, 0);
    }
}
