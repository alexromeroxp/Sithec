# Sithec
Backend Sithec prueba
Corra la migracion para crear la base de datos y la tabla,
Para probar el get que hace las operaciones matematicas es necesario agregar en la CURL los atributos:  por ejemplo:
curl --location 'https://localhost:7213/api/Math' \
--header 'accept: text/plain' \
--header 'argument1: 20' \
--header 'argument2: 2' \
--header 'argument3: 2'
