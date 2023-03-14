using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TAMIYANOMAR_navigator : MonoBehaviour
{
    [SerializeField]
    Transform target;     // �ڕW�n�_
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    LineRenderer line;

    NavMeshPath path;

    private bool activated = true; 
    // Start is called before the first frame update
    void Start()
    {
        // �o�H�擾�p�̃C���X�^���X�쐬
        path = new NavMeshPath();
        // �����I�Ȍo�H�v�Z���s
        agent.CalculatePath(target.position, path);
        agent.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            agent.destination = target.position;
            path = agent.path;
            // LineRenderer�Ōo�H�`��I
            line.SetVertexCount(path.corners.Length);
            line.SetPositions(path.corners);
            line.SetWidth(1f, 1f);
            
        }
        else
        {
            line.SetWidth(0f, 0f);
        }
    }

    public void activate()
    {
        activated = true;
    }

    public void deactivate()
    {
        activated = false;
    }
}
