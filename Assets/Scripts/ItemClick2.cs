using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick2 : MonoBehaviour {
	private GameObject scrollview;
	private UILabel label2;

	int index;
	private UILabel lab;
	void Awake() {
		scrollview = GameObject.FindGameObjectWithTag ("scroll1").gameObject;
		label2 = GameObject.FindGameObjectWithTag ("label2").GetComponent<UILabel> ();
		lab = GameObject.FindGameObjectWithTag ("label1").GetComponent<UILabel> ();
	}

	void Start()
	{
		
	}

	public void OnClick() {
		Global.place_lists = null;
//		lab.text = strtxt;
		lab.text = this.transform.Find("Label").transform.GetComponent<UILabel>().text;
		if (lab.text == "서울특별시") {
//			Debug.Log (lab.text);
			Global.place_lists = new string[]{ 
				"종로구", 
				"중구",
				"용산구",
				"성동구",
				"광진구",
				"동대문구",
				"중랑구",
				"성북구",
				"강북구",
				"도봉구",
				"노원구",
				"은평구",
				"서대문구",
				"마포구",
				"양천구",
				"강서구",
				"구로구",
				"금천구",
				"영등포구",
				"동작구",
				"관악구",
				"서초구",
				"강남구",
				"송파구",
				"강동구"};
		} else if (lab.text == "부산광역시") {

			Global.place_lists = new string[]{ 
				"중구",
				"서구",
				"동구",
				"영도구",
				"부산진구",
				"동래구",
				"남구",
				"북구",
				"해운대구",
				"사하구",
				"금정구",
				"강서구",
				"연제구",
				"수영구",
				"사상구",
				"기장군"
			};

		} else if (lab.text == "대구광역시") {

			Global.place_lists = new string[] { 
				"중구",
				"동구",
				"서구",
				"남구",
				"북구",
				"수성구",
				"달서구",
				"달성군"
			};
		} else if (lab.text == "인천광역시") {

			Global.place_lists = new string[] { 
				"중구",
				"동구",
				"남구",
				"연수구",
				"남동구",
				"북구",
				"부평구",
				"계양구",
				"서구",
				"강화군",
				"옹진군"
			};			
		} else if (lab.text == "광주광역시") {

			Global.place_lists = new string[] { 
				"동구",
				"서구",
				"남구",
				"북구",
				"광산구",
			};			
		} else if (lab.text == "대전광역시") {
			Global.place_lists = new string[] { 
				"동구",
				"중구",
				"서구",
				"유성구",
				"대덕구"
			};			
		} else if (lab.text == "울산광역시") {

			Global.place_lists = new string[] { 
				"중구",
				"남구",
				"동구",
				"북구",
				"울주군"
			};			

		} else if (lab.text == "세종특별자치시") {

			Global.place_lists = new string[] { 
				"세종시"
			};			
		} else if (lab.text == "경기도") {

			Global.place_lists = new string[] { 
				"수원시",
				"장안구",
				"권선구",
				"팔달구",
				"영통구",
				"성남시",
				"수정구",
				"중원구",
				"분당구",
				"의정부시",
				"안양시",
				"만안구",
				"동안구",
				"부천시",
				"원미구",
				"소사구",
				"오정구",
				"광명시",
				"평택시",
				"송탄시",
				"동두천시",
				"안산시",
				"상록구",
				"단원구",
				"고양시",
				"덕양구",
				"일산구",
				"일산동구",
				"일산서구",
				"과천시",
				"구리시",
				"미금시",
				"남양주시",
				"오산시",
				"시흥시",
				"군포시",
				"의왕시",
				"하남시",
				"용인시",
				"처인구",
				"기흥구",
				"수지구",
				"파주시",
				"이천시",
				"안성시",
				"김포시",
				"화성시",
				"광주시",
				"양주시",
				"포천시",
				"여주시",
				"양주군",
				"남양주군",
				"여주군",
				"평택군",
				"화성군",
				"파주군",
				"광주군",
				"연천군",
				"포천군",
				"가평군",
				"양평군",
				"이천군",
				"용인군",
				"안성군",
				"김포군",
				"강화군",
				"옹진군"
			};			
		} else if (lab.text == "강원도") {

			Global.place_lists = new string[] { 
				"춘천시",
				"원주시",
				"강릉시",
				"동해시",
				"태백시",
				"속초시",
				"삼척시",
				"춘천군",
				"홍천군",
				"횡성군",
				"원주군",
				"영월군",
				"평창군",
				"정선군",
				"철원군",
				"화천군",
				"양구군",
				"인제군",
				"고성군",
				"양양군",
				"명주군",
				"삼척군"
			};			
		} else if (lab.text == "충청북도") {

			Global.place_lists = new string[] { 
				"청주시 서원구",
				"청주시 청원구",
				"상당구",
				"흥덕구",
				"동부출장소",
				"서부출장소",
				"충주시",
				"제천시",
				"청원군",
				"보은군",
				"옥천군",
				"영동군",
				"증평군",
				"진천군",
				"괴산군",
				"음성군",
				"중원군",
				"제천군",
				"단양군",
				"증평출장소"
			};			
		} else if (lab.text == "충청남도") {

			Global.place_lists = new string[] { 
				"당진시",
				"천안시",
				"동남구",
				"서북구",
				"공주시",
				"대천시",
				"보령시",
				"온양시",
				"아산시",
				"서산시",
				"계룡출장소",
				"논산시",
				"계룡시",
				"금산군",
				"연기군",
				"공주군",
				"논산군",
				"부여군",
				"서천군",
				"보령군",
				"청양군",
				"홍성군",
				"예산군",
				"서산군",
				"태안군",
				"당진군",
				"아산군",
				"천안군"
			};		
		} else if (lab.text == "전라북도") {

			Global.place_lists = new string[] { 
				"전주시",
				"완산구",
				"덕진구",
				"효자출장소",
				"군산시",
				"익산시",
				"정읍시",
				"남원시",
				"김제시",
				"완주군",
				"진안군",
				"무주군",
				"장수군",
				"임실군",
				"남원군",
				"순창군",
				"정읍군",
				"고창군",
				"부안군",
				"김제군",
				"옥구군",
				"익산군"
			};			
		} else if (lab.text == "전라남도") {

			Global.place_lists = new string[] { 
				"목포시",
				"여수시",
				"순천시",
				"나주시",
				"여천시",
				"동광양시",
				"광양시",
				"담양군",
				"곡성군",
				"구례군",
				"광양군",
				"여천군",
				"승주군",
				"고흥군",
				"보성군",
				"화순군",
				"장흥군",
				"강진군",
				"해남군",
				"영암군",
				"무안군",
				"나주군",
				"함평군",
				"영광군",
				"장성군",
				"완도군",
				"진도군",
				"신안군"
			};			
		} else if (lab.text == "경상북도") {

			Global.place_lists = new string[] { 
				"포항시",
				"남구",
				"북구",
				"경주시",
				"김천시",
				"안동시",
				"구미시",
				"영주시",
				"영천시",
				"상주시",
				"점촌시",
				"문경시",
				"경산시",
				"달성군",
				"군위군",
				"의성군",
				"안동군",
				"청송군",
				"영양군",
				"영덕군",
				"영일군",
				"경주군",
				"영천군",
				"경산군",
				"청도군",
				"고령군",
				"성주군",
				"칠곡군",
				"금릉군",
				"선산군",
				"상주군",
				"문경군",
				"예천군",
				"영풍군",
				"봉화군",
				"울진군",
				"울릉군"
			};			
		} else if (lab.text == "경상남도") {

			Global.place_lists = new string[] { 
				"창원시",
				"의창구",
				"성산구",
				"마산합포구",
				"마산회원구",
				"진해구",
				"창원시",
				"울산시",
				"합포구",
				"회원구",
				"마산시",
				"진주시",
				"진해시",
				"충무시",
				"통영시",
				"삼천포시",
				"사천시",
				"김해시",
				"밀양시",
				"장승포시",
				"거제시",
				"양산시",
				"진양군",
				"의령군",
				"함안군",
				"창녕군",
				"밀양군",
				"양산군",
				"울산군",
				"김해군",
				"창원군",
				"통영군",
				"거제군",
				"고성군",
				"사천군",
				"남해군",
				"하동군",
				"산청군",
				"함양군",
				"거창군",
				"합천군"
			};			
		} else if (lab.text == "제주특별자치도") {

			Global.place_lists = new string[] {
				"제주시",
				"서귀포시",
				"북제주군",
				"남제주군"
			};			
		}
		scrollview.SetActive (false);
		label2.text = Global.place_lists [0];
		DeleteItems ();
	}

	void DeleteItems(){
		GameObject[] goDistItems = GameObject.FindGameObjectsWithTag ("Item1");
		for (int i = 0; i < goDistItems.Length; i++) {
			DestroyImmediate (goDistItems[i]);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
