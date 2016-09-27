# Proyecto en Unity3D

Unas simples guidelines para usar git y poder colaborar en un proyecto
de Unity3D.

## Configuracion

1. Asegurate que cuentas con la misma version de Unity que tu equipo (5.4.1)
2. Habilita los archivos .meta `` Edit -> Project Settings -> Editor -> Version Control -> Mode -> Visible Meta Files ``
3. Habilita la serializacion de Assets `` Edit -> Project Settings -> Editor -> Asset Serialization -> Mode -> Force Text ``
4. Instalar git-lfs (https://git-lfs.github.com)

## Haciendo commits

1. Antes de hacer un commit asegurate que guardes la escena y el proyecto.
2. Asegurate que guardes un .meta por cada asset.

## Haciendo pulls

1. Asegurate de cerrar Unity.
2. Haz pull.
3. Abre Unity.

## Scenes

Sincronizar escenas es lo mas complicado en usar Unity con sistemas de control
de versiones, la recomendacion principal es ** SOLAMENTE UNA PERSONA TRABAJA EN UNA ESCENA AL MISMO TIEMPO **
Ahora bien si quieres trabajar en una escena en la que alguien mas esta trabjando,
haz tus cambios y guardalos en un prefab. Despues regresa la escena a su estado original `` git reset HEAD nombreDeEscena.unity nombreDeEscena.unity.meta `` y haz tu commit.
