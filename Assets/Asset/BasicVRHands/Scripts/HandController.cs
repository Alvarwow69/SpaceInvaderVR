using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public class HandController : MonoBehaviour {

    private Animator animator;

    public string InputName;
    public HandController OtherHandReference;
    public XRNode NodeType;
    public Vector3 ObjectGrabOffset;
    public float GrabDistance = 0.1f;
    public string GrabTag = "Grab";
    public float ThrowMultiplier = 1.5f;
    public GameObject ship;
    public Animator anim;

    public Transform CurrentGrabObject
    {
        get { return _currentGrabObject; }
        set { _currentGrabObject = value; }
    }

    private Vector3 _lastFramePosition;
    private Transform _currentGrabObject;
    //private bool _isGrabbing;

    void Start()
    {
        animator = GetComponent<Animator>();
        _lastFramePosition = transform.position;
        XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);
        _currentGrabObject = null;
        //_isGrabbing = false;
    }

    void Shoot()
    {
        if (Input.GetKey("joystick button 14") || Input.GetKey("joystick button 15"))
        {
            GameObject.Find("Player").GetComponent<Ship>().Shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("right", false);
        anim.SetBool("left", false);



        Shoot();
        transform.localPosition = InputTracking.GetLocalPosition(NodeType) + new Vector3(0.1f, 0, 0.4f);
        transform.localRotation = InputTracking.GetLocalRotation(NodeType);

        if (Ship.alive)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                anim.SetBool("right", true);
                ship.transform.RotateAround(ship.transform.position, new Vector3(0, Input.GetAxis("Horizontal"), 0), 1);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("left", true);
                ship.transform.RotateAround(ship.transform.position, new Vector3(0, Input.GetAxis("Horizontal"), 0), 1);
            }
        }
        /*if (_currentGrabObject == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, GrabDistance);
            if (colliders.Length > 0)
            {
                if (Input.GetKey(InputName) && colliders[0].transform.CompareTag(GrabTag))
                {
                    if (_isGrabbing)
                        return;
                    _isGrabbing = true;
                    colliders[0].transform.SetParent(transform);
                    if (colliders[0].GetComponent<Rigidbody>() == null)
                        colliders[0].gameObject.AddComponent<Rigidbody>();
                    colliders[0].GetComponent<Rigidbody>().isKinematic = true;
                    _currentGrabObject = colliders[0].transform;
                    if (OtherHandReference.CurrentGrabObject != null)
                        OtherHandReference.CurrentGrabObject = null;
                }
            }
        }
        else
        {
            if (!Input.GetKey(InputName))
            {
                Rigidbody _objectRGB = _currentGrabObject.GetComponent<Rigidbody>();
                _objectRGB.isKinematic = false;
                _objectRGB.collisionDetectionMode = CollisionDetectionMode.Continuous;
                Vector3 CurrentVelocity = (transform.position - _lastFramePosition) / Time.deltaTime;
                _objectRGB.velocity = CurrentVelocity * ThrowMultiplier;
                _currentGrabObject.SetParent(null);
                _currentGrabObject = null;
            }
        }
        if (!Input.GetKey(InputName) && _isGrabbing)
            _isGrabbing = false;*/
        _lastFramePosition = transform.position;
        animator.SetBool("isGrabbing", Input.GetKey(InputName));
    }
}
