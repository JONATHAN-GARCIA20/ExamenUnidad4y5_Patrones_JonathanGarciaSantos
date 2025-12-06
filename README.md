# ExamenUnidad4y5_Patrones_JonathanGarciaSantos
Examen de la unidad 4 y 5 Patrones de diseño.
# 🚍 Sistema de Reserva y Seguimiento de Transportes  
Proyecto final de patrones — C#

Este sistema administra una flota de vehículos utilizando múltiples patrones de diseño:  
- **Singleton**  
- **Object Pool**  
- **State**  
- **Facade**  
- **Arquitectura en Capas (From Mud to Structure → Layers)**  

---

## 📌 Objetivo del Proyecto
Simular un sistema real de gestión de transporte donde los vehículos pueden:

- Ser asignados  
- Ser liberados  
- Entrar en mantenimiento automáticamente  
- Volver a estar disponibles  
- Mantener una ruta global compartida  

El sistema es totalmente interactivo y se maneja por consola.

---

# 🧩 Patrones Implementados

## 1️⃣ **Singleton — AdministradorRutas**
Este patrón garantiza que exista **una sola instancia global** de la ruta principal del sistema.

### 🧠 Justificación
La aplicación necesita **una sola ruta** que todos los módulos consulten.  
Esto evita inconsistencias o duplicaciones.

### 🏗 Cómo se aplica
```csharp
AdministradorRutas.ObtenerInstancia();
