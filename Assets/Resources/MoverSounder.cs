using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MoverSounder : MonoBehaviour
{
    Vector3 Vec;
    public AudioMixer mixer;
    public float cycleScale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Z: " + transform.position.z);

        Vec = transform.localPosition;
        Vec.y += Input.GetAxis("Jump") * Time.deltaTime * 20;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
        Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;
        transform.localPosition = Vec;

        ChangeFreq(mixer, "sinFreq", cycleScale * Mathf.Abs(transform.position.z));
    }

    void ChangeFreq(AudioMixer mixer, string paramName, float freqValue)
    {
        mixer.SetFloat(paramName, freqValue);
    }
}
