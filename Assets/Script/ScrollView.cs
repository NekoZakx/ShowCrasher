using UnityEngine;
using System;
using System.Collections.Generic;

public class CustomScrollView
{
	public Vector2 BeginScrollView(
		Rect viewArea,
		Vector2 scrollPosition,
		Rect contentRect,
		bool useHorizontal,
		bool useVertical,
		GUIStyle hStyle,
		GUIStyle vStyle,
		Vector4 margin)
	{
		//define scrollbar size
		Vector2 scrollbarSize = new Vector2(hStyle.CalcSize(GUIContent.none).y,vStyle.CalcSize(GUIContent.none).x);
		
		//Show scrollbar and move content in opposite direction
		//Create Horizontal scrollbar if enabled
		if (useHorizontal)
		{
			Rect hScrRect = new Rect(viewArea.x, viewArea.y + viewArea.height - scrollbarSize.y, viewArea.width, scrollbarSize.x);
			scrollPosition.x = GUI.HorizontalScrollbar(hScrRect,scrollPosition.x,viewArea.width,0,contentRect.width);
			viewArea.height -= scrollbarSize.x;
		}
		
		//Create Vertical scrollbar if enabled
		if (useVertical)
		{
			int size = (viewArea.height > contentRect.height)? (int)contentRect.height : (int)viewArea.height;
			Rect vScrRect = new Rect(viewArea.x, viewArea.y, scrollbarSize.y, viewArea.height);
			scrollPosition.y = GUI.VerticalScrollbar(vScrRect,scrollPosition.y,size,0,contentRect.height);
			viewArea.width -= scrollbarSize.y;
			viewArea.x += scrollbarSize.y;
		}
		
		//contentRect.x = viewArea.x;
		//contentRect.y = viewArea.y;
		contentRect.width = viewArea.width;
		
		//Setup Margin
		
		//X-axis
		viewArea.x += margin.x;
		viewArea.width -= margin.x - margin.z;
		
		//Y-axis
		viewArea.y += margin.y;
		viewArea.height -= margin.y - margin.w;
		
		GUILayout.BeginArea(viewArea);
		
		//if i'm not at the bottom, do bottom
		//if i'm exceeding, don't move
		
		if(viewArea.width <= contentRect.width && scrollPosition.x <= contentRect.width - viewArea.width)
			contentRect.x = -scrollPosition.x;
		else
			contentRect.x = -(contentRect.width - viewArea.width);
		
		
		if(viewArea.height <= contentRect.height && scrollPosition.y <= contentRect.height - viewArea.height)
			contentRect.y = -scrollPosition.y;
		else
			contentRect.y = -(contentRect.height - viewArea.height);
		
		
		GUI.BeginGroup(contentRect);
		return new Vector2(Math.Abs(contentRect.x),Math.Abs(contentRect.y));
	}
	
	public Vector2 BeginScrollView(
		Rect viewArea,
		Vector2 scrollPosition,
		int height,
		Vector4 margin,
		bool useHorizontal = false,
		bool useVertical = false)
	{
		Rect contentRect = new Rect(0,0,viewArea.width,height);
		return BeginScrollView(viewArea, scrollPosition, contentRect, useHorizontal, useVertical, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar,margin);
	}
	
	public void EndScrollView()
	{
		GUI.EndGroup();
		GUILayout.EndArea();
	}
}