# 🚍 Sistema de Reserva y Seguimiento de Transportes  
Examen Unidad 4 y 5 — Patrones de Diseño  
**Autor:** Jonathan García Santos  
**Número de Control:** 22210307  
**Proyecto:** Simular un sistema real de transporte donde los vehículos

**Materia:** Patrones de Diseño

Este sistema administra una flota de vehículos aplicando varios patrones de diseño y una arquitectura en capas.  
Los vehículos pueden estar **disponibles**, **en uso** o en **mantenimiento**.

---

# Objetivo del Proyecto

Simular un sistema real de transporte donde los vehículos:

- Se asignan por placa  
- Se liberan cuando ya no están en uso  
- Entran automáticamente en mantenimiento
- Regresan a estado disponible sin intervención del usuario  
- Comparten una ruta global mediante Singleton  

El sistema se maneja por consola y demuestra el uso conjunto de varios patrones de diseño.

---

# Patrones Implementados (Explicación Breve)

---

## 1️⃣ Singleton — **AdministradorRutas**

El patrón Singleton garantiza que exista **una sola instancia global** de la ruta principal del sistema.

### Justificación
Toda la aplicación debe trabajar con **la misma ruta**, evitando duplicaciones o inconsistencias.  
El Singleton asegura que solo se cree una instancia en todo el programa.

### Cómo se aplica

```csharp
AdministradorRutas.ObtenerInstancia();
```

La cual siempre devuelve **la misma instancia**, cumpliendo el patrón.

---

## 2️⃣ Object Pool — **VehiculoPool**

Este patrón administra **vehículos reutilizables**, moviéndolos entre:

- Disponibles  
- En uso  
- Mantenimiento  

### Justificación
Un sistema real de transporte no “crea” un vehículo cada vez que se usa.  
El Object Pool permite administrar recursos reutilizables y controlar su disponibilidad.

### Cómo se aplica

Las listas internas:

- vehiculosDisponibles  
- vehiculosEnUso  

Y los métodos:

```csharp
AsignarVehiculo()
LiberarVehiculo()
```

El Pool decide dónde debe estar cada vehículo y evita que un vehículo sea asignado dos veces usando `lock`.

---

## 3️⃣ State — **Estados del Vehículo**

Cada vehículo puede estar en tres estados:

- **EstadoDisponible**  
- **EstadoEnUso**  
- **EstadoMantenimiento**  

### Justificación
Evita el uso de estructuras condicionales grandes.  
Cada estado tiene su propia clase y comportamiento, lo que hace el sistema más ordenado y escalable.

### Cómo se aplica

```csharp
vehiculo.CambiarEstado(new EstadoMantenimiento());
```

Después de 1 minuto, el sistema actualiza automáticamente el estado a **Disponible**.

---

## 4️⃣ Facade — **FachadaTransporte**

Simplifica el uso del sistema proporcionando una **interfaz única** con la que Program.cs interactúa.

### Justificación
Sin la fachada, el archivo principal tendría que llamar directamente al Pool, al Singleton y a los estados.  
La fachada oculta la complejidad interna y simplifica el código.

### Cómo se aplica

```csharp
sistema.AsignarVehiculo(placa);
sistema.LiberarVehiculo(placa);
sistema.MostrarEstado();
```

Program.cs no necesita conocer detalles internos del sistema.

---

## 5️⃣ Arquitectura en Capas — **From Mud to Structure → Layers**

Este patrón organiza el código en capas lógicas separadas.

### Capas implementadas

| Capa | Función |
|------|---------|
| **Presentación (UI)** | Program.cs — Manejo del menú y entrada del usuario |
| **Aplicación** | FachadaTransporte — Coordina la lógica del sistema |
| **Dominio** | Vehículos, Estados, AdministradorRutas — Reglas del negocio |
| **Infraestructura** | VehiculoPool — Maneja recursos reutilizables |

### Justificación
No añade funciones nuevas, pero **organiza** el sistema de forma profesional, clara y fácil de mantener.

---
# ▶️ Cómo ejecutar el programa en Visual Studio Code (C# + .NET SDK)

## 1️⃣ Instalar el SDK de .NET (obligatorio)

Descargar desde el sitio oficial:

https://dotnet.microsoft.com/en-us/download

Instalar la versión **.NET SDK 6 o superior**.

---

## 2️⃣ Verificar que el SDK está instalado

Abrir una terminal y escribir:

```
dotnet --version
```

Si aparece algo como:

```
7.0.401
```

Entonces el SDK está correctamente instalado.

---

## 3️⃣ Abrir el proyecto en Visual Studio Code

1. Abrir **VS Code**  
2. Ir a **File → Open Folder**  
3. Seleccionar la carpeta del proyecto  

VS Code detectará automáticamente el proyecto C#.

---

## 4️⃣ Instalar la extensión de C#

Si VS Code muestra un aviso para instalar **"C# Dev Kit"**, seleccionar:

✔ Install

---

## 5️⃣ Ejecutar el programa desde la terminal integrada

En la terminal de VS Code, escribir:

```
dotnet run
```

Esto compilará y ejecutará el sistema, tambien entrar a la carpeta con cd (Nombre de la carpeta)

---




# Resumen Final de Patrones

- **Singleton:** Mantiene una ruta global única.  
- **Object Pool:** Maneja y reutiliza vehículos eficientemente.  
- **State:** Define comportamiento según el estado del vehículo.  
- **Facade:** Simplifica el uso del sistema.  
- **Capas:** Organización profesional del proyecto.

---

# Conclusión

Este proyecto me permitió entender mejor cómo los patrones de diseño pueden resolver problemas reales dentro de un sistema. Antes los veía como conceptos teóricos, pero al aplicarlos juntos en una sola 
aplicación pude ver cómo realmente hacen que el código sea más organizado, más claro y más fácil de mantener.
