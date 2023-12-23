using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetObject;
    public GameObject counterObject;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform counter;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    //private float speed;
    private float contactDistance;
    private float distanceWithTarget;
    private float distanceWithCounter;
    private float randomMoveParam;
    private bool isEnemyExists;
    public Vector2 moveSpot;
    private bool isDestroyed;
    private float current_time;
    private float max_time;

    public static float currentSpeed;

    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        max_time = Random.Range(2f, 5f);
        current_time = 0f;
        randomMoveParam = 0f;
        distanceWithTarget = 2f;
        distanceWithCounter = 1f;
        target = null;
        counter = null;
        isDestroyed = false;
        moveSpot = new Vector2(Random.Range(minX, maxX + 1), Random.Range(minY, maxY + 1));

        StartCoroutine(foundCounter());
        StartCoroutine(moveCoroutine());
    }


    IEnumerator foundCounter(){
        while(true){
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, distanceWithCounter);
            counter = null;
            if(cols.Length > 0){
                for(int i = 0; i < cols.Length; i++){
                    if(cols[i].CompareTag(counterObject.tag)){
                        counter = cols[i].gameObject.transform;
                    }
                }
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    IEnumerator moveCoroutine()
    {
        while(true){
            if(counter != null) 
            {
                animator.SetBool("IsMoving", true);
                runAwayFromCounter();
                current_time = 0;
                max_time = Random.Range(2f, 5f);
            }
            else if(target == null || !target.gameObject.activeSelf)
            {
                target = foundTarget();
                if(randomMoveParam < 5f)
                {
                    animator.SetBool("IsMoving", true);
                    moveRandom();
                }
                else{
                    animator.SetBool("IsMoving", false);
                    idle();
                }
            }
            else{
                if(foundTarget() == null){
                    target = null;
                    continue;
                }
                animator.SetBool("IsMoving", true);
                followTarget();
                current_time = 0;
                max_time = Random.Range(2f, 5f);
            }
            //yield return null;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private Transform foundTarget(){
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, distanceWithTarget);

        if(cols.Length > 0){
            for(int i = 0; i < cols.Length; i++){
                if(cols[i].CompareTag(targetObject.tag)){
                    Transform obj = cols[i].gameObject.transform;
                    return obj;
                }
            }
        }
        return null;
    }

    private void followTarget(){
        flipObject(target.position.x - transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, target.position, PlayerPrefs.GetFloat("Speed") * Time.deltaTime);
    }

    private void runAwayFromCounter(){
        Vector2 dir = transform.position - counter.position;
        dir.Normalize();
        flipObject(dir.x);
        transform.Translate(dir * PlayerPrefs.GetFloat("Speed") * Time.deltaTime);
    }

    private void moveRandom(){
        current_time += Time.deltaTime;
        flipObject(moveSpot.x - transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, PlayerPrefs.GetFloat("Speed") * Time.deltaTime);

        /*
        if(Vector2.Distance(transform.position, moveSpot) < 0.5 || current_time >= max_time)
        {
            current_time = 0;
            max_time = Random.Range(3f, 8f);
        }
        */
        if(current_time >= max_time)
        {
            current_time = 0;
            moveSpot = new Vector2(Random.Range(minX, maxX + 1), Random.Range(minY, maxY + 1));
            max_time = Random.Range(2f, 5f);
            randomMoveParam = Random.Range(0f, 10f);
        }
    }

    private void idle(){
        current_time += Time.deltaTime;
        
        if(current_time >= max_time)
        {
            current_time = 0;
            max_time = Random.Range(2f, 5f);
            randomMoveParam = Random.Range(0f, 10f);
        }
    }

    private void flipObject(float x){
        //float x = direction.x;
        if(x > 0f){
            spriteRenderer.flipX = false;
        }
        else if(x < 0){
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag(counterObject.tag) && !isDestroyed){
            SoundManager.instance.PlaySFXSound("EatSound");
            isDestroyed = true;
            GameManager.instance.pool.ReturnQ(gameObject);
            GameObject obj = GameManager.instance.pool.Get(counterObject);
            obj.transform.position = transform.position;
            gameObject.SetActive(false);
            //Instantiate(counterObject, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
    }
}
