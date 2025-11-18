# 📄 README.md — Proyecto Cliente/Servidor (C# .NET 8.0)
# **ServidorTCP-ProgramacionAvanzada**
Sistema Cliente/Servidor desarrollado en **C# .NET 8.0 con Windows Forms**, como parte del **Proyecto 2** del curso **00830 – Programación Avanzada**, II Cuatrimestre 2025, UNED.
El proyecto consiste en una solución **cliente/servidor** que permite a usuarios conectarse al servidor, validar su identificación, consultar artículos, registrar pedidos y consultar pedidos realizados. El servidor administra conexiones TCP, almacena datos en SQL Server y gestiona el inventario de artículos.

Tecnologías utilizadas
**Servidor**
* C# .NET 8.0
* Windows Forms
* TCP Sockets
* SQL Server
* Subprocesamiento múltiple (multithreading)
* ADO.NET
* POO con capas (Entidad, Acceso a Datos, Lógica, Presentación)

**Cliente**
* C# .NET 8.0
* Windows Forms
* TCP Sockets
* POO
* Manejo de excepciones
* Validaciones GUI

**Estructura del repositorio**
```
ServidorTCP-ProgramacionAvanzada/
│
├── ProyectoServidor/        # Aplicación Servidor TCP (Administrador)
│   ├── Proyecto/            # Entidades (POO)
│   ├── AccesoDatos/         # Comunicación con SQL Server (ADO.NET)
│   ├── LogicaNegocio/       # Reglas de negocio
│   ├── CapaDePresentacion/  # Interfaz Windows Forms (bitácora y menús)
│
├── ProyectoCliente/         # Aplicación Cliente TCP
│   ├── Proyecto/            # Entidades compartidas
│   ├── AccesoDatos/         # Llamadas según protocolo definido
│   ├── LogicaNegocio/       # Procesamiento y validaciones
│   ├── Interfaz.Cliente/    # Formularios del cliente
│
└── .gitignore               # Ignora archivos de compilación y configuraciones
└── README.md                # Información del proyecto
```
Requisitos para ejecutar

Base de Datos
* SQL Server instalado localmente
* Script de base de datos proporcionado por la UNED
* Conexión usando seguridad integrada

Servidor
* Debe ejecutarse **primero**
* Escucha conexiones en:
  ```
  Host: 127.0.0.1
  Puerto: 14100
  ```
* Permite varias conexiones simultaneas

Cliente
* Se ejecuta después del servidor
* Solicita número de identificación del cliente
* Solo permite operar si el servidor valida la identidad

Flujo general del sistema

1. Conexión del cliente
El cliente:
* Ingresa identificación
* Envía solicitud al servidor
  El servidor:
* Verifica en SQL Server
* Responde “Aceptado” o “Denegado”
  De ser válido:
* Se desbloquean los menús del cliente

2. Funcionalidades del Cliente
✔ Registrar Pedido de Artículos
✔ Consultar Lista de Artículos Activos
✔ Consultar Detalles de Artículos
✔ Ver mis Pedidos (todos o por ID)
✔ Validaciones completas
✔ Comunicación 100% vía TCP

3. Funcionalidades del Servidor
✔ Escuchar múltiples clientes simultáneos
✔ Registrar Tipos de Artículos
✔ Registrar Artículos
✔ Registrar Clientes
✔ Registrar Repartidores
✔ Registrar Pedidos (incluye detalle)
✔ Consultar todas las entidades
✔ Actualizar inventario según pedidos
✔ Mostrar en bitácora:
* Conexiones
* Desconexiones
* Pedidos
* Consultas

Cómo ejecutar el proyecto

Paso 1: Configurar la base de datos
1. Abrir SQL Server Management Studio
2. Ejecutar el script oficial de la cátedra
3. Verificar tablas: Cliente, Articulo, Pedido, Repartidor, etc.
4. Confirmar que la cadena de conexión en `App.config` esté correcta

   ```
   Data Source=.\local; Initial Catalog=GAMES4U2; Integrated Security=True;

   ```
Paso 2: Ejecutar el Servidor
1. Abrir `ProyectoServidor` en Visual Studio
2. Compilar
3. Ejecutar
4. Dejar que empiece a escuchar el Puerto **14100**

Paso 3: Ejecutar el Cliente
1. Abrir `ProyectoCliente`
2. Ejecutar
3. Ingresar identificación válida
4. Probar las funcionalidades

Entrega del Proyecto
Incluye:

* Todo el directorio del repositorio
* Código fuente completo
* Manual de uso
* Comentarios en cada clase según formato de la UNED
* Sin carpetas `bin`, `obj`, `.vs` (ya manejado con `.gitignore`)

Autor
Johel Smaiker Granados Elizondo
Estudiante — UNED
Código del Curso: 00830
II Cuatrimestre 2025
