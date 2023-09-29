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

Habilitar o 'Add to access token' no momento de configuração do Mapper.

Repetir este passo para a criação de Client scopes de todos os 3 Clients inicialmente citados.

Criar um admin scope que não tera mapeamentos porem no Scope sera assinalado o tipo default-roles-[Realm name]

A ideia e para o Client SistemaAdmin, adicionar os Client scopes de: sistemaAdmin, SistemaA e SistemaB.

Nos demais, adicionar ao Client SistemaA apenas seu client scope, da mesma maneira que o CLient SistemaB.


4 - Regsitrar nas APIs os client que servirão para autenticar os requests.

Nos Clients do Keycloak em Actions, selecionar a opção Download Adapter Config e de la copiar o json e coloca-lo no appsettings das APIs.

Coloque o do SistemaA na API.A e dos SistemaB na API.B. 

Ficando assim por exemplo:

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Keycloak": {
    "realm": "poc",
    "auth-server-url": "http://localhost:8089/",
    "ssl-required": "none",
    "resource": "sistemaA",
    "verify-token-audience": true,
    "credentials": {
      "secret": "RTqcFaCOmGUvbPF9WkxNJMog8AjNyOWN"
    },
    "confidential-port": 0
  }
}

Agora cada API possui uma maneira de autenticacão, e quem validará o token recebido e o keycloak definido em:  "auth-server-url".


Portanto, os tokens gerados com a secret da credencial do cliente SistemaA so serão autenticados pela API.A que utiliza a mesma secret , desta mesma maneira para a API.B com a secrete de SistemaB.

Porem os tokens gerados pelo Client SistemaAdmin, serão válidos tanto para a API.A como a API.B, uma vez que SistemaAdmin tem em seuS scopes tanto os de SistemaA como SistemaB.

5 - Criar um user e password no Keycloak

6 - Gerar Token
A Geração do toke pode ser feita na rota: http://localhost:8089/realms/poc/protocol/openid-connect/token

curl --data "grant_type=password&client_id=sistemaA-client&username=develop&password=develop-password&client_secret=RTqcFaCOmGUvbPF9WkxNJMog8AjNyOWN" \
    localhost:8980/realms/poc/protocol/openid-connect/token






