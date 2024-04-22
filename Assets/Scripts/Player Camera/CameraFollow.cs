using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    void FixedUpdate()
    {
        //Vector3 rotation = new Vector3(target.rotation.x, target.rotation.y, target.rotation.z);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, smoothSpeed);
        this.transform.position = smoothedPosition;

        //transform.rotation = target.rotation;
        //transform.forward = target.transform.forward;

 
    }*/


   
    public GameObject Target;
    public float DepthOffSet = 1;
    public float VerticalOffSet = 1;
    public float Interpolate = 0.125f;
    public Vector3 oldPosition;

  //  public float sholderOffset = 0.25f;
    private GameObject thePlayer;
    private bool PLayerStun;

    // Start is called before the first frame update
    void Start()
    {
        if (Target == null)
        {
            oldPosition = new Vector3(0, 0, 0);
            throw new System.Exception("no target specified");
        }

        //get if player's stun
        thePlayer = GameObject.Find("PLayer");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        PLayerStun = thePlayer.GetComponent<PlayerFloatMove>().controller;

        if (PLayerStun)
        {
            Vector3 d = Target.transform.forward * DepthOffSet;
            Vector3 v = Target.transform.up * VerticalOffSet;
           // Vector3 s = Target.transform.right * sholderOffset;

            Vector3 finalloc = d + v + Target.transform.position;
            this.transform.position = Vector3.Lerp(this.transform.position, finalloc, Interpolate);
        }

        this.transform.LookAt(Target.transform.position); //not for older the shoulder
        this.transform.forward = Target.transform.forward;
        oldPosition = Target.transform.position;


    }
    
}
