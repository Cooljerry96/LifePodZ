using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]

public class LineCollision : MonoBehaviour   
{
    MouseDraw lc;
    EdgeCollider2D edgeCollider;
    LineRenderer myLine;
    public Rigidbody2D lineGrav;
    private MouseDraw mouseDraw;
    // Start is called before the first frame update
    void Start()
    {

        edgeCollider = this.GetComponent<EdgeCollider2D>();
        myLine = this.GetComponent<LineRenderer>();
        mouseDraw = GameObject.Find("LineManager").GetComponent<MouseDraw>();
        lineGrav = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDraw.lineDone == true)
        {
            lineGrav.simulated = true;    
        }
        SetEdgeCollider(myLine);
    }

    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for(int point = 0; point<lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        edgeCollider.SetPoints(edges);
    }
    
}
