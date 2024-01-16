# UsersAPI

Está é uma API para gerenciamento de usuários, com endpoints para autenticação , recuperação de senha e manipulação de contas de usuário.

## Endpoints

### Autenticação

**POST /api/auth/login**

Endpoint para autenticar o usuário.

**POST /api/auth/forgot-password**

Endpoint para recuper a senha de acesso do usuário.

**POST /api/auth/reset-password**

Endpoint para reiniciar a senha de acesso do usuário.

### Usuários

**POST /api/users**

Endpoint para criar uma nova conta de usuário

**PUT /api/users**

Endpoint para alterar dados do usuário

**DELETE /api/users** 

Endpoint para excluir conta de usuário

**GET /api/users**

Endpoint para consultar dados do usuário.