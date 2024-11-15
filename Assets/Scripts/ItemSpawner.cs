using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour{
    // Lista de objetos que puedes definir en el Inspector
    public List<GameObject> objetosParaSpawn;  // Lista de GameObjects (por ejemplo, esfera, cubo, etc.)

    // Tiempo entre cada spawn
    public float spawnInterval = 2f;

    // Coordenadas donde se generarán los objetos
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    public float spawnHeight = 10f;

    // Altura a la que el objeto dejará de caer
    public float stopHeight = 1f;

    // Tiempo después del cual el objeto será destruido (despawn)
    public float despawnTime = 4f;

    void Start()
    {
        // Comenzamos a hacer spawn de los objetos
        StartSpawning();
    }

    // Método para iniciar el spawn continuo de objetos
    public void StartSpawning()
    {
        StartCoroutine(SpawnItemsContinuously());
    }

    // Corutina que maneja el spawn de los objetos
    private IEnumerator SpawnItemsContinuously()
    {
        while (true)
        {
            // Selecciona un objeto aleatorio de la lista de objetos
            GameObject selectedObject = objetosParaSpawn[Random.Range(0, objetosParaSpawn.Count)];

            // Calcula una posición aleatoria dentro de los límites establecidos
            Vector3 spawnPosition = new Vector3(
                Random.Range(minX, maxX),
                spawnHeight,
                Random.Range(minZ, maxZ)
            );

            // Crea el objeto en la escena
            SpawnItem(selectedObject, spawnPosition);

            // Espera el intervalo de spawn antes de crear el siguiente objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Método para instanciar el objeto y manejar su despawn
    public void SpawnItem(GameObject itemPrefab, Vector3 spawnPosition)
    {
        if (itemPrefab != null)
        {
            // Instancia el objeto en la escena
            GameObject spawnedObject = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

            // Obtener o agregar el Rigidbody para la caída
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = spawnedObject.AddComponent<Rigidbody>();
            }

            // Asegurarse de que la gravedad esté activada
            rb.useGravity = true;
            rb.isKinematic = false;

            // Iniciar la corutina para detener la caída una vez que el objeto llegue a la altura deseada
            StartCoroutine(StopFallingAtHeight(spawnedObject, stopHeight));

            // Iniciar la corutina para despawnear el objeto después del tiempo especificado
            StartCoroutine(DestroyItemAfterTime(spawnedObject, despawnTime));
        }
    }

    // Corutina para detener la caída del objeto cuando llegue a la altura deseada
    private IEnumerator StopFallingAtHeight(GameObject item, float stopHeight)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();

        // Esperar hasta que el objeto llegue a la altura deseada
        while (item.transform.position.y > stopHeight)
        {
            yield return null; // Esperar un frame y verificar nuevamente
        }

        // Detener la caída y desactivar la gravedad
        rb.useGravity = false; // Desactivar la gravedad
        rb.velocity = Vector3.zero; // Detener cualquier movimiento residual
    }

    // Corutina para destruir el objeto después de un tiempo determinado
    private IEnumerator DestroyItemAfterTime(GameObject item, float timeToWait)
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(timeToWait);

        // Destruye el objeto
        Destroy(item);
    }
}