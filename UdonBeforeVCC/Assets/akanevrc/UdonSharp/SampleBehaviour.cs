
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SampleBehaviour : UdonSharpBehaviour
{
    public int _intNumber = 0;
    public float _floatNumber = 0.0F;
    public Vector3 _vector = Vector3.zero;
    public Material _material = null;
    public UdonBehaviour _udonBehaviour = null;
}
