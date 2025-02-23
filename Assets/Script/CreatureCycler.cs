using UnityEngine;

public class CreatureCycler : MonoBehaviour {
    
    int activeIndex = 0;

    public void Cycle() {
        for(int i = 0; i < this.transform.childCount; i++) {
            if(this.transform.GetChild(i).gameObject.activeSelf) {
                activeIndex = i;
            }
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        int lastElement = activeIndex-1 == -1 ? this.transform.childCount-1 : activeIndex-1;
        this.transform.GetChild(lastElement).gameObject.SetActive(true);
    }

}
