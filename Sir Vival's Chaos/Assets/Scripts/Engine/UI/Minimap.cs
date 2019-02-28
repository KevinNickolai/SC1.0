using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    [SerializeField]
    private bool debugRay = false;

    private Vector2 mmPos;

    private RawImage minimap;

    private Camera mmCam;

    private void Start()
    {
        minimap = gameObject.GetComponent<RawImage>();

        mmCam = GameObject.Find("MinimapCamera").GetComponent<Camera>();


    }

    private void Update()
    {
        /**
         * Make the rectangle of the camera view
         */

        int layerMask = LayerMask.GetMask("Terrain");

        //coordinates for the 4 corners of the screen, in order to draw the view frustrum on the terrain of the map
        Ray topLeft = Camera.main.ScreenPointToRay(new Vector3(0, Screen.height));
        Ray topRight = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height));
        Ray bottomLeft = Camera.main.ScreenPointToRay(Vector3.zero);
        Ray bottomRight = Camera.main.ScreenPointToRay(new Vector3(Screen.width, 0));

        RaycastHit tl, tr, bl, br;

        //checking hits for each of the 4 corners of the view frustrum onto the terrain; need to think of a way to extend lines to end of terrain if a corner does not hit.
        //possibly some kind of multi-raycast from a corner that does hit; i.e. topLeft hits but not top right, then cast for top center, then logrithmically determine the last point to hit
        if (Physics.Raycast(topLeft, out tl, Mathf.Infinity, layerMask) &&
            Physics.Raycast(topRight,out tr,Mathf.Infinity,layerMask) &&
            Physics.Raycast(bottomLeft,out bl, Mathf.Infinity, layerMask) &&
            Physics.Raycast(bottomRight,out br, Mathf.Infinity, layerMask))
        {
            if (debugRay)
            {
                
                Debug.DrawLine(tl.point, tr.point, Color.red);
                Debug.DrawLine(tr.point, br.point, Color.red);
                Debug.DrawLine(br.point, bl.point, Color.red);
                Debug.DrawLine(bl.point, tl.point, Color.red);
            }

        }

        //center of screen ray, to translate raycast hits on terrain into a position on the orthogonal camera
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 100);
        Ray stwp = Camera.main.ScreenPointToRay(screenCenter);


        RaycastHit hit;
        if (Physics.Raycast(stwp, out hit, Mathf.Infinity, layerMask))
        {
            if (debugRay)
            {
                Debug.DrawRay(stwp.origin, stwp.direction * hit.distance, Color.red);
            }

            Vector3 vp = mmCam.WorldToViewportPoint(hit.point);
            //Debug.Log(vp);
        }
    }

    private void OnMouseDown()
    {
        int mmLayer = LayerMask.GetMask("Minimap");

        //no need to check for collider existence; a collider must exist for OnMouseDown to execute
        Vector3 mmSize = transform.GetComponent<BoxCollider>().size;

        //Debug.Log(mmSize);

        //the position of the minimap on the screen
        Vector3 mmScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        //getting bounds for the mouse click on the minimap
        Vector2 xBound = new Vector2(Mathf.Floor(mmScreenPos.x - mmSize.x / 2f), Mathf.Ceil(mmScreenPos.x + mmSize.x / 2f));
        Vector2 yBound = new Vector2(Mathf.Floor(mmScreenPos.y - mmSize.y / 2f), Mathf.Ceil(mmScreenPos.y + mmSize.x / 2f));


        Debug.Log(xBound);
        Debug.Log(yBound);
        Debug.Log(Input.mousePosition);


        //Debug.Log(Input.mousePosition);
    }
}
