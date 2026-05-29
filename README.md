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

- 🔗 **GitHub:** https://github.com/SentinelEye-GS2026/SentinelEye-DevOps
- 🎬 **Vídeo no YouTube:** https://youtu.be/gt8BI4icULA

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
- Acesso a uma VM Azure (Ubuntu 24.04 LTS recomendado)

---

### 1. Clonar o Repositório

```bash
git clone https://github.com/SentinelEye-GS2026/SentinelEye-DevOps.git
cd SentinelEye-DevOps
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
id            # ✅ mostra uid=100(appuser) — não-root!
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
# Acessa o container do Oracle
docker container exec -it oracle-db-rm565269 bash

# Conecta como sysdba
sqlplus / as sysdba
```

```sql
-- Aponta para o banco correto
ALTER SESSION SET CONTAINER=FREEPDB1;

-- Lista as tabelas do schema
SELECT table_name FROM all_tables WHERE owner='SENTINELUSER';

-- Consulta os dados
SELECT * FROM sentineluser."Regioes";
SELECT * FROM sentineluser."Agentes";
SELECT * FROM sentineluser."Ocorrencias";
SELECT * FROM sentineluser."Alertas";

EXIT
```

---

### 7. Acessar a API

Com os containers rodando, acesse:

- **Swagger UI:** `http://52.165.89.47:8080/swagger`

---

### 8. Testar o CRUD completo

Use o Swagger em `http://52.165.89.47:8080/swagger` para testar todos os endpoints:

```bash
# Exemplo: criar uma Região
curl -X POST http://52.165.89.47:8080/api/Regioes \
  -H "Content-Type: application/json" \
  -d '{"nome":"Amazônia","pais":"Brasil","nivelRisco":"Alto"}'

# Exemplo: listar todos os Agentes
curl http://52.165.89.47:8080/api/Agentes
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
SentinelEye-DevOps/
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
| CRUD completo com mínimo 2 tabelas | ✅ (Agentes, Alertas, Ocorrências, Regiões, ImagensSatelite) |
| App e banco na mesma rede Docker | ✅ (`sentineleyenet`) |
| Volume nomeado para persistência | ✅ (`oracle-data`) |
| Variável de ambiente no Banco | ✅ (`ORACLE_PASSWORD`, `ORACLE_DATABASE`) |
| Porta exposta no Banco | ✅ (1521) |
| Containers em modo background | ✅ (`docker compose up -d`) |
| Logs exibidos no terminal | ✅ (`docker logs`) |
| Terminal exec com ls-l, pwd, id | ✅ |
| SELECT no banco como evidência | ✅ |
| Repositório no GitHub com código e Dockerfile | ✅ |
| Desenho da Arquitetura Macro (não-TOGAF) | ✅ |
| Solução rodando em nuvem (Azure) | ✅ |
