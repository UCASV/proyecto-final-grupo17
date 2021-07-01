# Documentacion oficial

## Aspectos tecnicos

### Software utilizado para el desarrollo del programa

- Visual Studio Community 2019
- SQL Server Developer 2019
- Windows 10

### Patrones de diseño implementados
- Patron de repositorio:
Fue utilizado este patron de diseño para separar las partes de la base de datos de la programacion en si, para esa forma reducir grandes cantidades de codigo evitando las 
grandes cargas de codigo para llamar a la conexion, pedir todo y guardar cambios, con 
este patron se agiliza todas las operaciones CRUD dentro de la BD, permitiendonos 
programar con un enfoque mas al software, agilizando las operaciones y mejorando la 
visibilidad del codigo, por ese motivo se escogio el patron de diseño de repositorio.

### Paquetes externos (Nuget) utilizados en el proyecto:
- CircularProgressBar version: 2.8.0
- FontAwesome.Sharp version: 5.15.3
- itext7 version: 7.1.15
- Microsoft.EntityFrameworkCore version: 5.0.7
- Microsoft.EntityFrameworkCore.Design version: 5.0.7
- Microsoft.EntityFrameworkCore.SqlServer version: 5.0.7
- WinFormAnimation version: 1.6.0.4

* * *

## Instalación del software

### Requisitos previos a la instalacion del software

- Instalar o tener instalado SqlServer Developer (de preferencia una version reciente).
- Utilizar sistema operativo Windows 10.
- La version del framework a utilizar es .NET Core 5.
- Es necesario utilizar el gestor de BD previamente dicho, para ejecutar un script que contiene la base de datos a utilizar.

### Pasos para realizar la instalacion del software

1. Nos vamos a la raiz de las carpetas o repositorio, donde tendremos las carpetas Programacion orientada a objetos y Bases de datos.

2. Como mencionamos previamente necesitamos tener instalado Sql Server developer y un SMSS para ejecutar el codigo de la BD.

3. Una vez nos cerciorarnos de tener el SMSS y SQL Server developer instalado y estando en la raiz del repositorio, navegaremos dentro de la carpeta **Bases de datos** y abriremos el archivo nombrado **Banco de datos.sql** : 
(Raiz de carpetas o repositorio) -> Bases de datos -> Banco de datos.sql

4. Abrimos el script o Banco de datos en Sql Server, y solamente ejecutamos el codigo, automaticamente el gestor creara la BD y poblara la base de datos.

5. Una vez ejecutado el script y teniendo la base de datos creada, volvemos a dirigirnos a la raiz de nuestro repositorio nuevamente y procedemos a ejecutar el instalador, nos dirigimos a la carpeta **Programacion orientada a objetos**, luego dentro de ella hay una carpeta nombrada **ProyectoFinalPOOBD** , abrimos la carpeta, y dentro de ella habra una carpeta llamada Instalador, abrimos la carpeta **Instalador** y dentro de esta carpeta habra una carpeta llamada **Debug**, abrimos esta carpeta donde se encuentra el instalador nombrado como **setup.exe** <br>
(Raiz del directorio o repo) -> Programacion orientada a objetos -> ProyectoFinalPOOBD -> Instalador -> Debug -> setup.exe

6. Luego ejecutamos el instalador (setup.exe), y le damos a todas las opciones en siguiente, luego esperamos a que cargue y por ultimo le damos en cerrar.

7. Una vez realizado todo esto se habra generado un acceso directo al software en nuestro Desktop con el nombre de POOBD y un icono de un virus color rosa, lo abrimos y ya podemos utilizar el sistema.

### Notas importantes al utilizar el sistema:

- Para inciar sesion dentro del sistema se nos pedira un usuario, contraseña y numero de cabina, para ello se puede utilizar el usuario ADMIN01, con su contraseña: ROOT01 y podemos utilizar cualquier numero de cabina entre el 1 y 5.

- En el momento que se instala por un error el programa de raiz se llama Instalador, pero podemos buscarlo en la barra de busqueda o en el escritorio por el nombre de POOBD.