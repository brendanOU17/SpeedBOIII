using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
   public static bool tap, swipeLeft, swipeRight,swipeUp ,swipeDown;
    private bool isDrag = false;
    private Vector2 startTouch, swipeDelta;
    
    private void Update()
    {
        tap = swipeUp = swipeLeft = swipeRight = swipeDown = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDrag = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            Reset();
        }
        #endregion
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDrag = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            isDrag = false;
            Reset();
        }

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap=true;
                isDrag =true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDrag=false;
                Reset();
            }
        }
        #endregion

        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDrag = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDrag = false;
                Reset();
            }
        }

        //calculate the distance 
        swipeDelta = Vector2.zero;
        if (isDrag)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch; 
        }

        if (swipeDelta.magnitude > 125)
        {
            float x= swipeDelta.x;
            float y= swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
                   
                    
            }
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDrag = false;
    }


}
