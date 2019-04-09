using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Yeni versiyon unitler için oyunu tekrar yükleme kütüphanesi
using UnityEngine.UI; //Text ekleyebilmek için gerekli kütüphane.


public class karakter : MonoBehaviour
{

    // Use this for initialization
    public bool yerdemi; //Yerde olup olmadığını kontrol ettirmek için değişken oluşturduk.
    public float hiz; //Hiz değerini elle girmek için public bir değişken
    public float h; //H için public bir değişken
    public float ziplama_gucu; //ziplama gücü için public bir değişken
    Rigidbody2D fizik_karakter; //Karakter 2d olarak tanımlandı.
    Animator animasyon_oynatici; //Oluşturulan animasyon burada çağırıldı.
    public static int halka_sayisi; //Toplanan puanları değişkende tutuyoruz.
    public Text textimiz; //String ifade girebilmek için bir değişken oluşturduk.
    public int can_sayisi;//Dışarıdan elle değer girebilmek için public bir değişken oluşturduk.
    float time = 0f; //Kaktüse deydikten 3 sn kaçma şansı bırakmak için süre ekledik.
	void Start ()
    {
        can_sayisi = 3;
        fizik_karakter = GetComponent<Rigidbody2D>(); //Başlanıçda olarak karakter aktif edildi.
        animasyon_oynatici = GetComponent<Animator>();	//Başlangıçda animasyon aktif edildi.
        halka_sayisi = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        if (can_sayisi == 0) //Bütün canlarımız bittiği zaman oyunu baştan başlatıyoruz.
        {
            ol();
        }
        textimiz.text = halka_sayisi.ToString(); //Sol üstte bulunun toplam halka sayısını arttırır.
        if (Input.GetKeyDown(KeyCode.W) && yerdemi) //Zıplama olayı için W tuşu atandı.
        {
            fizik_karakter.velocity += new Vector2(0, ziplama_gucu);
            yerdemi = false;
        }

        if (transform.position.y < -7f) //Belirli bir yükseklik kontrol ettirme.
        {
            can_Azalma();//Ölündüğü zaman can azalmasını kontrol ettirmek için yaptım.
            ol();
        }

    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h*hiz*Time.deltaTime,0,0);
        animasyon_oynatici.SetFloat("hiz",Mathf.Abs(h));
        animasyon_oynatici.SetBool("yerde",yerdemi);
    }

    void ol() //Karakter öldüğü zaman oyunu başlangıç anından tekrar başlatır.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "kaktus")
        {
            if (time <= 0)
            { 
                can_Azalma();
                time = 3f; //Can azaldığı zaman 0 olan süreye 3 saniye ekliyoruz.
            }
        }
    }

    void OnTriggerStay2D(Collider2D coll) //Kaktüsün içinde 3 sn fazla kalındığında canın gitmesi için.
    {
        if (coll.gameObject.tag == "kaktus")
        {
            if (time <= 0)
            {
                can_Azalma();
                time = 3f; //Can azaldığı zaman 0 olan süreye 3 saniye ekliyoruz.
            }
        }
    }

    void can_Azalma() //Bu özellik şuanda aktif değil.Kontrol amaçlı yapıldı.
    {
        can_sayisi--;
        GameObject.Find("can" + can_sayisi.ToString()).active = false;
    }
}
