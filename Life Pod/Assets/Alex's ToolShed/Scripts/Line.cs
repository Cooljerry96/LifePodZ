using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Line : MonoBehaviour
{
    // private UnityEngine.UI.Slider energyBarUI; 
    
    public GameObject canvasParent;
    public UnityEngine.UI.Slider _slider;
    
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public Rigidbody2D rigidBody;
    

    [SerializeField] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    //The minimum distance between line's points.
    float pointsMinDistance = 0.1f;

    //Circle collider added to each line's point
    float circleColliderRadius;

    void Start()
    {
        _slider = canvasParent.GetComponent<UnityEngine.UI.Slider>();
        
    }


    public void AddPoint(Vector2 newPoint)
    {
        //If distance between last point and new point is less than pointsMinDistance do nothing (return)
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;
        // -------------------------------------------- Lower Energy Bar
        //float v = energyBarUI.value --;

        Debug.Log(" --- Points Count: "+pointsCount+" "+_slider.value);

        // -------------------------------------------- Lower Energy Bar

        //Add Circle Collider to the Point
        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;

        //Line Renderer
        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        //Edge Collider
        //Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
        if (pointsCount > 1)
            edgeCollider.points = points.ToArray();
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void UsePhysics(bool usePhysics)
    {
        // isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
        rigidBody.isKinematic = !usePhysics;
    }

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        circleColliderRadius = width / 2f;

        edgeCollider.edgeRadius = circleColliderRadius;
    }

}