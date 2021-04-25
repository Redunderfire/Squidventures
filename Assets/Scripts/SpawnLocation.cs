using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject shipPartPrefab;
    public Vector3 center;
    public Vector3 size;
    public int numberOfParts;
    List<string> chunks = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= numberOfParts; i++)
        {
            SpawnPart(i);
        }
            
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPart(int n)
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GameObject tempPrefab = Instantiate(shipPartPrefab,pos, Quaternion.identity);
        tempPrefab.name = "Ship Part " + n;
        IdentifyChunk(pos);
    }

    public void IdentifyChunk(Vector3 pos)
    {
        int a = 1, b = 1, c = 1;
        if (pos.x<0)
            a = -1;
        if (pos.y<0)
            b = -1;
        if (pos.z<0)
            c = -1;
        Vector3 chunkpos = new Vector3((int) (a * (Mathf.Abs(pos.x) + 10) / 20), (int) (b * (Mathf.Abs(pos.x) + 10) / 20), (int) (c * (Mathf.Abs(pos.x) + 10) / 20));
        //Debug.Log(chunkpos);
        chunks.Add("Chunk (" + chunkpos.x + ", " + chunkpos.y + ", " + chunkpos.z + ")");
    }
    public void HasShipPart(Chunk justCreated)
    {
        Debug.Log(justCreated.name);
        foreach (string partName in chunks)
        {
            if(partName == justCreated.name)
            {
                Debug.Log("Matched " + partName);
                //Bad bad shit code. Finds position from searching for game object by name. should change the list to be of gameobjects to hold the prefabs to get rid of this terrrible code
                GameObject tempPartPrefab = GameObject.Find("Ship Part " + chunks.IndexOf(partName) + 1);
                PlacePart(  //it should be fine might be a breakpoint though... idfk
                            IsInside(justCreated.GetComponent<Collider>(), tempPartPrefab.transform.position), tempPartPrefab);
            }
                
        }
    }

    public void PlacePart(bool inside, GameObject tempPartPrefab)
    {
        Vector3 pos = tempPartPrefab.transform.position;
        RaycastHit hitInfo;
        if (inside || Physics.Raycast(pos, Vector3.down))
        {
            Physics.Raycast(pos, Vector3.up, out hitInfo);
            Debug.DrawLine(pos, hitInfo.point, Color.blue);
            tempPartPrefab.transform.position = hitInfo.point;
            return;
        }
        if (!inside || Physics.Raycast(pos, Vector3.up))
        {
            Physics.Raycast(pos, Vector3.down, out hitInfo);
            Debug.DrawLine(pos, hitInfo.point, Color.green);
            tempPartPrefab.transform.position = hitInfo.point;
        }
    }

    public bool IsInside(Collider c, Vector3 point)
    {
        Vector3 closest = c.ClosestPoint(point);
        // Because closest=point if inside - not clear from docs I feel
        return closest == point;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
