using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private float swordAttackCD = .4f;
    [SerializeField] private WeaponInfo weaponInfo;
    
    private Transform weaponCollider;
    private Animator myAnimator;
    private GameObject slashAnim;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (PlayerController.Instance != null)
        {
            weaponCollider = PlayerController.Instance.GetWeaponCollider();
        }
        else
        {
            Debug.LogError("PlayerController.Instance is null!");
        }

        GameObject slashAnimSpawnPointObject = GameObject.Find("SlashAnimSpawnPoint");
        if (slashAnimSpawnPointObject != null)
        {
            slashAnimSpawnPoint = slashAnimSpawnPointObject.transform;
        }
        else
        {
            Debug.LogError("SlashAnimSpawnPoint not found!");
        }
    }



    private void Update()
    {
        MouseFollowWithOffSet();
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    
    public void Attack()
    {
            myAnimator.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
            // co routine silmemizin sebebi bizim bir atak yaptiktan sonra atagin buga girmesine sebep oluyordu.
    }
    
    //burada ki IEnumarator AttackCDRoutine sildik cunku biz bunu activeweapon class icerisine atiyoruz.


    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);
        if (PlayerController.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (PlayerController.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MouseFollowWithOffSet()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
