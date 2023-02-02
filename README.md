Este es el primer commit que realizo a el proyecto de Interfaces.
En este primer posteo, subo lo que sería la interfaz de mi aplicación WORDLE.
Obviamente faltan muchos retoques como cambiar las X por campos vacíos...

Para ver mi página web actual es: https://yuss1.odoo.com/@/

#Profe:
Un pequeño detalle, aquí debes describir el proyecto, las tecnonogías que usarás el objetivo.
En este proyecto utilizo WPF para la interfaz y la clase en la que realizo la lógica del programa
En esta sesión he cambiado visualmente los elementos de la interfaz (redondeandolos y cambiando de label a TextBox) y dándoles color.
También he realizado la lógica de busqueda de las letras de las palabras y el cambio de color según se encuentran. 
>>>VERDE letra correcta posicion correcta
>>>Amarillo la letra se encuentra en la palabra pero no en la posicion introducida
>>>Gris La letra no se encuentra en la palabra secreta.

También he incluido en el proyecto una carpeta nueva en la que se encuentra el fichero desde el cual se cogen las palabras secretas (Con un SteamReader) para el juego 
cargandose en un arrayList y seleccionandose de forma aleatoria con la clase Random.

Faltaría sacar un dialogo en caso de Win or Loose y pulir un par de cositas.

He creado una ventana que se muestra al acertar la palabra. Falta ponerlo en todos los metodos y pulirlo.
