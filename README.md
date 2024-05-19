# Api de productos

[OpenAPI (Swagger) ](https://apicarlosdlc.azurewebsites.net/swagger/index.html)

[Documentacion (Postman)](https://interstellar-star-64158.postman.co/workspace/Team-Workspace~17e6eaa8-5f6f-4287-8521-56d99656ba09/collection/7792095-fef6e6b7-e1cd-41f7-b450-72ee4944530a?action=share&creator=7792095)

[Diseño de arquitectura (Diagram.io)](https://drive.google.com/file/d/1xlbOXXR-g36iNowd-B54ItxmntqYWShR/view?usp=sharing)

## Pasos a seguir

1. Debes registrar un rol con el endpoint /api/Users/CreateRol
2. Debes registrar un usuario con el endpoint /api/Users/Register
3. Debes hacer login con el un usuario haciendo uso del el endpoint /api/Users/Login
4. Para las rutas protegidas como: Crear, Actualizar, Eliminar producto, debe aportar el token recibido en el /Register o /Login coo Bearer token en los headers de la peticion

## Design Patters implementados
Se realize implementaciones sobre los siguientes patrones de diseño.
- CQRS: Separacion de responsabilidades basado en las acciones que se le expone a los consumidores, tal que las consultas sean organizadas como Queries y las acciones de escritura sean Commands. 
- DI - Inyeccion de dependencias: Se inyectan los recursos transversales de la aplicacion por medio de la clase contenedora en orden de recuperar las dependencias abstractas en las clases implementadoras. 
- Mediatr: Patron para delegar las responsabilidades a las clases que si tienen la informacion necesaria para llevar a cabo una accion especifica. 

## Architecture
- Onion and Clean Architecture: Se separa el proyecto en tres capas: Aplicacion, Infraestructura y Dominio. Ademas la separacion de carpetas respeta lo solicitado en el ejercicio
