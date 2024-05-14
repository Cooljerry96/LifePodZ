using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class MouseDraw : MonoBehaviour
{

    public GameObject linePrefab;
    Coroutine drawing;
    public Rigidbody2D lineGrav;
    public bool lineDone;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }
    }

    void StartLine()
    {
        lineDone = false;

        if (drawing != null)
        {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(DrawLine()); 
    }

    void FinishLine()
    {
        lineDone = true;
      //  this.lineGrav.simulated = true;
        StopCoroutine(drawing);
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(linePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while(true)
        {
          Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount- 1,position);
          yield return null;
        }
    }
}
