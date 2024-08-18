using System.Collections;
using UnityEngine;

public class Parent : MonoBehaviour
{
    [SerializeField]
    private GameObject children;
    private Transform currentParent;

    private Vector3 spawnPosition;

    [SerializeField]
    private float waitTime;

    private void Awake()
    {
        currentParent = transform;
        spawnPosition = transform.position + Vector3.up;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            spawnPosition += new Vector3(0.1f, 0.05f, 0f);

            GameObject instance = Instantiate(children, spawnPosition, Quaternion.identity, currentParent);

            if (instance == null)
            {
                continue;
            }

            currentParent = instance.transform;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
