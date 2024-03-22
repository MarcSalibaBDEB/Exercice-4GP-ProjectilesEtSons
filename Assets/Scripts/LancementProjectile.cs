using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementProjectile : MonoBehaviour
{
    [SerializeField] private GameObject prefabProjectile;
    [SerializeField] private float vitesse;
    private Rigidbody rbProjectile;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LancerProjectile();
        }

    }

    private void LancerProjectile()
    {
        GameObject projectile = GameObject.Instantiate(prefabProjectile);

        projectile.transform.position = transform.position + transform.forward;

        rbProjectile = projectile.GetComponent<Rigidbody>();
        rbProjectile.velocity = transform.forward * vitesse * Time.fixedDeltaTime;
        
        StartCoroutine(TempsVieProjectile(projectile));
    }

    private IEnumerator TempsVieProjectile(GameObject _projectile)
    {
        yield return new WaitForSeconds(3f);
        Destroy(_projectile);
    }
}
