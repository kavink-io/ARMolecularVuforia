using UnityEngine;
using UnityEngine.InputSystem;

public class MoleculeInteraction : MonoBehaviour
{
    [Header("360° Rotation")]
    public float rotationSpeed = 0.25f;

    [Header("Pinch Zoom")]
    public float zoomSpeed = 0.001f;
    public float minScale = 0.05f;
    public float maxScale = 0.5f;

    private Vector3 originalScale;
    private Quaternion originalRotation;

    private float lastTapTime;
    private const float doubleTapDelay = 0.3f;

    void Start()
    {
        originalScale = transform.localScale;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        int touchCount = 0;

        foreach (var touch in Touchscreen.current.touches)
        {
            if (touch.press.isPressed)
                touchCount++;
        }

        // =========================
        // ONE FINGER: 360° ROTATION
        // =========================
        if (touchCount == 1)
        {
            var touch = Touchscreen.current.primaryTouch;

            Vector2 delta = touch.delta.ReadValue();

            if (delta != Vector2.zero)
            {
                // Horizontal finger movement
                // rotates around Y

                transform.Rotate(
                    Vector3.up,
                    -delta.x * rotationSpeed,
                    Space.World
                );

                // Vertical finger movement
                // rotates around X

                transform.Rotate(
                    Vector3.right,
                    delta.y * rotationSpeed,
                    Space.Self
                );
            }

            // Double tap = reset
            if (touch.press.wasReleasedThisFrame)
            {
                if (Time.time - lastTapTime < doubleTapDelay)
                {
                    ResetMolecule();
                }

                lastTapTime = Time.time;
            }
        }

        // =========================
        // TWO FINGER: PINCH ZOOM
        // =========================
        if (touchCount == 2)
        {
            Vector2 pos1 = Vector2.zero;
            Vector2 pos2 = Vector2.zero;

            Vector2 delta1 = Vector2.zero;
            Vector2 delta2 = Vector2.zero;

            int index = 0;

            foreach (var touch in Touchscreen.current.touches)
            {
                if (!touch.press.isPressed)
                    continue;

                if (index == 0)
                {
                    pos1 = touch.position.ReadValue();
                    delta1 = touch.delta.ReadValue();
                }
                else if (index == 1)
                {
                    pos2 = touch.position.ReadValue();
                    delta2 = touch.delta.ReadValue();
                }

                index++;

                if (index >= 2)
                    break;
            }

            float currentDistance =
                Vector2.Distance(pos1, pos2);

            float previousDistance =
                Vector2.Distance(
                    pos1 - delta1,
                    pos2 - delta2
                );

            float difference =
                currentDistance - previousDistance;

            float scale =
                transform.localScale.x +
                difference * zoomSpeed;

            scale = Mathf.Clamp(
                scale,
                minScale,
                maxScale
            );

            transform.localScale =
                Vector3.one * scale;
        }
    }

    public void ResetMolecule()
    {
        transform.localScale = originalScale;
        transform.localRotation = originalRotation;
    }
}