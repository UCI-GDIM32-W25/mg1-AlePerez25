using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {        
        //en esta area empeazamo a contar las plantas

        //se asigna valores par aempezar a realizar las operaciones y que el juego solo ponga
        //5 plantas en total.
        _numSeedsLeft = _numSeeds;

        //a este se le asigna cero pero se acctualizara sumando 1 cada ves que se le reste
        //a plantleft 1
        _numSeedsPlanted = 0;

        //etso le indica al plrograma si la variable _plantCountUI es no nula entonces actualiza 
        // los valores de seed lefts y seed planted.
        if (_plantCountUI != null)
        {
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }

    }

    private void Update()
    {
        //Apesar de que e sun juego 2d no significa que tengamos que usar vector2 
        //se puede usar vector3
        Vector3 movement = Vector3.zero;

        //Procedemos a escribir if staments para recinbir inputs y 
        // que el juego resccione a este input

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }

        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }

        //Este es el indicador de como que el juego reaccione y muestre la planta 
        //es importante usar GetKey Down en ves de GetKey ya que si no estas no se pondran una 
        //una por una. Tambien recuerda que solo el jugadro ncesita tener este scrip
        //el prefab no o necesita porque si no comensara a seguir al jugador.

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
        //esto se usa para que las indicaciones de arriva se puedan
        //llevar a cabo

        transform.Translate(movement * _speed * Time.deltaTime);
    }

    public void PlantSeed ()
    {

        //primero pondremos esto para aseguranos de que no existan 0 
        //si ese es el caso simplemente no se mostrara nada gracias a "return"(como python)
        if (_numSeedsLeft <= 0) 
            return;
        
        //instantiate se nos enseno en semana 1 pre-lerning week 2
        // este es para hacer copias de un on=bjeto contantemente cuando se le indique
        // se usa la variable de prefab y transformacion de pocision y rotacion 

        Instantiate(_plantPrefab, transform.position, transform.rotation);

        //Esto indica que se cada ves que se precione space las cantidades se actualizen 
        _numSeedsLeft--;
        _numSeedsPlanted++;

        if (_plantCountUI != null)
        {
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
        
    }
}
