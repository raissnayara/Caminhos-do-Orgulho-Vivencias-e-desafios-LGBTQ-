using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    public float smooth = 0.125f;  // Ajuste a suavização (quanto maior o valor, mais rápido a câmera segue)
    public Vector3 offset;  // O deslocamento da câmera em relação ao jogador (ajustável no Inspector)

    // Start is called before the first frame update
    void Start()
    {
        // Encontra o objeto do jogador pela tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Se não tiver o deslocamento definido, a câmera ficará na mesma altura que o jogador, mas com um deslocamento em X e Z
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 5, -10);  // Valor padrão
        }
    }

    // LateUpdate é chamado depois do Update e é ideal para manipulação de câmeras, pois garante que o movimento do jogador já foi processado
    void LateUpdate()
    {
        // Calcula a posição desejada com base na posição do jogador e no deslocamento
        Vector3 desiredPosition = player.position + offset;

        // Move a câmera suavemente em direção à posição desejada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smooth * Time.deltaTime);
    }
}