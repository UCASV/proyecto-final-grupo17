# Documentacion oficial

## Aspectos tecnicos

### Software utilizado para el desarrollo del programa:

- Visual Studio Community 2019
- SQL Server Developer 2019
- Windows 10

### Patrones de diseño implementados:
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