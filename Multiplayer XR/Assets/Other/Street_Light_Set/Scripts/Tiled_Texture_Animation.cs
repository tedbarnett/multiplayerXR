using UnityEngine;
using System.Collections;


class Tiled_Texture_Animation : MonoBehaviour
{		
	public int _uvTieX = 1;
	public int _uvTieY = 1;
	public float _fps = 10;
	
	public float mWaitBeforeStart = 0.0f;
	public int mLoopStartFrame = 3;
	
	private float mStartWait;
	
	private float iX = 0;
	private float iY = 1;
	
	private int mMaxFrames;
	private int mFrameCntr;
	private Vector2 _size;
	private Renderer _myRenderer;
	private int mLastCntr = -1;
	
	
    void Start ()
    {
		mStartWait = mWaitBeforeStart;

        _size = new Vector2 (1.0f / _uvTieX, 1.0f / _uvTieY);
 
        _myRenderer = GetComponent<Renderer>();
        if ( _myRenderer == null )
			enabled = false;
 
        _myRenderer.material.SetTextureScale("_MainTex", _size);
		
		Vector2 offset = new Vector2( 0.0f, 1.0f - _size.y );
		_myRenderer.material.SetTextureOffset( "_MainTex", offset ); 
		
		mMaxFrames = _uvTieX * _uvTieY;
		if ( mLoopStartFrame >= mMaxFrames )
		{
			Debug.Log( "mLoopStartFrame error!!" );
			mLoopStartFrame = 0;
		}
		mFrameCntr = 0;
    }

    void Update()
    {
		if ( mStartWait > 0.0f )
		{
			mStartWait -= Time.deltaTime;
			if ( mStartWait < 0.0f )
				mStartWait = 0.0f;
			else
				return;
		}
		
        int cntr = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);		
        if ( cntr != mLastCntr )
        {
			iX = mFrameCntr % _uvTieX;
			iY = ((mFrameCntr / _uvTieX) + 1) % _uvTieY;
			
            Vector2 offset = new Vector2( iX*_size.x, 1.0f - (_size.y * iY ) );
            _myRenderer.material.SetTextureOffset( "_MainTex", offset );
		
			mFrameCntr++;
			
			if ( mFrameCntr == mMaxFrames )
			{					
				iX = mLoopStartFrame % _uvTieX;
				iY = ((mLoopStartFrame / _uvTieX) + 1) % _uvTieY;
				mFrameCntr = mLoopStartFrame;
			}
			
			mLastCntr = cntr;
        }
    }
} 