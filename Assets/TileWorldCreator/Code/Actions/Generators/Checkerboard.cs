﻿
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using TWC.editor;

namespace TWC.Actions

{
//	// Define the category for this action (Generator or Modifier)
//	// Generator
	[ActionCategoryAttribute(Category=ActionCategoryAttribute.CategoryTypes.Generators)]
	
//	// Set the name of this action
	[ActionNameAttribute(Name="Checkerboard")]
//	// Inherit from TWCBlueprintAction and implement the ITWCAction interface
	public class Checkerboard : TWCBlueprintAction, ITWCAction
	{
		public bool horizontal = true;
		public bool vertical = true;
		public bool fillIntersections = true;
		public int spacing = 2;


		// Custom gui layout. If we want to implement a custom gui for this action we need this 
		// guilayout, so that the reorderable list can draw the gui correctly.
		private TWCGUILayout guiLayout;

		// Clone function
		// This is called when the user duplicated this action
		// Simply return a new class of this type and assign all parameters
		public ITWCAction Clone()
		{
			var _r = new Checkerboard();
			return _r;
		}
		
		
//		// The actual execution method which gets called by TileWorldCreator.
//		// Here you can make your map modifications. Make sure to return the new map.
		public bool[,] Execute(bool[,] map, TileWorldCreator _twc)
		{
			
			var width = map.GetLength(0);
			var height = map.GetLength(1);

			//for loop to go thru all x values
	        for (int x = 0; x < width; x ++)
	        {
				//for each value go thru all y values, so we have gone thru all values
	            for (int y = 0; y < height; y ++)
	            {
	                //if our bool it ticked, 
					if(horizontal)
						{
							//and the y value of a given square based on our modulo number
							if(y%spacing==0)
							{
								//fill or invert at intersections
								if(fillIntersections)
								{
									map[x,y] = true;
								}
								else
								{
								//flip that square's value
									map[x,y] = !map[x,y];
								}
							}
						}
					//do the same but for the vertical tick if bool is true
					if(vertical)
						{
							if(x%spacing==0)
								//fill or invert at intersections
								if(fillIntersections)
								{
									map[x,y] = true;
								}
								else
								{
								//flip that square's value
									map[x,y] = !map[x,y];
								}
						}
	            }
	        } 

	        return map;
		}
	    
	    #if UNITY_EDITOR
		// Custom gui for this action
		public override void DrawGUI(Rect _rect, int _layerIndex, TileWorldCreatorAsset _asset, TileWorldCreator _twc)
		{
			// Use the guiLayout to make sure the gui is drawn correctly in the reorderable list
			using (guiLayout = new TWCGUILayout(_rect))
			{

				guiLayout.Add();
				horizontal = EditorGUI.Toggle(guiLayout.rect, "Horizontal Lines", horizontal);
				guiLayout.Add();
				vertical = EditorGUI.Toggle(guiLayout.rect, "Vertical Lines", vertical);
				guiLayout.Add();
				fillIntersections = EditorGUI.Toggle(guiLayout.rect, "Fill Intersections", fillIntersections);
				guiLayout.Add();
				spacing = EditorGUI.IntField(guiLayout.rect, "Spacing", spacing);


			}
		}
		#endif
//	
//		// Must be implemented when using a custom gui.
//		// Here we're returning the height of the guiLayout.
		public float GetGUIHeight()
		{ 
			if (guiLayout != null)
			{
				return guiLayout.height;
			}
			else
			{
				return 18;
			}
		}
//		
	}
}