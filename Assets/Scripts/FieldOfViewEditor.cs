﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(FieldOfView))]

public class FieldOfViewEditor : Editor
{

    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);
        Handles.DrawLine(fow.transform.position, fow.transform.position - viewAngleA * fow.viewRadius * Mathf.Cos(fow.transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
        Handles.DrawLine(fow.transform.position, fow.transform.position - viewAngleB * fow.viewRadius * Mathf.Cos(fow.transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
    }
}
