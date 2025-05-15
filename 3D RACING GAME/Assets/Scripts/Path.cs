using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color linecolor;
    private List<Transform> nodes= new List<Transform>();//List of transform
    void OnDrawGizmosSelected(){//OnDrawGizmos to draw lines
        Gizmos.color=linecolor;
        Transform[] pathTransform=GetComponentsInChildren<Transform>();
        nodes=new List<Transform>();
        for(int i=0;i<pathTransform.Length;i++){
            if(pathTransform[i]!=transform){//this checks that nodes will not contain its own transform
                nodes.Add(pathTransform[i]);
            }
        }
        for(int i=0;i<nodes.Count-1;i++)//We will draw line connecting the nodes
        {
            Vector3 currentnode=nodes[i].position,nextnode=nodes[i+1].position;
            Gizmos.DrawLine(nodes[i].position,nodes[i+1].position);
            Gizmos.DrawWireSphere(currentnode,2f);
            Gizmos.DrawWireSphere(nextnode,2f);
        }
    }
}
