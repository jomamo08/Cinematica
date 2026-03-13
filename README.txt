Sistema de Partículas con Tiro Parabólico

## Descripción

He creado un sistema de partículas en Unity en donde cada partícula se mueve usando un tiro parabolico.

Cuando se pulsa el espacio, se crean varias partículas.
Estas partículas salen disparadas, se mueven con gravedad y desaparecen cuando termina su tiempo de vida.


## Estructura del proyecto

El proyecto tiene dos scripts:

1. Particle.cs

Este script guarda la información de cada partícula.

Cada partícula tiene:

* Velocidad inicial
* Ángulo inicial
* Tiempo de vida máximo
* Tiempo activo
* Gravedad


2. ParticlesController.cs

Este script controla todo el sistema de partículas.

Estos valores están en publico, asi que se pueden cambiar en el inspector:

* Número de partículas
* Velocidad inicial
* Ángulo inicial
* Tiempo de vida
* Gravedad

También tiene:

* Un prefab de partícula
* Una lista donde se guardan todas las partículas creadas


## Funcionamiento

Crear partículas

Cuando se pulsa el espacio se llama al método:

CreateParticleExplosion()

Este método:

1. Crea el número de partículas indicado.
2. Cada partícula se crea desde el prefab.
3. Algunas variables se generan con valores aleatorios:

   * Velocidad inicial
   * Tiempo de vida

4. Todas las partículas usan la misma gravedad.

Esto hace que las partículas no se muevan exactamente igual.


Actualizar partículas

Cada frame se actualiza la posición de cada partícula con el método:

UpdateParticlePosition()

Este método:

1. Aumenta el tiempo activo de la partícula.
2. Calcula su nueva posición usando las fórmulas del tiro parabólico.
3. Si el tiempo activo es mayor que el tiempo de vida, la partícula se elimina.


## Fórmulas usadas

Para mover las partículas  las fórmulas del tiro parabólico:

Posición en X:

x = velocidad * cos(ángulo) * tiempo

Posición en Y:

y = velocidad * sin(ángulo) * tiempo - (1/2 * gravedad * tiempo²)




## Controles

Al pulsar el espacio crea una explosión de partículas.

