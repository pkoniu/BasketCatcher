﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//PatrykKonior

[CreateAssetMenu]
public class PunchTweener : AbstractTweener
{
    public float punchScale;
    public float duration;
    public int vibrato;
    public float elastacity;
    public override void Tween(Transform transform)
    {
        var scl = new Vector3(punchScale, punchScale, punchScale);
        transform.DOPunchScale(scl, duration, vibrato, elastacity);
    }
}
