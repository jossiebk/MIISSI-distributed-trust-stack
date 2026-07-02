# MIISSI - Entorno Experimental Cloud Native

## Descripción

Este repositorio contiene la implementación del entorno experimental utilizado para la evaluación de un modelo de seguridad, auditoría y observabilidad sobre una arquitectura basada en microservicios desplegada en Kubernetes.

La solución está desarrollada usando .NET 8 y se esta organizada para permitir su ejecución local, contenerización mediante Docker y despliegue sobre Kubernetes. Asimismo, el repositorio documenta paso a paso el proceso de construcción, configuración, ejecución y validación de cada uno de los componentes que conforman el entorno experimental.

---

## Microservicios

La solución está compuesta por los siguientes microservicios:

- **ServicioUsuarios**
  - Responsable de la gestión de estudiantes.
  - Documentación:
    - [ServicioUsuarios/README.md](./ServicioUsuarios/README.md)

- **ServicioDocumentos**
  - Responsable de la gestión de documentos académicos.
  - Documentación:
    - [ServicioDocumentos/README.md](./ServicioDocumentos/README.md)

Cada uno de los proyectos cuenta con su propia documentación, donde se describe su instalación, ejecución local, endpoints disponibles y ejemplos de uso.

---

## Contenerización

Los microservicios pueden ser contenerizados individualmente utilizando los Dockerfile incluidos en cada proyecto.

### ServicioUsuarios

Ingresar al directorio del proyecto.

```bash
cd ServicioUsuarios
```

Construir la imagen Docker.

```bash
docker build -t nombre-imagen-usuarios:1.0 .
```

---

### ServicioDocumentos

Ingresar al directorio del proyecto.

```bash
cd ServicioDocumentos
```

Construir la imagen Docker.

```bash
docker build -t nombre-imagen-documentos:1.0 .
```

Al finalizar este proceso estarán disponibles ambas imágenes para su ejecución local o posterior publicación en algún registry.

---

## Validación mediante Docker

Una vez construidas las imágenes, es posible validar el funcionamiento de ambos microservicios ejecutándolos mediante contenedores Docker antes de proceder con su despliegue sobre Kubernetes.

### Crear la red Docker

```bash
docker network create miissi-network
```

### Ejecutar ServicioUsuarios

```bash
docker run -d --name servicio-usuarios --network miissi-network -p 6001:80 -e ASPNETCORE_ENVIRONMENT=Development nombre-imagen-usuarios:1.0
```

### Ejecutar ServicioDocumentos

```bash
docker run -d --name servicio-documentos --network miissi-network -p 6002:80 -e ASPNETCORE_ENVIRONMENT=Development -e Servicios__ServicioUsuarios=http://servicio-usuarios nombre-imagen-documentos:1.0
```

Una vez iniciados ambos contenedores, se recomienda validar el correcto funcionamiento utilizando los ejemplos descritos en la documentación de cada microservicio.

- [ServicioUsuarios/README.md](./ServicioUsuarios/README.md)
- [ServicioDocumentos/README.md](./ServicioDocumentos/README.md)

## Despliegue del entorno en Kubernetes

Las pruebas del entorno experimental fueron realizadas sobre un clúster local de Kubernetes utilizando Minikube como plataforma de ejecución. Una vez construidas y publicadas las imágenes Docker, el despliegue se realiza utilizando los manifiestos YAML ubicados en la carpeta `Kubernetes/01-Deployment`, aplicándolos en el orden indicado a continuación.

### Acceder al directorio de despliegue

```bash
cd kubernetes/01-Deployment
```

### 1. Crear el Namespace

```bash
kubectl apply -f 01-namespace.yaml
```

### 2. Crear el ConfigMap

```bash
kubectl apply -f 02-servicio-documentos-config.yaml
```

### 3. Desplegar el microservicio ServicioUsuarios

```bash
kubectl apply -f 03-servicio-usuarios-deployment.yaml
```

### 4. Desplegar el microservicio ServicioDocumentos

```bash
kubectl apply -f 04-servicio-documentos-deployment.yaml
```

### 5. Verificar que ambos Deployments estén disponibles

```bash
kubectl rollout status deployment/servicio-usuarios -n miissi
```

```bash
kubectl rollout status deployment/servicio-documentos -n miissi
```

### 6. Crear los Services

```bash
kubectl apply -f 05-servicio-usuarios-service.yaml
```

```bash
kubectl apply -f 06-servicio-documentos-service.yaml
```

### 7. Crear el Ingress

```bash
kubectl apply -f 07-ingress.yaml
```

### 8. Verificar los recursos desplegados

```bash
kubectl get all -n miissi
```

### 9. Verificar el Ingress

```bash
kubectl get ingress -n miissi
```

### Validación del entorno desplegado

Una vez realizado el despliegue de todos los recursos, es necesario exponer el controlador Ingress para permitir el acceso a los microservicios desde el equipo local.

```bash
kubectl port-forward -n ingress-nginx service/ingress-nginx-controller 8080:80
```

A partir de este momento, todos los endpoints documentados en los README de ServicioUsuarios y ServicioDocumentos podrán consumirse utilizando el puerto 8080, manteniendo la misma estructura de rutas definida para cada microservicio. Si las operaciones CRUD, los health checks y la comunicación entre ambos servicios responden correctamente, se considera que el entorno fue desplegado satisfactoriamente sobre Kubernetes.

## Implementación del modelo de seguridad

## Implementación de auditoría y observabilidad

## Ejecución de experimentos
