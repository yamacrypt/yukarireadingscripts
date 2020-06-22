﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

public class InfiniteScroll : UIBehaviour
{
	[SerializeField]
	private RectTransform itemPrototype;

	[SerializeField, Range(0, 30)]
	public int instantateItemCount = 9;

	[SerializeField]
	private Direction direction;

	public OnItemPositionChange onUpdateItem = new OnItemPositionChange();

	[System.NonSerialized]
	public LinkedList<RectTransform> itemList = new LinkedList<RectTransform>();

	protected float diffPreFramePosition = 0;

	protected int currentItemNo = 0;
	List<IInfiniteScrollSetup> controllers;
	ScrollRect scrollRect;
	public enum Direction
	{
		Vertical,
		Horizontal,
	}

	// cache component

	private RectTransform _rectTransform;
	protected RectTransform rectTransform {
		get {
			if(_rectTransform == null) _rectTransform = GetComponent<RectTransform>();
			return _rectTransform;
		}
	}

	private float anchoredPosition
	{
		get {
			return direction == Direction.Vertical ? -rectTransform.anchoredPosition.y : rectTransform.anchoredPosition.x;
		}
	}

	private float _itemScale = -1;
	public float itemScale {
		get {
			if(itemPrototype != null && _itemScale == -1) {
				_itemScale = direction == Direction.Vertical ? itemPrototype.sizeDelta.y : itemPrototype.sizeDelta.x;
			}
			return _itemScale;
		}
	}
	ItemControllerLimited itemControllerLimited;
	Seacher seacher;
	protected override void Start ()
	{
		//Debug.Log("loadscrill");
		seacher=GameObject.Find("EventSystem").GetComponent<Seacher>();
		itemControllerLimited =GetComponent<ItemControllerLimited>();
		controllers = GetComponents<MonoBehaviour>()
				.Where(item => item is  IInfiniteScrollSetup)
				.Select(item => item as  IInfiniteScrollSetup)
				.ToList();	
		scrollRect = GetComponentInParent<ScrollRect>();
		scrollRect.horizontal = direction == Direction.Horizontal;
		scrollRect.vertical = direction == Direction.Vertical;
		scrollRect.content = rectTransform;
		itemPrototype.gameObject.SetActive(false);
		
		for(int i = 0; i < instantateItemCount; i++) {
			var item = GameObject.Instantiate(itemPrototype) as RectTransform;
			item.SetParent(transform, false);
			item.name = i.ToString();
			item.anchoredPosition = direction == Direction.Vertical ? new Vector2(0, -itemScale * i) : new Vector2(itemScale * i, 0);
			itemList.AddLast(item);

			item.gameObject.SetActive(true);
			foreach(var controller in controllers) {
				//Debug.Log(i,item.gameObject);
				controller.OnUpdateItem(i, item.gameObject);
			}
		}
		
		foreach(var controller in controllers){
			controller.OnPostSetupItems();
		}

		//Searchresult();
	}
	public void Searchresult(){
		
		// create items
		int i=0;
		//Debug.Log(itemList.Count);
		foreach (var item in itemList)
		{ 
			foreach(var controller in controllers) {
				//Debug.Log(i,item.gameObject);
				controller.OnUpdateItem(i, item.gameObject);
				i++;
			}
		}
		foreach(var controller in controllers){
			controller.OnPostSetupItems();
		}

	}
	void Update()
	{
		if (itemList.First == null) {
			return;
		}

		while(anchoredPosition - diffPreFramePosition  < -itemScale * 2) {
			diffPreFramePosition -= itemScale;

			var item = itemList.First.Value;
			itemList.RemoveFirst();
			itemList.AddLast(item);

			var pos = itemScale * instantateItemCount + itemScale * currentItemNo;
			item.anchoredPosition = (direction == Direction.Vertical) ? new Vector2(0, -pos) : new Vector2(pos, 0);

			onUpdateItem.Invoke(currentItemNo + instantateItemCount, item.gameObject);

			currentItemNo++;
		}

		while(anchoredPosition - diffPreFramePosition > 0) {
			diffPreFramePosition += itemScale;

			var item = itemList.Last.Value;
			itemList.RemoveLast();
			itemList.AddFirst(item);

			currentItemNo--;

			var pos = itemScale * currentItemNo;
			item.anchoredPosition = (direction == Direction.Vertical) ? new Vector2(0, -pos): new Vector2(pos, 0);
			onUpdateItem.Invoke(currentItemNo, item.gameObject);
		}
		//Debug.Log(currentItemNo);
		if (currentItemNo>itemControllerLimited.max-8){
				//itemControllerLimited.max+=30;
				seacher.search();
		}
	}

	[System.Serializable]
	public class OnItemPositionChange : UnityEngine.Events.UnityEvent<int, GameObject> {}
}
