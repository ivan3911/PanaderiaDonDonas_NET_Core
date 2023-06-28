# PanaderiaDonDonas_NET_Core
El proposito del proyecto fue Generar APIs REST en NET Core simulando las ventas de donas en una panadería. se realizó el diseño, creación de la BD, y desarrollo de las APIS. La información se muestra a través de swagger, pero pueden ser consumidas desde cualquier aplicación de terceros (Postman, Insomnia, Hoppscotch, etc).

Dentro del proyecto se considera lo siguiente:

* La API debe tener endpoints para crear una venta de dona, obtener todas las ventas registradas y obtener una venta específica por medio de su identificador.

* Se Implementa un servicio de autenticación JWT (JSON Web Token) en .NET Core para 
proteger el endpoint que corresponde a la venta. los endpoints de las consultas pueden ser consumidas por usuarios autenticados y no autenticados


## Tecnologías utilizadas:
* .NET Core 6
* .ORM Entity Framework Core 6

## Tipos de proyectos generados:
* .ASP.NET Core Web API
* .Proyecto de BD SQL Server
---
Para el proyecto, se consideró el siguiente diagrama ER

   ![Diagrama ER](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/DiagramaER_DonDonas_NET_Core.png)

Listado de endpoints desarrollados:

   ![Endpoints](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/Endpoints.png)

Consulta de todas las ventas:

   ![VentasTotales](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/EndpointOrders.png)

Consulta de ventas por Id:

   ![VentasPorId](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/EndpointOrderById.png)

Operacion no permitida por no estar autenticado (Code 401):

   ![ErrorCode401](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/NotAutenticated.png)
   
Login:

   ![login](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/login.png)

Bearer + token:

   ![Auth](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/Auth.png)

Authorized:

   ![Auth2](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/Auth2.png)

Venta permitida ya que ha sido autenticado:

   ![Auth2](https://github.com/ivan3911/PanaderiaDonDonas_MVC/blob/main/assets/EndpointOrdersOK.png)