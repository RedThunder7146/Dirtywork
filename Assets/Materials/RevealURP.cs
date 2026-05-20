using UnityEngine;

[ExecuteInEditMode]
public class RevealURP : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;

    void Update()
    {
        if (Mat != null && SpotLight != null && SpotLight.isActiveAndEnabled == true)
        {
            // URP shader uses "_LightPosition", "_LightDirection", and "_LightAngle"
            Mat.SetVector("_LightPosition", SpotLight.transform.position);
            Mat.SetVector("_LightDirection", -SpotLight.transform.forward);
            Mat.SetFloat("_LightAngle", SpotLight.spotAngle);
        }

        else
        {
            Mat.SetVector("_LightPosition", Vector3.zero);
            Mat.SetVector("_LightDirection", Vector3.zero);
            Mat.SetFloat("_LightAngle", 0);
        }
    }
}