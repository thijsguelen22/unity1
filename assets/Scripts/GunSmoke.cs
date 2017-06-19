using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSmoke : MonoBehaviour {
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip; //Essentially this is accessing
                                                                                   //SteamVR_TrackedObject.cs and telling our script
                                                                                   //and defining it here.


    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId Axis0 = Valve.VR.EVRButtonId.k_EButton_Axis0;
    private Valve.VR.EVRButtonId Axis1 = Valve.VR.EVRButtonId.k_EButton_Axis1;
    private Valve.VR.EVRButtonId Axis2 = Valve.VR.EVRButtonId.k_EButton_Axis2;
    private Valve.VR.EVRButtonId Axis3 = Valve.VR.EVRButtonId.k_EButton_Axis3;
    private Valve.VR.EVRButtonId Axis4 = Valve.VR.EVRButtonId.k_EButton_Axis4;
    public bool testGrip;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    //public GameObject particle;
    public Transform barrelEnd;
    public Transform barrelBegin;
    public GameObject bullet;
    public GameObject bulletHole;
    public GameObject objectHit;

    public float timeBetweenBullets = 3;
    public ParticleSystem particle;
    public AudioSource pew;
    public bool ArduinoFire;
    private bool AllowTrigger = true;
    public bool HasShot = false;

    public float timer;
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        pew = GetComponent<AudioSource>();
        ArduinoFire = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("geschoten via keyboard of controller");
        }
        if (HasShot && AllowTrigger || ArduinoFire && AllowTrigger || Input.GetButton("Fire1") && AllowTrigger)
        {
            timer = 0;
            //Instantiate(particle, endOfgun.position, Quaternion.identity);
            particle.enableEmission = true; //deprecated. Moet worden vervangen

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(barrelEnd.position, barrelEnd.up, out hit))
            {
                Collider target = hit.collider;
                float distance = hit.distance; // How far out?
                Vector3 location = hit.point; // Where did I make impact?
                GameObject targetGameObject = hit.collider.gameObject; // What's the GameObject?

                print("object" + targetGameObject.name + "was hit");
                print("Hit something!");
                objectHit = targetGameObject;
                Debug.DrawLine(transform.position, hit.point);
                GameObject bulletInstance;
                GameObject bulletHoleInstance;
                bulletInstance = GameObject.Instantiate(bullet, hit.point, bullet.transform.rotation);
                Debug.Log("bullet instantiated");
                Debug.DrawRay(barrelEnd.position, barrelEnd.up * 0.1f);
                bulletHoleInstance = GameObject.Instantiate(bulletHole, hit.point, bulletHole.transform.rotation);
                bulletHoleInstance.tag = "GeoSphere01";
                //bulletInstance.velocity = (barrelEnd.forward * 1000000);
                //bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(hit.point.forward * 1000);
                Destroy(bulletInstance, 10.5f);
            }


            //old collider method
            /*
            GameObject bulletInstance;
            bulletInstance = GameObject.Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
            //bulletInstance.velocity = (barrelEnd.forward * 1000000);
            bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(barrelEnd.forward * 1000);
            Destroy(bulletInstance, 10.5f);*/

            pew.Play();
            AllowTrigger = false;
            ArduinoFire = false;

            Debug.Log("BAM!");
        }
        if (timer > 0.07f)
        {
            particle.enableEmission = false;
        }
        if(timer > timeBetweenBullets)
        {
            AllowTrigger = true;
        }
    }
}
