# Proyecto Web en .NET 8

## Descripción

Este proyecto es una aplicación web desarrollada en **.NET 8**. En este documento se detalla cómo configurar el entorno, ajustar la conexión a la base de datos y ejecutar la aplicación.

## Requisitos

Para poder ejecutar y trabajar con este proyecto, asegúrate de tener instalados los siguientes componentes:

### 1. **.NET SDK 8.0**
Descarga e instala el SDK desde el sitio oficial: [SDK .NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
Verifica que esté instalado correctamente ejecutando el siguiente comando en la terminal:
```
dotnet --version
```
Este comando debe devolver una versión igual o superior a `8.0.x`.

### 2. **Visual Studio 2022** (o superior)**
-   Descarga e instala Visual Studio 2022 desde [Visual Studio](https://visualstudio.microsoft.com/vs/)
-   Asegúrate de seleccionar las cargas de trabajo necesarias para **desarrollo en .NET** y **ASP.NET Core**.
-   Alternativamente, puedes usar **Visual Studio Code** junto con las extensiones necesarias para C# y .NET.

## Configuración de la Cadena de Conexión

Este proyecto utiliza **SQL Server** como base de datos. Antes de ejecutar la aplicación, debes asegurarte de configurar correctamente la cadena de conexión a la base de datos.
-   **Ubicación de la cadena de conexión**: La cadena de conexión se encuentra en el archivo `appsettings.json` en la raíz del proyecto.
    
-   **Ejemplo de cadena de conexión**:
```
"ConnectionStrings": { 
"DefaultConnection": Server=.;Database=NombreBaseDeDatos;Trusted_Connection=True;" 
}
```

## Cómo ejecutar la aplicación

### Opción 1: Usando Visual Studio 2022

1.  Abre el proyecto en **Visual Studio**.
    -   Navega a `Archivo` -> `Abrir` -> `Proyecto o Solución`, y selecciona el archivo `.csproj` o `.sln` del proyecto.
2.  Configura el **proyecto de inicio** (si es necesario) en el Explorador de Soluciones, haciendo clic derecho sobre el proyecto y seleccionando `Establecer como proyecto de inicio`.
3.  **Compila** y **ejecuta** la aplicación presionando `F5` o seleccionando el botón **Iniciar depuración** en la barra de herramientas.
4.  La aplicación se abrirá en el navegador predeterminado, y el servidor se iniciará automáticamente.

### Opción 2: Usando comandos de .NET CLI

Si prefieres usar la línea de comandos (ideal si estás usando **Visual Studio Code** o cualquier otro editor):

1.  **Abre una terminal** y navega a la carpeta raíz del proyecto donde está el archivo `WebApp.csproj`.
2.  **Restaurar paquetes NuGet**:
``dotnet restore``
3.  **Compilar la aplicación**
``dotnet build``
4.  **Ejecutar la aplicación**:
``dotnet run``