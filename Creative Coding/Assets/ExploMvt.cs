using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploMvt : MonoBehaviour
{
    public Vector3 posRnd;
    public GameObject citySpawner;
    public float radius;

    public Collider[] boiteColl;

    public float tempsEcouleVille;
    public float tempsEntreVille;
    public List<Vector3> pointParcour = new List<Vector3>();
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        ChooseDestination();
    }

    // Update is called once per frame
    void Update()
    {
        tempsEcouleVille += Time.deltaTime;
        boiteColl = Physics.OverlapSphere(transform.position, radius);
        if(boiteColl.Length < 8 && tempsEcouleVille > tempsEntreVille)
        {
            tempsEcouleVille = 0;
            GameObject newCity = Instantiate(citySpawner, transform.position, transform.rotation);
            transform.parent.GetComponent<ManagerAgent>().allPoint = pointParcour;
            transform.parent.GetComponent<ManagerAgent>().cityToTravel = newCity;
            //transform.parent.GetComponent<ManagerAgent>().allcity.Add(newCity.GetComponent<ManagerAgent>().allPoint);
            //pointParcour.Clear();
            coroutine = ClearParkour();
            StartCoroutine(coroutine);


        }
        transform.LookAt(posRnd);
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit, Mathf.Infinity))
        {
            if(Vector3.Distance(transform.position, hit.point) < 1 || Vector3.Distance(transform.position, hit.point) < 1)
            {
                ChooseDestination();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, posRnd, 5f * Time.deltaTime);
            }
        }
        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.black);
    }

    void ChooseDestination()
    {
        Debug.Log("JECOISIS UNE DIR");
        Vector3 rnd = Random.insideUnitSphere * 5;
        posRnd = transform.position + new Vector3(rnd.x, 0, rnd.z).normalized * 1000;
        pointParcour.Add(transform.position);

    }

    private IEnumerator ClearParkour()
    {
        transform.parent.GetComponent<ManagerAgent>().allPoint = pointParcour;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        //Destroy(gameObject);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
