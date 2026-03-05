# Inventory Manager API

API CRUD de inventário construída como um roteiro prático de evolução em Engenharia de Software, com foco em fundamentos, tomada de decisão consciente e construção de confiança técnica.

O objetivo não é apenas “fazer funcionar”, mas entender o porquê das decisões arquiteturais, técnicas e de processo ao longo do ciclo de desenvolvimento.

---

## 🎯 Objetivo do Projeto

Desenvolver uma API de Inventário de forma incremental, iniciando simples (in-memory) e evoluindo até práticas profissionais como:

* Arquitetura em camadas
* Validação estruturada
* Testes automatizados
* Integração Contínua (CI)
* Docker
* Banco de Dados real
* Deploy e CD
* Infraestrutura como Código (IaC)

O foco é amadurecimento técnico, não velocidade.

---

## 📦 Domínio da Aplicação

Entidade central: **Inventory Item**

Propriedades:

* `Id: Guid`
* `Name: string`
* `Quantity: int`
* `Category: string`
* `CreatedAt: DateTime`

### Regras básicas

* Nome e Categoria são obrigatórios
* Quantidade deve ser ≥ 0
* `Id` e `CreatedAt` são gerados automaticamente

---

## 🔌 Endpoints

* `GET /inventory` → Lista itens
* `GET /inventory/{id}` → Busca por Id
* `POST /inventory` → Cria item
* `PUT /inventory/{id}` → Atualiza item
* `DELETE /inventory/{id}` → Remove item

Persistência inicial: **em memória** (volátil).

---

## 🧠 Estrutura de Evolução (Milestones)

O projeto evolui obrigatoriamente na seguinte sequência:

0. **Git e GitHub fundamentals**
   0.1 **Fundamentos de execução (.NET / runtime / JIT)**
1. **API inicial em memória**
   1.1 **Boas práticas REST e HTTP**
   1.2 **Arquitetura em camadas (Domain, Application, Infra)**
   1.3 **Validação estruturada**
2. **Testes automatizados (unit tests)**
   2.1 **HTTP e DNS aprofundado**
3. **CI com GitHub Actions**
4. **Docker e containers**
5. **Banco de dados real**
6. **Migrações de schema**
7. **Deploy público**
8. **Continuous Delivery (CD)**
9. **Infraestrutura como Código (IaC)**

Cada milestone deve ser documentada de forma reflexiva.

---

## 🗂 Organização

### Branch naming

```
milestone-{numero}-{descricao}-username-feature
```

### Issues

* `[TECH]` Implementação técnica
* `[ME]` Reflexão e mentalidade
* `[HO]` Hands-on / Provas práticas

---

## 📘 Documentação no Notion

Cada milestone deve conter:

* O que foi construído
* Como foi construído
* Perguntas e dúvidas
* Erros cometidos e correções
* Reflexões pessoais
* Aprendizados
* O que não repetir
* Diagramas arquiteturais

A documentação é parte central do aprendizado.

---

## 🛠 Stack Recomendada

* .NET 7+ (Web API Minimal)
* Swagger
* NUnit + FluentAssertions
* Docker
* Banco local (SQLite ou outro)
* GitHub Actions

---

## 🔍 Mentalidade do Projeto

* Entender antes de abstrair
* Simplicidade antes de arquitetura complexa
* Testes como ferramenta de confiança
* CI/CD como cultura, não apenas ferramenta
* Evolução incremental com consciência de trade-offs

---

## 📌 Extensões Futuras

* EF Core
* Autenticação e autorização
* Observabilidade (logs e tracing)
* Deploy em nuvem
* IaC com Terraform

---

## 📄 Licença e Uso

Este roadmap é orientado para aprendizado pessoal.
Adaptações são esperadas conforme contexto e objetivos individuais.

---

Este projeto não é apenas uma API.
É um laboratório estruturado para desenvolver julgamento técnico e consistência como engenheiro de software.
