using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(InfiniteScroll))]
public class ItemControllerLimited : UIBehaviour, IInfiniteScrollSetup {

	//[SerializeField]
	public int max = 0;

	public void OnPostSetupItems()
	{
		var infiniteScroll = GetComponent<InfiniteScroll>();
		infiniteScroll.onUpdateItem.AddListener(OnUpdateItem);
		GetComponentInParent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;

		var rectTransform = GetComponent<RectTransform>();
		var delta = rectTransform.sizeDelta;
		delta.y = infiniteScroll.itemScale * max;
		rectTransform.sizeDelta = delta;
	}

	public void OnUpdateItem(int itemCount, GameObject obj)
	{
		if(itemCount < 0 || itemCount >= max) {
			obj.SetActive (false);
		}
		else {
			obj.SetActive (true);
			
			if (obj.GetComponentInChildren<Item>()){
				var item=obj.GetComponentInChildren<Item>();
				item.UpdateItem(itemCount);
			}
			else {
				var item=obj.GetComponentInChildren<LibItem>();
				item.UpdateItem(itemCount);
			} 
			
		}
	}
}
