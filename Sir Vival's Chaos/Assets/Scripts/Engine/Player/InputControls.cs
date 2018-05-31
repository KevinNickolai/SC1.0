using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour {

    /// <summary>
    /// Bounds for the camera to stay within the map
    /// </summary>
    public const float CAM_BOUND_LEFT = 50;
    public const float CAM_BOUND_RIGHT = 450;
    public const float CAM_BOUND_TOP = 400;
    public const float CAM_BOUND_BOT = -50;

    public const string HORIZONTAL_KEY = "Horizontal";

    public const string VERTICAL_KEY = "Vertical";

    /// <summary>
    /// Base Speed of the camera pan
    /// </summary>
    public const float BASE_PAN_SPEED = .75f;

    /// <summary>
    /// boundary for panning, in pixels
    /// </summary>
    public const int PAN_BOUNDARY = 5;

    /// <summary>
    /// panning multiplier
    /// </summary>
    public const int PAN_MULT = 100;

    /// <summary>
    /// The screen's width
    /// </summary>
    private int screenWidth;

    /// <summary>
    /// The screen's height
    /// </summary>
    private int screenHeight;

    public void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    public void Update()
    {
        /**
         * Update the camera position for any panning operations
         * 
         * Adapted from
         * https://answers.unity.com/questions/266454/top-down-2d-gamehow-to-make-the-camera-move-on-hit.html
         */
        #region Camera Panning

        //temporary value to store the transform of the camera
        Vector3 tf = transform.position;

        if (Input.GetAxisRaw("Mouse ScrollWheel") == 1) {
            Debug.Log("Mouse Scroll");
        }

        //Moving right (+x) on panning or a Horizontal+ input
        if ((Input.mousePosition.x > screenWidth - PAN_BOUNDARY) || (Input.GetAxisRaw(HORIZONTAL_KEY) == 1))
        {
            //Moving only to the bound of the camera box
            if(tf.x < CAM_BOUND_RIGHT)
            {
                tf.x += BASE_PAN_SPEED + PAN_MULT * Time.deltaTime;
            }
        }

        //Moving left (-x) on panning or a Horizontal- input
        if (Input.mousePosition.x < 0 + PAN_BOUNDARY || (Input.GetAxisRaw(HORIZONTAL_KEY) == -1))
        {
            if(tf.x > CAM_BOUND_LEFT)
            {
                tf.x -= BASE_PAN_SPEED + PAN_MULT * Time.deltaTime;
            }
        }

        //Moving up (+z) on panning or a Vertical+ input
        if (Input.mousePosition.y > screenHeight - PAN_BOUNDARY || (Input.GetAxisRaw(VERTICAL_KEY) == 1))
        {
            if(tf.z < CAM_BOUND_TOP)
            {
                tf.z += BASE_PAN_SPEED + PAN_MULT * Time.deltaTime;
            }
        }

        //Moving down (-z) on panning or a Vertical- input
        if (Input.mousePosition.y < 0 + PAN_BOUNDARY || (Input.GetAxisRaw(VERTICAL_KEY) == -1))
        {
            if(tf.z > CAM_BOUND_BOT)
            {
                tf.z -= BASE_PAN_SPEED + PAN_MULT * Time.deltaTime;
            }
        }

        transform.position = tf;
        #endregion

        #region Game Input

        if (Input.GetAxisRaw("Cancel") == 1)
        {
            GameObject.FindObjectOfType<UIController>().ClearInfo();
        }

        #endregion
    }
}
