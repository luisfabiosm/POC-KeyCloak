# POC-KeyCloak
Testes simples com KeyCloak

O exemplo consiste em 2 Apis que tem seu acesso controlado pela autenticação do Keycloak, portanto as mesmas exigem um Bearer Token valido, gerado pelo Keycloak com as credencias adequadas.

Primeira etapa: Instalar o Keycloak

Rodar o comando Docker para criação do container.

docker run -p 8089:8080 --name keycloak-server -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:21.0.0 start-dev

Usei a porta 8089 pois já estava ocupada a 8080.


Segunda  etapa: Configurar o Keycloak

1 - Ao logar no Keycloack, você precisará criar um Realm, no botão Create Realm.

2 - No Realm criado você criará três clientes:

No exemplo: SistemaA, SistemaB e SistemaAdmin. Ao criar o cliente você deve definir:

Client Type: OpenID Connect

Client ID: [criar seu Id] SistemaA por exemplo

Habilitar: Client authentication   e  manter o restante como padrão.

3 - Apos a criação dos clientes, criar os Client scopes:

Name: [criar um nome], no exemplo SistemaA-scope, pr exemplo.

Type: Default
Protocol: OpenID Connect

Após Salvar, vá em Mappers e configure new mapper, selecionando o tipo Audience.

Em seguida defina um Name a sua escolha e em Included Client Audience, selecione o nome do cliente para o qual esta sendo criado o scope.






