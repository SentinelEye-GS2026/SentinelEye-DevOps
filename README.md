# 🛰️ SentinelEye API — DevOps Tools & Cloud Computing

## 👥 Integrantes do Grupo

| Nome | RM | Turma |
|---|---|---|
| Eduardo Augusto de Oliveira Souza | RM565269 | 2TDS |
| Fellipe Costa de Oliveira | RM564673 | 2TDS |
| Felype Ferreira Maschio | RM563009 | 2TDS |
| Gustavo Vieira de Matos | RM563304 | 2TDS |
| Pedro Henrique dos Santos Costa | RM562156 | 2TDS |

---

## 📌 Links

- 🔗 **GitHub:** https://github.com/EduardoSouza19/SentinelEyeAPI
- 🎬 **Vídeo no YouTube:** _(inserir link após gravação)_

---

## 📖 Descrição da Solução

O **SentinelEye** é uma solução de monitoramento orbital para combate a atividades ilícitas como pesca ilegal e tráfico humano. A API REST em .NET 8 gerencia ocorrências, alertas, agentes e regiões monitoradas via satélite, integrando dados espaciais com inteligência operacional em campo.

---

## 🏗️ Arquitetura Macro da Solução em Nuvem

<img width="976" height="681" alt="Arquitetura Macro da Solução em Nuvem — SentinelEye" src="https://github.com/user-attachments/assets/ae1d1ced-c645-4892-8152-e6663a128dcc" />


---

## 🚀 How-to — Executando o Projeto do Zero

### Pré-requisitos

- Git instalado
- Docker e Docker Compose instalados
- Acesso a uma VM Azure (Ubuntu 22.04 LTS recomendado)

---

### 1. Clonar o Repositório

```bash
git clone https://github.com/EduardoSouza19/SentinelEyeAPI.git
cd SentinelEyeAPI
```

---

### 2. Subir os Containers em Background (modo -d)

```bash
# ✅ Sobe AMBOS os containers em segundo plano
docker compose up -d --build
```

> O Oracle leva ~2 minutos para ficar saudável na primeira execução. Aguarde o healthcheck passar.

---

### 3. Verificar que os Containers estão rodando

```bash
docker ps
```

Você deve ver **dois containers** ativos:
- `oracle-db-rm565269`
- `sentineleyeapi-rm565269`

---

### 4. Exibir Logs dos Containers

```bash
# ✅ Logs do banco de dados
docker logs oracle-db-rm565269

# ✅ Logs da aplicação
docker logs sentineleyeapi-rm565269
```

---

### 5. Acessar o Terminal de Cada Container

```bash
# ── Container da Aplicação ──────────────────────
docker container exec -it sentineleyeapi-rm565269 sh

# Dentro do container, execute:
pwd           # ✅ mostra /app (WORKDIR definido)
ls -l         # ✅ lista estrutura de diretórios
whoami        # ✅ mostra appuser (não-root!)
exit

# ── Container do Banco de Dados ─────────────────
docker container exec -it oracle-db-rm565269 bash

# Dentro do container, execute:
pwd
ls -l
whoami
exit
```

---

### 6. Evidências de Persistência no Banco (SELECT)

```bash
# Acessa o banco via sqlplus dentro do container
docker container exec -it oracle-db-rm565269 sqlplus sentineluser/SentinelUser@2026@localhost:1521/SENTINELDB

# Dentro do sqlplus, execute as queries:
SELECT * FROM "Agentes";
SELECT * FROM "Alertas";
SELECT * FROM "Ocorrencias";
SELECT * FROM "Regioes";
SELECT * FROM "Imagens";
exit
```

---

### 7. Acessar a API

Com os containers rodando, acesse:

- **Swagger UI:** `http://<IP-DA-VM>:8080/swagger`
- **Scalar Docs:** `http://<IP-DA-VM>:8080/scalar/v1`

---

### 8. Testar o CRUD completo

Use o Swagger ou qualquer cliente HTTP (Postman, curl):

```bash
# Exemplo: criar um Agente
curl -X POST http://<IP-DA-VM>:8080/api/Agentes \
  -H "Content-Type: application/json" \
  -d '{"nome":"Agente Alpha","status":"Ativo","cargo":"Analista"}'

# Exemplo: listar todos os Alertas
curl http://<IP-DA-VM>:8080/api/Alertas
```

---

### 9. Parar os Containers

```bash
docker compose down
# Para remover volumes também (dados do banco):
docker compose down -v
```

---

## 🔧 Estrutura dos Arquivos DevOps

```
SentinelEyeAPI/
├── Dockerfile            # Imagem personalizada do App (.NET 8)
├── docker-compose.yml    # Orquestração App + Oracle
├── .dockerignore         # Arquivos ignorados no build
├── architecture.png      # Diagrama da arquitetura em nuvem
└── README.md             # Este arquivo
```

---

## ✅ Checklist de Requisitos DevOps

| Requisito | Status |
|---|---|
| Dockerfile com imagem personalizada para o App | ✅ |
| Usuário não-root no container da aplicação | ✅ (`appuser`) |
| WORKDIR definido | ✅ (`/app`) |
| Variável de ambiente no App | ✅ (`ASPNETCORE_ENVIRONMENT`, `ASPNETCORE_URLS`, `ConnectionStrings`) |
| Porta exposta no App | ✅ (8080) |
| Nome do container com RM | ✅ (`rm565269`) |
| CRUD completo com mínimo 2 tabelas | ✅ (Agentes, Alertas, Ocorrências, Regiões, Imagens) |
| App e banco na mesma rede Docker | ✅ (`sentineleyenet`) |
| Volume nomeado para persistência | ✅ (`oracle-sentineleyedata`) |
| Variável de ambiente no Banco | ✅ (`ORACLE_PASSWORD`, `ORACLE_DATABASE`) |
| Porta exposta no Banco | ✅ (1521) |
| Containers em modo background | ✅ (`docker compose up -d`) |
| Logs exibidos no terminal | ✅ (`docker logs`) |
| Terminal exec com ls-l, pwd, whoami | ✅ |
| SELECT no banco como evidência | ✅ |
| Repositório no GitHub com código e Dockerfile | ✅ |
| Desenho da Arquitetura Macro (não-TOGAF) | ✅ |
| Solução rodando em nuvem (Azure) | ✅ |
