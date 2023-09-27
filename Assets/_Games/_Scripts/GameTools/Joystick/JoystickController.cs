using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{

    [SerializeField] protected RectTransform joystickBG;
    [SerializeField] protected RectTransform joystickController;
    [SerializeField] protected GameObject joystickPanel;
    [SerializeField] protected float magnitude;

    protected Vector3 direction;
    public Vector3 Direction { get => direction; set => direction = value; }

    protected Vector3 screen;
    protected Vector3 mousePos => Input.mousePosition - screen / 2;
    protected Vector3 startPos;
    protected Vector3 updatePos;

    protected void Start()
    {

        screen.x = Screen.width;
        screen.y = Screen.height;
        joystickPanel.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            joystickPanel.gameObject.SetActive(true);
            startPos = mousePos;
            joystickBG.anchoredPosition = startPos;
        }
        if (Input.GetMouseButton(0))
        {
            updatePos = mousePos;
            joystickController.anchoredPosition = Vector3.ClampMagnitude((updatePos - startPos), magnitude) + startPos;
            direction = (updatePos - startPos).normalized;
            direction.z = direction.y;
            direction.y = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
            joystickPanel.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        direction = Vector3.zero;
    }
}
