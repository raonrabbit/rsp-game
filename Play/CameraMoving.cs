using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    const int MAX_X = 5;
    const int MIN_X = -5;
    const int MAX_Y = 3;
    const int MIN_Y = -3;
    const float fscale = 0.01f;
    const float zoomSpeed = 0.005f;

    Camera mainCamera;
    Vector2 vscale = new Vector2(fscale, fscale);
    Vector2 startPos;
    Vector2 curPos;
    Vector2 change;
    bool hold = false;


    void Start()
    {
        mainCamera = GetComponent<Camera>();
        StartCoroutine(Cameramove());
    }

    IEnumerator Cameramove()
    {
        while(true){
            if(StartSetter.instance.isStart && !GameManager.isWindowActive){
                if(Input.touchCount == 1)
                {
                    if(Input.GetMouseButtonDown(0)){
                        this.hold = true;
                        this.startPos = Input.mousePosition;
                    }
                    else if(Input.GetMouseButtonUp(0))
                    {
                        this.hold = false;
                    }
                    if(this.hold)
                    {
                        this.curPos = Input.mousePosition;
                        transform.Translate((mainCamera.orthographicSize / 5) * vscale * (startPos - curPos));
                        if(outside()) transform.Translate((mainCamera.orthographicSize / 5) * vscale * (curPos - startPos));
                        startPos = curPos;
                    }
                }

                else if (Input.touchCount > 1){
                    Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                    // check how much zoom in / out
                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                    // zoom camera
                    float newSize = mainCamera.orthographicSize + (deltaMagnitudeDiff * zoomSpeed);
                    newSize = Mathf.Max(newSize, 1f);
                    newSize = Mathf.Min(newSize, 6f);
                    mainCamera.orthographicSize = newSize;
                }
            }
            yield return null;
        }
    }

    // check if outside the boundary
    bool outside() {
        if (transform.position.x > MAX_X || transform.position.x < MIN_X
            || transform.position.y > MAX_Y || transform.position.y < MIN_Y)
            return true;
        else return false;
    }
}
