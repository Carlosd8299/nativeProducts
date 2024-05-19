# Api de productos

[La documentacion (Swagger) ](https://apicarlosdlc.azurewebsites.net/swagger/index.html)

[La documentacion (Postman)](https://interstellar-star-64158.postman.co/workspace/Team-Workspace~17e6eaa8-5f6f-4287-8521-56d99656ba09/collection/7792095-fef6e6b7-e1cd-41f7-b450-72ee4944530a?action=share&creator=7792095)

## Pasos a seguir

- 1. Debes registrar un rol con el endpoint /api/Users/CreateRol
- 2. Debes registrar un usuario con el endpoint /api/Users/Register
- 3. Debes hacer login con el un usuario haciendo uso del el endpoint /api/Users/Login
- 4. Para las rutas protegidas como: Crear, Actualizar, Eliminar producto, debe aportar el token recibido en el /Register o /Login coo Bearer token en los headers de la peticion