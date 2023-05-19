using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerMovement : MonoBehaviour
{
    public Material material;
    public float startWidth = 0.2f;
    public float endWidth = 0.0f;
    public Color startColour = Color.white;
    public Color endColour = Color.clear;
    [SerializeField]
    Slider StrikerSlider;
    public Vector2 Value;

    private LineRenderer lineRenderer;
    private new Rigidbody2D rigidbody2D;
    public static StrikerMovement Movement;

 
    void Start()
    {
        Movement = this;
        // Get a refernece to our RigidBody, or add one if not present.
        rigidbody2D = GetComponent<Rigidbody2D>();
        //if (rigidbody2D == null)
        //{
        //    rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        //}

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
        lineRenderer.material = material;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.startColor = startColour;
        lineRenderer.endColor = endColour;
        lineRenderer.numCapVertices = 20;
        Value = transform.position;
        Debug.Log(Value);
    }

   
    void Update()
    {
       StrikerMovements();
        //StrikerReset();
    }
    
    

    public void StrikerMovements()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, startPos);
            lineRenderer.enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(1, endPos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            lineRenderer.enabled = false;

       
            Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
            rigidbody2D.AddForce(inputForce, ForceMode2D.Impulse);
        }
    }
    public void StrikerReset()
    {
        transform.position = new Vector2(0.36f, -3.25f);
    }
}