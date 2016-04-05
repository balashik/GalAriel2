using UnityEngine;
using System.Collections;
using System;

//Consider even abstracting this class further, especially the whole particle system stuff. - a
public class Laser : MonoBehaviour, IProjectile
{
    //[SerializeField]
    public ParticleSystem _myParticleSystem;


    public void Fire()
    {
        if (_myParticleSystem != null)
            _myParticleSystem.Emit(1);
        else Debug.LogError("Cannot fire weapon - attached particle system seems to not be connected");
    }

    // Use this for initialization
    void Start()
    {
        _myParticleSystem = GetComponent<ParticleSystem>();
        if (_myParticleSystem == null)
            Debug.LogError("Could not fetch the Particle System component from this weapon.");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }


    /// <summary>
    /// So this is where we'd handle the logic of lasers hitting something.
    /// </summary>
    /// <param name="other"></param>
    void OnParticleCollision(GameObject other)
    {

        //should do this in layers or something.
        //temp
        BaseHealthScript otherHealth = other.GetComponent<BaseHealthScript>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(6);
            other.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        }
    }

}
