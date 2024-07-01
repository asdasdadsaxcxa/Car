using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(NavMeshAgent))]
public class BotTest : CarMoving
{
    private LineRenderer mLineRenderer; //라인 렌더러
    private NavMeshAgent mNavAgent; //네브 에이전트

    // 네브 타겟 위치
    [SerializeField] private Transform mTargetPos; //네브 타겟의 위치
    [SerializeField] private Transform mOriginTransform; //네브의 시작점 위치

    [SerializeField] float BotRotSpeed = 90;

    NavMeshPath Path;

    private void Start()
    {
        Path = new NavMeshPath();
        transform.position = mOriginTransform.position;
        InitNaviManager(mOriginTransform, mTargetPos, 0.03f);
    }
    //[SerializeField] GameObject TestBox_1;
    //[SerializeField] GameObject TestBox_2;

    private void OnDrawGizmos()
    {
        if (mNavAgent != null)
        {
            Gizmos.color = UnityEngine.Color.white;
            for (int i = 1; i < Path.corners.Length; ++i)
            {
                Gizmos.DrawCube(Path.corners[i], Vector3.one / 2);
            }
            if (Path.corners.Length > 2)
            {
                Gizmos.color = UnityEngine.Color.red;
                Gizmos.DrawCube(Path.corners[1], Vector3.one / 2);
            }
        }

        //Debug.Log(GetAngle(TestBox_1.transform.position, TestBox_2.transform.position));
    }

    //private void FixedUpdate()
    //{
    //    //if (mNavAgent != null && Path.corners.Length > 2)
    //    //{
    //    //    GetAngle();
    //    //}
    //}


    void GetAngle()
    {
        TrigetEvent(true);
        //float Target = GetAngle(transform.position, TestBox_2.transform.position) * -1;
        float Target = GetAngle(transform.position, Path.corners[1]) * -1;
        float angle = transform.rotation.eulerAngles.y > 180 ? transform.rotation.eulerAngles.y - 360 : transform.rotation.eulerAngles.y;
        Target = angle - Target;
        //Target %= 360;
        Target = Target < -180 ? Target + 360 : Target;

        //Debug.Log(Target * -1 / 90);

        SliderValueSet(Target*-1/ BotRotSpeed);
    }
    float GetAngle(Vector3 from, Vector3 to)
    {
        Vector3 v = to - from;
        float angle = (Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg) - 90;//z축을 0으로 하기위해
        return angle;
    }
    #region Nav
    public void InitNaviManager(Transform trans, Transform pos, float updateDelay)
    {
        SetOriginTransform(trans);
        SetDestination(pos);

        mLineRenderer = GetComponent<LineRenderer>();
        mLineRenderer.startWidth = 0.5f;
        mLineRenderer.endWidth = 0.5f;
        mLineRenderer.positionCount = 0;

        //Material mat = new Material(Shader.Find("Shader Graphs/SampleTwinkle"));
        //mat.SetColor("_BaseColor", Color.green);
        //mLineRenderer.material = mat;

        mNavAgent = GetComponent<NavMeshAgent>();
        mNavAgent.isStopped = true;
        //mNavAgent.radius = 1.0f;
        //mNavAgent.height = 1.0f;

        StartCoroutine(UpdateNavi(updateDelay));
    }
    private IEnumerator UpdateNavi(float updateDelay)
    {
        WaitForSeconds delay = new WaitForSeconds(updateDelay);
        
        while (true)
        {
            //타겟 위치 설정
            mNavAgent.CalculatePath(mTargetPos.position , Path);

            //패스 그리기
            DrawPath();

            //Bot 적용
            if (mNavAgent != null && Path.corners.Length > 1)
            {
                GetAngle();
            }
            yield return delay;
        }
    }
    public void SetDestination(Transform pos)
    {
        mTargetPos = pos;
    }

    public void SetOriginTransform(Transform trans)
    {
        mOriginTransform = trans;
        transform.position = mOriginTransform.position;
    }
    private void DrawPath()
    {
        //mLineRenderer.positionCount = mNavAgent.path.corners.Length;
        mLineRenderer.positionCount = Path.corners.Length;
        mLineRenderer.SetPosition(0, transform.position);

        //if (mNavAgent.path.corners.Length < 2)
        if (Path.corners.Length < 2)
        {
            return;
        }

        //for (int i = 1; i < mNavAgent.path.corners.Length; ++i)
        for (int i = 1; i < Path.corners.Length; ++i)
        {
            mLineRenderer.SetPosition(i, Path.corners[i]);
        }
    }

    #endregion
}
