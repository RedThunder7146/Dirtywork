using UnityEngine;

[ExecuteInEditMode]
public class RevealURP : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;

    void Update()
    {
        if (Mat != null && SpotLight != null)
        {
            // URP shader uses "_LightPosition", "_LightDirection", and "_LightAngle"
            Mat.SetVector("_LightPosition", SpotLight.transform.position);
            Mat.SetVector("_LightDirection", -SpotLight.transform.forward);
            Mat.SetFloat("_LightAngle", SpotLight.spotAngle);
        }
    }
}