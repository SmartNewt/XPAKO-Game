using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class destructibleTiles : MonoBehaviour
{
    public Tilemap Objectmap;
    public Vector3Int hitPos;
    public ChunkGeneration script;
    // Start is called before the first frame update
    void Start()
    {
        Objectmap = GetComponent<Tilemap>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                hitPos = Objectmap.WorldToCell(hitPosition);
                hitPos.z = -5;

                // Debug.Log("collision point");
                // Debug.Log(hitPos);
                // Debug.Log(Objectmap.GetTile(hitPos));

                Objectmap.SetTile(hitPos, null);
                script.numberObjects -= 1;
                break;
            }
        }
    }
}
